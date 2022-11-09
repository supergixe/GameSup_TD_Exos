namespace GSGD1
{
	using GSGD1;
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;

	public abstract class Tower : MonoBehaviour, IPickerGhost, ICellChild
	{

		private void Awake()
		{
			enabled = false;
		}

		public void Enable(bool isEnabled)
		{
			enabled = isEnabled;
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
	}
}