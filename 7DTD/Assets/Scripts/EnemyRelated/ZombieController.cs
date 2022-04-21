using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Pathfinding;
using UnityEngine.UI;

public class ZombieController : MonoBehaviour
{
    private Animator myAnim;
    private PlayerController player;
    private AIDestinationSetter setter;
    private AIPath path;
    public Slider ZheltBar;
    public int Zhealth;
    public GameObject blood;

    private Vector3 dir;

    void Start()
    {
        myAnim = GetComponent<Animator>();
        SceneManager.sceneLoaded += OnSceneLoaded;
        Findtarget();
        ZheltBar.maxValue = Zhealth;
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
        Findtarget();
    }

    private void Findtarget() {
        player = FindObjectOfType<PlayerController>();
        setter = GetComponent<AIDestinationSetter>();
        path = GetComponent<AIPath>();       
        setter.target = player.transform;


    }

    // Update is called once per frame
    void Update()
    {
        dir = player.transform.position - transform.position;
        dir.Normalize();   
        if (Vector3.Distance(player.transform.position, transform.position)>10)
        {
            path.enabled = false;
            myAnim.SetFloat("MoveX", 0);
            myAnim.SetFloat("MoveY", 0);
        }else
        {
            path.enabled = true; 
        //animace
        myAnim.SetFloat("MoveX", dir.x);
        myAnim.SetFloat("MoveY", dir.y);

        }


    }
    void OnMouseDown()
    {
        if (Vector3.Distance(player.transform.position, transform.position) < 0.5)
        {
            if (player.itemHeld.ItemType == typ.MeleeWeapon)
            {
                Instantiate(blood, transform.position, Quaternion.identity);
                if (Zhealth > 0)
                {
                    Zhealth -= 10;
                    ZheltBar.value = Zhealth;
                
                }else{
                    Destroy(gameObject);
                }
            }
            
        }
        
    }


}
