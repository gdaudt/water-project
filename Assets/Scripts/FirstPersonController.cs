using UnityEngine;
using System.Collections;

public class FirstPersonController : MonoBehaviour {

	public float turnSpeed = 50f;
	public float sensitivity = 0.01f;
	public float movementAmount = 0.5f;
		
	// Update is called once per frame
	void Update () {

		MouseLook ();
		KeyboardMovement ();

	}

	private void MouseLook(){
		Vector3 rot = new Vector3 (0f, 0f, 0f);
		//rotate left
		if (Input.GetAxis ("Mouse X") < 0)
			rot.x -= 1;
		//rotate right
		if (Input.GetAxis ("Mouse X") > 0)
			rot.x += 1;
		//rotate up
		if (Input.GetAxis ("Mouse Y") < 0)
			rot.y -= 1;
		//rotate down
		if (Input.GetAxis ("Mouse X") > 0)
			rot.y += 1;
	}

	private void KeyboardMovement(){
		Vector3 movementVector = new Vector3 (0f, 0f, 0f);
		float horizontalMovement = Input.GetAxis ("Horizontal");
		float verticalMovement = Input.GetAxis ("Vertical");
		//left arrow
		if (horizontalMovement < -sensitivity)
			movementVector.x = -movementAmount;
		//right arrow
		if (horizontalMovement > sensitivity)
			movementVector.x = movementAmount;
		//up arrow
		if (verticalMovement < -sensitivity)
			movementVector.y = -movementAmount;
		//down arrow
		if (verticalMovement > sensitivity)
			movementVector.y = movementAmount;
	}
}
