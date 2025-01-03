using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private InputHandler inputHandler;
    [SerializeField] private bool debugAnalogInputs = true; // Toggle for analog input debug messages
    [SerializeField] private bool debugButtonInputs = true; // Toggle for button input debug messages

    private void OnEnable()
    {
        // Subscribe to InputHandler events
        inputHandler.OnLeftStick += LeftStick;
        inputHandler.OnRightStick += RightStick;
        inputHandler.OnButtonSouth += ButtonSouth;
        inputHandler.OnButtonWest += ButtonWest;
        inputHandler.OnButtonNorth += ButtonNorth;
        inputHandler.OnButtonEast += ButtonEast;
        inputHandler.OnLeftTrigger += LeftTrigger;
        inputHandler.OnRightTrigger += RightTrigger;
        inputHandler.OnLeftShoulder += LeftShoulder;
        inputHandler.OnRightShoulder += RightShoulder;
        inputHandler.OnLeftStickPress += LeftStickPress;
        inputHandler.OnRightStickPress += RightStickPress;
        inputHandler.OnPadLeft += PadLeft;
        inputHandler.OnPadRight += PadRight;
        inputHandler.OnPadUp += PadUp;
        inputHandler.OnPadDown += PadDown;
        inputHandler.OnLeftStickLeft += LeftStickLeft;
        inputHandler.OnLeftStickRight += LeftStickRight;
        inputHandler.OnLeftStickUp += LeftStickUp;
        inputHandler.OnLeftStickDown += LeftStickDown;
        inputHandler.OnButtonStart += ButtonStart;
        inputHandler.OnButtonSelect += ButtonSelect;
    }

    private void OnDisable()
    {
        // Unsubscribe from InputHandler events
        inputHandler.OnLeftStick -= LeftStick;
        inputHandler.OnRightStick -= RightStick;
        inputHandler.OnButtonSouth -= ButtonSouth;
        inputHandler.OnButtonWest -= ButtonWest;
        inputHandler.OnButtonNorth -= ButtonNorth;
        inputHandler.OnButtonEast -= ButtonEast;
        inputHandler.OnLeftTrigger -= LeftTrigger;
        inputHandler.OnRightTrigger -= RightTrigger;
        inputHandler.OnLeftShoulder -= LeftShoulder;
        inputHandler.OnRightShoulder -= RightShoulder;
        inputHandler.OnLeftStickPress -= LeftStickPress;
        inputHandler.OnRightStickPress -= RightStickPress;
        inputHandler.OnPadLeft -= PadLeft;
        inputHandler.OnPadRight -= PadRight;
        inputHandler.OnPadUp -= PadUp;
        inputHandler.OnPadDown -= PadDown;
        inputHandler.OnButtonStart -= ButtonStart;
        inputHandler.OnButtonSelect -= ButtonSelect;
    }

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

    private void ButtonStart()
    {
        DebugLog("ButtonStart pressed!", false);
    }

    private void ButtonSelect()
    {
        DebugLog("ButtonSelect pressed!", false);
    }
}