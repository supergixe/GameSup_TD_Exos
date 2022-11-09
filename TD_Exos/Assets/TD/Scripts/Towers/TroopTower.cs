using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GSGD1;

public class TroopTower : Tower
{
    [SerializeField]
    private Blockers blockers;

    private Blockers[] myBlockers = new Blockers[3];

    [SerializeField]
    Transform[] positions = new Transform[3];

    [SerializeField]
    Transform flagPosition;

    [SerializeField]
    GameObject floorAvailable;


    private void Awake()
    {
        
        for (int i = 0; i < myBlockers.Length; i++)
        {
            Vector3 realPosition = this.transform.position + flagPosition.position + positions[i].position;
            Blockers currentBlocker = Instantiate(blockers);
            currentBlocker.transform.position = this.transform.position;
            print("oui");
            currentBlocker.Initialyse(realPosition, i);
            myBlockers[i] = currentBlocker;
        }
    }






}
