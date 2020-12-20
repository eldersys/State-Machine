
using Library;
using UnityEngine;

public class Moving : IState
{
    ////////////// OWNER OF THE STATE //////////////
    
    /// <summary>The owner of this state</summary>
    private Player m_owner;
    
    /// <summary>
    /// Should implement the owner of this state
    /// </summary>
    /// <param name="p_owner"> The owner of the state</param>
    public Moving(Player p_owner) { m_owner = p_owner;}
    
    ////////////// OWNER OF THE STATE //////////////
    
    public void Enter()
    {
        Debug.Log("Entered Moving State");
    }

    public void Execute()
    {
        if (m_owner.m_movementMode == MovementMode.Free)
        {
            Move();
        }
        else if(m_owner.m_movementMode == MovementMode.Constraint)
        {
            MoveConstraint();
        }
        
    }

    public void Exit()
    {
        
    }
    
    /// <summary>
    /// The move method for the free mode of movement
    /// </summary>
    private void Move()
    {
        //Get the input axis in a vector2
        m_owner.m_inputAxis = new Vector2(Input.GetAxis(m_owner.m_horizontal), Input.GetAxis(m_owner.m_vertical));
        
        //If both horizontal & vertical are used simultaneously, limit speed (if allowed), so the total doesn't exceed normal move speed
        float inputModifyFactor = (m_owner.m_inputAxis.x != 0.0f && m_owner.m_inputAxis.y != 0.0f && true) ? .7071f : 1.0f;
        
        //Set the move direction of the player
        Vector3 moveDirection = new Vector3(m_owner.m_inputAxis.x*inputModifyFactor, 0, m_owner.m_inputAxis.y*inputModifyFactor);
        //Change the space to  global space
        moveDirection = m_owner.transform.TransformDirection(moveDirection) * m_owner.m_speed;
        //Set the gravity
        moveDirection.y = m_owner.m_gravity;

        m_owner.m_characterController.Move(moveDirection * Time.deltaTime);
    }
    
    /// <summary>
    /// The move method for the constraint mode of movement
    /// </summary>
    private void MoveConstraint()
    {
        //Set the rotation of the player to the rotation of the anchor of the camera. Since the anchor of the camera is the child of the camera, the rotation are the same.
        Quaternion camRotation = m_owner.m_playerCamera.transform.rotation;
        camRotation.x = m_owner.transform.rotation.x;
        camRotation.z = m_owner.transform.rotation.z;

        m_owner.transform.SetPositionAndRotation(m_owner.transform.position, camRotation);
        
        //Get the input axis in a vector2
        m_owner.m_inputAxis = new Vector2(Input.GetAxis(m_owner.m_horizontal), Input.GetAxis(m_owner.m_vertical));
        
        //If both horizontal & vertical are used simultaneously, limit speed (if allowed), so the total doesn't exceed normal move speed
        float inputModifyFactor = (m_owner.m_inputAxis.x != 0.0f && m_owner.m_inputAxis.y != 0.0f && true) ? .7071f : 1.0f;
        
        //Set the move direction of the player
        Vector3 moveDirection = new Vector3(m_owner.m_inputAxis.x*inputModifyFactor, 0, m_owner.m_inputAxis.y*inputModifyFactor);
        //Change the space to global space
        moveDirection = m_owner.transform.TransformDirection(moveDirection) * m_owner.m_speed;
        //Set the gravoty
        moveDirection.y = m_owner.m_gravity;

        m_owner.m_characterController.Move(moveDirection * Time.deltaTime);
    }
}
