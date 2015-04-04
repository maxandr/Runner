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
	public int  currentAxis;//1 = x 2 = y 3 = z
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
		if (Input.GetKeyDown(KeyCode.K) ||Input.GetKeyDown(KeyCode.JoystickButton4)) {
			Pausegame(true);
			targetAngle -= 90.0f;
			degree -= 90f;
			mover.GetComponent<PlanesMover>().Reposition(currentAxis);
		} else if (Input.GetKeyDown(KeyCode.L)||Input.GetKeyDown(KeyCode.JoystickButton5)) {
			Pausegame(true);
			targetAngle += 90.0f;
			degree += 90f;
			mover.GetComponent<PlanesMover>().Reposition(currentAxis);
		}

		currentAxis = 0;
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
			mover.GetComponent<PlanesMover>().Move(currentAxis);
			if(currentAxis == -3) {
				Vector3 temp =  transform.position;
				temp.z =cameraDistance;
				transform.position = temp;
			}
			if(currentAxis == 3) {
				Vector3 temp =  transform.position;
				temp.z = -cameraDistance;
				transform.position = temp;
			}
			if(currentAxis == 1) {
				Vector3 temp =  transform.position;
				temp.x = -cameraDistance;
				transform.position = temp;
			}
			if(currentAxis == -1) {
				Vector3 temp =  transform.position;
				temp.x = cameraDistance;
				transform.position = temp;
			}
			Pausegame(false);
		}
	}
	protected void CheckCoords() {
		if (transform.eulerAngles.y < 3 || transform.eulerAngles.y > 367) {
			currentAxis=3;
		}
		if (transform.eulerAngles.y < 183 && transform.eulerAngles.y > 177) {
			currentAxis=-3;
		}
		if (transform.eulerAngles.y < 273 && transform.eulerAngles.y > 267) {
			currentAxis=-1;
		}
		if (transform.eulerAngles.y < 93 && transform.eulerAngles.y > 87) {
			currentAxis=1;
		}
	}
}
