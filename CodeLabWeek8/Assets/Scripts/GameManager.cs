using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.UI;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI question;
    public TextMeshProUGUI choiceAText;
    public TextMeshProUGUI choiceBText;
    public Image image;
    public Button choiceA;
    public Button choiceB;
    public Button back;
    public DescriptionScriptableObject currentDescription;
    public DescriptionScriptableObject welcome;
    
    // Start is called before the first frame update
    void Start()
    {
        UpdateDescription();//update on starting the game
    }

    private void UpdateDescription()
    {
        question.text = currentDescription.question; // get the displayed text
        image.sprite = currentDescription.image; // get the image
        choiceAText.text = currentDescription.choiceAText; // get the button texts
        choiceBText.text = currentDescription.choiceBText;

        if (currentDescription.choiceA == null) // do not display the button if there's nothing following it
        {
            choiceA.gameObject.SetActive(false);
        }
        else
        {
            choiceA.gameObject.SetActive(true);
            currentDescription.choiceA.backward = currentDescription; // hook up the backward button of the next one 
            if (currentDescription.name.Contains("End")) // if returning from the end scene
            {
                currentDescription.choiceA.backward = null; // do not go back to the end scene
            }
        }

        if (currentDescription.choiceB == null)
        {
            choiceB.gameObject.SetActive(false);
        }
        else
        {
            choiceB.gameObject.SetActive(true);
            currentDescription.choiceB.backward = currentDescription;
        }

        if (currentDescription.backward == null)
        {
            back.gameObject.SetActive(false);
        }
        else
        {
            back.gameObject.SetActive(true);
        }
    }

    public void proceedToNext(int choice) // on button press 
    {
        switch (choice) // switch between the different input from different buttons
        {
            case 0:
                currentDescription = currentDescription.choiceA;
                break;
            case 1:
                currentDescription = currentDescription.choiceB;
                break;
            case 2:
                currentDescription = currentDescription.backward;
                break;
        }
        UpdateDescription(); // remember to update!
    }
}
