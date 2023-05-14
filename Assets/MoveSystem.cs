using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MoveSystem : MonoBehaviour
{
    public List<GameObject> correctForms;
    public Button button1;
    public Button button2;
    public Button button3;
    public Button button4;
    public Button button5;
    public Button button6;

    [SerializeField] private Image myImage1;
    [SerializeField] private Image myImage2;
    [SerializeField] private Image FirstShadowBerzelius;
    [SerializeField] private Image SecondShadowBerzelius;
    [SerializeField] private Image FirstShadowCilinder;
    [SerializeField] private Image SecondShadowCilinder;
    [SerializeField] private Image ThirdShadowCilinder;
    [SerializeField] private Image AuxiliarSecondShadowCilinder;
    [SerializeField] private Image AuxiliarThirdShadowCilinder;
    [SerializeField] private Image FirstShadowBerzeliush;
    [SerializeField] private Image SecondShadowBerzeliush;
    [SerializeField] private Image FirstShadowPipette;
    [SerializeField] private Image SecondShadowPipette;
    [SerializeField] private Image ThirdShadowPipette;
    [SerializeField] private Image FourthShadowPipette;
    [SerializeField] private Image FifthShadowPipette;
    [SerializeField] private Image AuxiliarSecondShadowPipette;

    public Image dissapear;
    public Image Eprubette1;
    public Image Eprubette2;
    public Image Eprubette1Shadow;
    public Image Eprubette2Shadow;
    public Image HotBerzelius;
    public Image ColdBerzelius;
    public Image FifthShadowPipettedissapear;
    public Sprite FinalHotBerzelius;
    public Sprite FinalColdBerzelius;


    [SerializeField] private Image Arrow;
    [SerializeField] private Color BlackColor;
    [SerializeField] private Color TransparentColor;

    private bool moving;
    private float startPosx;
    private float startPosy;
    private Vector3 resetPosition;

    private int count1 = 0;
    private int count2 = 0;
    private int count3 = 0;

    public GameObject gameObjectToTransform;
    public GameObject gameObjectToTransform2;

    public GameObject LeftArrow;
    public GameObject RightArrow;

    public GameObject RightArrowHotWater;
    public GameObject LeftArrowColdWater;

    void Start()
    {
        resetPosition = this.transform.localPosition;
        button1.interactable = false; // initially disable the button
        BlackColor.a = 1;
        TransparentColor.a = 0;
        Eprubette1.enabled = false;
        Eprubette2.enabled = false;
        Arrow.enabled = false;
        Eprubette1Shadow.enabled = false;
        Eprubette2Shadow.enabled = false;
        LeftArrow.SetActive(false);
        RightArrow.SetActive(false);
        LeftArrowColdWater.SetActive(false);
        RightArrowHotWater.SetActive(false);
    }

    void Update()
    {
        if (moving)
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            this.gameObject.transform.localPosition = new Vector3(mousePos.x - startPosx, mousePos.y - startPosy, this.gameObject.transform.localPosition.z);
        }
    }
    private void OnMouseUp()
    {
        moving = false;

        bool isCorrectForm = false;
        int correctFormIndex = -1;

        for (int i = 0; i < correctForms.Count; i++)
        {
            GameObject form = correctForms[i];

            if (Mathf.Abs(this.transform.localPosition.x - form.transform.localPosition.x) <= 100f &&
                Mathf.Abs(this.transform.localPosition.y - form.transform.localPosition.y) <= 100f)
            {
                this.transform.localPosition = new Vector3(form.transform.localPosition.x, form.transform.localPosition.y, form.transform.localPosition.z);
                isCorrectForm = true;
                correctFormIndex = i;
                break;
            }
        }

        if (!isCorrectForm)
        {
            this.transform.localPosition = new Vector3(resetPosition.x, resetPosition.y, resetPosition.z);
        }
        else
        {
            if (gameObject.name == "Berzelius cold")
            {
                if (correctFormIndex == 0)
                {
                    button1.interactable = true;
                    FirstShadowBerzelius.color = TransparentColor;
                    SecondShadowBerzelius.color = BlackColor;
                }
                if (correctFormIndex == 1)
                {
                    button1.interactable = false;
                    SecondShadowBerzelius.color = TransparentColor;
                    FirstShadowCilinder.color = BlackColor;
                }
            }
            else if (gameObject.name == "Cilinder empty")
            {
                    if(correctFormIndex == 0)
                    {
                    button1.interactable = true;
                    }
                    if (correctFormIndex == 1)
                    {
                        count2++;
                    if (count2 == 1)
                    {
                        button1.interactable = false;
                        FirstShadowBerzeliush.color = BlackColor;
                        AuxiliarSecondShadowCilinder.color = TransparentColor;
                    }
                    if (count2 == 2)
                    {
                        this.transform.Rotate(Vector3.back * 138f);
                        button4.interactable = false;
                        Color firstShadowColor = FourthShadowPipette.color;
                        firstShadowColor.a = 1;
                        FourthShadowPipette.color = firstShadowColor;
                        dissapear.enabled = false;


                    }
                        
                    }
                    if (correctFormIndex == 2)
                    {
                        count1++;
                        if (count1 == 1)
                        {
                            this.transform.Rotate(Vector3.forward * 138f);
                            button4.interactable = true;
                        }
                    }
            }
            else if(gameObject.name == "Berzelius hot")
            {
                if(correctFormIndex == 0)
                {
                    button2.interactable = true;
                    FirstShadowBerzeliush.color = TransparentColor;
                    SecondShadowBerzeliush.color = BlackColor;
                }
                if(correctFormIndex == 1)
                {
                    button2.interactable = false;
                    SecondShadowBerzeliush.color = TransparentColor;
                    FirstShadowPipette.color = BlackColor;
                }
            }
            else if(gameObject.name == "Pipette")
            {
                if(correctFormIndex == 0)
                {
                    button3.interactable = true;
                    FirstShadowPipette.color = TransparentColor;
                    SecondShadowPipette.color = BlackColor;  
                }
                if(correctFormIndex == 1)
                {
                        AuxiliarSecondShadowPipette.color = TransparentColor;
                        button3.interactable = false;
                        button4.interactable = true;
                        Arrow.enabled = true;
                        
                }
                if(correctFormIndex == 2)
                {
                    count3++;
                    if (count3 == 1)
                    {
                        SecondShadowPipette.enabled = false;
                        ThirdShadowPipette.color = TransparentColor;
                        Color secondShadowColor = ThirdShadowCilinder.color;
                        secondShadowColor.a = 1;
                        ThirdShadowCilinder.color = secondShadowColor;
                    }
                    
                    if(count3 == 2)
                    {
                        ThirdShadowPipette.color = TransparentColor;
                    }

                }
                if (correctFormIndex == 3) {
                    button5.interactable = true;
                    FourthShadowPipette.color = TransparentColor;
                    Color ShadowColor = FifthShadowPipette.color;
                    ShadowColor.a = 1;
                    FifthShadowPipette.color = ShadowColor;
                }
                if (correctFormIndex == 4)
                {
                    FifthShadowPipettedissapear.enabled = false;
                    button5.interactable = false;
                    button4.interactable = true;
                }
            }
            else if(gameObject.name == "Eprubette 1")
            {
                if(correctFormIndex == 0)
                {   RightArrowHotWater.SetActive(true);
                    HotBerzelius.sprite = FinalHotBerzelius;
                    Eprubette1.enabled = false;
                    Eprubette1Shadow.enabled = false;
                    Eprubette2Shadow.enabled = true;
                    Vector3 currentScale = gameObject.transform.localScale;
                    gameObjectToTransform.transform.localScale = new Vector3(currentScale.x, 1.3f, currentScale.z);
                    Vector3 currentPositionnn = gameObjectToTransform.transform.position;
                    gameObjectToTransform.transform.position = new Vector3(currentPositionnn.x, currentPositionnn.y + 15f, currentPositionnn.z);
                    button6.interactable = false;
                }
            }
            else if(gameObject.name == "Eprubette 2")
            {
                LeftArrowColdWater.SetActive(true);
                RightArrowHotWater.SetActive(false);
                ColdBerzelius.sprite = FinalColdBerzelius;
                Eprubette2.enabled = false;
                Eprubette2Shadow.enabled = false;
                Vector3 currentScalee = gameObject.transform.localScale;
                gameObjectToTransform2.transform.localScale = new Vector3(currentScalee.x, 1.3f, currentScalee.z);
                Vector3 currentPositionnn2 = gameObjectToTransform2.transform.position;
                gameObjectToTransform2.transform.position = new Vector3(currentPositionnn2.x, currentPositionnn2.y + 15f, currentPositionnn2.z);
                LeftArrow.SetActive(true);
                RightArrow.SetActive(false);
            }
        }
    }
            
 




private void OnMouseDown()
     {
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 mousePos;
                mousePos = Input.mousePosition;
                mousePos = Camera.main.ScreenToWorldPoint(mousePos);

                startPosx = mousePos.x - this.transform.localPosition.x;
                startPosy = mousePos.y - this.transform.localPosition.y;

                moving = true;
            }
     }
}

