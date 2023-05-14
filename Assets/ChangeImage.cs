using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeImage : MonoBehaviour
{
    public Image original1;
    public Image original2;
    public Image original3;
    public Image original4;
    public Image original5;
    public Image original6;
    public Image original7;
    public Image original8;
    public Image original9;
    public Image original10;
    [SerializeField] private Image image1;
    [SerializeField] private Image image2;
    [SerializeField] private Image image3;
    [SerializeField] private Image image4;
    public Sprite newSprite1;
    public Sprite newSprite2;
    public Sprite newSprite3;
    public Sprite newSprite4;
    public Sprite newSprite5;
    public Sprite newSprite6;
    public Sprite newSprite7;
    public Sprite newSprite8;
    public Sprite newSprite9;
    public Sprite newSprite10;
    [SerializeField] private Color Black;
    [SerializeField] private Color Transparent;
    public Image image11;
    public Image image22;
    public Image Arrow;
    public Image Eprubette1;
    public Image PipetteShadow;
    public Image imageToMove2;
    private int numClicks1 = 0;
    public Button button;
    public GameObject objectToMove;

    public GameObject LeftArrow;
    public GameObject RightArrow;

    public GameObject RightArrowHotWater;
    public GameObject LeftArrowColdWater;

    void Start()
    {
        Black.a = 1;
        Transparent.a = 0;
    }

    void Update()
    {

    }

    public void NewImage()
    {
        numClicks1++;
        original1.sprite = newSprite1;
        if (numClicks1 == 2)
        {
            original2.sprite = newSprite2;
        }
        /*if (button.name == "EPRUBETTE BUTTON")
        {
            Vector3 newPosition = objectToMove.transform.position + new Vector3(100f, 0, 0);
            objectToMove.transform.position = newPosition;
        }*/
        else if(numClicks1 == 3)
        {
            original3.sprite = newSprite3;
            Vector3 currentPositionn = imageToMove2.transform.position;
            imageToMove2.transform.position = new Vector3(currentPositionn.x - 10000f, currentPositionn.y, currentPositionn.z);
        }
        else if(numClicks1 == 4)
        {
            original4.sprite = newSprite4;
            image11.enabled = true;
        }
        else if(numClicks1 == 5)
        {
            original5.sprite = newSprite5;
            original6.sprite = newSprite6;
            image22.enabled = true;
            button.interactable = false;
            Arrow.enabled = false;
            PipetteShadow.enabled = false;
        }
        else if(numClicks1 == 6)
        {
            original7.sprite = newSprite7;
            original8.sprite = newSprite8;
            image1.color = Transparent;
            image2.color = Black;
            LeftArrow.SetActive(true);
        }
        else if (numClicks1 == 7)
        {
            original9.sprite = newSprite9;
            original10.sprite = newSprite10;
            image3.color = Transparent;
            image4.color = Transparent;
            Vector3 currentPosition = objectToMove.transform.position;
            objectToMove.transform.position = currentPosition + new Vector3(570f, -180f, 0f);
            Eprubette1.enabled = true;
            LeftArrow.SetActive(false);
            RightArrow.SetActive(true);
        }
    }
}
