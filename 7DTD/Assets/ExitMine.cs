using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitMine : MonoBehaviour
{
    private PlayerController player;
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape)){
            player.transform.position = new Vector3(-13,-3,0);
            SceneManager.LoadScene("scene2");
        }
    }
}
