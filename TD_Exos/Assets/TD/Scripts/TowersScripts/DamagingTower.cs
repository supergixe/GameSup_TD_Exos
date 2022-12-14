namespace GSGD1
{
	using GSGD1;
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;

	/// <summary>
	/// Facade for Tower subsystems
	/// </summary>
	public class DamagingTower : Tower
	{
		[SerializeField]
		private WeaponController _weaponController = null;


		[SerializeField]
		private DamageableDetector _damageableDetector = null;

        public override void OnTowerAction()
        {
            throw new System.NotImplementedException();
        }

        public override void SelectingTower()
        {
            base.SelectingTower();
        }

        private void Update()
		{
			if (_damageableDetector.HasAnyDamageableInRange() == true)
			{
				Damageable damageableTarget = _damageableDetector.GetNearestDamageable();

				_weaponController.LookAtAndFire(damageableTarget.GetAimPosition());
			}
		}
	}
}