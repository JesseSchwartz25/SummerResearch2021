using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuManager : MonoBehaviour
{

    public Button StartButton, InstructionsButton, backButton, backButton2, startExpButton;
    public Canvas MainCanvas, NameCanvas, InstructionsCanvas;
    public TMP_InputField nameInput;


    //this script deals with the UI at the start of the experiment. 
    //it ensures that the user is seeing and interacting with the correct buttons/text
    //mildly obselete after we decided to read the instructions to everyone before we started the experiment
    //but still usefull and necessary for certain interactions.

    // Start is called before the first frame update
    void Start()
    {
        NameCanvas.enabled = false;
        InstructionsCanvas.enabled = false;
        backButton2.interactable = false;
        startExpButton.interactable = false;
        backButton.interactable = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(nameInput.text == "")
        {
            startExpButton.interactable = false;
        }
        else
        {
            startExpButton.interactable = true;

        }

    }

    public void toName()
    {
        MainCanvas.enabled = false;
        StartButton.interactable = false;
        InstructionsButton.interactable = false;

        NameCanvas.enabled = true;
        startExpButton.interactable = true;
        backButton.interactable = true;

        InstructionsCanvas.enabled = false;
        backButton2.interactable = false;
    }

    public void toInstructions()
    {
        InstructionsCanvas.enabled = true;
        backButton2.interactable = true;


        MainCanvas.enabled = false;
        StartButton.interactable = false;
        InstructionsButton.interactable = false;

        NameCanvas.enabled = false;
        startExpButton.interactable = false;
        backButton.interactable = false;
       
    }

   public void toMain()
    {
        InstructionsCanvas.enabled = false;
        backButton2.interactable = false;

        MainCanvas.enabled = true;
        StartButton.interactable = true;
        InstructionsButton.interactable = true;

        NameCanvas.enabled = false;
        startExpButton.interactable = false;
        backButton.interactable = false;
    }

    public void toExperiment()
    {

        NameScript namescript = GameObject.Find("NameObject").GetComponent<NameScript>();
        namescript.name = nameInput.text;
        if(nameInput.text != "")
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("TestEnvironment");
        }
    }
}
