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
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(transform.position, target.position);
        
        if (distance<1)
        {
            waitToHurt -= Time.deltaTime;
             if (waitToHurt <= 0)
             {
                 PHM.getDamage(damage);
                 waitToHurt = 1f;
             }
        }
        
    }

}
