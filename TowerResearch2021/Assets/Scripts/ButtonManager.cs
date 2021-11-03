using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{

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
        buttonAnimator = startButton.GetComponent<Animator>();
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


        //implemented the improved code for buttons. commented out code seems to be obsolete but give it a minute to make sure we really don't need it anymore


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
        


            //if (hit.collider == startButton.GetComponent<Collider>()) //ray is hitting this button
            //{
            //    //Debug.Log("Hit something");
            //    //this works. just make sure the layers are correct


            //    //startButton.OnPointerEnter();
            //    //startButton.animationTriggers.

            //    if (startButtonManager.buttonPressed && newGrabberRelease() && state != 3) // button is released after being pressed, go selected --> because we are still hovering we go to HoverSelect (disabled)
            //    {
                    
            //        buttonAnimator.SetTrigger(startButton.animationTriggers.disabledTrigger);
            //        state = 4;
            //        startButton.onClick.Invoke();
            //    }



            //    if (newGrabberPress()) //button is pressed, go pressed. doesnt matter the previous state
            //    {

            //        buttonAnimator.SetTrigger(startButton.animationTriggers.pressedTrigger);
            //        startButtonManager.buttonPressed = !startButtonManager.buttonPressed;
            //        state = 2;

            //    }
            //    else if (!startButtonManager.buttonPressed && newGrabberRelease() || (state == 0 && !grabberButtonThis)) //button is normal but hovered --> go hover. makes sure we do not highlight two buttons at the same time
            //    {
            //        buttonAnimator.SetTrigger(startButton.animationTriggers.highlightedTrigger);
            //        state = 1;
            //    }

            //    else if (!startButtonManager.buttonPressed && newGrabberRelease() || state == 3 && !grabberButtonThis) //hovered while selected, go selectedHover (disabled)
            //    {
            //        buttonAnimator.SetTrigger(startButton.animationTriggers.disabledTrigger);
            //        state = 4;

            //    }


            //}

            //else //this is here in case we are hovering over another button while we release from the first button
            ////raycast hitting something else
            //{
            //    if (state == 1) //button is not pressed, not hovered, go normal
            //    {
            //        buttonAnimator.SetTrigger(startButton.animationTriggers.normalTrigger);
            //        state = 0;
            //    }

            //    if (state == 4) // if hovered and selected, go selected when no longer hovered
            //    {
            //        buttonAnimator.SetTrigger(startButton.animationTriggers.selectedTrigger);
            //        state = 3;

            //    }

            //    if (startButtonManager.buttonPressed && newGrabberRelease() && state != 3) // button is released after being pressed, go selected
            //    {
            //        buttonAnimator.SetTrigger(startButton.animationTriggers.selectedTrigger);
            //        state = 3;
            //        startButton.onClick.Invoke();

            //    }
            //    if (!startButtonManager.buttonPressed && newGrabberRelease()) // button is released after being pressed, go selected
            //    {
            //        buttonAnimator.SetTrigger(startButton.animationTriggers.normalTrigger);
            //        state = 0;
            //    }
            //}

        }//no raycasthit
        else //this is for releasing when we are not hovering a different button
        {
            startButton.OnPointerExit(null);
            startButton.OnDeselect(null);
            //if (!startButtonManager.buttonPressed && state == 1) //button is not pressed, not hovered, go normal
            //{
            //    buttonAnimator.SetTrigger(startButton.animationTriggers.normalTrigger);
            //    state = 0;
            //}

            //if (state == 4) // if hovered and selected, go selected when no longer hovered
            //{
            //    buttonAnimator.SetTrigger(startButton.animationTriggers.selectedTrigger);
            //    state = 3;
            //}

            //if (startButtonManager.buttonPressed && newGrabberRelease() && state != 3) // button is released after being pressed, go selected
            //{
            //    buttonAnimator.SetTrigger(startButton.animationTriggers.selectedTrigger);
            //    state = 3;
            //    startButton.onClick.Invoke();

            //}
            //if (!startButtonManager.buttonPressed && newGrabberRelease()) // button is released after being pressed, go selected
            //{
            //    buttonAnimator.SetTrigger(startButton.animationTriggers.normalTrigger);
            //    state = 0;
            //}
        }




        //startButtonText.text = "" + state;
        
    }

    public void buttonReset()
    {
        buttonAnimator.SetTrigger(startButton.animationTriggers.normalTrigger);
        state = 0;
        buttonPressed = false;
        buttonAnimator.ResetTrigger("Highlighted");
        buttonAnimator.ResetTrigger("Selected");
        buttonAnimator.ResetTrigger("Disabled");
        buttonAnimator.SetTrigger("Normal");
        buttonAnimator.ResetTrigger("Normal");

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
        Animator baseAnimator = GameObject.Find("Base").GetComponent<Animator>();
        baseAnimator.SetTrigger("Spin");

        Debug.Log("test");

    }

}
