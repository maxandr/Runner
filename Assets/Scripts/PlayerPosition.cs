using UnityEngine;
using System.Collections;

public class PlayerPosition : MonoBehaviour {
	void Update() {
	}
	public void SetPosition(Vector3 tPos) {
		transform.position = tPos;
	}
	public void Set3DPosision(int currentAxis) {
		RaycastHit hit;
		SphereCollider t = GetComponent<SphereCollider> ();
		Vector3 a = t.transform.position;
		a.y -= t.radius;
		if (Physics.Raycast (a, -Vector3.up, out hit)) {
			Vector3 c = Camera.main.transform.position;
			if(currentAxis == -3) {
				c.z -=1;
			}
			if(currentAxis == 3) {
				c.z +=1;
			}
			if(currentAxis == 1) {
				c.x +=1;
			}
			if(currentAxis == -1) {
				c.x -=1;
			}
		}//HERE I AM
	}
}
