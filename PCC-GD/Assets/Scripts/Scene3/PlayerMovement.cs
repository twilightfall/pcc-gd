using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private GameObject _playerModel;
    private CharacterController _controller;
    private Vector3 _movementDir;
    private Vector3 _jumpVector;

    private bool _isJumping = false;
    private bool _isGrounded = true;

    [SerializeField]
    private float _movementSpeed;
    private float _tempSpeed;
    [SerializeField]
    private float _jumpForce;
    [SerializeField]
    private float _rotSpeed;

    private int _jumpCount = 0;

    void Awake()
    {
        this._controller = GetComponent<CharacterController>();
    }
    void Update()
    {
        this.HandleMovement();
        this.HandleGravity();
        //this.RaycastGroundCheck();
    }
    
    private bool RaycastGroundCheck()
    {
        RaycastHit hit;
        Ray ray = new Ray(this.transform.position, -Vector3.down);

        Debug.DrawRay(this.transform.position, Vector3.down * 2f, Color.blue);

        if(Physics.Raycast(ray, out hit))
        {
            if(hit.collider.tag == "Ground")
            {
                float height = hit.distance - 2f;
                Debug.Log(height);
                //hit.distance < 0 return !this._isGrounded??????
            }
        }
        return this._isGrounded;
    }
    private void HandleGravity()
    {
        if(!this._isJumping)
        {       
            this._jumpVector.y += Physics.gravity.y * Time.deltaTime;
            this._controller.Move(this._jumpVector * Time.deltaTime);
        }

        if(this._controller.isGrounded)
        {
            this._jumpCount = 0;
        }
    }
    public void OnMove(InputAction.CallbackContext value)
    {
        if(this._controller.isGrounded)
        {
            this._movementDir = new Vector3(value.ReadValue<Vector2>().x, 0f, value.ReadValue<Vector2>().y).normalized;
        }
    }

    private void HandleMovement()
    {
        if(this._movementDir != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(this._movementDir);
            this.transform.rotation = Quaternion.RotateTowards(this.transform.rotation, targetRotation, this._rotSpeed * Time.deltaTime);
        }
        this._controller.Move(this._movementDir * this._movementSpeed * Time.deltaTime);
    }

    public void OnJump(InputAction.CallbackContext value)
    {
        if(value.performed)
        {
            this.HandleJump();
        }
    }

    private void HandleJump()
    {
        if(this._jumpCount != 2)
        {
            this._jumpVector.y = Mathf.Sqrt(1f * -this._jumpForce * Physics.gravity.y);
            this._isGrounded = false;
            this._jumpCount++;
        }
    }

    public void OnDash(InputAction.CallbackContext value)
    {
        float dashSpeed = this._movementSpeed * 2f;
        this._tempSpeed = this._movementSpeed / 2f;

        if(value.performed)
        {
            this._movementSpeed = dashSpeed;
            Debug.Log("Dashing");
            Debug.Log(this._movementSpeed);
        }

        if(value.canceled)
        {
            this._movementSpeed = this._tempSpeed;
            Debug.Log("Default speed");
            Debug.Log(this._movementSpeed);
        }

    }

    public void OnCrouch(InputAction.CallbackContext value)
    {
        if(value.performed)
        {
            this._playerModel.transform.localScale = new Vector3(1f, 0.5f, 1f);
        }

        if(value.canceled)
        {
            this._playerModel.transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }
}
