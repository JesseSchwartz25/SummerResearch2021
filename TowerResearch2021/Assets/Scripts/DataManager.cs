using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//need these for file writing
using System;
using System.IO;
using System.Threading.Tasks;

public class DataManager : MonoBehaviour
{

    /**
     * 
     * This script manages all data collection in the program
     * It is stored in a plaintext file, but tab separated to it can easily be copied into a spreadsheet.
     * 
     * Data is collected both when the user hits submit (entering their choices, rotation, )
     * and when the towers have finished falling
     * 
     * 
     * 
     */

    public StabilityManager stability;
    public ZoneScript direction;
    public ButtonManager2 submit;
    public BaseController rotation;
    Button[] buttons;
    public GameManager gm;

    public int zone;
    public int zone2;
    public float stable;
    float time;
    public int epochs;
    public float yRotFinal;

    //these are the blocks that the user can play with
    public GameObject vertBlock, vert2;
    public GameObject horBlock, ho2;
    Vector3 vertStart, vert2start, hoStart, ho2start;



    //collect data from the UI
    //add data to the "spreadsheet"
    //the data files are just .txt files, but they are pre-formatted and can easily just be copied and pasted into excel/google sheets with correct formatting

    // Start is called before the first frame update
    void Start()
    {
        epochs = 0;
        gm = GameManager.instance;
        buttons = direction.returnButtons();
        gm.Invoke("buildTower", .7f);
        resetData();

        vertStart = vertBlock.transform.position;
        hoStart = horBlock.transform.position;
        vert2start = vert2.transform.position;
        ho2start = ho2.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //make sure at least one zone is selected - can't submit if no zones are selected
        //the user does not have to touch stability in order to submit. only select one zone
        //so we have to make sure they are focusing on stability and not forgetting it.
        if (direction.returnDataChoice()[0] != -1)
        {
            submit.readyToSubmit = true;
        }
        else
        {
            submit.readyToSubmit = false;
        }
        if (!stability.slider.IsInteractable())
        {
            //if we can't use the slider, we can't use anything else
            rotation.resetButton.interactable = false;
            rotation.spinClockwise.interactable = false;
            rotation.spinCounter.interactable = false;
            submit.readyToSubmit = false;
        }

        if(gm.blocksIndex >= 300)
        {
            //reset the trial index each time we finish an epoch (50 trials)
            gm.blocksIndex = 0;
            epochs++;
            
        }
        if (epochs == 3 && gm.blocksIndex != 0)
        {
            //end the experiment
            UnityEngine.SceneManagement.SceneManager.LoadScene("EndScene");
        }

    }

    public void submitData()
    {
        if (submit.readyToSubmit) //ie: at least one zone is selected
        {
            GameObject baseObject = GameObject.Find("Base");

            //collect values and reset rotation
            zone = direction.returnDataChoice()[0];
            zone2 = direction.returnDataChoice()[1];
            stable = stability.slider.value;
            yRotFinal = baseObject.transform.rotation.eulerAngles.y;
            rotation.ResetRotation();

            Debug.Log("Data saved");
            Debug.Log("Zone: " + zone + " Stability: " + stable);

            //collect the starting position of each block

            Rigidbody[] rbList = baseObject.GetComponentsInChildren<Rigidbody>();
            startingPositions = new Vector3[rbList.Length];
            for (int i = 0; i < rbList.Length; i++)
            {
                startingPositions[i] = rbList[i].position;
            }

            direction.setZoneChoice(new int[] { -1, -1 });

            foreach (Button i in buttons)
            {
                i.interactable = false;
            }
            stability.slider.interactable = false;

            //activate physics in 1.1 seconds, then collect the truth in 6 seconds
            //I've found these times to feel the most natural and consistant in terms of towers having finished their physics interactions.
            gm.Invoke("towerFall", 1.1f);
            Invoke("collectTruth", 6.0f);
            
            //once to delete the old tower, once to spawn in the new one.
            //has to work this way because it is coded that way...
            //there is a break between the deletion and spawning because
            //if the new tower is spawned to soon, the algortithm will not work properly
            //this is dependent on processing speed, so it happens occasionally during runtime anyways.
            //see bug report for more information.
            gm.Invoke("buildTower", 6.1f);
            gm.Invoke("buildTower", 6.25f);
            Invoke("resetData", 6.26f);

            //reset the position of the playable blocks
            vertBlock.transform.position = vertStart;
            horBlock.transform.position = hoStart;
            vert2.transform.position = vert2start;
            ho2.transform.position = ho2start;
            vertBlock.SetActive(false);
            horBlock.SetActive(false);
            ho2.SetActive(false);
            vert2.SetActive(false);



        }




    }

