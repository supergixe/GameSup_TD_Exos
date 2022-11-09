using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[SelectionBase]
public class Blockers : MonoBehaviour
{

    [SerializeField, Range(0,10f)]
    float speed;

    Vector3 position;

    int number;


    public void Initialyse(Vector3 myPosition, int myIndex)
    {
        position = myPosition;
        number = myIndex;
        print("non");
        while(!IsArrive()) MoveTo(position);

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
        else return false;
    }
}
