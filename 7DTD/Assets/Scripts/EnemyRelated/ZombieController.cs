using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour
{

    

    [SerializeField] private GameObject Player;
    [SerializeField] private float speed = 100f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position,Player.transform.position,speed*Time.deltaTime);

    }
}
