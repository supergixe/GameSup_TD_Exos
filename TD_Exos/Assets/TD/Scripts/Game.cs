using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GSGD1;

public class Game : MonoBehaviour
{
    [SerializeField]
    TowerManager towerManager;

    [SerializeField]
    LayerMask towerLayer;

    Ray ray;
    RaycastHit hit;

    Tower selectedTower = null;

    Tower.TowerType selectedTowerType;


    private void Awake()
    {
      
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && selectedTower == null)
        {
            Debug.Log("tu choisis");
            selectedTower = GetTower();
            Debug.Log(selectedTower);
            if (selectedTower != null)
            {
                selectedTower.SelectingTower();
                selectedTowerType = selectedTower.GetMyType();
            }
        }
        else if (Input.GetKeyDown(KeyCode.Mouse0) && selectedTower != null)
        {
            Debug.Log("J'ai choisis");
            selectedTower.OnTowerAction();
            selectedTower = null;
        }
    }


    Tower GetTower()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if ( Physics.Raycast(ray, out hit, float.MaxValue,towerLayer))
        {
            return hit.collider.GetComponentInParent<Tower>();
        }
        return null;
    }


}
