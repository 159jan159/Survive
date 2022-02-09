using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;
using SuperTiled2Unity;

public class CameraSetter : MonoBehaviour
{
    private PlayerController player;
    //private PolygonCollider2D mainMap;
    private CinemachineVirtualCamera Vcam;
    private CinemachineConfiner VcamC;
    // Start is called before the first frame update
    void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        findPlayerControler();
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
        findPlayerControler();
    }
    private void findPlayerControler(){
        player = FindObjectOfType<PlayerController>();
        Vcam = GetComponent<CinemachineVirtualCamera>();
        VcamC = GetComponent<CinemachineConfiner>();
        //mainMap = FindObjectOfType<PolygonCollider2D>();

        Vcam.Follow = player.transform;
        //VcamC.m_BoundingShape2D = mainMap;   
        
    }
}
