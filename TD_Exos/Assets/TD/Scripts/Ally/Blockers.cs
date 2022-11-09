using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[SelectionBase]
public class Blockers : MonoBehaviour
{

    [SerializeField, Range(1,10f)]
    float speed;

    float verification;

    Vector3 position;

    int number;

    TroopTower myTower;

    state myState = state.passive;

    enum state
    {
        passive,tracking,attacking
    }


    public void Initialyse(Vector3 myPosition, int myIndex, TroopTower myTower)
    {
        position = myPosition;
        number = myIndex;
        verification = speed;
        MoveTo(position);
    }

    private void MoveTo(Vector3 position)
    {
        Vector3 movement = (position - transform.position).normalized * speed * Time.deltaTime;
        transform.position += movement;
    }

    private bool IsArrive()
    {
        if (Vector3.Distance(transform.position, position) < 0.5f)
        {
            return true;
        }
        else 
        {
            MoveTo(position);
            return false; 
        }
    }

    private void Update()
    {

        switch (myState)
        {
            case state.passive: IsArrive(); break;
            case state.tracking: break;
            case state.attacking: break;
        } 
        
    }
}
