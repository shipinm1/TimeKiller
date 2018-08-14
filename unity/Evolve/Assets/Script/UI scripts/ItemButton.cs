using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemButton : MonoBehaviour {

    public Button button;
    public Image icon;
    public Text itemname;
    public Text price;
    public Text instruction;
    public Text levelnum;

    private Item item;
	// Use this for initialization
	void Start () {
		button.onClick.AddListener(HandleClick);
    }

    public void SetUp(Item targetItem) {
        item = targetItem;

        icon.overrideSprite = targetItem.icon;
        itemname.text = targetItem.itemName;
        price.text = targetItem.price.ToString();
        levelnum.text = targetItem.itemLevel.ToString();
    }

    public void HandleClick()
    {
        item.Use();
        SetUp(item);
       //Debug.Log(item.na)
    }
}
