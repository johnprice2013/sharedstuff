using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour {
	
	CharacterController characterController;
	public float gravity = 10f;
	
	public float characterMovementSpeed = 5f;
	public float jumptime = .2f;

	public bool jumping = false;
	// Use this for initialization
	void Start () {
	
		characterController = GetComponent<CharacterController>();
	
		
	
		
	}
	
	
	
	// Update is called once per frame
	void Update () {
		
		if(characterController.isGrounded && Input.GetKey (KeyCode.Space))
		{
		StartCoroutine ("jumper");
		}
		
		float y;
		float x = Input.GetAxis ("Horizontal")*characterMovementSpeed;
		
		if(!jumping)
		{
		y = -gravity;
		}
		else
		{
		y = gravity;
		}
		
		
		float z = 0f;
		Vector3 movement = new Vector3(x,y,z);
		movement = movement*Time.deltaTime;
		characterController.Move(movement);
		Debug.Log (movement);
		
		
		
		
	}
	
		IEnumerator jumper()
	{
		jumping = true;
		yield return new WaitForSeconds(jumptime);
		jumping = false;
		
	}
}
