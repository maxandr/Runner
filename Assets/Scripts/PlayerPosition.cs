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
		SphereCollider tSphereCollider = GetComponent<SphereCollider> ();
		Vector3 a = tSphereCollider.transform.position;
		a.y -= tSphereCollider.radius;
		if (Physics.Raycast (a, -Vector3.up, out hit)) {
			Debug.Log(hit.collider.gameObject.transform.position);
			Vector3 collaiderOldPosition = hit.collider.GetComponent<OldPosisions> ().GetOldPosition ();
			Debug.Log(collaiderOldPosition);
			collaiderOldPosition.y = transform.position.y;
			if (currentAxis == "-z") {
				collaiderOldPosition.z -= hit.transform.localScale.z / 2;
				collaiderOldPosition.x = transform.position.x;
			}
			if (currentAxis == "z") {
				collaiderOldPosition.z += hit.transform.localScale.z / 2;
				collaiderOldPosition.x = transform.position.x;
			}
			if (currentAxis == "x") {
				collaiderOldPosition.x += hit.transform.localScale.z / 2;
				collaiderOldPosition.z = transform.position.z;
			}
			if (currentAxis == "-x") {
				collaiderOldPosition.x -= hit.transform.localScale.z / 2;
				collaiderOldPosition.z = transform.position.z;
			}
			transform.position = collaiderOldPosition;
		} else {
			Debug.Log("Plane NOT FINDED!");
		}
	}
}
