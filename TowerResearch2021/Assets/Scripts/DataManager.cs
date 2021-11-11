using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataManager : MonoBehaviour
{

    public StabilityManager stability;
    public ZoneScript direction;
    public ButtonManager2 submit;
    public BaseController rotation;
    Button[] buttons;
    public GameManager gm;

    public int zone;
    public float stable;
    




    //collect data from the UI
    //add data to the spreadsheet
    //profit?

    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.instance;
        buttons = direction.returnButtons();
        gm.Invoke("buildTower", 0.1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (direction.returnDataChoice() != -1)
        {
            submit.readyToSubmit = true;
        }
        else
        {
            submit.readyToSubmit = false;
        }
        if (!stability.slider.IsInteractable())
        {
            rotation.resetButton.interactable = false;
            rotation.spinClockwise.interactable = false;
            rotation.spinCounter.interactable = false;
            submit.readyToSubmit = false;
        }

    }

    public void submitData()
    {
        if (submit.readyToSubmit)
        {
            zone = direction.returnDataChoice();
            stable = stability.slider.value;

            rotation.ResetRotation();

            Debug.Log("Data saved");
            Debug.Log("Zone: " + zone + " Stability: " + stable);

            direction.setZoneChoice(-1);

            foreach (Button i in buttons)
            {
                i.interactable = false;
            }
            stability.slider.interactable = false;


            gm.Invoke("towerFall", 1f);
            Invoke("collectTruth", 5.5f);
            
            //once to delete the old tower, once to spawn in the new one.
            //has to work this way because it is coded that way...
            gm.Invoke("buildTower", 5.6f);
            gm.Invoke("buildTower", 5.7f);
            Invoke("resetData", 5.8f);



        }
       



    }

    Vector3 drawAvg;
    Vector3 centerOfMass;
    Vector3 furthestXZ;
    int[] zoneMajority;

    public void collectTruth()
    {
        GameObject baseObject = GameObject.Find("Base");
        Rigidbody[] rbList = baseObject.GetComponentsInChildren<Rigidbody>();
        int numKids = baseObject.transform.childCount;

        Vector3 avgPos = new Vector3(0, 0, 0);
        centerOfMass = new Vector3(0, 0, 0);
        furthestXZ = new Vector3(0, 0, 0);
        float mass = 0;
        zoneMajority = new int[5] {0, 0, 0, 0, 0};

        foreach(Rigidbody rb in rbList)
        {
            avgPos += rb.position;
            centerOfMass += rb.position * rb.mass;
            mass += rb.mass;

            //calculate the furthest from the center
            if(rb.position.x * rb.position.x + rb.position.z * rb.position.z > furthestXZ.x * furthestXZ.x + furthestXZ.z + furthestXZ.z)
            {
                furthestXZ = rb.position;
            }

            //calculate majority zone.
            //this tests if it's still over the baseblock

            RaycastHit hit;
            if(Physics.Raycast(rb.position, new Vector3(0, -1, 0), out hit, 15f, LayerMask.GetMask("Data")));
            {
                try
                {
                    Debug.Log(rb.name + " hit " + hit.collider.name);

                    //add them to the array. Base, red, blue, green, yellow
                    if (hit.collider.name == "BaseDataCube")
                    {
                        zoneMajority[0]++;
                    }
                    if (hit.collider.name == "RedCube")
                    {
                        zoneMajority[1]++;
                    }
                    if (hit.collider.name == "BlueCube")
                    {
                        zoneMajority[2]++;
                    }
                    if (hit.collider.name == "GreenCube")
                    {
                        zoneMajority[3]++;
                    }
                    if (hit.collider.name == "YellowCube")
                    {
                        zoneMajority[4]++;
                    }


                }
                catch (System.Exception)
                {
                    Debug.Log("Couldnt do the thing");
                    //throw;
                }
            }



        }


        int? maxVal = null; //nullable so this works even if you have all super-low negatives
        int majorityIndex = -1;
        for (int i = 0; i < zoneMajority.Length; i++)
        {
            int thisNum = zoneMajority[i];
            if (!maxVal.HasValue || thisNum >= maxVal.Value)
            {
                maxVal = thisNum;
                majorityIndex = i;
            }
        }

        avgPos /= numKids;

        centerOfMass /= mass;
        

        Debug.Log("Average Position of Blocks: " + avgPos);
        Debug.Log("Center of Mass is: " + centerOfMass);
        Debug.Log("Furthest Block is: " + furthestXZ);
        Debug.Log("Majority layout: " + majorityIndex);
        //Debug.DrawRay(avgPos, transform.up);
        drawAvg = avgPos;
    }

    public void resetData()
    {


        stability.slider.interactable = true;
        foreach (Button i in buttons)
        {
            i.OnDeselect(null);
            i.interactable = true;
        }

        //direction.setZoneChoice(-1);

        stability.slider.value = 4;

        rotation.resetButton.interactable = true;
        rotation.spinClockwise.interactable = true;
        rotation.spinCounter.interactable = true;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(drawAvg, drawAvg + new Vector3(0, 3, 0));
        Gizmos.DrawSphere(centerOfMass, .1f);
        Gizmos.DrawCube(furthestXZ, new Vector3(.1f, .1f, .1f));
    }
}
