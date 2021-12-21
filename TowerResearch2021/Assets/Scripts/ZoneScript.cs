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
    private int ZoneChoice2 = -1;
    public ButtonManager bm;
    float timer = 0;
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
        timer += Time.deltaTime;

        RaycastHit hit;
        bool breakouter = false;
        if (bm.newGrabberPress() && !bm.newGrabberRelease() && timer > 0.2f)//Grabber.GetComponent<HapticGrabber>().getButtonStatus())
        {
            timer = 0;
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
                        if (thisButton.IsInteractable() && bm.newGrabberPress())
                        {
                            for (int j = 0; j < buttons.Length; j++)
                            {
                                if (thisButton != buttons[j])
                                {
                                    //not this button, do nothing
                                    continue;
                                }
                                else
                                {
                                    if (ZoneChoice == j)
                                    {
                                        thisButton.OnDeselect(null);
                                        ZoneChoice = -1;
                                        Debug.Log("Deselecting 1");


                                    }
                                    else if (ZoneChoice == -1)
                                    {
                                        ZoneChoice = j;
                                        thisButton.OnSelect(null);
                                        thisButton.onClick.Invoke();
                                    }

                                    else
                                    {
                                        if (ZoneChoice2 == j)
                                        {
                                            thisButton.OnDeselect(null);
                                            ZoneChoice2 = -1;
                                            Debug.Log("Deselecting 2");
                                        }

                                        else if (ZoneChoice2 != j && ZoneChoice != -1)
                                        {
                                            if (ZoneChoice2 != -1)
                                            {
                                                buttons[ZoneChoice2].OnDeselect(null);
                                                Debug.Log("changing 2");
                                            }
                                            ZoneChoice2 = j;
                                            thisButton.OnSelect(null);
                                            thisButton.onClick.Invoke();
                                        }
                                    }

                                   



                                    //shift back incase 1 is deselected:
                                    if(ZoneChoice == -1 && ZoneChoice2 != -1)
                                    {
                                        ZoneChoice = ZoneChoice2;
                                        ZoneChoice2 = -1;
                                    }

                                    if (j != ZoneChoice && j != ZoneChoice2)
                                    {
                                        //buttons[j].OnDeselect(null);

                                    }


                                    //break if j == 0

                                    if(j == 0)
                                    {
                                        breakouter = true;
                                        break;
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
        Debug.Log(ZoneChoice + " : " + ZoneChoice2);
        
    }
    public int[] returnDataChoice()
    {
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
