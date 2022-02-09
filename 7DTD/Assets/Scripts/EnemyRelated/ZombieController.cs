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
        setter.target = target;

    }

    // Update is called once per frame
    void Update()
    {

        dir = target.position - transform.position;
        dir.Normalize();    
        //animace
        myAnim.SetFloat("MoveX", dir.x);
        myAnim.SetFloat("MoveY", dir.y);

    }


}
