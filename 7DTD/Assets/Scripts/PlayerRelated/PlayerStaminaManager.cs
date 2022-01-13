using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStaminaManager : MonoBehaviour
{
    public int maxStamina;
    public float currentStamina;
    public bool canRegen;
    // Start is called before the first frame update
    void Start()
    {
        currentStamina = maxStamina;
    }

    // Update is called once per frame
    void Update()
    {
        if (canRegen && currentStamina<maxStamina)
        {
            staminaRegen();
        }
        
    }

    public void loseStamina(float stamina){
        currentStamina -= stamina;
    }
    public void staminaRegen(){
        currentStamina += 2*Time.deltaTime;
    }
    public void gainStamina(int stamina){
        currentStamina += stamina;
    }
    public void resetStamina(){
        currentStamina = maxStamina;
    }
}
