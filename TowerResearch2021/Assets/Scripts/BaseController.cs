using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Animations;
using UnityEngine.UI;

public class BaseController : MonoBehaviour
{
    private Vector3 rotate;
    public Animator baseAnimator;
    public Button spinClockwise;
    public Button spinCounter;
    public Button resetButton;

    // Start is called before the first frame update
    void Start()
    {
        //baseAnimator = GetComponent<Animator>();
        rotate = new Vector3(0, 50, 0);

    }

    // Update is called once per frame
    void Update()
    {
        if (spinClockwise.GetComponent<ButtonManager>().state == 2)
        {
            RotateClockwise();
        }

        if (spinCounter.GetComponent<ButtonManager>().state == 2)
        {
            RotateCounterClockwise();
        }

        if (spinCounter.GetComponent<ButtonManager>().newGrabberRelease())
        {
            spinCounter.GetComponent<ButtonManager>().buttonReset();
            spinClockwise.GetComponent<ButtonManager>().buttonReset();
            resetButton.GetComponent<ButtonManager>().buttonReset();

        }

    }

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
        LeanTween.rotate(this.gameObject, new Vector3(0, 0, 0), 0.5f).setEaseInOutCubic();
        //leantween is a library that makes some animations a little bit easier to do in code
    }
}
