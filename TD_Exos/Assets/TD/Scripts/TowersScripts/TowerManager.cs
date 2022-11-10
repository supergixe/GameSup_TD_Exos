using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GSGD1;

public class TowerManager : MonoBehaviour
{
    List<Tower> towers;

    public void AddTower(Tower tower)
    {
        towers.Add(tower);
    }

    public void SetIndex(Tower tower)
    {
        towers.IndexOf(tower);
    }

    public Tower GetTower(int index)
    {
        return towers[index];
    }

}
