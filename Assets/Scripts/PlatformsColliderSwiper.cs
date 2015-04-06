using UnityEngine;
using System.Collections;

public class PlatformsColliderSwiper : MonoBehaviour {
	public GameObject ObjectsList;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Transform[] allChildren = ObjectsList.GetComponentsInChildren<Transform>();
		foreach (Transform child in allChildren) {
			if(child.gameObject.tag=="ground") {
				if(child.transform.parent.gameObject.transform.parent.name=="BoxPlane20") {
					int a =0;
				}
				if(child.gameObject.transform.position.y >= transform.position.y) {
					//if(child.GetComponent<BoxCollider>()!=null) {
						child.GetComponent<BoxCollider>().isTrigger=true;
					//}
				}
				else {
					//if(child.GetComponent<BoxCollider>()!=null) {
					child.GetComponent<BoxCollider>().isTrigger=false;
					//}
				}
			}
		}
	}
}
