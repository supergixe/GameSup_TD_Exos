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

    bool isSelected = false;

    private Blockers[] myBlockers = new Blockers[3];

    [SerializeField]
    Transform[] positions = new Transform[3];

    [SerializeField]
    Transform flagPosition;

    [SerializeField]
    GameObject floorAvailable;

    float spawnRate = 10f;

    float spawn = 0f;


    private void Awake()
    {
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
        currentBlocker.Initialyse(positions[index].position, index, this);
        myBlockers[index] = currentBlocker;
    }

    bool CanSelectTower()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        //if(Physics.Raycast(ray,out hit, float.MaxValue, _layerMask))
        if(Physics.Raycast(ray,out hit, float.MaxValue, layerTower))
        {
            print("yeuxtevois");
            return true;
        }
        else
        {
            return false;
        }
    }

    void MoveFlag()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, float.MaxValue, layerFloor))
        {
            flagPosition.position = hit.point;
            
        }
        else
        {
            
        }
    }
    void SelectingTower()
    {
        if (CanSelectTower())
        {
            print("ça marche !");
            isSelected = true;
            floorAvailable.SetActive(true);
        }
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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (!isSelected)
            {
                SelectingTower();
                print("Click !");
            }
            else
            {
                MoveFlag();
            }
            

        }
    }
}
