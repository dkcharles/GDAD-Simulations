using UnityEngine;

public class InputVisualiser : MonoBehaviour
{
    public Color inactiveColor = Color.white;
    public Color activeColor = Color.green;
    
    public SpriteRenderer btnSouth;
    

    #region InputHandler Events Subscription
    private void OnEnable()
    {
        // Subscribe to InputHandler events
        InputHandler.OnLeftStick += LeftStick;
        InputHandler.OnRightStick += RightStick;
        InputHandler.OnButtonSouth += ButtonSouth;
        InputHandler.OnButtonWest += ButtonWest;
        InputHandler.OnButtonNorth += ButtonNorth;
        InputHandler.OnButtonEast += ButtonEast;
        InputHandler.OnLeftTrigger += LeftTrigger;
        InputHandler.OnRightTrigger += RightTrigger;
        InputHandler.OnLeftShoulder += LeftShoulder;
        InputHandler.OnRightShoulder += RightShoulder;
        InputHandler.OnLeftStickPress += LeftStickPress;
        InputHandler.OnRightStickPress += RightStickPress;
        InputHandler.OnPadLeft += PadLeft;
        InputHandler.OnPadRight += PadRight;
        InputHandler.OnPadUp += PadUp;
        InputHandler.OnPadDown += PadDown;
        InputHandler.OnLeftStickLeft += LeftStickLeft;
        InputHandler.OnLeftStickRight += LeftStickRight;
        InputHandler.OnLeftStickUp += LeftStickUp;
        InputHandler.OnLeftStickDown += LeftStickDown;
        InputHandler.OnRightStickLeft += RightStickLeft;
        InputHandler.OnRightStickRight += RightStickRight;
        InputHandler.OnRightStickUp += RightStickUp;
        InputHandler.OnRightStickDown += RightStickDown;
        InputHandler.OnButtonStart += ButtonStart;
        InputHandler.OnButtonSelect += ButtonSelect;
    }

    private void OnDisable()
    {
        // Unsubscribe from InputHandler events
        InputHandler.OnLeftStick -= LeftStick;
        InputHandler.OnRightStick -= RightStick;
        InputHandler.OnButtonSouth -= ButtonSouth;
        InputHandler.OnButtonWest -= ButtonWest;
        InputHandler.OnButtonNorth -= ButtonNorth;
        InputHandler.OnButtonEast -= ButtonEast;
        InputHandler.OnLeftTrigger -= LeftTrigger;
        InputHandler.OnRightTrigger -= RightTrigger;
        InputHandler.OnLeftShoulder -= LeftShoulder;
        InputHandler.OnRightShoulder -= RightShoulder;
        InputHandler.OnLeftStickPress -= LeftStickPress;
        InputHandler.OnRightStickPress -= RightStickPress;
        InputHandler.OnPadLeft -= PadLeft;
        InputHandler.OnPadRight -= PadRight;
        InputHandler.OnPadUp -= PadUp;
        InputHandler.OnPadDown -= PadDown;
        InputHandler.OnLeftStickLeft -= LeftStickLeft;
        InputHandler.OnLeftStickRight -= LeftStickRight;
        InputHandler.OnLeftStickUp -= LeftStickUp;
        InputHandler.OnLeftStickDown -= LeftStickDown;
        InputHandler.OnRightStickLeft -= RightStickLeft;
        InputHandler.OnRightStickRight -= RightStickRight;
        InputHandler.OnRightStickUp -= RightStickUp;
        InputHandler.OnRightStickDown -= RightStickDown;
        InputHandler.OnButtonStart -= ButtonStart;
        InputHandler.OnButtonSelect -= ButtonSelect;
    }

    #endregion
    
    void Awake()
    {
        // Set the color of the sprite to the inactive color
        btnSouth.color = inactiveColor;
        
        btnSouth.gameObject.SetActive(false);
    }
    
    private void LeftStick(Vector2 input)
    {
        
    }

    private void RightStick(Vector2 input)
    {

    }

    private void ButtonSouth()
    {
        // Set the color of the sprite to the active color
        btnSouth.color = activeColor;
        btnSouth.gameObject.SetActive(true);
    }

    private void ButtonWest()
    {

    }

    private void ButtonNorth()
    {

    }

    private void ButtonEast()
    {

    }

    private void LeftTrigger(float input)
    {

    }

    private void RightTrigger(float input)
    {

    }

    private void LeftShoulder()
    {

    }

    private void RightShoulder()
    {

    }

    private void LeftStickPress()
    {

    }

    private void RightStickPress()
    {

    }

    private void PadLeft()
    {

    }

    private void PadRight()
    {

    }

    private void PadUp()
    {

    }

    private void PadDown()
    {

    }

    private void LeftStickLeft()
    {

    }

    private void LeftStickRight()
    {
 
    }

    private void LeftStickUp()
    {

    }

    private void LeftStickDown()
    {

    }
    
    private void RightStickLeft()
    {

    }
    
    private void RightStickRight()
    {

    }
    
    private void RightStickUp()
    {

    }
    
    private void RightStickDown()
    {

    }

    private void ButtonStart()
    {

    }

    private void ButtonSelect()
    {

    }
}