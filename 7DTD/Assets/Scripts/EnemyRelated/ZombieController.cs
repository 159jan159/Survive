using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour
{
    private Animator myAnim;
    private float lastX;
    private float lastY;

    
    void Start()
    {
        myAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        Debug.Log(lastX +"|"+ lastY);


        //animace
        myAnim.SetFloat("MoveX", lastX-transform.position.x);
        myAnim.SetFloat("MoveY", lastY-transform.position.y);

           
        lastX = transform.position.x;
        lastY = transform.position.y;

        //if (Input.GetAxisRaw("Horizontal")==1 || Input.GetAxisRaw("Horizontal")==-1 || Input.GetAxisRaw("Vertical")==1 ||Input.GetAxisRaw("Vertical")==-1)
        //{
        //    myAnim.SetFloat("LastX", Input.GetAxisRaw("Horizontal"));
        //    myAnim.SetFloat("LastY", Input.GetAxisRaw("Vertical"));
        //}
    }
}
