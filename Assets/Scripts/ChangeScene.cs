using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
public class ChangeScene : MonoBehaviour, IPointerClickHandler
{
    public int id;

    public void OnPointerClick(PointerEventData eventData)
    {
        SceneManager.LoadScene(id);
    }
}
