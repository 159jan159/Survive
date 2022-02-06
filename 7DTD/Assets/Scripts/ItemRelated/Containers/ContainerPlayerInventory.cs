using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerPlayerInventory : Container
{
   public ContainerPlayerInventory(Inventory containerInventory, Inventory playerInventory): base (containerInventory, playerInventory){
       //adding slots
        //Řádek HOTBAR
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
       
   }

   public override GameObject getContainerPrefab(){
       return InventoryManager.INSTANCE.getContainerPrefab("Player Inventory");
   }
}
