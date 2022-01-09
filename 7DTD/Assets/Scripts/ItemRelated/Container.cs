using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Container
{
    // Start is called before the first frame update
    private GameObject spawnedContainerPrefab;
    private Inventory containerInventory;
    private Inventory playerInventory;

    public Container(Inventory containerInventory, Inventory playerInventory){
        this.containerInventory = containerInventory;
        this.playerInventory = playerInventory;
        openContainer();
    }

    public void openContainer(){
        spawnedContainerPrefab = Object.Instantiate(getContainerPrefab(), InventoryManager.INSTANCE.transform);
    }

    public void closeConteiner(){
        Object.Destroy(spawnedContainerPrefab);
    }

    // needs to be overriden 
    public virtual GameObject getContainerPrefab(){
        return null;
    }

    public GameObject getSpawnedContainer(){
        return spawnedContainerPrefab;
    }

    public Inventory getContainerInventory(){
        return containerInventory;
    }

    public Inventory getPlayerInventory(){
        return playerInventory;
    }




}
