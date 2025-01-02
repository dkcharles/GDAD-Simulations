using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private InputHandler inputHandler;
    [SerializeField] private bool debugMode = true; // Toggle for debug messages

    private void OnEnable()
    {
        // Subscribe to InputHandler events
        inputHandler.OnMove += Move;
        inputHandler.OnLook += Look;
        inputHandler.OnJump += Jump;
        inputHandler.OnAttack += Attack;
        inputHandler.OnInteract += Interact;
        inputHandler.OnCrouch += Crouch;
        inputHandler.OnSprint += Sprint;
        inputHandler.OnAim += Aim;
        inputHandler.OnShoot += Shoot;
        inputHandler.OnLeftShoulder += LeftShoulder;
        inputHandler.OnRightShoulder += RightShoulder;
        inputHandler.OnLeftStickPress += LeftStickPress;
        inputHandler.OnRightStickPress += RightStickPress;
        inputHandler.OnLeft += Left;
        inputHandler.OnRight += Right;
        inputHandler.OnUp += Up;
        inputHandler.OnDown += Down;
        inputHandler.OnPause += Pause;
    }

    private void OnDisable()
    {
        // Unsubscribe from InputHandler events
        inputHandler.OnMove -= Move;
        inputHandler.OnLook -= Look;
        inputHandler.OnJump -= Jump;
        inputHandler.OnAttack -= Attack;
        inputHandler.OnInteract -= Interact;
        inputHandler.OnCrouch -= Crouch;
        inputHandler.OnSprint -= Sprint;
        inputHandler.OnAim -= Aim;
        inputHandler.OnShoot -= Shoot;
        inputHandler.OnLeftShoulder -= LeftShoulder;
        inputHandler.OnRightShoulder -= RightShoulder;
        inputHandler.OnLeftStickPress -= LeftStickPress;
        inputHandler.OnRightStickPress -= RightStickPress;
        inputHandler.OnLeft -= Left;
        inputHandler.OnRight -= Right;
        inputHandler.OnUp -= Up;
        inputHandler.OnDown -= Down;
        inputHandler.OnPause -= Pause;
    }

    private void DebugLog(string message)
    {
        if (debugMode)
        {
            Debug.Log(message);
        }
    }

    private void Move(Vector2 input)
    {
        DebugLog($"Moving with input: {input}");
    }

    private void Look(Vector2 input)
    {
        DebugLog($"Looking with input: {input}");
    }

    private void Jump()
    {
        DebugLog("Jumping!");
    }

    private void Attack()
    {
        DebugLog("Attacking!");
    }

    private void Interact()
    {
        DebugLog("Interacting!");
    }

    private void Crouch()
    {
        DebugLog("Crouching!");
    }

    private void Sprint()
    {
        DebugLog("Sprinting!");
    }

    private void Aim(float input)
    {
        DebugLog($"Aiming with input: {input}");
    }

    private void Shoot(float input)
    {
        DebugLog($"Shooting with input: {input}");
    }

    private void LeftShoulder()
    {
        DebugLog("Left shoulder action triggered!");
    }

    private void RightShoulder()
    {
        DebugLog("Right shoulder action triggered!");
    }

    private void LeftStickPress()
    {
        DebugLog("Left stick press action triggered!");
    }

    private void RightStickPress()
    {
        DebugLog("Right stick press action triggered!");
    }

    private void Left()
    {
        DebugLog("Previous action triggered!");
    }

    private void Right()
    {
        DebugLog("Next action triggered!");
    }

    private void Up()
    {
        DebugLog("Up action triggered!");
    }

    private void Down()
    {
        DebugLog("Down action triggered!");
    }

    private void Pause()
    {
        DebugLog("Game paused!");
    }
}
