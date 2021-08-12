using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockScript : MonoBehaviour
{
    // Start is called before the first frame update


    private Rigidbody rb = null;
    public bool grabbed = false;
    public string starttag = null;
    public List<string> hitsList;




    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotation;
        rb.constraints = RigidbodyConstraints.FreezeAll;
        starttag = this.gameObject.tag;
        hitsList = null;
        GameManager.RBList.Add(rb);
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
 
          

        

    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("GrabberObject"))
        {
            Debug.Log(this.gameObject.name + " left the grabber");
            grabbed = false;
        }
    }


    private void OnCollisionStay(Collision collision)
    {
        if (!GameManager.freeRotation)
        {
           // this.transform.Translate(new Vector3(Random.Range(-.01f,.01f), 0.001f, Random.Range(-.01f,.01f)));
        }
    }





}
