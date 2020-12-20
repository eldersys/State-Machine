using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    #region VARIABLES
    
    /////////////////////////////////// PUBLIC VARIABLES ///////////////////////////////////
    
    // -------------------------- CAMERA SETTINGS -------------------------- //
    
    ///<summary> The character controller of the player </summary>
    [Space(20.0f)][Header("CAMERA SETTINGS")]
    [Tooltip("The target (as Player)")][SerializeField] private Player m_target;

    ///<summary> The rotate sensitivity of the camera </summary>
    [Space(20.0f)][Header("ROTATION PARAMETERS")]
    [Space(8.0f)][Range(0.0f, 20.0f)][Tooltip("The rotate sensitivity of the camera ")][SerializeField] private float m_rotateSensitivity;
    
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
        if (Input.GetMouseButton(0) && Input.GetAxis("Mouse X") !=null)
        {
            transform.RotateAround(m_target.transform.position,Vector3.up , Input.GetAxis("Mouse X")*m_rotateSensitivity);
        }
    }

}
