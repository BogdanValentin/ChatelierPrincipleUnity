using UnityEngine;
using UnityEngine.UI;

public class MoveButton : MonoBehaviour
{
    public Button button;
    public GameObject imageObject;   // Reference to the GameObject that contains the image
    public float moveDistance = 10f;
    private int count = 0;
    [SerializeField] private Image image;
    [SerializeField] private Color Black;

    private RectTransform imageTransform;   // Reference to the RectTransform component of the image

    void Start()
    {
        Black.a = 1;
        imageTransform = imageObject.GetComponent<RectTransform>();
        button.onClick.AddListener(OnButtonClicked);
    }

    void OnButtonClicked()
    {
        count++;
        if (count < 5)
        {
            Vector2 currentPosition = imageTransform.anchoredPosition;
            Vector2 newPosition = new Vector2(currentPosition.x + moveDistance, currentPosition.y);
            imageTransform.anchoredPosition = newPosition;
        }
        if(count == 5)
        {
            image.color = Black;
        }
    }
}

