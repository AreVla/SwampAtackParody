using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    private int _openedWindow = 0;

    private void OnEnable()
    {
        Time.timeScale = 0;
    }

    public void OpenPanel(GameObject panel)
    {
        panel.SetActive(true);
        _openedWindow++;
        Time.timeScale = 0;
    }

    public void ClosePanel(GameObject panel)
    {
        panel.SetActive(false);
        _openedWindow--;

        if (_openedWindow < 1)
            Time.timeScale = 1;
    }

    public void Exit()
    {
        Application.Quit();
    }
}
