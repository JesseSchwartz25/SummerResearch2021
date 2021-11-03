using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataManager : MonoBehaviour
{

    public StabilityManager stability;
    public ZoneScript direction;
    public ButtonManager2 submit;
    public BaseController rotation;
    Button[] buttons;
    public GameManager gm;

    public int zone;
    public float stable;
    




    //collect data from the UI
    //add data to the spreadsheet
    //profit?

    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.instance;
        buttons = direction.returnButtons();
        gm.Invoke("buildTower", 0.1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (direction.returnDataChoice() != -1)
        {
            submit.readyToSubmit = true;
        }
        else
        {
            submit.readyToSubmit = false;
        }
        if (!stability.slider.IsInteractable())
        {
            rotation.resetButton.interactable = false;
            rotation.spinClockwise.interactable = false;
            rotation.spinCounter.interactable = false;
            submit.readyToSubmit = false;
        }
    }

    public void submitData()
    {
        if (submit.readyToSubmit)
        {
            zone = direction.returnDataChoice();
            stable = stability.slider.value;

            rotation.ResetRotation();

            Debug.Log("Data saved");

            direction.setZoneChoice(-1);

            foreach (Button i in buttons)
            {
                i.interactable = false;
            }
            stability.slider.interactable = false;


            gm.Invoke("towerFall", 1f);

            gm.Invoke("buildTower", 5f);
            gm.Invoke("buildTower", 5.1f);
            Invoke("resetData", 5.2f);



        }
       



    }

    public void resetData()
    {
        stability.slider.interactable = true;
        foreach (Button i in buttons)
        {
            i.OnDeselect(null);
            i.interactable = true;
        }

        //direction.setZoneChoice(-1);

        stability.slider.value = 4;

        rotation.resetButton.interactable = true;
        rotation.spinClockwise.interactable = true;
        rotation.spinCounter.interactable = true;
    }
}
