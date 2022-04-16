using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    private PlayerController player;
    private InventoryManager inventoryManager;
    private Inventory inventory = new Inventory(24);

    public List<LootTable> lootTable = new List<LootTable>();
    public int PocetItemu;

	void Start ()
    {
        player = FindObjectOfType<PlayerController>();
        inventoryManager = InventoryManager.INSTANCE;
        generateLoot();
    }
    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);

        if(distance <= 1 && !inventoryManager.hasInventoryCurrentlyOpen())
        {
            if(Input.GetMouseButtonDown(1))//Right Click
            {
                inventoryManager.openContainer(new ContainerChest(inventory, player.getInventory()));
            }
        }
    }
    private void generateLoot(){
        List<Item> commonLootTable = new List<Item>();
        List<Item> uncommonLootTable = new List<Item>();
        List<Item> rareLootTable = new List<Item>();
        List<Item> epicLootTable = new List<Item>();
        List<Item> legendaryLootTable = new List<Item>();
        foreach (var item in lootTable)
        {
            if (item.value == Rarity.Common)
            {
                commonLootTable.Add(item.item);
            }
            if (item.value == Rarity.Uncommon)
            {
                uncommonLootTable.Add(item.item);
            }
            if (item.value == Rarity.Rare)
            {
                rareLootTable.Add(item.item);
            }
            if (item.value == Rarity.Epic)
            {
                epicLootTable.Add(item.item);
            }
            if (item.value == Rarity.Legendary)
            {
                legendaryLootTable.Add(item.item);
            }
        }
        for (int i = 0; i < PocetItemu; i++)
        {
            int SelectedRarity = Random.Range(0,100);
            if (SelectedRarity <= 50)
            {
                inventory.addItem(new ItemStack(commonLootTable[Random.Range(0,commonLootTable.Count)],1));
            }
            if (SelectedRarity > 50 && SelectedRarity <= 75)
            {
                inventory.addItem(new ItemStack(uncommonLootTable[Random.Range(0,uncommonLootTable.Count)],1));
            }
            if (SelectedRarity > 75 && SelectedRarity <= 90)
            {
                inventory.addItem(new ItemStack(rareLootTable[Random.Range(0,rareLootTable.Count)],1));
            }
            if (SelectedRarity > 90 && SelectedRarity <= 99)
            {
                inventory.addItem(new ItemStack(epicLootTable[Random.Range(0,epicLootTable.Count)],1));
            }
            if (SelectedRarity > 99)
            {
                inventory.addItem(new ItemStack(legendaryLootTable[Random.Range(0,legendaryLootTable.Count)],1));
            }
        }

    }

    [System.Serializable]
public class LootTable
{
    public Item item;
    public Rarity value;
}
public enum Rarity
{
    Common, //0-50
    Uncommon, //50-75
    Rare,  //75-90
    Epic, //90-99
    Legendary //99-100
}
}