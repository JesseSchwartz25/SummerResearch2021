using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonManager2 : MonoBehaviour
{
    /// <summary>
    /// Manages the haptic interactions with buttons, a much simplified, faster, and easier to read iteration compared to buttonmanager
    /// </summary>
    public GameObject Grabber;
    public Button button;
    public Color readyColor, notReadyColor;
    public bool readyToSubmit = false;
    public Image btnImage;

    //this script controls the submit button. uses some improved button methods. which I tried to throw onto the other buttons as well but I would need to work on the tags a little bit.



    // Start is called before the first frame update
    void Start()
    {
        Grabber = GameObject.Find("Grabber");
        btnImage = button.GetComponent<Image>();
        button.interactable = false;
        
    }

    // Update is called once per frame
    /// <summary>
    /// If we are looking at the button (raycast), we basically just pretend that the grabber is a mouse.
    /// 
    /// This works perfectly for the grabber, however it leads to some minor issues if you actually end up using the mouse.
    /// It also works very similarly to the slidermanager code
    /// </summary>
    void Update()
    {
        button.interactable = readyToSubmit;
        //check if we are looking at the button
        RaycastHit hit;
        Ray ray = new Ray(Grabber.transform.position, -Grabber.transform.forward);

        //invoke mouse based functions on the button based on our grabber
        if (Physics.Raycast(ray, out hit, .5f, LayerMask.GetMask("UI")))
        {
            if (hit.collider.CompareTag("Button") && readyToSubmit)
            {
                button.OnPointerEnter(null);
                if (Grabber.GetComponent<HapticGrabber>().getButtonStatus())
                {
                    button.onClick.Invoke();
                    button.OnSelect(null);
                    return;
                }

            }
            else
            {
                button.OnPointerExit(null);
                button.OnDeselect(null);
            }
        }
        else
        {
            button.OnPointerExit(null);
            button.OnDeselect(null);
        }



    }






}
