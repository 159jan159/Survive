using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShopScript : MonoBehaviour, IPointerDownHandler
{
    public Trade trade = new Trade();
    private PlayerController player;
    public Slot slot1;
    public Slot slot2;

    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        slot1.itemIcon.sprite = trade.sourceItem1.ItemIcon;
        slot1.itemAmount.text = trade.countOfItem1.ToString();
        slot2.itemIcon.sprite = trade.buyItem.ItemIcon;
        slot2.itemAmount.text = trade.buyCount.ToString();
    }
    
    public void craft(){
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (player.myInventory.getCountOfItems(trade.sourceItem1) >= trade.countOfItem1)
        {
                player.myInventory.removeItems(trade.sourceItem1, trade.countOfItem1);
                player.myInventory.addItem(new ItemStack(trade.buyItem, trade.buyCount));
        }
    }
}

[System.Serializable]
public class Trade
{
    public Item sourceItem1;
    public int countOfItem1;
    public Item buyItem;
    public int buyCount;
}

