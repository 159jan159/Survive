using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class CraftingScript : MonoBehaviour, IPointerDownHandler
{
    public Recepie recept = new Recepie();
    private PlayerController player;
    public Slot slot1;
    public Slot slot2;
    public Slot slot3;

    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        slot1.itemIcon.sprite = recept.sourceItem1.ItemIcon;
        slot1.itemAmount.text = recept.countOfItem1.ToString();
        slot2.itemIcon.sprite = recept.sourceItem2.ItemIcon;
        slot2.itemAmount.text = recept.countOfItem2.ToString();
        slot3.itemIcon.sprite = recept.craftingResult.ItemIcon;
        slot3.itemAmount.text = recept.countOfResult.ToString();
    }
    
    public void craft(){
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {

        if (player.myInventory.getCountOfItems(recept.sourceItem1) >= recept.countOfItem1)
        {
            if (player.myInventory.getCountOfItems(recept.sourceItem2) >= recept.countOfItem2)
            {
                player.myInventory.removeItems(recept.sourceItem1, recept.countOfItem1);
                player.myInventory.removeItems(recept.sourceItem2, recept.countOfItem2);
                player.myInventory.addItem(new ItemStack(recept.craftingResult,recept.countOfResult));
            }
        }
    }
}

[System.Serializable]
public class Recepie
{
    public Item sourceItem1;
    public int countOfItem1;
    public Item sourceItem2;
    public int countOfItem2;
    public Item craftingResult;
    public int countOfResult;
}