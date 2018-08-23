using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopScrollList : MonoBehaviour {

    public static ShopScrollList shopScrollList;
    public Transform shopContent;

    public SimpleObjectPool objectPool;
    public List<Sprite> buttonBack;
    public Button[] topmenu = new Button[3];

    private List<Item> shopList;

   /** void Awake()
    {
        //instance = this;
        if (shopScrollList == null)
        {
            DontDestroyOnLoad(gameObject);
            shopScrollList = this;
        }
        else if (shopScrollList != this)
        {
            Destroy(gameObject);
        }
    }**/

    void Start () {
        shopList = new List<Item>();
	}

    public void Refresh(int dex) {
        //Debug.Log("refresh");
        for (int i = 0; i < 3; i++)
        {
            if (i == dex)
            {
                topmenu[i].interactable = false;
            }
            else
            {
                topmenu[i].interactable = true;
            }
        }
        AddButton(dex);
        
    }
    private void AddButton(int buttonbackdex) {
        switch (buttonbackdex)
        {
            case 0:
                //Debug.Log("case 0");
                //shopList = PlayerItemDatabase.Instance.playerItemDatabase;
                SetShopList(PlayerItemDatabase.Instance.playerItemDatabase);
                break;
            //case 1:
                //shopList = EnvItemDatabase.Instance.envItemDatabase;
               // break;
            default:
                break;
        }
        
        for (int i = 0; i < shopList.Count; i++)
        {
            //Debug.Log(shopList[i].itemName);
            if (shopList[i].available == true)
            {
                Item tempItem = shopList[i];
                GameObject newbutton = objectPool.GetObject();
                newbutton.transform.SetParent(shopContent);
                newbutton.GetComponent<Image>().sprite = buttonBack[buttonbackdex];
                ItemButton itemButton = newbutton.GetComponent<ItemButton>();
                itemButton.SetUp(tempItem);
            }
        }
    }

    private void SetShopList(List<Item> database) {
        
        foreach (Item i in database)
        {
            if (i.available == true)
            {
                shopList.Add(i.Copy());
            }
        }
    }


}
