using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioDialRotation : MonoBehaviour
{

    public GameObject baseObject;
    private Quaternion startRotation;
    public Light light;
    // Start is called before the first frame update
    void Start()
    {
        startRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = baseObject.transform.rotation;
        transform.Rotate(0, 45, 0);
        
    }
}
