using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PlayerStamina : MonoBehaviour
{
    public Image staminaFill;
    public float Stamina, MaxStamina;
    public float GlideCost;
    InputAction isGliding;
    private Coroutine playerRecovering;
    public float StaminaRecovery;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isGliding = InputSystem.actions.FindAction("Player/Glide");
    }

    // Update is called once per frame
    void Update()
    {
        if (isGliding.IsPressed())
        {
            Debug.Log("Gliding!");
            Stamina -= GlideCost;
            if (Stamina <= 0)
            {
                Stamina = 0;
                Debug.Log("I'm tired of gliding...");
            }
            staminaFill.fillAmount = Stamina / MaxStamina;

            if(playerRecovering != null)
            {
                StopCoroutine(playerRecovering);
                playerRecovering = StartCoroutine(RechargeStamina());
            }
        }
    }
       
    private IEnumerator RechargeStamina()
    {
        yield return new WaitForSeconds(1f);
        while (Stamina < MaxStamina) 
        {
            Debug.Log("Taking a break");
            Stamina += StaminaRecovery;
            if(Stamina > MaxStamina)
            {
                Stamina = MaxStamina;
            }
            staminaFill.fillAmount = Stamina / MaxStamina;
            yield return new WaitForSeconds(1f);
        }
    }
}
