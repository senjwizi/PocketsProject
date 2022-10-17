using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class Manager : MonoBehaviour
{
    Window window;
    public int winCell;
    public Transform tab;

    private void Start()
    {
        window = FindObjectOfType<Window>();
    }

    void AnimateCubesLine(int cellId)
    {
        for (int i = cellId - 2; i < winCell + 1; i++)
        {
            tab.GetChild(i).transform.GetChild(0).GetComponent<Animation>().Play();
        }
    }

    public IEnumerator StartEvent(Pocket pocket)
    {
        Window.EventName eventName = pocket.cellIndex == winCell ? Window.EventName.Win : Window.EventName.GameOver;

        if (eventName == Window.EventName.Win)
        {
            AnimateCubesLine(winCell);
            yield return new WaitForSeconds(1);
        }

        window.OpenWindow(eventName);
    }
}
