using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;


[RequireComponent(typeof(CharacterController))]
public class PlayerControllerNew : MonoBehaviour
{
    private Vector2 _input;
    CharacterController _characterController;
    CapsuleCollider _capsuleCollider;
    public InventoryManager inventoryManager;

    public readonly float movementSpeed = 6f;
    public readonly float jumpSpeed = 6f;
    private float _dashSpeed = 1f;

    public int maxNumberJumps = 2;
    private int _numJumps;

    private Vector3 _velocity;
    private float _currentVelocity;
    private bool _isGrounded;
    private bool _isJumped;

    private float angle;



    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        _capsuleCollider = GetComponent<CapsuleCollider>();
    }


    private void Update()
    {
        Vector3 playerFoot = transform.position;
        _isGrounded = Physics.Raycast(origin: playerFoot,
                                      direction: -transform.up, 
                                      maxDistance: _characterController.skinWidth + 0.01f);



        ApplyRotation();
        ApplyGravity();
        ApplyMovement();
    }


    public void Move(InputAction.CallbackContext context)
    {
        _input = context.ReadValue<Vector2>();
        _velocity.x = _input.x * movementSpeed;
        _velocity.z = _input.y * movementSpeed;

    }


    public void Jump(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if (_isGrounded)
            {
                _velocity.y = jumpSpeed;
                _isJumped = true;
            }
            else
            {
                if (_numJumps < maxNumberJumps)
                {
                    _velocity.y = jumpSpeed / ((float)_numJumps + 0.25f);
                }
            }

            _numJumps++;
        }

        
    }


    public void Dash(InputAction.CallbackContext context)
    {
        if (!_isGrounded) return;

        if (context.performed || context.performed)
        {
            _dashSpeed = 1.75f;
        }
        else
        {
            _dashSpeed = 1f;
        }
    }


    public void Crouch(InputAction.CallbackContext context)
    {
        if (!_isGrounded) return;

        if (context.started)
        {
            transform.localScale -= new Vector3(0f, 0.5f, 0f);
        }
        else if (context.canceled)
        {
            transform.localScale += new Vector3(0f, 0.5f, 0f);
        }
    }

    private void ApplyGravity()
    {
        if (!_isGrounded)
        {
            _velocity.y += Physics.gravity.y * Time.deltaTime * 2f;
        }
        else
        {
            if (_isJumped && _velocity.y < 0)
            {
                _velocity.y *= 0f;
                _isJumped = false;
                _numJumps = 0;
            }
        }
    }


    private void ApplyRotation()
    {
        if (_input.sqrMagnitude == 0) return;

        float targetAngle = Mathf.Atan2(_velocity.x, _velocity.z) * Mathf.Rad2Deg;
        angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _currentVelocity, 0.05f);
        transform.rotation = Quaternion.Euler(0f, angle, 0f);
    }


    private void ApplyMovement()
    {
        _characterController.Move(Time.deltaTime * _velocity * _dashSpeed);
    }


    public void NumberPress(InputAction.CallbackContext context)
    {

        if (context.started)
        {
            int numberPressed = int.Parse(context.control.displayName);
            inventoryManager.ChangeSelectSlot(numberPressed - 1);
        }
    }

    public void DropItem(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            GameObject currentObject = inventoryManager.GetCurrentItem().itemPrefab;
            Vector3 dropPosition = new Vector3(transform.position.x, 0f, transform.position.z+1);
            Instantiate(currentObject, dropPosition, Quaternion.identity);
            inventoryManager.RemoveItem();
        }
    }
}
