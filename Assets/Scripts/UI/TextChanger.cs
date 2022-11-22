using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextChanger : MonoBehaviour
{
    public Text textToChange;
    public string textInput;
    private void Update()
    {
        textToChange.text = textInput;
    }
}
