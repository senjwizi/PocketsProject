using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Cube : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    Transform currentPocket,targetPocket;
    Transform mainSpace;
    [HideInInspector] public Image image;

    void Awake()
    {
        currentPocket = transform.parent;
        mainSpace = FindObjectOfType<Canvas>().transform;
        image = GetComponent<Image>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.touches[0].position;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        image.raycastTarget = false;
        transform.SetParent(mainSpace);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        image.raycastTarget = true;
        if (targetPocket == null)
            SetPocket(currentPocket);
    }

    public void SetPocket(Transform pocket)
    { 
        currentPocket = pocket;
        targetPocket = null;
        transform.SetParent(currentPocket);
        transform.localPosition = Vector3.zero;
    }
}
