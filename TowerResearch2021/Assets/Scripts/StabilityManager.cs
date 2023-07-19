using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class StabilityManager : MonoBehaviour
{
    /// <summary>
    /// Manage the slider in the UI which controls the stability choice by the user
    /// </summary>

    public GameObject Grabber;
    public Slider slider;
    public ColorBlock cb;
    Color highlighted;


    // Start is called before the first frame update
    void Start()
    {
        Grabber = GameObject.Find("Grabber");
        cb = slider.colors;
    }

    // Update is called once per frame
    void Update()
    {
        //check if we are looking at the slider
        RaycastHit hit;
        Ray ray = new Ray(Grabber.transform.position, -Grabber.transform.forward);

        //move the slider to the correct spot, on a scale of 1-7
        if (Physics.Raycast(ray, out hit, .5f, LayerMask.GetMask("UI")))
        {
            if(hit.collider.name == "Background")
            {
                slider.OnPointerEnter(null);
                if (Grabber.GetComponent<HapticGrabber>().getButtonStatus())
                {
                    slider.value = (hit.point.x + 0.5f) * 7 - 1.75f;
                }
               
            }
        }
        else
        {
            slider.OnPointerExit(null);
        }


    }



   

}
