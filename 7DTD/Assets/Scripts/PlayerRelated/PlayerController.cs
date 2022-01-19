using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Item[] itemsToAdd;
    private Inventory myInventory = new Inventory(28);
    private Rigidbody2D myRB;
    private Animator myAnim;
    private PlayerStaminaManager playerStamina;
    private bool isInventoryOpen;

    [SerializeField]
    private float speed;

    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
        playerStamina = GetComponent<PlayerStaminaManager>();

        foreach (Item item in itemsToAdd)
        {
            myInventory.addItem(new ItemStack(item,1));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!isInventoryOpen)
            {
                InventoryManager.INSTANCE.openContainer(new ContainerPlayerInventory(null, myInventory));
                isInventoryOpen = true;
            }else
            {
                InventoryManager.INSTANCE.closeContainer();
                isInventoryOpen = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isInventoryOpen)
            {
                InventoryManager.INSTANCE.closeContainer();
                isInventoryOpen = false;
            }
        }
        //running if shift
        if (Input.GetKey(KeyCode.LeftShift) && playerStamina.currentStamina > 0){
            playerStamina.canRegen = false;
            speed = 1000f;
            Debug.Log(1*Time.deltaTime);
            playerStamina.loseStamina(3*Time.deltaTime);
        }else{
            playerStamina.canRegen = true;
            speed = 800f;
        }

        //pohyb
        myRB.velocity = new Vector2(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical")).normalized*speed*Time.deltaTime;        
        //animace
        myAnim.SetFloat("MoveX", myRB.velocity.x);
        myAnim.SetFloat("MoveY", myRB.velocity.y);

        if (Input.GetAxisRaw("Horizontal")==1 || Input.GetAxisRaw("Horizontal")==-1 || Input.GetAxisRaw("Vertical")==1 ||Input.GetAxisRaw("Vertical")==-1)
        {
            myAnim.SetFloat("LastX", Input.GetAxisRaw("Horizontal"));
            myAnim.SetFloat("LastY", Input.GetAxisRaw("Vertical"));
        }
          
    }
}
