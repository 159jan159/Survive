using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealthManager : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;

    private Respawn deathScrean;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        SceneManager.sceneLoaded += OnSceneLoaded;
        FindRespawn();
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
        FindRespawn();
    }

    private void FindRespawn() {

        deathScrean = FindObjectOfType<Respawn>(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
            deathScrean.gameObject.SetActive(true);
        }
    }

    public void getDamage(int damage){
        currentHealth -=damage;
    }

    public void healDamage(int heal){
        currentHealth += heal;
    }

    public void restoreMaxHealth(){
        currentHealth = maxHealth;
    }
}
