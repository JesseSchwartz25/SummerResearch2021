using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockScript : MonoBehaviour
{
    // Start is called before the first frame update


    private Rigidbody rb = null;
    public bool grabbed = false;
    public string starttag = null;
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
      //s  rb.constraints = RigidbodyConstraints.FreezeRotation;
        starttag = this.gameObject.tag;
    }

    // Update is called once per frame

    
    void Update()
    {
        //if (grabbed)
        //{
        //    rb.useGravity = true;
        //}

        //else
        //{
        //    rb.useGravity = false;
        //}

        if (!grabbed)
        {
            this.gameObject.tag = "Touchable";
        }
        else
        {
            this.gameObject.tag = starttag;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("GrabberObject"))
        {
            Debug.Log(this.gameObject.name + " touched the grabber");
            grabbed = true;
        }

        

        if(grabbed == false)
        {
           
            Debug.Log(this.gameObject.name + "'s parent is now " + collision.gameObject.name);
        }

        

    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("GrabberObject"))
        {
            Debug.Log(this.gameObject.name + " left the grabber");
            grabbed = false;
        }
    }





}
