﻿namespace GSGD1
{
	using System.Collections.Generic;
	using UnityEngine;

	public class DamageableDetector : MonoBehaviour
	{
		[System.NonSerialized]
		private List<Damageable> _damageablesInRange = new List<Damageable>();

		const int _enemyLayerMask = 1 << 9;

		const int _allyLayerMask = 1 << 8;

		enum AttackerType
        {
			Tower,Enemy
        }

		[SerializeField]
		private AttackerType _attackerType = AttackerType.Tower;


		public bool HasAnyDamageableInRange()
		{
			return _damageablesInRange.Count > 0;
		}

		public Damageable GetFirstDamageable()
		{
			if (HasAnyDamageableInRange() == true)
			{
				return _damageablesInRange[0];
			}
			else
			{
				return null;
			}
		}

		public Damageable GetNearestDamageable()
		{
			float shortestDistance = 0;
			int shortestDistanceIndex = 0;
			for (int i = 0, length = _damageablesInRange.Count; i < length; i++)
			{
				var distance = (_damageablesInRange[i].transform.position - transform.position).sqrMagnitude;
				if (distance < shortestDistance)
				{
					shortestDistance = distance;
					shortestDistanceIndex = i;
				}
			}

			return _damageablesInRange[shortestDistanceIndex];
		}


		private void OnTriggerEnter(Collider other)
		{
			Damageable damageable = other.GetComponentInParent<Damageable>();

			if (damageable != null && _damageablesInRange.Contains(damageable) == false)
			{
				if( AttackerType.Tower == _attackerType)
                {
					if(other.GetComponent<LayerMask>().value == _enemyLayerMask)
                    {
						damageable.DamageTaken -= Damageable_OnDamageTaken;
						damageable.DamageTaken += Damageable_OnDamageTaken;
						_damageablesInRange.Add(damageable);
					}
				}
				else if(AttackerType.Enemy == _attackerType)
                {
					if (other.GetComponent<LayerMask>().value == _allyLayerMask)
					{
						damageable.DamageTaken -= Damageable_OnDamageTaken;
						damageable.DamageTaken += Damageable_OnDamageTaken;
						_damageablesInRange.Add(damageable);
					}
				}
			}
		}

		private void OnTriggerExit(Collider other)
		{
			Damageable damageable = other.GetComponentInParent<Damageable>();

			if (damageable != null && _damageablesInRange.Contains(damageable) == true)
			{
				damageable.DamageTaken -= Damageable_OnDamageTaken;
				_damageablesInRange.Remove(damageable);
			}
		}

		private void Damageable_OnDamageTaken(Damageable caller, int currentHealth, int damageTaken)
		{
			if (currentHealth <= 0)
			{
				_damageablesInRange.Remove(caller);
			}
		}

	}
}