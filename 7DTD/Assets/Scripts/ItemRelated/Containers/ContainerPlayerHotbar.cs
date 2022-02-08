using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerPlayerHotbar : Container
{
    public ContainerPlayerHotbar(Inventory containerInventory, Inventory playerInventory) : base(containerInventory, playerInventory)
    {
        for(int i = 0; i < 7; i++)
        {
            addSlotToContainer(playerInventory, i, 10 + (50 * i), -10, 40);
        }
    }

    public override GameObject getContainerPrefab()
    {
        return InventoryManager.INSTANCE.getContainerPrefab("Player Hotbar");
    }

}
