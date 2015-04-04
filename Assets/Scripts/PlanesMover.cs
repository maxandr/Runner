using UnityEngine;
using System.Collections;

public class PlanesMover : MonoBehaviour {

	public GameObject ObjectsList;
	private ArrayList oldParams ;   
	public GameObject Player;
	public void Reposition(string currentAxis) {
		Player.GetComponent<PlayerPosition>().Set3DPosision(currentAxis);
		Transform[] allChildren = ObjectsList.GetComponentsInChildren<Transform>();
		foreach (Transform child in allChildren) {
			if (child.gameObject.name == "front" || child.gameObject.name == "back" || child.gameObject.name == "left" || child.gameObject.name == "right") {
				child.gameObject.GetComponent<OldPosisions> ().RepositionToOldPosition ();
			}
		}
	}
	public void Move(string currentAxis) {
		Transform[] allChildren = ObjectsList.GetComponentsInChildren<Transform>();
		ArrayList movedObjects = new ArrayList();
		foreach (Transform child in allChildren) {
			if(currentAxis == "-z") {
				if(child.gameObject.name=="front") {
					int temp=0;
					bool finded = false;
					foreach (Transform i in movedObjects) {
						if(i.parent.position.x == child.parent.position.x && i.parent.position.y == child.parent.position.y) {
							if(i.GetComponent<OldPosisions>().GetOldPosition().z < child.GetComponent<OldPosisions>().GetOldPosition().z) {
								i.GetComponent<OldPosisions>().RepositionToOldPosition();
								movedObjects.RemoveAt(temp);
								break;
							}
							else {
								finded = true;
								break;
							}
						}
						temp++;
					}
					if(!finded) {
					Vector3 a = Camera.main.transform.position;
						a.z -=1;
						a.x = child.position.x;
						a.y = child.position.y;
						child.position= a;
						movedObjects.Add(child);  
					}
				}
			}
			if(currentAxis == "z") {
				if(child.gameObject.name=="back") {
					int temp=0;
					bool finded = false;
					foreach (Transform i in movedObjects) {
						if(i.parent.position.x == child.parent.position.x && i.parent.position.y == child.parent.position.y) {
							if(i.GetComponent<OldPosisions>().GetOldPosition().z > child.GetComponent<OldPosisions>().GetOldPosition().z) {
								i.GetComponent<OldPosisions>().RepositionToOldPosition();
								movedObjects.RemoveAt(temp);
								finded = true;
								break;
							}
							else {
								finded = true;
								break;
							}
						}
						temp++;
					}
					if(!finded) {
						Vector3 a = Camera.main.transform.position;
						a.z +=1;
						a.x = child.position.x;
						a.y = child.position.y;
						child.position= a;
						movedObjects.Add(child);  
					}
				}
			}
			if(currentAxis == "x") {
				if(child.gameObject.name=="right") {
					int temp=0;
					bool finded = false;
					foreach (Transform i in movedObjects) {
						if(i.parent.position.z == child.parent.position.z && i.parent.position.y == child.parent.position.y) {
							if(i.GetComponent<OldPosisions>().GetOldPosition().x > child.GetComponent<OldPosisions>().GetOldPosition().x) {
								i.GetComponent<OldPosisions>().RepositionToOldPosition();
								movedObjects.RemoveAt(temp);
								finded = true;
								break;
							}
							else {
								finded = true;
								break;
							}
						}
						temp++;
					}
					if(!finded) {
						Vector3 a = Camera.main.transform.position;
						a.x +=1;
						a.z = child.position.z;
						a.y = child.position.y;
						child.position= a;
						movedObjects.Add(child);  
					}
				}
			}
			if(currentAxis == "-x") {
				if(child.gameObject.name=="left") {
					int temp=0;
					bool finded = false;
					foreach (Transform i in movedObjects) {
						if(i.parent.position.z == child.parent.position.z && i.parent.position.y == child.parent.position.y) {
							if(i.GetComponent<OldPosisions>().GetOldPosition().x < child.GetComponent<OldPosisions>().GetOldPosition().x) {
								i.GetComponent<OldPosisions>().RepositionToOldPosition();
								movedObjects.RemoveAt(temp);
								finded = true;
								break;
							}
							else {
								finded = true;
								break;
							}
						}
						temp++;
					}
					if(!finded) {
						Vector3 a = Camera.main.transform.position;
						a.x -=1;
						a.z = child.position.z;
						a.y = child.position.y;
						child.position= a;
						movedObjects.Add(child);  
					}
				}
			}
		}
		Vector3 t = Camera.main.transform.position;
		if(currentAxis == "-z") {
					t.z -=1;
		}
		if(currentAxis == "z") {
					t.z +=1;
		}
		if(currentAxis == "x") {
					t.x +=1;
		}
		if(currentAxis == "-x") {
					t.x -=1;
		}
		Player.GetComponent<PlayerPosition>().SetPosition(t);
		
	}
}
