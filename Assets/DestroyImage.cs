using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DeleteImage : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        // Caută imaginea în obiectul curent
        Image droppedImage = GetComponent<Image>();

        // Verifică dacă există o imagine pe care să o ștergi
        if (droppedImage != null)
        {
            // Șterge imaginea
            Destroy(droppedImage.gameObject);
        }
    }
}
