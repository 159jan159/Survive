using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour
{

    private Rigidbody2D myRB;
    private Animator myAnim;

    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //animace
        myAnim.SetFloat("MoveX", myRB.velocity.x);
        myAnim.SetFloat("MoveY", myRB.velocity.y);

        //if (Input.GetAxisRaw("Horizontal")==1 || Input.GetAxisRaw("Horizontal")==-1 || Input.GetAxisRaw("Vertical")==1 ||Input.GetAxisRaw("Vertical")==-1)
        //{
        //    myAnim.SetFloat("LastX", Input.GetAxisRaw("Horizontal"));
        //    myAnim.SetFloat("LastY", Input.GetAxisRaw("Vertical"));
        //}
    }
}
