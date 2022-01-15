using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IPointerDownHandler
{
    public Image itemIcon;
    public Text itemAmount;
    private int slotID;
    private ItemStack myStack;
    private Container attachedContainer;
    private InventoryManager inventoryManager;

    public void setSlot(Inventory attachedInventory, int slotID, Container attachedContainer){
        this.slotID = slotID;
        this.attachedContainer = attachedContainer;
        myStack = attachedInventory.getStackInSlot(slotID);
        inventoryManager = InventoryManager.INSTANCE;
        updateSlot();
    }
    public void updateSlot(){
        if(!myStack.isEmpty()){
            itemIcon.enabled = true;
            itemIcon.sprite = myStack.getItem().ItemIcon;

            if (myStack.getCount()>1)
            {
                itemAmount.text = myStack.getCount().ToString();
            }else{
                itemAmount.text = string.Empty;
            }
        }else{
            itemIcon.enabled = false;
            itemAmount.text = string.Empty;
        }

    }

    private void setSlotContaints(ItemStack stackIn){
        myStack.setStack(stackIn);
        updateSlot();
    }
        public void OnPointerDown(PointerEventData eventData)
    {
        ItemStack curDraggedStack = inventoryManager.getDragedItemStack();
        ItemStack stackCopy = myStack.copy();

        if (eventData.pointerId == -1)
        {
            onLeftClick(curDraggedStack, stackCopy);
        }
        if (eventData.pointerId == -2)
        {
            onRightClick();
        }
    }

    private void onLeftClick(ItemStack curDragedStack, ItemStack stackCopy){
        if (!myStack.isEmpty() && curDragedStack.isEmpty())
        {
            inventoryManager.setDragedItemStack(stackCopy);
            this.setSlotContaints(ItemStack.Empty);         
        }
        if (myStack.isEmpty() && !curDragedStack.isEmpty())
        {
            this.setSlotContaints(curDragedStack);     
            inventoryManager.setDragedItemStack(ItemStack.Empty);
        }
        if (!myStack.isEmpty()&& !curDragedStack.isEmpty()){
            if (ItemStack.areItemsEqual(stackCopy, curDragedStack))
            {
                if (stackCopy.canAddToo(curDragedStack.getCount()))
                {
                    stackCopy.increaseAmount(curDragedStack.getCount());
                    this.setSlotContaints(stackCopy);
                    inventoryManager.setDragedItemStack(ItemStack.Empty);
                }
            }else{
                int difference = (stackCopy.getCount() + curDragedStack.getCount())-stackCopy.getItem().maxStackSize;
                stackCopy.setCount(myStack.getItem().maxStackSize);
                ItemStack dragCopy = curDragedStack.copy();
                dragCopy.setCount(difference);
                this.setSlotContaints(stackCopy);
                inventoryManager.setDragedItemStack(dragCopy);
            }
        }
    }
    private void onRightClick(){

    }
}
