using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour
{
    private Animator myAnim;
    private Transform target;

    private Vector3 dir;

    void Start()
    {
        myAnim = GetComponent<Animator>();
        target = GameObject.FindWithTag("Player").transform;
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
