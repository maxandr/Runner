using UnityEngine;
using System.Collections;

public class CameraRotate : MonoBehaviour {
	public GameObject targetObject;
	private float targetAngle = 0;
	public float rotationAmount = 1.5f;
	public float rDistance = 1.0f;
	public float rSpeed = 1.0f;
	public float degree;
	public float angle;
	// Update is called once per frame
	void Update()
	{
		
		// Trigger functions if Rotate is requested
		if (Input.GetKeyDown(KeyCode.K)) {
			targetAngle -= 90.0f;
			degree -= 90f;
		} else if (Input.GetKeyDown(KeyCode.L)) {
			targetAngle += 90.0f;
			degree += 90f;
		}
		
		if(targetAngle !=0)
		{
			Rotate();
		}
	}
	
	protected void Rotate()
	{
		
		float step = rSpeed * Time.deltaTime;
		float orbitCircumfrance = 2F * rDistance * Mathf.PI;
		float distanceDegrees = (rSpeed / orbitCircumfrance) * 360;
		float distanceRadians = (rSpeed / orbitCircumfrance) * 2 * Mathf.PI;
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

	}
}
