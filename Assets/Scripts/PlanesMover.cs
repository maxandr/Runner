using UnityEngine;
using System.Collections;

public class PlanesMover : MonoBehaviour {

	public GameObject ObjectsList;
	private ArrayList oldParams ;   
	public GameObject Player;
	public void Reposition(int currentAxis) {
		Player.GetComponent<PlayerPosition>().Set3DPosision(currentAxis);
		Transform[] allChildren = ObjectsList.GetComponentsInChildren<Transform>();
		foreach (Transform child in allChildren) {
			if (child.gameObject.name == "front" || child.gameObject.name == "back" || child.gameObject.name == "left" || child.gameObject.name == "right") {
				child.gameObject.GetComponent<OldPosisions> ().Reposition ();
			}
		}
	}
	public void Move(int currentAxis) {
		Transform[] allChildren = ObjectsList.GetComponentsInChildren<Transform>();

		foreach (Transform child in allChildren) {
			if(currentAxis == -3) {
				if(child.gameObject.name=="front") {
					Vector3 a = Camera.main.transform.position;
					a.z -=1;
					a.x = child.position.x;
					a.y = child.position.y;
					child.position= a;
				}
			}
			if(currentAxis == 3) {
				if(child.gameObject.name=="back") {
					Vector3 a = Camera.main.transform.position;
					a.z +=1;
					a.x = child.position.x;
					a.y = child.position.y;
					child.position= a;
				}
			}
			if(currentAxis == 1) {
				if(child.gameObject.name=="right") {
					Vector3 a = Camera.main.transform.position;
					a.x +=1;
					a.z = child.position.z;
					a.y = child.position.y;
					child.position= a;
				}
			}
			if(currentAxis == -1) {
				if(child.gameObject.name=="left") {
					Vector3 a = Camera.main.transform.position;
					a.x -=1;
					a.z = child.position.z;
					a.y = child.position.y;
					child.position= a;
				}
			}
		}
		Vector3 t = Camera.main.transform.position;
		if(currentAxis == -3) {
					t.z -=1;
		}
		if(currentAxis == 3) {
					t.z +=1;
		}
		if(currentAxis == 1) {
					t.x +=1;
		}
		if(currentAxis == -1) {
					t.x -=1;
		}
		Player.GetComponent<PlayerPosition>().SetPosition(t);
		
	}
}
