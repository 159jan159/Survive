using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Pathfinding;

public class ZombieController : MonoBehaviour
{
    private Animator myAnim;
    private Transform target;
    private AIDestinationSetter setter;
    private AIPath path;

    private Vector3 dir;

    void Start()
    {
        myAnim = GetComponent<Animator>();
        SceneManager.sceneLoaded += OnSceneLoaded;
        Findtarget();
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
        Findtarget();
    }

    private void Findtarget() {
        target = GameObject.FindWithTag("Player").transform;
        setter = GetComponent<AIDestinationSetter>();
        path = GetComponent<AIPath>();
        setter.target = target;

    }

    // Update is called once per frame
    void Update()
    {
        dir = target.position - transform.position;
        dir.Normalize();   
        if (Vector3.Distance(target.transform.position, transform.position)>10)
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


}
