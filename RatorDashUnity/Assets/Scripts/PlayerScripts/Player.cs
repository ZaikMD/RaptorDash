using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{
	public CharacterController m_Controller;
	public GameObject m_Laser;
	public GameObject m_FirePoint;
	InputManager m_InputManager;

	float m_MoveSpeed = 4.25f;
	float m_JumpSpeed = 6.0f;
	float m_Gravity = 10.0f;
	float m_FallSpeed = 9.0f;
	float m_AirMoveSpeed;
	float m_MirrorXScale = -0.75f;
	float m_Scale = 0.75f;

	float m_FireTime = 0.25f;
	float m_ConstFireTime;
	float m_LaserDirectionX;
	bool m_left = false;
	bool m_Right = true;
	bool m_HasFired = false;

	Vector3 m_Direction;

	Camera m_Camera;
	
	void Start () 
	{
		m_AirMoveSpeed = m_MoveSpeed / 1.5f;
		m_Camera = Camera.main;
		gameObject.AddComponent ("InputManager");
		m_InputManager = gameObject.GetComponent(typeof(InputManager)) as InputManager;
		m_ConstFireTime = m_FireTime;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(m_InputManager.leftInput())
		{
			m_left = true;
			m_Right = false;

			transform.localScale = new Vector3(m_MirrorXScale,m_Scale,m_Scale);
		}

		if(m_InputManager.rightInput())
		{
			m_Right = true;
			m_left = false;

			transform.localScale = new Vector3(m_Scale,m_Scale,m_Scale);
		}

		if(m_Camera != null) //Sets the position of the camera to the players x and y+1  co-ords
		{
			m_Camera.transform.position = new Vector3 (transform.position.x,transform.position.y + 1.0f, m_Camera.transform.position.z);
		}

		if(m_Controller.isGrounded) // If the player is on the ground
		{

			m_Direction = new Vector3 (Input.GetAxis ("Horizontal"), (-m_Gravity * Time.deltaTime), 0.0f);
			//Set the direction from the input axis
			m_Direction = transform.TransformDirection (m_Direction);
			m_Direction *= m_MoveSpeed; //multiply the direction by the move speed
		}

		else
		{
			m_Direction.y -= m_FallSpeed * Time.deltaTime; //If the player is not grounded then they are falling
		}

		if(m_InputManager.jumpInput())
		{
			if(m_Controller.isGrounded)
			{
				m_Direction.y = m_JumpSpeed; // if space is pressed then the player is jumping
			}
		}


		if(!m_Controller.isGrounded) //movement for when the player is in the air. Same as ground movement but slower x speed.
		{
			m_Direction = new Vector3(Input.GetAxis("Horizontal"), m_Direction.y, 0.0f);
			m_Direction = transform.TransformDirection (m_Direction);
			m_Direction.x *= m_AirMoveSpeed;
		}
	
		m_Controller.Move (m_Direction * Time.deltaTime); //Move the player

		//Firing Code
		if(m_InputManager.fireInput()) //If the fire button is pressed
		{
			if(!m_HasFired) //If hasFired is false
			{
				GameObject laser; //Create laser gameobj
				laser = (GameObject)Instantiate(m_Laser, m_FirePoint.transform.position, m_Laser.transform.rotation); //Instantiate
				Laser laserScript; //Get the laser script from the gameobj
				laserScript = laser.GetComponent(typeof (Laser)) as Laser;

				if(m_left)
				{
					m_LaserDirectionX = -1;
				}

				else
				{
					m_LaserDirectionX = 1;
				}
				laserScript.m_Direction.x =  m_LaserDirectionX; //Set the x direction to the last hit direction key

				m_HasFired = true;
			}
		}

		if(m_HasFired)
		{
			m_FireTime -= Time.deltaTime;

			if(m_FireTime <= 0.0f)
			{
				m_FireTime = m_ConstFireTime;
				m_HasFired = false;
			}
		}
	}
}
