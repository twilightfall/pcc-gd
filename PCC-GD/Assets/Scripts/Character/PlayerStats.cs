using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [HideInInspector]
    public int PlayerLevel;
    public int MaxHealth = 50;
    public int CurrentHealth = 50;

    public int MaxStamina = 40;
    public int CurrentStamina = 40;

    public int AttackPower = 10;
    public int Defense = 7;

    public int Speed = 6;
    public int JumpSpeed = 6;

    public List<GameObject> Inventory;
}
