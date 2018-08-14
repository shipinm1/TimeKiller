using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour {

	#region Singleton

	public static EquipmentManager instance;

	void Awake () 
	{
		instance = this;
	}

	#endregion

	public delegate void OnEquipmentChanged(Equipment newEquip, Equipment oldEquip);
	public event OnEquipmentChanged onEquipmentChanged;
}
