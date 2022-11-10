using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GSGD1;

public class TroopTower : Tower
{
    [SerializeField]
    private Blockers blockers;

    const int layerTower = 1 << 8;

    const int layerFloor = 1 << 7;

    [SerializeField]
    LayerMask _layerMask = 0;

    private Blockers[] myBlockers = new Blockers[3];

    [SerializeField]
    GameObject[] positions = new GameObject[3];

    [SerializeField]
    GameObject flagPosition;

    [SerializeField]
    GameObject floorAvailable;

    float spawnRate = 10f;

    float spawn = 0f;


    private void Awake()
    {
        //myManager.AddTower(this);
        //myManager.SetIndex(this);
        Debug.Log(index);
        for (int i = 0; i < myBlockers.Length; i++)
        {
            print(myBlockers.Length);
            Spawning(i);
        }
    }

    void Spawning(int index)
    {
        Blockers currentBlocker = Instantiate(blockers);
        currentBlocker.transform.position = this.transform.position;
        currentBlocker.Initialyse(positions[index].transform.position, index, this);
        myBlockers[index] = currentBlocker;
    }

    void MoveFlag()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, float.MaxValue, layerFloor))
        {
            flagPosition.transform.position = hit.point;
            print(flagPosition.transform.position);
            for (int i = 0; i < myBlockers.Length; i++)
            {
                myBlockers[i].UpdatePosition(positions[i].transform.position);
            }
            isSelected = false;
            floorAvailable.SetActive(false);
        }
        else
        {
            isSelected = false;
            floorAvailable.SetActive(false);
        }
    }

    public override void OnTowerAction()
    {
        MoveFlag();
    }
    override public void SelectingTower()
    {
            isSelected = true;
            floorAvailable.SetActive(true);
    }

    public float SpawningTimer(float customSpawnRate = 10, int index = 0) 
    {
        if(spawn >= customSpawnRate)
        {
            Spawning(index);
            return spawn = 0;
        }
        else
        {
            return SpawningTimer(customSpawnRate);
        }
    }


}
