using UnityEngine;

public class InputVisualiser : MonoBehaviour
{
    [SerializeField] public Color inactiveColor;
    [SerializeField] public Color activeColor;
    
    [SerializeField] float stickScale = 5.0f; // Adjust the scale as needed
    
    private Vector3 initialLeftStickPosition;
    private Vector3 initialRightStickPosition;
    
    public SpriteRenderer leftStick;
    public SpriteRenderer rightStick;
    public SpriteRenderer btnNorth;
    public SpriteRenderer btnSouth;
    public SpriteRenderer btnEast;
    public SpriteRenderer btnWest;
    public SpriteRenderer btnLeftShoulder;
    public SpriteRenderer btnRightShoulder;
    public SpriteRenderer btnLeftTrigger;
    public SpriteRenderer btnRightTrigger;
    public SpriteRenderer btnLeftStickPress;
    public SpriteRenderer btnRightStickPress;
    public SpriteRenderer btnPadLeft;
    public SpriteRenderer btnPadRight;
    public SpriteRenderer btnPadUp;
    public SpriteRenderer btnPadDown;
    public SpriteRenderer btnStart;
    public SpriteRenderer btnSelect;

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
        // InputHandler.OnLeftStickLeft += LeftStickLeft;
        // InputHandler.OnLeftStickRight += LeftStickRight;
        // InputHandler.OnLeftStickUp += LeftStickUp;
        // InputHandler.OnLeftStickDown += LeftStickDown;
        // InputHandler.OnRightStickLeft += RightStickLeft;
        // InputHandler.OnRightStickRight += RightStickRight;
        // InputHandler.OnRightStickUp += RightStickUp;
        // InputHandler.OnRightStickDown += RightStickDown;
        InputHandler.OnButtonStart += ButtonStart;
        InputHandler.OnButtonSelect += ButtonSelect;

        // Subscribe to canceled events
        InputHandler.OnLeftStickCanceled += LeftStickCanceled;
        InputHandler.OnRightStickCanceled += RightStickCanceled;
        InputHandler.OnButtonSouthCanceled += ButtonSouthCanceled;
        InputHandler.OnButtonWestCanceled += ButtonWestCanceled;
        InputHandler.OnButtonNorthCanceled += ButtonNorthCanceled;
        InputHandler.OnButtonEastCanceled += ButtonEastCanceled;
        InputHandler.OnLeftTriggerCanceled += LeftTriggerCanceled;
        InputHandler.OnRightTriggerCanceled += RightTriggerCanceled;
        InputHandler.OnLeftShoulderCanceled += LeftShoulderCanceled;
        InputHandler.OnRightShoulderCanceled += RightShoulderCanceled;
        InputHandler.OnLeftStickPressCanceled += LeftStickPressCanceled;
        InputHandler.OnRightStickPressCanceled += RightStickPressCanceled;
        InputHandler.OnPadLeftCanceled += PadLeftCanceled;
        InputHandler.OnPadRightCanceled += PadRightCanceled;
        InputHandler.OnPadUpCanceled += PadUpCanceled;
        InputHandler.OnPadDownCanceled += PadDownCanceled;
        // InputHandler.OnLeftStickLeftCanceled += LeftStickLeftCanceled;
        // InputHandler.OnLeftStickRightCanceled += LeftStickRightCanceled;
        // InputHandler.OnLeftStickUpCanceled += LeftStickUpCanceled;
        // InputHandler.OnLeftStickDownCanceled += LeftStickDownCanceled;
        // InputHandler.OnRightStickLeftCanceled += RightStickLeftCanceled;
        // InputHandler.OnRightStickRightCanceled += RightStickRightCanceled;
        // InputHandler.OnRightStickUpCanceled += RightStickUpCanceled;
        // InputHandler.OnRightStickDownCanceled += RightStickDownCanceled;
        InputHandler.OnButtonStartCanceled += ButtonStartCanceled;
        InputHandler.OnButtonSelectCanceled += ButtonSelectCanceled;
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
        // InputHandler.OnLeftStickLeft -= LeftStickLeft;
        // InputHandler.OnLeftStickRight -= LeftStickRight;
        // InputHandler.OnLeftStickUp -= LeftStickUp;
        // InputHandler.OnLeftStickDown -= LeftStickDown;
        // InputHandler.OnRightStickLeft -= RightStickLeft;
        // InputHandler.OnRightStickRight -= RightStickRight;
        // InputHandler.OnRightStickUp -= RightStickUp;
        // InputHandler.OnRightStickDown -= RightStickDown;
        InputHandler.OnButtonStart -= ButtonStart;
        InputHandler.OnButtonSelect -= ButtonSelect;

