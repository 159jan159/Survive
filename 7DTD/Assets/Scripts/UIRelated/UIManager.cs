using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Slider healthBar;
    public Text HPText;
    public PlayerHealthManager playerHealth;
    public Slider staminaBar;
    public Text StaminaText;
    public PlayerStaminaManager playerStamina;
    public static bool uiExists;

    void Start()
    {
        if (!uiExists)
        {
            uiExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.maxValue = playerHealth.maxHealth;
        healthBar.value = playerHealth.currentHealth;

        HPText.text = playerHealth.currentHealth+" / "+playerHealth.maxHealth;

        staminaBar.maxValue = playerStamina.maxStamina;
        staminaBar.value = Mathf.RoundToInt(playerStamina.currentStamina);
        

        StaminaText.text = Mathf.RoundToInt(playerStamina.currentStamina)+" / "+playerStamina.maxStamina;
    }
}
