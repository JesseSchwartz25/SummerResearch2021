using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseController : MonoBehaviour
{
    private Vector3 rotate;
    public Button spinClockwise;
    public Button spinCounter;
    public Button resetButton;

    // Start is called before the first frame update
    void Start()
    {
        rotate = new Vector3(0, 50, 0);

    }

    // Update is called once per frame
    // void Update()

    // //! [07/23] Pretty sure all of this is obsolete
    // //TODO: Verify obsolete
    // {
    //     if (spinClockwise.GetComponent<ButtonManager>().state == 2)
    //     {
    //        RotateClockwise();
    //     }

    //     if (spinCounter.GetComponent<ButtonManager>().state == 2)
    //     {
    //        RotateCounterClockwise();
    //     }

    //     if (spinCounter.GetComponent<ButtonManager>().newGrabberRelease())
    //     {
    //        spinCounter.GetComponent<ButtonManager>().buttonReset();
    //        spinClockwise.GetComponent<ButtonManager>().buttonReset();
    //        resetButton.GetComponent<ButtonManager>().buttonReset();

    //     }

    // }

    


    //These functions are taken directly by the three buttons in the UI    
    public void RotateClockwise()
    {

        this.gameObject.transform.Rotate(0, 30 * Time.deltaTime, 0, Space.Self);


    }

    public void RotateCounterClockwise()
    {
        this.gameObject.transform.Rotate(0, -30 * Time.deltaTime, 0, Space.Self);
    }

    public void ResetRotation()
    {
        LeanTween.rotate(this.gameObject, new Vector3(0, 0, 0), 1.0f).setEaseInOutCubic();
        //LeanTween is a library that makes some animations a little bit easier to do in code
        //this one just resets the base to rotation 0 in a cubic manner in 1 second but it has lots of other cool applications in unity
    }
}