    Vector3 drawAvg;
    Vector3 centerOfMass;
    Vector3 furthestXZ;
    int[] zoneMajority;
    Vector3[] finalPositions;

    public void collectTruth()
    {

        //grab the correct values after physics have been activated

        GameObject baseObject = GameObject.Find("Base");
        Rigidbody[] rbList = baseObject.GetComponentsInChildren<Rigidbody>();
        int numKids = baseObject.transform.childCount;

        Vector3 avgPos = new Vector3(0, 0, 0);
        centerOfMass = new Vector3(0, 0, 0);
        furthestXZ = new Vector3(0, 0, 0);
        float mass = 0;
        zoneMajority = new int[5] {0, 0, 0, 0, 0};
        finalPositions = new Vector3[rbList.Length];


        finalPositions = new Vector3[rbList.Length];
        for (int i = 0; i < rbList.Length; i++)
        {
            finalPositions[i] = rbList[i].position;
        }

        foreach (Rigidbody rb in rbList)
        {
            avgPos += rb.position;
            centerOfMass += rb.position * rb.mass;
            mass += rb.mass;

            //calculate the furthest block from the center
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
                    //this shouldnt happen, but there were issues without it
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


        WriteToFile();

    }

    Vector3[] startingPositions;
    public void resetData()
    {

        //reset the rest of the data collection UI
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
        time = Time.time;

        vertBlock.SetActive(true);
        horBlock.SetActive(true);
        vert2.SetActive(true);
        ho2.SetActive(true);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(drawAvg, drawAvg + new Vector3(0, 3, 0));
        Gizmos.DrawSphere(centerOfMass, .1f);
        Gizmos.DrawCube(furthestXZ, new Vector3(.1f, .1f, .1f));
    }



    public void WriteToFile()
    {

        //this works pretty well, check the data files if you are confused about anything and it should clear things up for you

        float timeToSubmit = Time.time - time;
        Debug.Log(timeToSubmit);
        //write the file. first need to check and see if the file exists.

        //float[] dataToWrite = new float[] { zone, stable, drawAvg,  };
        int[] userData = new int[] {zone, (int)stable};
        var fileName = gm.userName + "Data.txt";
        string path = @"C:\Users\js9764a\Desktop\IntPhysTowersExperimentData\" + fileName;

        if (!File.Exists(path))
        {
            Debug.Log(fileName + " does not exist, initializing document");
            using (StreamWriter sw = File.CreateText(path))
            {
                //write the header for the data
                sw.WriteLine(fileName);
                sw.WriteLine("Zone1 \tZone2 \tStability \tTime \tAvg Pos \tFurthest \tCenterOfMass \tY Rotation \tMajority \tStart Pos \tFinal Pos");
            }

        }
        string startPosString = "{";
        string finalPosString = "{";
        for(int rb = 0; rb < startingPositions.Length; rb++)
        {
            startPosString += startingPositions[rb].ToString();
            finalPosString += finalPositions[rb].ToString();

            if(rb < startingPositions.Length - 1)
            {
                startPosString += ", ";
                finalPosString += ", ";
            }
            else
            {
                startPosString += "}";
                finalPosString += "}";
            }
        }

        string majorityString = String.Format("[{0}, {1}, {2}, {3}, {4}]", zoneMajority[0], zoneMajority[1], zoneMajority[2], zoneMajority[3], zoneMajority[4]);
            

        Debug.Log("Appending " + fileName);
        using (StreamWriter sw = File.AppendText(path))
        {
            //preformatted so that it can be pasted into a spreadsheet easily.
            sw.WriteLine(zone + "\t" + zone2 + "\t" + stable + "\t" + timeToSubmit + "\t" + drawAvg.ToString() + "\t" + furthestXZ.ToString() + "\t" + centerOfMass.ToString() + "\t" + yRotFinal + "\t" + majorityString + 
                "\t" + startPosString + "\t" + finalPosString);
        }
        
    }
}
