using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStats {

	public Stat damage;
	public Stat coldResist;
	public Stat fireResist;
	public Stat highPressureResist;
	public Stat lowPressureResist;
    public Stat health;
	public int coin;
    //public int level;
    //private bool levelUp;
    //public int currentXP;
    //public int maxXP;

    #region Singleton
    //public bool isDead = false;

    public static PlayerStats instance;

    //Call on Awake
    void Awake()
    {
        instance = this;
    }

    #endregion
    void Start ()
	{
        maxHealth = health.GetValue();
        currentHealth = maxHealth;
		//EquipmentManager.instance.onEquipmentChanged += OnEquipmentChanged;
		//level = 1;
		//levelUp = false;
	}
	
	/**void OnEquipmentChanged (Equipment newEquip, Equipment oldEquip)
	{
		if (newEquip != null) {
			damage.AddModifier(newEquip.damageModifier);
			coldResist.AddModifier(newEquip.coldResistModifier);
			hotResist.AddModifier(newEquip.hotResistModifier);
			highPressureResist.AddModifier(newEquip.highPressureResistModifier);
			lowPressureResist.AddModifier(newEquip.lowPressureResistModifier);
		}

		if (oldEquip != null) {
			damage.RemoveModifier(oldEquip.damageModifier);
			coldResist.RemoveModifier(oldEquip.coldResistModifier);
			hotResist.RemoveModifier(oldEquip.hotResistModifier);
			highPressureResist.RemoveModifier(oldEquip.highPressureResistModifier);
			lowPressureResist.RemoveModifier(oldEquip.lowPressureResistModifier);
		}
	}**/

	/**public void LevelUp ()
	{
		levelUp = true;
		level++;
	}**/

	public override void Dead ()
	{
		base.Dead();
		Player.instance.Dead();	
	}
}
