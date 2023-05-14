using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragAndDrop : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private bool isDragging = false;
    private Vector3 initialPosition;

    public Image newImage;

    public void OnPointerDown(PointerEventData eventData)
    {
        isDragging = true;
        initialPosition = transform.position;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (isDragging)
        {
            isDragging = false;

            // Check if we are over a valid drop target
            GameObject dropTarget = eventData.pointerCurrentRaycast.gameObject;
            if (dropTarget != null && dropTarget.CompareTag("DropTarget"))
            {
                // Change the image of the drop target to the new image
                dropTarget.GetComponent<Image>().sprite = newImage.sprite;
            }
            else
            {
                // Move the image back to its initial position
                transform.position = initialPosition;
            }
        }
    }
}

