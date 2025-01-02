using UnityEngine;
using System;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private InputHandler inputHandler;

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

    private void Move(Vector2 input)
    {
        Debug.Log($"Moving with input: {input}");
    }

    private void Look(Vector2 input)
    {
        Debug.Log($"Looking with input: {input}");
    }

    private void Jump()
    {
        Debug.Log("Jumping!");
    }

    private void Attack()
    {
        Debug.Log("Attacking!");
    }

    private void Interact()
    {
        Debug.Log("Interacting!");
    }

    private void Crouch()
    {
        Debug.Log("Crouching!");
    }

    private void Sprint()
    {
        Debug.Log("Sprinting!");
    }
    
    private void Aim(float input)
    {
        Debug.Log($"Aiming with input: {input}");
    }
    
    private void Shoot(float input)
    {
        Debug.Log($"Shooting with input: {input}");
    }

    private void LeftShoulder()
    {
        Debug.Log("Left shoulder action triggered!");
    }
    
    private void RightShoulder()
    {
        Debug.Log("Right shoulder action triggered!");
    }
    
    private void LeftStickPress()
    {
        Debug.Log("Left stick press action triggered!");
    }
    
    private void RightStickPress()
    {
        Debug.Log("Right stick press action triggered!");
    }
    
    private void Left()
    {
        Debug.Log("Previous action triggered!");
    }
    
    private void Right()
    {
        Debug.Log("Next action triggered!");
    }
    
    private void Up()
    {
        Debug.Log("Up action triggered!");
    }
    
    private void Down()
    {
        Debug.Log("Down action triggered!");
    }

    private void Pause()
    {
        Debug.Log("Game paused!");
    }
}