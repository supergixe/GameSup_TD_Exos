using System.Collections;
using System.Collections.Generic;
//using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _layoutButton = null;

    [SerializeField]
    private GameObject _levelSelectLayout = null;

    [SerializeField]
    private GameObject _settings = null;

    [SerializeField]
    private List<GameObject> _objectToDisableOnStart;

    private void Start()
    {
        MainMenuSeter();
    }

    public void MainMenuSeter()
    {
        for (int i = 0; i < _objectToDisableOnStart.Count; i++)
        {
            _objectToDisableOnStart[i].SetActive(false);
        }
    }

    public void LevelSelectEnable()
    {
        _levelSelectLayout.SetActive(true);

        _settings.SetActive(false);
    }

    public void LevelSelectDisable()
    {
        _levelSelectLayout.SetActive(false);

        _settings.SetActive(true);
    }

    public void LauchLevel(int scene)
    {
        Debug.Log("LauchLevel : " + scene);

        //SceneManager.LoadScene(scene);
    }

    public void SettingsEnable()
    {
        _settings.SetActive(true);

        _levelSelectLayout.SetActive(false);
    }

    public void SettingsDisable()
    {
        _settings.SetActive(false);

        _levelSelectLayout.SetActive(true);
    }

    public void Back()
    {
        for (int i = 0; i < _objectToDisableOnStart.Count; i++)
        {
            _objectToDisableOnStart[i].SetActive(false);
        }
    }

    public void QuitGame()
    {
        Debug.Log("Quit");


#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
        }
}
