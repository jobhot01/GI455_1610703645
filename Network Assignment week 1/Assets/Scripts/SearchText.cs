using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SearchText : MonoBehaviour
{
    public InputField InputField;
    public Text DisplayText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckText()
    {
        if (InputField.text == "Lamborghini" || InputField.text == "lamborghini")
            DisplayText.text = "Lamborghini Fond!";

        else if (InputField.text == "Ferrari" || InputField.text == "ferrari")
            DisplayText.text = "Ferrari Fond!";
        else if (InputField.text == "Aston Martin" || InputField.text == "aston martin")
            DisplayText.text = "Aston Martin Found!";
        else if (InputField.text == "Maserati" || InputField.text == "maserati")
            DisplayText.text = "Maserati Found!";
        else if (InputField.text == "Porsche" || InputField.text == "porsche")
            DisplayText.text = "Porsche Found!";
        else
        {
            DisplayText.text = "Not Found!";
        }
    }
}
