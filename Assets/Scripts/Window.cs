using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Window : MonoBehaviour
{
    public enum EventName
    {
        GameOver,
        Win
    }

    public TMP_Text windowLabel;
    public GameObject window;

    public void OpenWindow(EventName type)
    {
        window.SetActive(true);
        windowLabel.text = type == EventName.GameOver ? "Ошибка" : "Победа";
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}