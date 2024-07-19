using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.PlayerLoop;
using UnityEngine.Rendering.Universal;

public class PlayerManager : MonoBehaviour
{
    public GameObject player;
    [HideInInspector]
    public int PlayerLevel;
    public int MaxHealth = 100;
    public int CurrentHealth = 100;
    public int MaxStamina = 100;
    public int CurrentStamina = 100;
    [SerializeField]
    private float Speed;
    private int index = -1;

    public List<GameObject> Inventory;

    public static PlayerManager instance;
    public bool get_item = false;
    private bool speed_up = false;
    private bool init_speed = true;
    private float accrutime = 0.0f;

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void Cycle(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (Inventory.Count == 0)
            {
                print("No Items");
            }
            else
            {
                index = index + 1;
                if (index == Inventory.Count)
                {
                    index = 0;
                }
                print(Inventory[index]);
            }
        }
    }

    public void Use(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (index == -1)
            {
                print("Select Item First");
            }
            else
            {
                if (Inventory.Count == 0)
                {
                    print("No Items");
                }
                else
                {
                    Destroy(Inventory[index]);
                    Inventory.RemoveAt(index);
                    index = index - 1;
                    if (Inventory.Count == 0)
                    {
                        print("No Items");
                    }
                }
            }
        }
    }
    public void Drop(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (index == -1)
            {
                print("Select Item First");
            }
            else
            {
                if (Inventory.Count == 0)
                {
                    print("No Items");
                }
                else
                {
                    var drop_loc = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z + 2.0f);
                    Inventory[index].GetComponent<Renderer>().enabled = true;
                    Inventory[index].GetComponent<Collider>().enabled = true;
                    Inventory[index].transform.position = drop_loc;
                    // Instantiate(Inventory[index], drop_loc, Quaternion.identity);
                    // Destroy(Inventory[index]);
                    Inventory.RemoveAt(index);
                    index = index - 1;
                    if (Inventory.Count == 0)
                    {
                        print("No Items");
                    }
                }
            }
        }
    }
    public void Pickup(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            get_item = true;
        }
        if (context.canceled)
        {
            get_item = false;
        }
    }
    public void SpeedUp()
    {
        speed_up = true;
    }
    void Start()
    {
        Speed = player.GetComponent<InputMangerCharacterMovement>().movementSpeed;
    }
    void Update()
    {
        if (speed_up == true)
        {
            if (init_speed == true)
            {
                player.GetComponent<InputMangerCharacterMovement>().movementSpeed *=4;
                accrutime = 0.0f;
                init_speed = false;
                Speed = player.GetComponent<InputMangerCharacterMovement>().movementSpeed;
            }
            if (accrutime < 5.0f)
            {
                accrutime += Time.deltaTime;
            }
            else
            {
                player.GetComponent<InputMangerCharacterMovement>().movementSpeed /=4;
                speed_up = false;
                Speed = player.GetComponent<InputMangerCharacterMovement>().movementSpeed;
            }
        }
    }
}
