using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _pausePanel = null;

    private int _timeScale;

    private static PauseManager _instance = null;
    public static PauseManager Instance
    {
        get
        {
            if (_instance == null)
            {
                PauseManager[] foundInstances = FindObjectsOfType<PauseManager>();

                if (foundInstances.Length == 0)
                {
                    // Error no singleton
                    Debug.LogError("No PauseManager found.");
                }

                if (foundInstances.Length > 1)
                {
                    // too many singleton
                    Debug.LogError("Too many PauseManager found.");
                }

                _instance = foundInstances[0];
            }

            return _instance;
        }
    }



    private void Start()
    {
        _pausePanel.SetActive(false);
    }

    public void Pause()
    {
        Time.timeScale = 0;
        _pausePanel.SetActive(true);
    }

    public void Unpause()
    {
        Time.timeScale = _timeScale;
        _pausePanel.SetActive(false);
    }

    public void QuitGame()
    {
        SceneManager.LoadScene(0);
    }

    public void SetTimeScale(int timeScale)
    {
        _timeScale = timeScale;
    }

    public void FullScreen()
    {
        Screen.fullScreen = true;
    }
}
