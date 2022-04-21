using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenShop : MonoBehaviour
{
    private PlayerController player;

    void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }
    void OnMouseDown()
    {
        InventoryManager.INSTANCE.openContainer(new ContainerShop(null, player.myInventory));
    }
}
