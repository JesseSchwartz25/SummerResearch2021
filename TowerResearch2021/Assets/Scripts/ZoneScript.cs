using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZoneScript : MonoBehaviour
{

    public Button Orange, Red, Yellow, Green, Blue;
    public GameObject Grabber;
    public LayerMask layerMask;
    private Button[] buttons;
    private int ZoneChoice = -1;
    public ButtonManager bm;
    // Start is called before the first frame update
    void Start()
    {
        buttons = gameObject.GetComponentsInChildren<Button>();
        Orange = buttons[0];
        Red = buttons[1];
        Blue = buttons[2];
        Green = buttons[3];
        Yellow = buttons[4];

        Orange.transform.SetAsLastSibling();

        Grabber = GameObject.Find("Grabber");


    }

    // Update is called once per frame
    void Update()
    {


        RaycastHit hit;

        if (Grabber.GetComponent<HapticGrabber>().getButtonStatus())
        {
            //if the button is pressed at all.
            Ray ray = new Ray(Grabber.transform.position, -Grabber.transform.forward);
            RaycastHit[] hits = Physics.RaycastAll(ray, 0.15f, LayerMask.GetMask("UI"));

            if(hits != null)
            {
                foreach(RaycastHit i in hits)
                {
                    if (i.collider.CompareTag("DataDir") && bm.newGrabberPress())
                    {


                        //Debug.Log("hit: " + i.collider.name);
                        Button thisButton = i.collider.GetComponent<Button>();
                        if (thisButton.IsInteractable())
                        {
                            for (int j = 0; j < buttons.Length; j++)
                            {
                                if (thisButton != buttons[j])
                                {
                                    buttons[j].OnDeselect(null);
                                }
                                else
                                {
                                    if (ZoneChoice != j)
                                    {
                                        ZoneChoice = j;
                                        thisButton.OnSelect(null);
                                        thisButton.onClick.Invoke();
                                    }

                                }


                            }
                            break;
                        }

                        
                    }


                    //Debug.Log(i.collider.name);
                }
            }

            //if (Physics.Raycast(ray, out hit, .25f, LayerMask.GetMask("UI")))            
            //{
            //    if (hit.collider.CompareTag("DataDir"))
            //    {


            //        Debug.Log("hit: " + hit.collider.name);

            //    }
            //}


            //if(Physics.ch)
        }
        

    }


   public void getDataChoice()
    {
        Debug.Log(ZoneChoice);
        
    }
    public int returnDataChoice()
    {
        return ZoneChoice;
    }
    public Button[] returnButtons()
    {
        return buttons;
    }
    public void setZoneChoice(int num)
    {
        ZoneChoice = num;
    }

}
