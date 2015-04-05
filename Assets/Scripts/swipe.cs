using UnityEngine;
using System.Collections;

public class swipe : MonoBehaviour {
	
	//inside class

	public Camera mCamera;
	
	//inside class
	private Vector2 firstPressPos;
	private Vector2 secondPressPos;
	private Vector2 currentSwipe;
	void Start() {
		mCamera = Camera.main;
	}
	
	void Update()
	{
		if(Input.GetMouseButtonDown(0))
		{
			//save began touch 2d point
			firstPressPos = new Vector2(Input.mousePosition.x,Input.mousePosition.y);
		}
		if(Input.GetMouseButtonUp(0))
		{
			//save ended touch 2d point
			secondPressPos = new Vector2(Input.mousePosition.x,Input.mousePosition.y);
			
			//create vector from the two points
			currentSwipe = new Vector2(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);
			
			//normalize the 2d vector
			currentSwipe.Normalize();
			
			//swipe upwards
			if(currentSwipe.y > 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)
			{
				mCamera.GetComponent<CameraRotate>().swipe("up");
				Debug.Log("up swipe");
			}
			//swipe down
			if(currentSwipe.y < 0 && currentSwipe.x > -0.5f  &&currentSwipe.x < 0.5f)
			{
				mCamera.GetComponent<CameraRotate>().swipe("down");
				Debug.Log("down swipe");
			}
			//swipe left
			if(currentSwipe.x < 0  &&currentSwipe.y > -0.5f&&  currentSwipe.y < 0.5f)
			{
				mCamera.GetComponent<CameraRotate>().swipe("left");
				Debug.Log("left swipe");
			}
			//swipe right
			if(currentSwipe.x > 0&&  currentSwipe.y > -0.5f  &&currentSwipe.y < 0.5f)
			{
				mCamera.GetComponent<CameraRotate>().swipe("right");
				Debug.Log("right swipe");
			}
		}
	}
}