using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GrabberPointer : MonoBehaviour
{


    //public Button startButton;
    //public GameObject Grabber;
    //public Animator buttonAnimator;
    //public TMP_Text startButtonText;
    //public int state;


    ////0 for normal
    ////1 for hover
    ////2 for pressed
    ////3 for selected

    ////things for the buttons
    //public ButtonManager startButtonManager;
    //public HapticGrabber hapticGrabber;
    //private bool grabberButtonLast;
    //private bool grabberButtonThis;





    //// Start is called before the first frame update
    //void Start()
    //{
    //    hapticGrabber = Grabber.GetComponent<HapticGrabber>();
    //    startButtonManager = startButton.GetComponent<ButtonManager>();
    //    state = 0;
    //    grabberButtonThis = hapticGrabber.getButtonStatus();
    //}

    //// Update is called once per frame
    //void Update()
    //{

    //    grabberButtonLast = grabberButtonThis;
    //    grabberButtonThis = hapticGrabber.getButtonStatus();

    //    //if the ray extending from the end of the grabber hits a button, highlight the button

    //    RaycastHit hit;
    //    Ray ray = new Ray(Grabber.transform.position, -Grabber.transform.forward);

    //    Debug.DrawRay(Grabber.transform.position, -Grabber.transform.forward);

    //    if (Physics.Raycast(ray, out hit))
    //    {
    //        if (hit.collider.CompareTag("Start"))
    //        {
    //            //Debug.Log("Hit something");
    //            //this works. just make sure the layers are correct


    //            //startButton.OnPointerEnter();
    //            //startButton.animationTriggers.

    //            if (startButtonManager.buttonPressed && newGrabberRelease()) // button is released after being pressed, go selected
    //            {
    //                buttonAnimator.SetTrigger(startButton.animationTriggers.disabledTrigger);
    //                state = 4;
    //            }



    //            if (newGrabberPress()) //button is pressed, go pressed. doesnt matter the previous state
    //            {

    //                buttonAnimator.SetTrigger(startButton.animationTriggers.pressedTrigger);
    //                startButtonManager.buttonPressed = !startButtonManager.buttonPressed;
    //                state = 2;



    //                //if (!startButtonManager.buttonPressed) //button is normal state and pressed --> go pressed
    //                //{
    //                //    buttonAnimator.SetTrigger(startButton.animationTriggers.pressedTrigger);
    //                //    startButtonManager.buttonPressed = true;
    //                //    state = 2;


    //                //}
    //                //else //button is pressed and pressed again --> go normal
    //                //{
    //                //    buttonAnimator.SetTrigger(startButton.animationTriggers.pressedTrigger);
    //                //    startButtonManager.buttonPressed = false;
    //                //    state = 0;
    //                //}


    //            }
    //            else if (!startButtonManager.buttonPressed && newGrabberRelease() || state == 0) //button is normal but hovered --> go hover
    //            {
    //                buttonAnimator.SetTrigger(startButton.animationTriggers.highlightedTrigger);
    //                state = 1;
    //            }

    //            else if (!startButtonManager.buttonPressed && newGrabberRelease() || state == 3) //hovered while selected, go selectedHover (disabled)
    //            {
    //                buttonAnimator.SetTrigger(startButton.animationTriggers.disabledTrigger);
    //                state = 4;

    //            }






    //        }

    //    }
    //    else
    //    {
    //        if (!startButtonManager.buttonPressed && state == 1) //button is not pressed, not hovered, go normal
    //        {
    //            buttonAnimator.SetTrigger(startButton.animationTriggers.normalTrigger);
    //            state = 0;
    //        }

    //        if (state == 4) // if hovered and selected, go selected when no longer hovered
    //        {
    //            buttonAnimator.SetTrigger(startButton.animationTriggers.selectedTrigger);
    //            state = 3;
    //        }

    //        if (startButtonManager.buttonPressed && newGrabberRelease()) // button is released after being pressed, go selected
    //        {
    //            buttonAnimator.SetTrigger(startButton.animationTriggers.selectedTrigger);
    //            state = 3;
    //        }
    //        if (!startButtonManager.buttonPressed && newGrabberRelease()) // button is released after being pressed, go selected
    //        {
    //            buttonAnimator.SetTrigger(startButton.animationTriggers.normalTrigger);
    //            state = 0;
    //        }
    //    }







    //    startButtonText.text = "" + state;



    //}


    //bool newGrabberPress()
    //{
    //    return grabberButtonThis && !grabberButtonLast;
    //}

    //bool newGrabberRelease()
    //{
    //    return !grabberButtonThis && grabberButtonLast;
    //}


    //private void OnDrawGizmos()
    //{

    //    //this draws a (short) ray from the end of the grabber. Turn on gizmos to see
    //    Gizmos.color = Color.red;
    //    // Gizmos.DrawRay(Grabber.transform.position, -Grabber.transform.forward * 10);
    //}
}
