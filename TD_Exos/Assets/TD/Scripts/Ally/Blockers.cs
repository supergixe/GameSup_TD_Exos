using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GSGD1;


[SelectionBase]
public class Blockers : Damageable
{

    [SerializeField, Range(1,10f)]
    float speed;

    float verification;

    [SerializeField]
    DamageableDetector _damageableDetector;

    [SerializeField]
    WeaponController _weaponController;

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
        this.myTower = myTower;
        verification = speed;
        MoveTo(position);
    }
    public void UpdatePosition(Vector3 myPosition)
    {
        position = myPosition;
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
        if (_damageableDetector.HasAnyDamageableInRange() == true)
        {
            Damageable damageableTarget = _damageableDetector.GetNearestDamageable();

            _weaponController.LookAtAndFire(damageableTarget.GetAimPosition());
        }
        switch (myState)
        {
            case state.passive: IsArrive(); return;
            case state.tracking: return;
            case state.attacking: return;
        }
    }
}
