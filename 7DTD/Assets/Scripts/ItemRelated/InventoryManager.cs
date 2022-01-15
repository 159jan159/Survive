using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    #region Singleton

    public static InventoryManager INSTANCE;

    private void Awake(){
        INSTANCE = this;
    }
    #endregion

    public GameObject slotPrefab;
    public List<ContainerGetter> containers = new List<ContainerGetter>();
    private Container currentOpenContainer;
    private ItemStack curDraggedStack = ItemStack.Empty;
    private GameObject spawnedDragStack;
    private DragedItemStack dragStack;


    private void Start()
    {
        dragStack = GetComponent<DragedItemStack>();
    }

    public GameObject getContainerPrefab(string name){
        foreach (ContainerGetter container in containers)
        {
            if (container.containerName == name){
                return container.containerPrefab;
            }
        }
        return null;
    }

    public void openContainer(Container container){
        if (currentOpenContainer != null){
            currentOpenContainer.closeConteiner();
        }
        currentOpenContainer = container;
    }
    public void closeContainer(){
        if (currentOpenContainer != null){
            currentOpenContainer.closeConteiner();
        }
    }

    public ItemStack getDragedItemStack(){
        return curDraggedStack;
    }

    public void setDragedItemStack(ItemStack stackIn){
        dragStack.setDragedStack(curDraggedStack = stackIn);
    }
}

[System.Serializable]
public class ContainerGetter{
    public string containerName;
    public GameObject containerPrefab;
}