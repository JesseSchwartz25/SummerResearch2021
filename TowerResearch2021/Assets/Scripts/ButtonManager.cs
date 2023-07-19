using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    /// <summary>
    /// Used mainly for the rotation buttons. Not totally sure what the differences between this and v2 are but they work on different buttons
    /// </summary>

    public bool buttonPressed;

    public Button startButton; //this is porbably obselete, but it works with it so only remove and fix if we need to improve speed. this is just a reference to this button
    public GameObject Grabber;
    public Animator buttonAnimator;
    public TMP_Text startButtonText;
    public int state;
    private int prevState;
    public Slider slider;
    


    //0 for normal
    //1 for hover
    //2 for pressed
    //3 for selected

    //things for the buttons
    public ButtonManager startButtonManager;
    public HapticGrabber hapticGrabber;
    private bool grabberButtonLast;
    private bool grabberButtonThis;
    bool spin;
    





    // Start is called before the first frame update
    void Start()
    {
        Grabber = GameObject.Find("Grabber");
        startButton = this.GetComponent<Button>();
        hapticGrabber = Grabber.GetComponent<HapticGrabber>();
        startButtonManager = this;
        state  = 0;
        grabberButtonThis = hapticGrabber.getButtonStatus();
        //buttonAnimator = startButton.GetComponent<Animator>();
        startButtonText = startButton.GetComponentInChildren<TMP_Text>();
        spin = false;
        buttonReset();
    }

    // Update is called once per frame
    void Update()
    {

        grabberButtonLast = grabberButtonThis;
        grabberButtonThis = hapticGrabber.getButtonStatus();


        //if the ray extending from the end of the grabber hits a button, highlight the button

        RaycastHit hit;
        Ray ray = new Ray(Grabber.transform.position, -Grabber.transform.forward);

        Debug.DrawRay(Grabber.transform.position, -Grabber.transform.forward);


        //implemented the improved code for buttons.

        if (Physics.Raycast(ray, out hit, 1.5f, LayerMask.GetMask("UI")))
        {


            if(hit.collider == startButton.GetComponent<Collider>() && startButton.IsInteractable())
            {
                startButton.OnPointerEnter(null);
                if (Grabber.GetComponent<HapticGrabber>().getButtonStatus())
                {
                    startButton.onClick.Invoke();
                    startButton.OnSelect(null);
                    return;
                }
                else
                {
                    startButton.OnPointerExit(null);
                    startButton.OnDeselect(null);
                }
            }
            else
            {
                startButton.OnPointerExit(null);
                startButton.OnDeselect(null);
            }
        

        }//no raycasthit
        else //this is for releasing when we are not hovering a different button
        {
            startButton.OnPointerExit(null);
            startButton.OnDeselect(null);
        }




        //startButtonText.text = "" + state;
        
    }

    public void buttonReset()
    {
        state = 0;
        buttonPressed = false;
    }


    public bool newGrabberPress()
    {
        return grabberButtonThis && !grabberButtonLast;
    }

    public bool newGrabberRelease()
    {
        return !grabberButtonThis && grabberButtonLast;
    }


    private void OnDrawGizmos()
    {

        //this draws a (short) ray from the end of the grabber. Turn on gizmos to see
        Gizmos.color = Color.red;
        // Gizmos.DrawRay(Grabber.transform.position, -Grabber.transform.forward * 10);
    }

    public void testClicked()
    {
        Debug.Log("I was clicked!");
    }

    public void testClicked2()
    {
        Debug.Log("Me 2!");
    }

    public void spinClicked()
    {
        //Animator baseAnimator = GameObject.Find("Base").GetComponent<Animator>();
       // baseAnimator.SetTrigger("Spin");

        Debug.Log("test");

    }

}
