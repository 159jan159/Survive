using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hittingTree : MonoBehaviour
{
    public int Health = 5;
    public Item itemDrop;
    private PlayerController player;
    public GameObject particles;
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        
    }
    void OnMouseDown()
    {
        if (Vector3.Distance(player.transform.position, transform.position) < 1)
        {
            Debug.Log("dostblítko");

            if (player.itemHeld.ItemType == typ.Tool)
            {
                if (player.actionTimeCounter <= 0)
                {
                    Instantiate(particles, transform.position, Quaternion.identity);
                    if (Health >= 0)
                    {                        
                        Health -= player.itemHeld.Damage;
                    }else
                    {
                        player.myInventory.addItem(new ItemStack(itemDrop, Random.Range(2,5)));
                        Destroy(gameObject);   
                    }
                }                
            }   
        }
    }
}
