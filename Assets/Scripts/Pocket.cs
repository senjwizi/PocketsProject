using UnityEngine;
using UnityEngine.EventSystems;

public class Pocket : MonoBehaviour, IDropHandler
{
    Manager manager;
    public bool isCell;
    public bool freezMove;
    [HideInInspector] public int cellIndex;

    void Start()
    {
        if (isCell)
            cellIndex = transform.GetSiblingIndex() + 1;

        if (transform.childCount > 0 && freezMove)
        {
            transform.GetChild(0).GetComponent<Cube>().image.raycastTarget = false;
        }
        manager = FindObjectOfType<Manager>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null && transform.childCount == 0)
        { 
            eventData.pointerDrag.GetComponent<Cube>().SetPocket(transform);
            if (isCell)
                StartCoroutine(manager.StartEvent(this));
        }
    }

}
