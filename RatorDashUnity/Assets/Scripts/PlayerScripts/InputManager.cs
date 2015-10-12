using UnityEngine;
using System.Collections;
/// <summary>
/// Input manager.
/// Will handle all the inputs for the game
/// </summary>
public class InputManager : MonoBehaviour 
{
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		checkInputs();
	}


	void checkInputs()
	{
		leftInput ();
		rightInput ();
		jumpInput ();
		duckInput ();
		fireInput ();
		pauseInput ();
		escInput ();

	}

	public bool leftInput()
	{
		if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
		{
			return true;
		}

		return false;
	}

	public bool rightInput()
	{
		if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
		{
			return true;
		}
		
		return false;
	}

	public bool jumpInput()
	{
		if(Input.GetKey(KeyCode.W)|| Input.GetKey(KeyCode.UpArrow) )
		{
			return true;
		}
		
		return false;
	}

	public bool duckInput()
	{
		if(Input.GetKey(KeyCode.S)|| Input.GetKey(KeyCode.DownArrow) )
		{
			return true;
		}
		
		return false;
	}

	public bool fireInput()
	{
		if(Input.GetKey(KeyCode.Space))
		{
			return true;
		}
		
		return false;
	}

	public bool pauseInput()
	{
		if(Input.GetKey(KeyCode.Return))
		{
			return true;
		}
		
		return false;
	}

	public bool escInput()
	{
		if(Input.GetKey(KeyCode.Escape))
		{
			return true;
		}
		
		return false;
	}

}
