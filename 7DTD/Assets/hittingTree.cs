using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hittingTree : MonoBehaviour
{
    public int Health = 5;
    public Item itemDrop;
    private PlayerController player;
    private SpriteRenderer item;
    private float cooldown = 0f;
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        
    }

    // Update is called once per frame
    void Update()
    {
      
    }
    void OnMouseDown()
    {
        if (Vector3.Distance(player.transform.position, transform.position) < 0.8)
        {
            if (player.itemHeld.ItemName.Contains("Axe"))
            {
                cooldown -= Time.deltaTime;
                if (cooldown <= 0)
                {
                    if (Health >= 0)
                    {
                        player.myAnim.SetBool("Action",true);
                        Health--;
                    }else
                    {
                        player.myAnim.SetBool("Action",false);
                        player.myInventory.addItem(new ItemStack(itemDrop, Random.Range(2,5)));
                        Destroy(gameObject);   
                    }
                }else
                {
                    player.myAnim.SetBool("Action",false);
                }                  
            }      
        }
    }
}
