using UnityEngine;
using System.Collections;

public class PlayerPosition : MonoBehaviour {
	GameObject previosBox;
	void Update() {
		RaycastHit hit;
		SphereCollider tSphereCollider = GetComponent<SphereCollider> ();
		Vector3 a = tSphereCollider.transform.position;
		a.y -= tSphereCollider.radius;
		if (Physics.Raycast (a, -Vector3.up, out hit)) {
			previosBox = hit.collider.gameObject;
		}
	}
	public void SetPosition(Vector3 tPos) {
		transform.position = tPos;
	}
	public void Set3DPosision(string currentAxis) {
		/*SphereCollider tSphereCollider = GetComponent<SphereCollider> ();
		RaycastHit hit;
		Vector3 a = tSphereCollider.transform.position;
		a.y -= tSphereCollider.radius;
		if (Physics.Raycast (a, -Vector3.up, out hit)) {
			Debug.Log(hit.collider.gameObject.transform.position);*/
		Vector3 collaiderOldPosition = previosBox.GetComponent<OldPosisions> ().GetOldPosition ();
			collaiderOldPosition.y = transform.position.y;
			if (currentAxis == "-z") {
			collaiderOldPosition.z -= previosBox.transform.localScale.z / 2;
				collaiderOldPosition.x = transform.position.x;
			}
			if (currentAxis == "z") {
			collaiderOldPosition.z += previosBox.transform.localScale.z / 2;
				collaiderOldPosition.x = transform.position.x;
			}
			if (currentAxis == "x") {
			collaiderOldPosition.x += previosBox.transform.localScale.z / 2;
				collaiderOldPosition.z = transform.position.z;
			}
			if (currentAxis == "-x") {
			collaiderOldPosition.x -= previosBox.transform.localScale.z / 2;
				collaiderOldPosition.z = transform.position.z;
			}
			transform.position = collaiderOldPosition;/*
		} else {
			Debug.Log("Plane NOT FINDED!");
		}*/
	}
}
