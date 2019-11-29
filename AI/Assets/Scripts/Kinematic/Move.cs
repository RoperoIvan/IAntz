using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Move : MonoBehaviour {

	public GameObject target;
	public GameObject aim;
	public Slider arrow;
	public float max_mov_speed = 3f;
	public float max_mov_acceleration = 0.1f;
	public float max_rot_speed = 200f; // in degrees / second
	public float max_rot_acceleration = 100f; // in degrees
    Animator m_Animator;
    [Header("-------- Read Only --------")]
	public Vector3 current_velocity = Vector3.zero;
	public float current_rotation_speed = 0.0f; // degrees

    public Vector3[] movement_velocity = new Vector3[6];
    public float[] angular_velocity = new float[6];

    // Methods for behaviours to set / add velocities
    public void SetMovementVelocity (Vector3 velocity, int priority) 
	{
        // movement_velocity[priority] = velocity;
        for (int i = 0; i < movement_velocity.Length; i++)
        {
            movement_velocity[i] = Vector3.zero;
        }
        current_velocity = velocity;
	}

	public void AccelerateMovement (Vector3 acceleration, int priority) 
	{
        movement_velocity[priority] += acceleration;
        
        //current_velocity += acceleration;
    }

	public void SetRotationVelocity (float rotation_speed, int priority) 
	{

        //angular_velocity[priority] = rotation_speed;
        current_rotation_speed = rotation_speed;
	}

	public void AccelerateRotation (float rotation_acceleration, int priority)
    {
        angular_velocity[priority] += rotation_acceleration;
        //current_rotation_speed += rotation_acceleration;
	}
    private void Start()
    {
        m_Animator = gameObject.GetComponent<Animator>();
        m_Animator.SetBool("Movement", true);
    }
    // Update is called once per frame
    void Update () 
	{
		// cap velocity
        
        for (int i = movement_velocity.Length - 1; i >= 0; i--)
        {
            if (movement_velocity[i] != Vector3.zero)
            {
                current_velocity += movement_velocity[i];
                break;
            }
            else
            {
                current_velocity += Vector3.zero;
            }
        }
        for (int i = angular_velocity.Length - 1; i >= 0; i--)
        {
            if (angular_velocity[i] != 0)
            {
                current_rotation_speed += angular_velocity[i];
                break;
            }
            else
            {
                current_rotation_speed += 0;
              
            }
            
        }


        if (current_velocity.magnitude > max_mov_speed)
		{
            current_velocity = current_velocity.normalized * max_mov_speed;
		}

        // cap rotation
        current_rotation_speed = Mathf.Clamp(current_rotation_speed, -max_rot_speed, max_rot_speed);

		// rotate the arrow
		float angle = Mathf.Atan2(current_velocity.x, current_velocity.z);
		aim.transform.rotation = Quaternion.AngleAxis(Mathf.Rad2Deg * angle, Vector3.up);

		// strech it
		arrow.value = current_velocity.magnitude * 4;

		// final rotate
		transform.rotation *= Quaternion.AngleAxis(current_rotation_speed * Time.deltaTime, Vector3.up);

		// finally move
		transform.position += current_velocity * Time.deltaTime;


        for (int i = 0; i < movement_velocity.Length; i++)
        {
            movement_velocity[i] = Vector3.zero;
        }
        for (int i = 0; i < angular_velocity.Length; i++)
        {
            angular_velocity[i] = 0f;
        }
    }
    public Animator GetAnimator()
    {
        return m_Animator;
    }
}
