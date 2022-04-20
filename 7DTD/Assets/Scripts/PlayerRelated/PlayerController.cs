using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public Item[] itemsToAdd;

    public SpriteRenderer itemInHand;
    public Inventory myInventory = new Inventory(35);
    private Rigidbody2D myRB;
    public Animator myAnim;
    private PlayerStaminaManager playerStamina;
    private bool isInventoryOpen;
    public Item itemHeld;

    private int selectedHotbarIndex = 0;
    private float cooldowntoaction = 0f;

    private KeyCode[] hotbarControls = new KeyCode[]
    {
        KeyCode.Alpha1,
        KeyCode.Alpha2,
        KeyCode.Alpha3,
        KeyCode.Alpha4,
        KeyCode.Alpha5,
        KeyCode.Alpha6,
        KeyCode.Alpha7
    };

    private static bool isPlayerExists;

    [SerializeField]
    private float speed;

    // Start is called before the first frame update
    void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        
        findStuff();  
        
        foreach(Item item in itemsToAdd)
        {
            myInventory.addItem(new ItemStack(item, 1));
        }
        InventoryManager.INSTANCE.openContainer(new ContainerPlayerHotbar(null, myInventory));
        InventoryManager.INSTANCE.resetInventoryStatus();
              
        if (!isPlayerExists)
        {
            isPlayerExists = true;
            DontDestroyOnLoad(gameObject);
        }else
        {
            Destroy(gameObject);
        } 
    

        
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
        findStuff();    
  
    }

    public void findStuff(){
        myRB = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
        playerStamina = GetComponent<PlayerStaminaManager>();

    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        //pohyb
        float xS = Input.GetAxisRaw("Horizontal");
        float yS = Input.GetAxisRaw("Vertical");

        myRB.velocity = new Vector2(xS,yS).normalized*speed*Time.deltaTime;

    }
    private void Update(){
        //running if shift
        if (Input.GetKey(KeyCode.LeftShift) && playerStamina.currentStamina > 0){
            playerStamina.canRegen = false;
            speed = 500f;
            playerStamina.loseStamina(3*Time.deltaTime);
        }else{
            playerStamina.canRegen = true;
            speed = 200f;
        }
        //animace
        myAnim.SetFloat("MoveX", myRB.velocity.x);
        myAnim.SetFloat("MoveY", myRB.velocity.y);

        if (Input.GetAxisRaw("Horizontal")==1 || Input.GetAxisRaw("Horizontal")==-1 || Input.GetAxisRaw("Vertical")==1 ||Input.GetAxisRaw("Vertical")==-1)
        {
            myAnim.SetFloat("LastX", Input.GetAxisRaw("Horizontal"));
            myAnim.SetFloat("LastY", Input.GetAxisRaw("Vertical"));
        }
        
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!InventoryManager.INSTANCE.hasInventoryCurrentlyOpen())
            {
                InventoryManager.INSTANCE.openContainer(new ContainerPlayerInventory(null, myInventory));
            }
        }

        updateSelectedHotbarIndex(Input.GetAxis("Mouse ScrollWheel"));

        for(int i = 0; i < hotbarControls.Length; i++)
        {
            if(Input.GetKeyDown(hotbarControls[i]))
            {
                selectedHotbarIndex = i;
                swapItem();
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("klik");
            if (cooldowntoaction <= 0)
            {
                myAnim.SetTrigger("Action");
                cooldowntoaction = 0.5f;
            }
        }
        if (cooldowntoaction > 0)
        {
            cooldowntoaction -= Time.deltaTime;
        }      
            
    }
    private void updateSelectedHotbarIndex(float direction){
        if (direction > 0) direction = 1;
        if (direction < 0) direction = -1;

        for (selectedHotbarIndex -= (int) direction ; selectedHotbarIndex < 0 ; selectedHotbarIndex += 7);

        while(selectedHotbarIndex >= 7)selectedHotbarIndex -= 7;
        swapItem();
    }

    public int getSelectedHotbarIndex(){
        return selectedHotbarIndex;
    }
    public Inventory getInventory()
    {
        return myInventory;
    }
    private void swapItem(){
        if (myInventory.getStackInSlot(selectedHotbarIndex).isEmpty())
        {
                        //Debug.Log("setting true");
            myAnim.SetBool("Tool", false);
            itemInHand.enabled = false;

        }
        else
        {
            //Debug.Log("setting false");
            myAnim.SetBool("Tool", true);
            itemHeld = myInventory.getStackInSlot(selectedHotbarIndex).item;
            itemInHand.enabled = true;
            itemInHand.sprite = myInventory.getStackInSlot(selectedHotbarIndex).item.ItemIcon;
        }        
    }
}

