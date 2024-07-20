using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [HideInInspector]
    public int PlayerLevel;
    public int MaxHealth = 100;
    public int CurrentHealth = 100;
    public int MaxStamina = 100;
    public int CurrentStamina = 100;

    public static PlayerManager Instance;

    [SerializeField]
    private Transform _itemDropPos;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public Transform PlayerDropPosition()
    {
        return this._itemDropPos;
    }

}
