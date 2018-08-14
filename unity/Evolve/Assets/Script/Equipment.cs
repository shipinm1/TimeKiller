using System;
using UnityEngine;

[Serializable]
public class Equipment : Item {

	public int damageModifier;
	public int coldResistModifier;
	public int hotResistModifier;
	public int highPressureResistModifier;
	public int lowPressureResistModifier;

	#region Singleton

	public static Equipment instance;

	void Awake () 
	{
		instance = this;
	}

	#endregion
}
