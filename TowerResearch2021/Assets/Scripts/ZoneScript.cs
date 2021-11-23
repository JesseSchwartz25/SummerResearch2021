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
        bool breakouter = false;
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
                                    if(j == 0)
                                    {
                                        //if we select the 0 button. for whatever reason this button is super finicky because its above other buttons
                                        buttons[1].OnDeselect(null);
                                        buttons[2].OnDeselect(null);
                                        buttons[3].OnDeselect(null);
                                        buttons[4].OnDeselect(null);

                                        ZoneChoice = j;
                                        buttons[0].OnSelect(null);
                                        buttons[0].onClick.Invoke();
                                        breakouter = true;
                                        break;
                                    }
                                }
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
