using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class InputHandler : MonoBehaviour
{
    // Define events for input actions
    public event Action<Vector2> OnMove;
    public event Action<Vector2> OnLook;
    public event Action OnAttack;
    public event Action OnJump;
    public event Action OnInteract;
    public event Action OnCrouch;
    public event Action OnSprint;
    public event Action<float> OnAim;
    public event Action<float> OnShoot;
    public event Action OnLeftShoulder;
    public event Action OnRightShoulder;
    public event Action OnLeftStickPress;
    public event Action OnRightStickPress;
    public event Action OnLeft;
    public event Action OnRight;
    public event Action OnUp;
    public event Action OnDown;
    
    public event Action OnPause;

    // Reference to the Input Actions asset
    [SerializeField] private InputActionAsset inputActions;

    // Cached input actions
    private InputAction moveAction;
    private InputAction lookAction;
    
    private InputAction attackAction;
    private InputAction jumpAction;
    private InputAction interactAction;
    private InputAction crouchAction;
    private InputAction sprintAction;
    
    private InputAction aimAction;
    private InputAction shootAction;

    private InputAction leftShoulderAction;
    private InputAction rightShoulderAction;
    private InputAction leftStickPressAction;
    private InputAction rightStickPressAction;
    
    private InputAction leftAction;
    private InputAction rightAction;
    private InputAction upAction;
    private InputAction downAction;
    
    private InputAction pauseAction;

    private void Awake()
    {
        // Get individual input actions
        var playerInputMap = inputActions.FindActionMap("Player"); // Replace "Player" with your action map name
        moveAction = playerInputMap.FindAction("Move");
        lookAction = playerInputMap.FindAction("Look");
        
        attackAction = playerInputMap.FindAction("Attack");
        jumpAction = playerInputMap.FindAction("Jump");
        interactAction = playerInputMap.FindAction("Interact");
        crouchAction = playerInputMap.FindAction("Crouch");
        sprintAction = playerInputMap.FindAction("Sprint");
        
        aimAction = playerInputMap.FindAction("Aim");
        shootAction = playerInputMap.FindAction("Shoot");
        
        leftShoulderAction = playerInputMap.FindAction("LeftShoulder");
        rightShoulderAction = playerInputMap.FindAction("RightShoulder");
        leftStickPressAction = playerInputMap.FindAction("LeftStickPress");
        rightStickPressAction = playerInputMap.FindAction("RightStickPress");
        
        leftAction = playerInputMap.FindAction("Left");
        rightAction = playerInputMap.FindAction("Right");
        upAction = playerInputMap.FindAction("Up");
        downAction = playerInputMap.FindAction("Down");
        
        pauseAction = playerInputMap.FindAction("Pause");
    }

    private void OnEnable()
    {
        // Enable input actions
        moveAction.Enable();
        lookAction.Enable();
        attackAction.Enable();
        jumpAction.Enable();
        interactAction.Enable();
        crouchAction.Enable();
        sprintAction.Enable();
        aimAction.Enable();
        shootAction.Enable();
        leftShoulderAction.Enable();
        rightShoulderAction.Enable();
        leftStickPressAction.Enable();
        rightStickPressAction.Enable();
        leftAction.Enable();
        rightAction.Enable();
        upAction.Enable();
        downAction.Enable();
        pauseAction.Enable();

        // Subscribe to input action callbacks
        moveAction.performed += HandleMove;
        moveAction.canceled += HandleMove; // To detect stop moving
        lookAction.performed += HandleLook;
        lookAction.canceled += HandleLook; // To detect stop looking
        attackAction.performed += HandleAttack;
        jumpAction.performed += HandleJump;
        interactAction.performed += HandleInteract;
        crouchAction.performed += HandleCrouch;
        sprintAction.performed += HandleSprint;
        aimAction.performed += HandleAim;
        shootAction.performed += HandleShoot;
        leftShoulderAction.performed += HandleLeftShoulder;
        rightShoulderAction.performed += HandleRightShoulder;
        leftStickPressAction.performed += HandleLeftStickPress;
        rightStickPressAction.performed += HandleRightStickPress;
        leftAction.performed += HandleLeft;
        rightAction.performed += HandleRight;
        upAction.performed += HandleUp;
        downAction.performed += HandleDown;
        pauseAction.performed += HandlePause;
    }

    private void OnDisable()
    {
        // Unsubscribe to avoid memory leaks
        moveAction.performed -= HandleMove;
        moveAction.canceled -= HandleMove;
        lookAction.performed -= HandleLook;
        lookAction.canceled -= HandleLook;
        attackAction.performed -= HandleAttack;
        jumpAction.performed -= HandleJump;
        interactAction.performed -= HandleInteract;
        crouchAction.performed -= HandleCrouch;
        sprintAction.performed -= HandleSprint;
        aimAction.performed -= HandleAim;
        shootAction.performed -= HandleShoot;
        leftShoulderAction.performed -= HandleLeftShoulder;
        rightShoulderAction.performed -= HandleRightShoulder;
        leftStickPressAction.performed -= HandleLeftStickPress;
        rightStickPressAction.performed -= HandleRightStickPress;
        leftAction.performed -= HandleLeft;
        rightAction.performed -= HandleRight;
        upAction.performed -= HandleUp;
        downAction.performed -= HandleDown;
        pauseAction.performed -= HandlePause;

        // Disable input actions
        moveAction.Disable();
        lookAction.Disable();
        attackAction.Disable();
        jumpAction.Disable();
        interactAction.Disable();
        crouchAction.Disable();
        sprintAction.Disable();
        aimAction.Disable();
        shootAction.Disable();
        leftShoulderAction.Disable();
        rightShoulderAction.Disable();
        leftStickPressAction.Disable();
        rightStickPressAction.Disable();
        leftAction.Disable();
        rightAction.Disable();
        upAction.Disable();
        downAction.Disable();
        pauseAction.Disable();
    }

    // Input event handlers
    private void HandleMove(InputAction.CallbackContext context)
    {
        var input = context.ReadValue<Vector2>();
        OnMove?.Invoke(input);
    }

    private void HandleLook(InputAction.CallbackContext context)
    {
        var input = context.ReadValue<Vector2>();
        OnLook?.Invoke(input);
    }

    private void HandleAttack(InputAction.CallbackContext context)
    {
        OnAttack?.Invoke();
    }

    private void HandleJump(InputAction.CallbackContext context)
    {
        OnJump?.Invoke();
    }

    private void HandleInteract(InputAction.CallbackContext context)
    {
        OnInteract?.Invoke();
    }

    private void HandleCrouch(InputAction.CallbackContext context)
    {
        OnCrouch?.Invoke();
    }

    private void HandleSprint(InputAction.CallbackContext context)
    {
        OnSprint?.Invoke();
    }
    
    private void HandleAim(InputAction.CallbackContext context)
    {
        var input = context.ReadValue<float>();
        OnAim?.Invoke(input);
    }
    
    private void HandleShoot(InputAction.CallbackContext context)
    {
        var input = context.ReadValue<float>();
        OnShoot?.Invoke(input);
    }
    
    private void HandleLeftShoulder(InputAction.CallbackContext context)
    {
        OnLeftShoulder?.Invoke();
    }
    
    private void HandleRightShoulder(InputAction.CallbackContext context)
    {
        OnRightShoulder?.Invoke();
    }
    
    private void HandleLeftStickPress(InputAction.CallbackContext context)
    {
        OnLeftStickPress?.Invoke();
    }
    
    private void HandleRightStickPress(InputAction.CallbackContext context)
    {
        OnRightStickPress?.Invoke();
    }
    
    private void HandleLeft(InputAction.CallbackContext context)
    {
        OnLeft?.Invoke();
    }
    
    private void HandleRight(InputAction.CallbackContext context)
    {
        OnRight?.Invoke();
    }
    
    private void HandleUp(InputAction.CallbackContext context)
    {
        OnUp?.Invoke();
    }
    
    private void HandleDown(InputAction.CallbackContext context)
    {
        OnDown?.Invoke();
    }
    
    private void HandlePause(InputAction.CallbackContext context)
    {
        OnPause?.Invoke();
    }
}
