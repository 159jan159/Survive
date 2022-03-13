using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HurtPlayer : MonoBehaviour
{
    public int damage;
    private Transform target;
    private PlayerHealthManager PHM;
    private float waitToHurt = 0f;
    private Animator myAnim;
    void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        Findtarget();
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
        Findtarget();
    }

    private void Findtarget() {
        target = GameObject.FindWithTag("Player").transform;
        PHM = FindObjectOfType<PlayerHealthManager>();
        myAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(transform.position, target.position);
        
        if (distance<0.5f)
        {
            waitToHurt -= Time.deltaTime;
             if (waitToHurt <= 0)
             {
                 myAnim.SetBool("Attack",true);
                 PHM.getDamage(damage);                 
                 waitToHurt = 1f;
             }

        }else
             {
                 myAnim.SetBool("Attack",false);
             }
        
    }

}
