using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonManager2 : MonoBehaviour
{
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
    void Update()
    {
        button.interactable = readyToSubmit;

        RaycastHit hit;
        Ray ray = new Ray(Grabber.transform.position, -Grabber.transform.forward);

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
