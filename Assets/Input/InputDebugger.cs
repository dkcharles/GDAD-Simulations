using UnityEngine;

public class InputDebugger : MonoBehaviour
{
    [SerializeField] private bool debugAnalogInputs = true; // Toggle for analog input debug messages
    [SerializeField] private bool debugButtonInputs = true; // Toggle for button input debug messages

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
    
    private void DebugLog(string message, bool isAnalog)
    {
        if ((isAnalog && debugAnalogInputs) || (!isAnalog && debugButtonInputs))
        {
            Debug.Log(message);
        }
    }

    private void LeftStick(Vector2 input)
    {
        DebugLog($"LeftStick with input: {input}", true);
    }

    private void RightStick(Vector2 input)
    {
        DebugLog($"RightStick with input: {input}", true);
    }

    private void ButtonSouth()
    {
        DebugLog("ButtonSouth pressed!", false);
    }

    private void ButtonWest()
    {
        DebugLog("ButtonWest pressed!", false);
    }

    private void ButtonNorth()
    {
        DebugLog("ButtonNorth pressed!", false);
    }

    private void ButtonEast()
    {
        DebugLog("ButtonEast pressed!", false);
    }

    private void LeftTrigger(float input)
    {
        DebugLog($"LeftTrigger with input: {input}", true);
    }

    private void RightTrigger(float input)
    {
        DebugLog($"RightTrigger with input: {input}", true);
    }

    private void LeftShoulder()
    {
        DebugLog("LeftShoulder pressed!", false);
    }

    private void RightShoulder()
    {
        DebugLog("RightShoulder pressed!", false);
    }

    private void LeftStickPress()
    {
        DebugLog("LeftStickPress pressed!", false);
    }

    private void RightStickPress()
    {
        DebugLog("RightStickPress pressed!", false);
    }

    private void PadLeft()
    {
        DebugLog("PadLeft pressed!", false);
    }

    private void PadRight()
    {
        DebugLog("PadRight pressed!", false);
    }

    private void PadUp()
    {
        DebugLog("PadUp pressed!", false);
    }

    private void PadDown()
    {
        DebugLog("PadDown pressed!", false);
    }

    private void LeftStickLeft()
    {
        DebugLog("LeftStickLeft pressed!", false);
    }

    private void LeftStickRight()
    {
        DebugLog("LeftStickRight pressed!", false);
    }

    private void LeftStickUp()
    {
        DebugLog("LeftStickUp pressed!", false);
    }

    private void LeftStickDown()
    {
        DebugLog("LeftStickDown pressed!", false);
    }
    
    private void RightStickLeft()
    {
        DebugLog("RightStickLeft pressed!", false);
    }
    
    private void RightStickRight()
    {
        DebugLog("RightStickRight pressed!", false);
    }
    
    private void RightStickUp()
    {
        DebugLog("RightStickUp pressed!", false);
    }
    
    private void RightStickDown()
    {
        DebugLog("RightStickDown pressed!", false);
    }

    private void ButtonStart()
    {
        DebugLog("ButtonStart pressed!", false);
    }

    private void ButtonSelect()
    {
        DebugLog("ButtonSelect pressed!", false);
    }
}