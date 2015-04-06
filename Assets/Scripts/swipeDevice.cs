using UnityEngine;
using System.Collections;

public class swipeDevice : MonoBehaviour {
	
	//inside class
	
	public Camera mCamera;
	public GameObject Player;
	
	//inside class
	private Vector2 firstPressPos;
	private Vector2 secondPressPos;
	private Vector2 currentSwipe;
	void Start() {
		mCamera = Camera.main;
	}
	
	void Update()
	{
		Player.GetComponent<PlayerControl>().SetMovingDirection(0);
		if(Input.touches.Length == 1)
		{
			Touch t = Input.GetTouch(0);
			if(t.position.x<Screen.width/2) {
					Player.GetComponent<PlayerControl>().SetMovingDirection(-1);
			}
			else {
					Player.GetComponent<PlayerControl>().SetMovingDirection(1);
			}
			if(t.phase == TouchPhase.Began)
			{
				//save began touch 2d point
				firstPressPos = new Vector2(t.position.x,t.position.y);
			}
			if(t.phase == TouchPhase.Ended)
			{
				//save ended touch 2d point
				secondPressPos = new Vector2(t.position.x,t.position.y);
				
				//create vector from the two points
				currentSwipe = new Vector3(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);
				
				//normalize the 2d vector
				//currentSwipe.Normalize();
				bool swiped=false;
				//swipe upwards
				if(currentSwipe.y > Screen.width/10 )
				{
					mCamera.GetComponent<CameraRotate>().swipe("up");
					Debug.Log("up swipe");
					swiped=true;
					return;
				}
				//swipe left
				if(Mathf.Abs( currentSwipe.x) > Screen.width/7 && currentSwipe.x<0 )
				{
					mCamera.GetComponent<CameraRotate>().swipe("left");
					Debug.Log("left swipe");
					return;
					swiped=true;
				}
				//swipe right
				if(Mathf.Abs( currentSwipe.x) > Screen.width/7 && currentSwipe.x>0 )
				{
					mCamera.GetComponent<CameraRotate>().swipe("right");
					Debug.Log("right swipe");
					return;
					swiped=true;
				}
				if(!swiped) {
					Vector2 pos = new Vector2(t.position.x,t.position.y) ;
				//		Player.GetComponent<PlayerControl>().Flip();
				}

			}
		}
	}
}