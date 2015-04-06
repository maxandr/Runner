using UnityEngine;
using System.Collections;

public class CameraRotate : Pauser {
	public PlanesMover mover;
	public GameObject targetObject;
	private float targetAngle = 0;
	public float rotationAmount = 1.5f;
	[HideInInspector]
	public float degree;
	[HideInInspector]
	public bool status;
	[HideInInspector]
	public string  currentAxis;//1 = x 2 = y 3 = z
	private float cameraDistance;
	// Update is called once per frame
	void Start() {
		cameraDistance = transform.position.z;
		StartCoroutine(Start1());
		status = false;
		CheckCoords ();
		mover.GetComponent<PlanesMover>().Move(currentAxis);
	}
	protected override void DoUpdate()
	{
		// Trigger functions if Rotate is requested
		if (Input.GetKeyDown(KeyCode.K) ||Input.GetKeyDown(KeyCode.JoystickButton4) && !status) {
			Pausegame(true);
			targetAngle -= 90.0f;
			degree -= 90f;
			mover.GetComponent<PlanesMover>().Reposition(currentAxis);
		} else if (Input.GetKeyDown(KeyCode.L)||Input.GetKeyDown(KeyCode.JoystickButton5)&& !status) {
			Pausegame(true);
			targetAngle += 90.0f;
			degree += 90f;
			mover.GetComponent<PlanesMover>().Reposition(currentAxis);
		}

		currentAxis = "";
		if(targetAngle !=0) {
			Rotate();
		}
		CheckCoords ();
		if (targetAngle != 0) {
			status = true;
		} else {
			status = false;
		}
	}
	public void swipe(string axis) {
		if (axis == "up") {
			targetObject.GetComponent<PlayerControl>().Jump();
		}
		if (axis == "down") {
		
		}
		if (axis == "left") {
			Pausegame(true);
			targetAngle -= 90.0f;
			degree -= 90f;
			mover.GetComponent<PlanesMover>().Reposition(currentAxis);
		}
		if (axis == "right") {
			Pausegame(true);
			targetAngle += 90.0f;
			degree += 90f;
			mover.GetComponent<PlanesMover>().Reposition(currentAxis);
		}

	}
	protected void Rotate()
	{
		targetObject.transform.LookAt (transform);
		if (targetAngle>0)
		{
			transform.RotateAround(targetObject.transform.position, Vector3.up, -rotationAmount);
			targetAngle -= rotationAmount;
		}
		else if(targetAngle <0)
		{
			transform.RotateAround(targetObject.transform.position, Vector3.up, rotationAmount);
			targetAngle += rotationAmount;
		}
		if (targetAngle == 0) {
			CheckCoords();
			if(currentAxis == "-z") {
				Vector3 temp =  transform.position;
				temp.z = cameraDistance;
				transform.position = temp;
			}
			if(currentAxis == "z") {
				Vector3 temp =  transform.position;
				temp.z = -cameraDistance;
				transform.position = temp;
			}
			if(currentAxis == "x") {
				Vector3 temp =  transform.position;
				temp.x = -cameraDistance;
				transform.position = temp;
			}
			if(currentAxis == "-x") {
				Vector3 temp =  transform.position;
				temp.x = cameraDistance;
				transform.position = temp;
			}
			mover.GetComponent<PlanesMover>().Move(currentAxis);
			Pausegame(false);
		}
	}
	protected void CheckCoords() {
		if (transform.eulerAngles.y < 3 || transform.eulerAngles.y > 367) {
			currentAxis="z";
		}
		if (transform.eulerAngles.y < 183 && transform.eulerAngles.y > 177) {
			currentAxis="-z";
		}
		if (transform.eulerAngles.y < 273 && transform.eulerAngles.y > 267) {
			currentAxis="-x";
		}
		if (transform.eulerAngles.y < 93 && transform.eulerAngles.y > 87) {
			currentAxis="x";
		}
	}
}
