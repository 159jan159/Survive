using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;


public class setConfiner : MonoBehaviour
{
    private GameObject player;
    private CinemachineVirtualCamera CVC;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        CVC = GetComponent<CinemachineVirtualCamera>();

        CVC.Follow = player.transform;
        
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
