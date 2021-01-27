using Library;
using UnityEngine;
using Sirenix.OdinInspector;
/// <summary>
/// The 2 modes of movement. Constraint by the camera & free to move independently of the camera
/// </summary>
[EnumPaging]
public enum MovementMode
{
    Free,
    Constraint
}

/// <summary>
/// The player class, implementing a state machine
/// </summary>
[RequireComponent(typeof(CharacterController))]
public class Player : MonoBehaviour
{
    #region VARIABLES

    /////////////////////////////////// PUBLIC VARIABLES ///////////////////////////////////
    
    // -------------------------- PlAYER SETTINGS -------------------------- //
    
    ///<summary> The character controller of the player </summary>
    [Title("PLAYER SETTINGS")]
    
    [TabGroup("Player")][InlineEditor(InlineEditorModes.LargePreview)]
    [Space(20.0f)]
    [PropertyTooltip("The character controller of the player")][SerializeField] public CharacterController m_characterController;
    
    ///<summary> The speed of the player </summary>
    [TabGroup("Player")][PropertyRange(0, 100)]
    [Space(8.0f)][Tooltip("The speed of the player")][SerializeField] public int m_speed;
    
    ///<summary> The gravity of the player </summary>
    [TabGroup("Player")][PropertyRange(-5.0f, -90.0f)]
    [Space(8.0f)][Tooltip("The gravity of the player")][SerializeField] public float m_gravity;
    
    ///<summary> The mode of movement of the player </summary>
    [TabGroup("Player")]
    [Space(8.0f)][Tooltip("The mode of movement of the player")][SerializeField] public MovementMode m_movementMode;
    
    // -------------------------- INPUT AXIS -------------------------- //
    
    /// <summary>The horizontal & vertical axis of the input</summary>
    
    [Title("INPUT SETTINGS")]
    
    [TabGroup("Inputs")][MinMaxSlider(-1, 1)]
    [Space(8.0f)][Tooltip("The horizontal & vertical axis of the input")][SerializeField] public Vector2 m_inputAxis;
    
    /// <summary>The horizontal axis</summary>
    [TabGroup("Inputs")]
    [Space(8.0f)][Tooltip("Horizontal axis")] [SerializeField] public string m_horizontal;
    
    /// <summary>The vertical axis</summary>
    [TabGroup("Inputs")]
    [Space(8.0f)][Tooltip("Vertical axis")] [SerializeField] public string m_vertical;
    
    // -------------------------- CAMERA -------------------------- //
    
    /// <summary>The player camera</summary>
    
    [Title("CAMERA SETTINGS")]
    
    [TabGroup("Camera")]
    [Space(8.0f)][Tooltip("The player camera")] [SerializeField] public Camera m_playerCamera;
    
    /////////////////////////////////// HIDDEN VARIABLES ///////////////////////////////////
    [ShowInInspector]
    private StateMachine m_stateMachine = new StateMachine();
    
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        //Set a new state machine of type Moving
        m_stateMachine.ChangeState(new Moving(this));
    }

    // Update is called once per frame
    void Update()
    {
        //Update the execution of the current state
        m_stateMachine.Update();
    }
}
