using UnityEngine;
using System.Collections;

public class PlayerPosition : MonoBehaviour {
	void Update() {
	}
	public void SetPosition(Vector3 tPos) {
		transform.position = tPos;
	}
	public void Set3DPosision(string currentAxis) {

		RaycastHit hit;
		SphereCollider t = GetComponent<SphereCollider> ();
		Vector3 a = t.transform.position;
		a.y -= t.radius;
		if (Physics.Raycast (a, -Vector3.up, out hit)) {
			Vector3 temp =  hit.collider.GetComponent<OldPosisions> ().GetOldPosition ();
			temp.y = transform.position.y;
			Vector3 c = Camera.main.transform.position;
			if(currentAxis == "-z") {
				temp.z -= hit.transform.localScale.z/2;
				c.z -=1;
			}
			if(currentAxis == "z") {
				temp.z += hit.transform.localScale.z/2;
				c.z +=1;
			}
			if(currentAxis == "x") {
				temp.x += hit.transform.localScale.z/2;
				c.x +=1;
			}
			if(currentAxis == "-x") {
				temp.x -= hit.transform.localScale.z/2;
				c.x -=1;
			}
			transform.position=temp;
		}
	}
}
