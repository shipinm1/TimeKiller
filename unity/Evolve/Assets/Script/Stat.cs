using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
/**
 * modifier sequence:
 * position 0 ---- the individual stat level up modifier (ex: only efect the current stat, fire resist or water resist)
 **/
[Serializable]
public class Stat {
	
	[SerializeField]
	int baseValue;

	private List<float> modifierList = new List<float> { 0,0,0,0,0};

	public float GetValue ()
	{
		float final = baseValue;
		modifierList.ForEach(x => final += baseValue * x);
		return final;
	}

	public void AddModifier (int index, float modifier)
	{
		if (modifier != 0f) {
            modifierList[index] = modifier;
		}
	}

	public void RemoveModifier (int index, int modifier)
	{
		if (modifier != 0f) {
            modifierList[index] = 1;
		}
	}

}
