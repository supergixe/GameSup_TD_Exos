using GSGD1;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatsUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _ressourcesText = null;

    private int _playerRessources = 0;

    private static PlayerStatsUI _instance = null;
    public static PlayerStatsUI Instance
    {
        get
        {
            if (_instance == null)
            {
                PlayerStatsUI[] foundInstances = FindObjectsOfType<PlayerStatsUI>();

                if (foundInstances.Length == 0)
                {
                    // Error no singleton
                    Debug.LogError("No PlayerStatsUI found.");
                }

                if (foundInstances.Length > 1)
                {
                    // too many singleton
                    Debug.LogError("Too many PlayerStatsUI found.");
                }

                _instance = foundInstances[0];
            }

            return _instance;
        }
    }


    private void Start()
    {
        _ressourcesText.text = _playerRessources.ToString();
    }

    public void RessourcesUpdater(int ressources)
    {
        _playerRessources += ressources;
        _ressourcesText.text = _playerRessources.ToString();
    }

    public void SetRessourcesAboveZero()
    {
        if (_playerRessources < 0)
        {
            _playerRessources = 0;
            RessourcesUpdater(_playerRessources);
        }
    }
}
