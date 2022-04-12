using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public Item[] itemsToAdd;
    private Inventory myInventory = new Inventory(35);
    private Rigidbody2D myRB;
    private Animator myAnim;
    private PlayerStaminaManager playerStamina;
    private bool isInventoryOpen;

    private int selectedHotbarIndex = 0;

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
            DontDestroyOnLoad(transform.gameObject);
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
        InventoryManager.INSTANCE.openContainer(new ContainerPlayerHotbar(null, myInventory));
        InventoryManager.INSTANCE.resetInventoryStatus();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        //pohyb
        //myRB.velocity = new Vector2(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical")).normalize*speed*Time.deltaTime; 
        float xS = Input.GetAxisRaw("Horizontal");
        float yS = Input.GetAxisRaw("Vertical");

        myRB.velocity = new Vector2(xS,yS).normalized*speed*Time.deltaTime;

    }
    private void Update(){
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!InventoryManager.INSTANCE.hasInventoryCurrentlyOpen())
            {
                InventoryManager.INSTANCE.openContainer(new ContainerPlayerInventory(null, myInventory));
            }
        }
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
          updateSelectedHotbarIndex(Input.GetAxis("Mouse ScrollWheel"));
    }
    private void updateSelectedHotbarIndex(float direction){
        if (direction > 0) direction = 1;
        if (direction < 0) direction = -1;

        for (selectedHotbarIndex -= (int) direction ; selectedHotbarIndex < 0 ; selectedHotbarIndex += 7);

        while(selectedHotbarIndex >= 7)selectedHotbarIndex -= 7;
    }

    public int getSelectedHotbarIndex(){
        return selectedHotbarIndex;
    }
    public Inventory getInventory()
    {
        return myInventory;
    }
}
