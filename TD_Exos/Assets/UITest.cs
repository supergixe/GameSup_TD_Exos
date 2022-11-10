using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITest : MonoBehaviour
{
    [SerializeField]
    private PlayerStatsUI _playerStatsUI = null;

    [SerializeField]
    private int ressources;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _playerStatsUI.RessourcesUpdater(ressources);
        }

        if (Input.GetMouseButtonDown(1))
        {
            _playerStatsUI.RessourcesUpdater(-ressources);
            _playerStatsUI.SetRessourcesAboveZero();
        }
    }
}
