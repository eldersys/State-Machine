using Library;
using UnityEngine;

/// <summary>
/// The 2 modes of movement. Constraint by the camera & free to move independently of the camera
/// </summary>
public enum MovementMode
{
    Free,
    Constraint
}

/// <summary>
/// The player class, implementing a state machine
/// </summary>
public class Player : MonoBehaviour
{
    #region VARIABLES

    /////////////////////////////////// PUBLIC VARIABLES ///////////////////////////////////
    
    // -------------------------- PlAYER SETTINGS -------------------------- //
    
    ///<summary> The character controller of the player </summary>
    [Space(20.0f)][Header("PLAYER SETTINGS")]
    [Tooltip("The character controller of the player")][SerializeField] public CharacterController m_characterController;
    
    ///<summary> The speed of the player </summary>
    [Space(8.0f)][Tooltip("The speed of the player")][SerializeField] public float m_speed;
    
    ///<summary> The gravity of the player </summary>
    [Space(8.0f)][Range(-5.0f, -90.0f)][Tooltip("The gravity of the player")][SerializeField] public float m_gravity;
    
    ///<summary> The mode of movement of the player </summary>
    [Space(8.0f)][Tooltip("The mode of movement of the player")][SerializeField] public MovementMode m_movementMode;
    
    // -------------------------- INPUT AXIS -------------------------- //
    
    /// <summary>The horizontal & vertical axis of the input</summary>
    [Space(8.0f)][Tooltip("The horizontal & vertical axis of the input")][SerializeField] public Vector2 m_inputAxis;
    
    /// <summary>The horizontal axis</summary>
    [Space(8.0f)][Tooltip("Horizontal axis")] [SerializeField] public string m_horizontal;
    
    /// <summary>The vertical axis</summary>
    [Space(8.0f)][Tooltip("Vertical axis")] [SerializeField] public string m_vertical;
    
    // -------------------------- CAMERA -------------------------- //
    
    /// <summary>The anchor of rotation based on the camera</summary>
    [Space(8.0f)][Tooltip("The anchor of rotation based on the camera")] [SerializeField] public GameObject m_anchor;
    
    /////////////////////////////////// HIDDEN VARIABLES ///////////////////////////////////
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
        Debug.DrawRay(transform.position, transform.forward * 5.0f, Color.red);
        //Update the execution of the current state
        m_stateMachine.Update();
    }
}
