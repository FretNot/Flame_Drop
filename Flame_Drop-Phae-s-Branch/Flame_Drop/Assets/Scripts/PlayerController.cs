using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    //Variables: Movement
    private Vector2 _input;
    private CharacterController _characterController;
    private Vector3 _direction;

    //[SerializeField] private float smoothTime = 0.05f;
    //private float _currentVelocity;

    [SerializeField] private float speed;

    [SerializeField] private float rotationSpeed = .00005f;

    private Camera mainCamera;

    private float _gravity = -9.81f;

    [SerializeField] private float gravityMultiplier = 3.0f;

    private float _velocity;

    [SerializeField] private float jumpPower;



    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        mainCamera = Camera.main;
    }
    public void Move(InputAction.CallbackContext context)
    {
        _input = context.ReadValue<Vector2>();
        _direction = new Vector3(_input.x, 0.0f, _input.y);
        Debug.Log(_input);
    }

    private void Update()
    {
        RotateThatShit();
        DostThouGravity();
        MoveThatShit();
    }

    private void RotateThatShit()
    {
        if (_input.sqrMagnitude == 0) return;

        _direction = Quaternion.Euler(0.0f, mainCamera.transform.eulerAngles.y, 0.0f) * new Vector3(_input.x, 0.0f, _input.y);
        var targetRotation = Quaternion.LookRotation(_direction, Vector3.up);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        //if (_input.sqrMagnitude == 0) return;
        //var targetAngle = Mathf.Atan2(_direction.x, _direction.y) * Mathf.Rad2Deg;
        //var anglefloat = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _currentVelocity, smoothTime);
        //transform.rotation = Quaternion.Euler(0.0f, anglefloat, 0.0f);


       // _direction = Quaternion.Euler(0.0f, mainCamera.transform.eulerAngles.y, 0.0f) * new Vector3(_input.x, 0.0f, _input.y);
       // var targetRotation = Quaternion.LookRotation(_direction, Vector3.up);

        //transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    private void MoveThatShit()
    {
        _characterController.Move(_direction * speed * Time.deltaTime);
    }

    private void DostThouGravity()
    {
        if (_isGrounded() && _velocity < 0.0f)
        {
            _velocity = -1.0f;
        }
        else
        {
            _velocity += _gravity * gravityMultiplier * Time.deltaTime;
        }
        _direction.y = _velocity;
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (!context.started) return;
        if (!_isGrounded()) return;

        _velocity += jumpPower;
    }

    private bool _isGrounded() => _characterController.isGrounded;

    public void Fire_Hopping(InputAction.CallbackContext context)
    {
        _input = context.ReadValue<Vector2>();
        Debug.Log("Player Started Hopping");
    }
}
