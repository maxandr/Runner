using UnityEngine;
using System.Collections;

public class OldPosisions : MonoBehaviour {
	private Vector3 position;
	// Use this for initialization
	void Start () {
		position = transform.position;
	}
	public void Reposition() {
		transform.position = position;
	}
	public Vector3 GetOldPosition() {
		return position;
	}
}
