using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageColor : MonoBehaviour
{
    [SerializeField] private Image myImage1;
    [SerializeField] private Image myImage2;
    [SerializeField] private Image myImage3;
    [SerializeField] private Color myColor1;
    [SerializeField] private Color myColor2;
    public Button Button;
    private int numClicks = 0;

    private void Start()
    {
        myColor1.a = 1;
        myColor2.a = 0;
    }

    public void OnClick()
    {
        numClicks++;
        if (numClicks == 2)
        {
            myImage1.color = myColor1;
            myImage2.color = myColor2;
        }
        if (Button.name == "X BUTTON")
        {
            myImage3.color = myColor1;
        }
    }
}


