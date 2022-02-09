using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Respawn : MonoBehaviour
{   
    private PlayerController pC;
    private PlayerHealthManager pHC;
    void Start()
    {
        pC = FindObjectOfType<PlayerController>(true);
        pHC = FindObjectOfType<PlayerHealthManager>(true);
    }
    public void respawnPlayer(){
        pC.gameObject.SetActive(true);
        pHC.restoreMaxHealth();
        SceneManager.LoadScene("SampleScene");
    }
    public void konec(){
        Application.Quit();
    }
}
