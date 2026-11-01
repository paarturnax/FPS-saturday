using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform cameraHolder;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float mouseSensitivity = 0.1f;
    [SerializeField] private float gravity = -20f;

    private CharacterController characterController;
    private float verticalRotation;
    private float verticalVelocity;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        Vector2 mouseDelta = Mouse.current.delta.ReadValue() * mouseSensitivity;
        transform.Rotate(Vector2.up *  mouseDelta.x);

        verticalRotation -= mouseDelta.y;
        verticalRotation = Mathf.Clamp(verticalRotation, -90f, 90f);

        cameraHolder.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);

        float horizontal = 0f;
        float vertical = 0f;

        if (Keyboard.current.aKey.isPressed) horizontal -= 1f;
        if (Keyboard.current.dKey.isPressed) horizontal += 1f;
        if (Keyboard.current.sKey.isPressed) vertical -= 1f;
        if (Keyboard.current.wKey.isPressed) vertical += 1f;

        Vector3 movement = transform.right * horizontal + transform.forward * vertical;
        movement = Vector3.ClampMagnitude(movement, 1f) * moveSpeed;

    }
}
