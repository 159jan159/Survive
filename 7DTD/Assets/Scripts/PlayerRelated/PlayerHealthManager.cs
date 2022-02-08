using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;

    public GameObject deathScrean;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;

    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
            deathScrean.SetActive(true);
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
