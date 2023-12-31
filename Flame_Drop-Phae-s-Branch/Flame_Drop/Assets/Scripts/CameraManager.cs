using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private Transform target;
    private float distanceToPlayer;
    private Vector2 _input;

    [SerializeField] private MouseSensitivity mouseSensitivity;
    [SerializeField] private CameraAngle cameraAngle;

    private CameraRotation cameraRotation;

    private void Awake() => distanceToPlayer = Vector3.Distance(transform.position, target.position);
   

    private void Update()
    {
        cameraRotation.Yaw += _input.x * -mouseSensitivity.horizontal * BoolToInt(mouseSensitivity.invertHorizontal)* Time.deltaTime;
        cameraRotation.Pitch += _input.y * mouseSensitivity.vertical * BoolToInt(mouseSensitivity.invertVertical) * Time.deltaTime;
        cameraRotation.Pitch = Mathf.Clamp(cameraRotation.Pitch, cameraAngle.min, cameraAngle.max);
    }

    public void Look(InputAction.CallbackContext context)
    {
        _input += context.ReadValue<Vector2>();
    }

    private void LateUpdate()
    {
        transform.eulerAngles = new Vector3(cameraRotation.Pitch, cameraRotation.Yaw, 0.0f);
        transform.position = target.position - transform.forward * distanceToPlayer;
    }

    private static int BoolToInt(bool b) => b ? 1 : -1;

    [System.Serializable]
    public struct MouseSensitivity
    {
        public float vertical;
        public float horizontal;
        public bool invertVertical;
        public bool invertHorizontal;
    }
}


public struct CameraRotation
{
    public float Pitch;
    public float Yaw;
}

[System.Serializable]
public struct CameraAngle
{
    public float min;
    public float max;
}
