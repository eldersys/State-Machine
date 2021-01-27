using UnityEngine;
using Sirenix.OdinInspector;

public class PlayerCamera : MonoBehaviour
{
    #region VARIABLES
    
    /////////////////////////////////// PUBLIC VARIABLES ///////////////////////////////////
    
    // -------------------------- CAMERA SETTINGS -------------------------- //
    
    ///<summary> The character controller of the player </summary>
    [Title("CAMERA SETTINGS")]
    
    [Space(20.0f)][InlineEditor(InlineEditorModes.LargePreview)][TabGroup("Camera")]
    [Tooltip("The target (as Player)")][SerializeField] public Player m_target;

    ///<summary> The rotate sensitivity of the camera </summary>
    [Title("ROTATION SETTINGS")]
    
    [Space(20.0f)][TabGroup("Rotation")]
    [Space(8.0f)][PropertyRange(0.0f, 20.0f)][Tooltip("The rotate sensitivity of the camera ")][SerializeField] public float m_rotateSensitivity;
    
    #endregion
   
    
    // Update is called once per frame
    void LateUpdate()
    {
        CameraBehaviour();
    }
    
    /// <summary>
    /// The camera behaviour. Implementing a zoom and a rotation around target for now
    /// </summary>
    private void CameraBehaviour()
    {
        //CAN IMPLEMENT FOLLOW PART
        //CAN IMPLEMENT ZOOM PART
        // ROTATE AROUND PART
        if (Input.GetMouseButton(0))
        {
            transform.RotateAround(m_target.transform.position,Vector3.up , Input.GetAxis("Mouse X")*m_rotateSensitivity);
        }
    }

}
