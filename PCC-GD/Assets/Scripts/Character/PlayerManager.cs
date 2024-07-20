using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [HideInInspector]
    public int PlayerLevel;
    public int MaxHealth = 50;
    public int CurrentHealth = 30;

    public int MaxStamina = 40;
    public int CurrentStamina = 20;

    public int AttackPower = 10;
    public int Defense = 7;

    public int Speed = 6;
    public int JumpSpeed = 6;

    public InventoryManager inventoryManager;

    public static PlayerManager Instance {  get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }


    public void ChangeHealth(int amount)
    {
        int newHealth = CurrentHealth + amount;
        if (newHealth > MaxHealth) CurrentHealth = MaxHealth;
        else if (newHealth <= 0) CurrentHealth = 0;
        else CurrentHealth = newHealth;
    }

    public void ChangeStamina(int amount)
    {
        int newStamina = CurrentStamina + amount;
        if (newStamina > MaxStamina) CurrentStamina = MaxStamina;
        else if (newStamina <= 0) CurrentStamina = 0;
        else CurrentStamina = newStamina;
    }


    public void ResetStats()
    {
        CurrentHealth = MaxHealth;
        CurrentStamina = MaxStamina;
    }

}
