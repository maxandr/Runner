using UnityEngine;
using System.Collections;

public class OldPosisions : MonoBehaviour {
	public Vector3 position;
	// Use this for initialization
	void Awake () {
		position = transform.position;
	}
	public void RepositionToOldPosition() {
		transform.position = position;
	}
	public Vector3 GetOldPosition() {
		return position;
	}
}
