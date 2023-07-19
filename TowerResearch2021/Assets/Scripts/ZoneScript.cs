using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZoneScript : MonoBehaviour
{
    /// <summary>
    /// This script works with the UI and the user to make sure that the zones that they select are the actually selected.
    /// this script is currently set up to work with the user selecting 2 zones per trial, but can be set up for just one
    /// </summary>





    public Button Orange, Red, Yellow, Green, Blue;
    public GameObject Grabber;
    public LayerMask layerMask;
    private Button[] buttons;

    //set to -1 because neither currently represents a zone
    private int ZoneChoice = -1;
    private int ZoneChoice2 = -1;

    //these are used to make sure only one zone is selected per click
    public ButtonManager bm;
    float timer = 0;


    // Start is called before the first frame update
    void Start()
    {

        //this is set up with how the objects are ordered in the editor which is necessary for the UI to show as it is intended.
        //if you are talented at UI, it can probably be done better but it currently works as is.
        buttons = gameObject.GetComponentsInChildren<Button>();
        Orange = buttons[0];
        Red = buttons[1];
        Blue = buttons[2];
        Green = buttons[3];
        Yellow = buttons[4];


        //needed to set the UI as intended visually
        Orange.transform.SetAsLastSibling();

        Grabber = GameObject.Find("Grabber");


    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        RaycastHit hit;
        bool breakouter = false;

        //check if it is a new, unique press
        if (bm.newGrabberPress() && !bm.newGrabberRelease() && timer > 0.2f)
        {
            timer = 0;
            //if the button is pressed at all.
            //check if we hit the UI at all (must be close enough)
            Ray ray = new Ray(Grabber.transform.position, -Grabber.transform.forward);
            RaycastHit[] hits = Physics.RaycastAll(ray, 0.15f, LayerMask.GetMask("UI"));

            if(hits != null)
            {
                foreach(RaycastHit i in hits)
                {
                    if (i.collider.CompareTag("DataDir") && bm.newGrabberPress())
                    {

                        Button thisButton = i.collider.GetComponent<Button>();
                        if (thisButton.IsInteractable() && bm.newGrabberPress())
                        {
                            for (int j = 0; j < buttons.Length; j++)
                            {

                                //iterated through the list of buttons to select the correct one.
                                //this can probably done better but it currently works as is and the 
                                //program is simple enough where this time waste doesn't hurt at all.

                                if (thisButton != buttons[j])
                                {
                                    //not this button, do nothing
                                    continue;
                                }
                                else
                                {
                                    if (ZoneChoice == j)
                                    {
                                        //deselect the current button
                                        thisButton.OnDeselect(null);
                                        ZoneChoice = -1;
                                        Debug.Log("Deselecting 1");


                                    }
                                    else if (ZoneChoice == -1)
                                    {
                                        //no zone is selected, choose this zone.
                                        ZoneChoice = j;
                                        thisButton.OnSelect(null);
                                        thisButton.onClick.Invoke();
                                    }

                                    else
                                    {
                                        if (ZoneChoice2 == j)
                                        {
                                            //deselect the second zone
                                            thisButton.OnDeselect(null);
                                            ZoneChoice2 = -1;
                                            Debug.Log("Deselecting 2");
                                        }

                                        else if (ZoneChoice2 != j && ZoneChoice != -1)
                                        {
                                            if (ZoneChoice2 != -1)
                                            {
                                                //change second selection - deselect current second zone
                                                buttons[ZoneChoice2].OnDeselect(null);
                                                Debug.Log("changing 2");
                                            }

                                            //choose second zone
                                            ZoneChoice2 = j;
                                            thisButton.OnSelect(null);
                                            thisButton.onClick.Invoke();
                                        }
                                    }

                                   



                                    //shift back in case first zone is deselected:
                                    if(ZoneChoice == -1 && ZoneChoice2 != -1)
                                    {
                                        ZoneChoice = ZoneChoice2;
                                        ZoneChoice2 = -1;
                                    }



                                    //break if j == 0

                                    if(j == 0)
                                    {
                                        breakouter = true;
                                        break;
                                        //we need this because the UI is super janky and such.
                                    }


                                }

                                
                                //this works for one selection. above works for two selections

                                //if (thisButton != buttons[j])
                                //{
                                //    buttons[j].OnDeselect(null);
                                //}
                                //else
                                //{
                                //    if (ZoneChoice != j)
                                //    {
                                //        ZoneChoice = j;
                                //        thisButton.OnSelect(null);
                                //        thisButton.onClick.Invoke();


                                //    }
                                //    if(j == 0)
                                //    {
                                //        //if we select the 0 button. for whatever reason this button is super finicky because its above other buttons
                                //        buttons[1].OnDeselect(null);
                                //        buttons[2].OnDeselect(null);
                                //        buttons[3].OnDeselect(null);
                                //        buttons[4].OnDeselect(null);

                                //        ZoneChoice = j;
                                //        buttons[0].OnSelect(null);
                                //        buttons[0].onClick.Invoke();
                                //        breakouter = true;
                                //        break;
                                //    }
                                //}
                            }
                        }

                        if (breakouter)
                            break;
                        //break the outer loop if zero is selected
                    }
                }
            }
        }        
    }


   public void getDataChoice()
    {
        //debug function which prints which zones are currently selected
        Debug.Log(ZoneChoice + " : " + ZoneChoice2);
        
    }
    public int[] returnDataChoice()
    {
        //returns the zone choices. this could probably be cleaned up to not have global values for the zone choices but it currently works
        return new int[] { ZoneChoice, ZoneChoice2 };
    }
    public Button[] returnButtons()
    {
        return buttons;
    }
    public void setZoneChoice(int[] num)
    {
        ZoneChoice = num[0];
        ZoneChoice2 = num[1];
    }

}
