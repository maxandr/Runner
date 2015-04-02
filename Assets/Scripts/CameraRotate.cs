using UnityEngine;
using System.Collections;

public class CameraRotate : MonoBehaviour {
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
	// Update is called once per frame
	void Start() {
		status = false;
		CheckCoords ();
		mover.GetComponent<PlanesMover>().Move(currentAxis);
	}
	void FixedUpdate()
	{
		// Trigger functions if Rotate is requested
		if (Input.GetKeyDown(KeyCode.K) ||Input.GetKeyDown(KeyCode.JoystickButton4)) {
			targetAngle -= 90.0f;
			degree -= 90f;
			mover.GetComponent<PlanesMover>().Reposition();
		} else if (Input.GetKeyDown(KeyCode.L)||Input.GetKeyDown(KeyCode.JoystickButton5)) {
			targetAngle += 90.0f;
			degree += 90f;
			mover.GetComponent<PlanesMover>().Reposition();
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
		Debug.Log (status);
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
		Debug.Log (currentAxis);
	}
}