        // Unsubscribe from canceled events
        InputHandler.OnLeftStickCanceled -= LeftStickCanceled;
        InputHandler.OnRightStickCanceled -= RightStickCanceled;
        InputHandler.OnButtonSouthCanceled -= ButtonSouthCanceled;
        InputHandler.OnButtonWestCanceled -= ButtonWestCanceled;
        InputHandler.OnButtonNorthCanceled -= ButtonNorthCanceled;
        InputHandler.OnButtonEastCanceled -= ButtonEastCanceled;
        InputHandler.OnLeftTriggerCanceled -= LeftTriggerCanceled;
        InputHandler.OnRightTriggerCanceled -= RightTriggerCanceled;
        InputHandler.OnLeftShoulderCanceled -= LeftShoulderCanceled;
        InputHandler.OnRightShoulderCanceled -= RightShoulderCanceled;
        InputHandler.OnLeftStickPressCanceled -= LeftStickPressCanceled;
        InputHandler.OnRightStickPressCanceled -= RightStickPressCanceled;
        InputHandler.OnPadLeftCanceled -= PadLeftCanceled;
        InputHandler.OnPadRightCanceled -= PadRightCanceled;
        InputHandler.OnPadUpCanceled -= PadUpCanceled;
        InputHandler.OnPadDownCanceled -= PadDownCanceled;
        // InputHandler.OnLeftStickLeftCanceled -= LeftStickLeftCanceled;
        // InputHandler.OnLeftStickRightCanceled -= LeftStickRightCanceled;
        // InputHandler.OnLeftStickUpCanceled -= LeftStickUpCanceled;
        // InputHandler.OnLeftStickDownCanceled -= LeftStickDownCanceled;
        // InputHandler.OnRightStickLeftCanceled -= RightStickLeftCanceled;
        // InputHandler.OnRightStickRightCanceled -= RightStickRightCanceled;
        // InputHandler.OnRightStickUpCanceled -= RightStickUpCanceled;
        // InputHandler.OnRightStickDownCanceled -= RightStickDownCanceled;
        InputHandler.OnButtonStartCanceled -= ButtonStartCanceled;
        InputHandler.OnButtonSelectCanceled -= ButtonSelectCanceled;
    }
    #endregion
    
    void Awake()
    {
        SetGraphics();
        
        initialLeftStickPosition = leftStick.transform.localPosition;
        initialRightStickPosition = rightStick.transform.localPosition;
    }
    
    private void SetGraphics()
    {
        // Set the color of the sprite to the inactive color
        leftStick.color = inactiveColor;
        rightStick.color = inactiveColor;
        btnNorth.color = inactiveColor;
        btnSouth.color = inactiveColor;
        btnEast.color = inactiveColor;
        btnWest.color = inactiveColor;
        btnLeftShoulder.color = inactiveColor;
        btnRightShoulder.color = inactiveColor;
        btnLeftTrigger.color = inactiveColor;
        btnRightTrigger.color = inactiveColor;
        btnLeftStickPress.color = inactiveColor;
        btnRightStickPress.color = inactiveColor;
        btnPadLeft.color = inactiveColor;
        btnPadRight.color = inactiveColor;
        btnPadUp.color = inactiveColor;
        btnPadDown.color = inactiveColor;
        btnStart.color = inactiveColor;
        btnSelect.color = inactiveColor;
        
        //set the pad buttons inactive
        btnPadLeft.gameObject.SetActive(false);
        btnPadRight.gameObject.SetActive(false);
        btnPadUp.gameObject.SetActive(false);
        btnPadDown.gameObject.SetActive(false);
    }
    
    // input events
    private void LeftStick(Vector2 input)
    {
        leftStick.color = activeColor;
        
        Vector3 newPosition = initialLeftStickPosition + new Vector3(input.x, input.y, 0) * stickScale;
        leftStick.transform.localPosition = newPosition;
    }

    private void RightStick(Vector2 input)
    {
        rightStick.color = activeColor;
        
        Vector3 newPosition = initialRightStickPosition + new Vector3(input.x, input.y, 0) * stickScale;
        rightStick.transform.localPosition = newPosition;
    }

    private void ButtonSouth()
    {
        btnSouth.color = activeColor;
    }

    private void ButtonWest()
    {
        btnWest.color = activeColor;
    }

    private void ButtonNorth()
    {
        btnNorth.color = activeColor;
    }

    private void ButtonEast()
    {
        btnEast.color = activeColor;
    }

    private void LeftTrigger(float input)
    {
        Color color = activeColor;
        color.a = Mathf.Clamp01(input); // Set the alpha based on the input, clamped between 0 and 1
        btnLeftTrigger.color = color;
    }

    private void RightTrigger(float input)
    {
        Color color = activeColor;
        color.a = Mathf.Clamp01(input); // Set the alpha based on the input, clamped between 0 and 1
        btnRightTrigger.color = color;
    }

    private void LeftShoulder()
    {
        btnLeftShoulder.color = activeColor;
    }

    private void RightShoulder()
    {
        btnRightShoulder.color = activeColor;
    }

    private void LeftStickPress()
    {
        btnLeftStickPress.color = activeColor;
    }

    private void RightStickPress()
    {
        btnRightStickPress.color = activeColor;
    }

    private void PadLeft()
    {
        btnPadLeft.gameObject.SetActive(true);
        btnPadLeft.color = activeColor;
    }

    private void PadRight()
    {
        btnPadRight.gameObject.SetActive(true);
        btnPadRight.color = activeColor;
    }

    private void PadUp()
    {
        btnPadUp.gameObject.SetActive(true);
        btnPadUp.color = activeColor;
    }

    private void PadDown()
    {
        btnPadDown.gameObject.SetActive(true);
        btnPadDown.color = activeColor;
    }

    // private void LeftStickLeft()
    // {
    //     leftStick.color = activeColor;
    // }
    //
    // private void LeftStickRight()
    // {
    //     leftStick.color = activeColor;
    // }
    //
    // private void LeftStickUp()
    // {
    //     leftStick.color = activeColor;
    // }
    //
    // private void LeftStickDown()
    // {
    //     leftStick.color = activeColor;
    // }
    //
    // private void RightStickLeft()
    // {
    //     rightStick.color = activeColor;
    // }
    //
    // private void RightStickRight()
    // {
    //     rightStick.color = activeColor;
    // }
    //
    // private void RightStickUp()
    // {
    //     rightStick.color = activeColor;
    // }
    //
    // private void RightStickDown()
    // {
    //     rightStick.color = activeColor;
    // }

    private void ButtonStart()
    {
        btnStart.color = activeColor;
    }

    private void ButtonSelect()
    {
        btnSelect.color = activeColor;
    }
    
    //canceled events
    private void LeftStickCanceled()
    {
        leftStick.color = inactiveColor;
        leftStick.transform.localPosition = initialLeftStickPosition;
    }
    
    private void RightStickCanceled()
    {
        rightStick.color = inactiveColor;
        rightStick.transform.localPosition = initialRightStickPosition;
    }
    
    private void ButtonSouthCanceled()
    {
        btnSouth.color = inactiveColor;
    }
    
    private void ButtonWestCanceled()
    {   
        btnWest.color = inactiveColor;
    }
    
    private void ButtonNorthCanceled()
    {
        btnNorth.color = inactiveColor;
    }
    
    private void ButtonEastCanceled()
    {   
        btnEast.color = inactiveColor;
    }
    
    private void LeftTriggerCanceled()
    {
        btnLeftTrigger.color = inactiveColor;
    }
    
    private void RightTriggerCanceled()
    {
        btnRightTrigger.color = inactiveColor;
    }
    
    private void LeftShoulderCanceled()
    {
        btnLeftShoulder.color = inactiveColor;
    }
    
    private void RightShoulderCanceled()
    {
        btnRightShoulder.color = inactiveColor;
    }
    
    private void LeftStickPressCanceled()
    {
        btnLeftStickPress.color = inactiveColor;
    }
    
    private void RightStickPressCanceled()
    {   
        btnRightStickPress.color = inactiveColor;
    }
    
    private void PadLeftCanceled()
    {
        btnPadLeft.color = inactiveColor;
        btnPadLeft.gameObject.SetActive(false);
    }
    
    private void PadRightCanceled()
    {
        btnPadRight.color = inactiveColor;
        btnPadRight.gameObject.SetActive(false);
    }
    
    private void PadUpCanceled()
    {
        btnPadUp.color = inactiveColor;
        btnPadUp.gameObject.SetActive(false);
    }
    
    private void PadDownCanceled()
    {
        btnPadDown.color = inactiveColor;
        btnPadDown.gameObject.SetActive(false);
    }
    
    // private void LeftStickLeftCanceled()
    // {
    //     leftStick.color = inactiveColor;
    // }
    //
    // private void LeftStickRightCanceled()
    // {
    //     leftStick.color = inactiveColor;
    // }
    //
    // private void LeftStickUpCanceled()
    // {
    //     leftStick.color = inactiveColor;
    // }
    //
    // private void LeftStickDownCanceled()
    // {
    //     leftStick.color = inactiveColor;
    // }
    //
    // private void RightStickLeftCanceled()
    // {
    //     rightStick.color = inactiveColor;
    // }
    //
    // private void RightStickRightCanceled()
    // {
    //     rightStick.color = inactiveColor;
    // }
    //
    // private void RightStickUpCanceled()
    // {
    //     rightStick.color = inactiveColor;
    // }
    //
    // private void RightStickDownCanceled()
    // {
    //     rightStick.color = inactiveColor;
    // }
    
    private void ButtonStartCanceled()
    {
        btnStart.color = inactiveColor;
    }
    
    private void ButtonSelectCanceled()
    {
        btnSelect.color = inactiveColor;
    }
    
}