using Cinemachine;
using Mirror;
using UnityEngine;
using UnityEngine.InputSystem;
[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(CharacterController))]
public class NetworkPlayerController : NetworkBehaviour
{
    [SerializeField] private CharacterController characterController;
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private float movementSpeed = 5.0f;
    [SerializeField] private float rotationSpeed = 16.0f;
    [SerializeField] private CinemachineFreeLook playerCamera;
    private Vector2 _moveInput;
    private Camera _mainCamera;
    private void Start()
    {
        if (!isLocalPlayer)
        {
            playerCamera.gameObject.SetActive(false);
            return;
        }

        playerInput = GetComponent<PlayerInput>();
        playerInput.camera ??= Camera.main;
        _mainCamera = Camera.main;
        characterController = GetComponent<CharacterController>();
    }
    private void Update()
    {
        if (!isLocalPlayer) return;

        MovePlayer();
    }
    private void OnMove(InputValue inputValue) => _moveInput = inputValue.Get<Vector2>();
    private void MovePlayer()
    {
        if (_moveInput == Vector2.zero) return;
        var forward = _mainCamera.transform.forward;
        var right = _mainCamera.transform.right;
        forward.y = 0;  // Ensure the movement is strictly horizontal
        right.y = 0;

        forward.Normalize();
        right.Normalize();

        var moveDirection = forward * _moveInput.y + right * _moveInput.x;
        characterController.Move(moveDirection * movementSpeed * Time.deltaTime);
        var targetRotation = Quaternion.LookRotation(moveDirection);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}
