using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(
    fileName = "New Description",
    menuName = "ScriptableObjects/Description",
    order = 0
    )] // allow unity to create a new scriptable object (this one) directly

public class DescriptionScriptableObject : ScriptableObject // not monobehavior
{
    public string question; //contains a question string
    public Sprite image; // contains a image

    public DescriptionScriptableObject choiceA; // contains three possible options held with scriptable objects
    public DescriptionScriptableObject choiceB;
    public DescriptionScriptableObject backward;

    public string choiceAText; // strings for the buttons
    public string choiceBText;
}
