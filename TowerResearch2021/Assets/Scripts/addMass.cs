using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addMass : MonoBehaviour
{

    /// <summary> 
    ///This script is in charge of setting the mass for each object
    ///
    ///Not used in version 1 of the tower experiment.
    /// </summary>

    public GameObject grabber;
    public Material[] materials;
    private int matcount;
    public HapticGrabber grabberScript;
    private bool contacted;
    private bool buttonHeld;

    // Start is called before the first frame update
    void Start()
    {
        matcount = 0;
        grabberScript = grabber.GetComponent<HapticGrabber>();
        contacted = false;
        buttonHeld = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (grabberScript.getButtonStatus() && contacted && !buttonHeld)
        {
            this.gameObject.GetComponent<Renderer>().material = materials[matcount];
            matcount++;
            if (matcount >= materials.Length)
            {
                matcount = 0;

            }
            Debug.Log("button pressed");
        }


        if (grabberScript.getButtonStatus())
        {
            buttonHeld = true;
        }
        else
        {
            buttonHeld = false;
        }
    }


    private void OnCollisionStay(Collision collision)
    {

        contacted = true;

       

    }

    private void OnCollisionExit(Collision collision)
    {
        contacted = false;
    }

    public int getMassStatus()
    {
        return matcount;
        //0 for red (off), 1 for green (on)
        //testtesttest
    }

}
