using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerChest : Container
{
    public ContainerChest(Inventory containerInventory, Inventory playerInventory): base (containerInventory, playerInventory)
    {
        //Player Hotbar Slots
        for (int i = 0; i < 7; i++)
        {
            addSlotToContainer(playerInventory,i,10+(50*i),-220,40);
        }
        //Řádky
        for (int i = 0; i < 7; i++)
        {
            addSlotToContainer(playerInventory,7+i,10+(50*i),-10,40);
        }
        for (int i = 0; i < 7; i++)
        {
            addSlotToContainer(playerInventory,14+ i,10+(50*i),-60,40);
        }
        for (int i = 0; i < 7; i++)
        {
            addSlotToContainer(playerInventory,21+ i,10+(50*i),-110,40);
        }
        for (int i = 0; i < 7; i++)
        {
            addSlotToContainer(playerInventory,28+ i,10+(50*i),-160,40);
        }

        //Chest Inventory Slots Row 1
        for (int i = 0; i < 5; i++)
        {
            addSlotToContainer(containerInventory, i, 365 + (50 * i), -10,40);
        }

        //Chest Inventory Slots Row 2
        for (int i = 0; i < 5; i++)
        {
            addSlotToContainer(containerInventory, 6 + i, 365 + (50 * i), -60,40);
        }

        //Chest Inventory Slots Row 3
        for (int i = 0; i < 5; i++)
        {
            addSlotToContainer(containerInventory, 12 + i, 365 + (50 * i), -110,40);
        }

        //Chest Inventory Slots Row 4
        for (int i = 0; i < 5; i++)
        {
            addSlotToContainer(containerInventory, 18 + i, 365 + (50 * i), -160,40);
        }
    }

    public override GameObject getContainerPrefab()
    {
        return InventoryManager.INSTANCE.getContainerPrefab("Chest Inventory");
    }
}