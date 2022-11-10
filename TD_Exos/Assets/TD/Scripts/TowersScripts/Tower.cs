namespace GSGD1
{
	using GSGD1;
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;

	public abstract class Tower : MonoBehaviour, IPickerGhost, ICellChild
	{
		protected int index;

		protected TowerManager myManager;

		protected bool isSelected = false;

		public enum TowerType
        {
			damagingTower, troopTower
        }

		[SerializeField]
		TowerType type;

		
		public TowerType GetMyType()
        {
			return type;
        }


		abstract public void OnTowerAction(RaycastHit hit, Ray ray);

		virtual public void SelectingTower()
        {
			isSelected = true;
        }

		private void Awake()
		{
			enabled = false;
        }

		public void Enable(bool isEnabled)
		{
			enabled = isEnabled;
		}

		public int GetIndex()
        {
			return index;
        }

		// Interfaces
		public Transform GetTransform()
		{
			return transform;
		}

		public void OnSetChild()
		{
			Enable(true);
		}

        private void OnEnable()
        {
			

        }
    }
}