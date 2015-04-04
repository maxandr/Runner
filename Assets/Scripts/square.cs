using UnityEngine;
using System.Collections;

public class square : MonoBehaviour 
{
	public Material mat;
	public GameObject Create(Transform transf)
	{
		GameObject obstacle = new GameObject();
		//Create 4 Vertices
		Vector3[] vert = new Vector3[4];
		vert [0] = new Vector3 (transf.position.x - transf.localScale.x / 2, transf.position.y - transf.localScale.y / 2, 10);//0
		vert [1] = new Vector3 (transf.position.x + transf.localScale.x / 2, transf.position.y - transf.localScale.y / 2, 10);//1
		vert [2] = new Vector3 (transf.position.x + transf.localScale.x / 2, transf.position.y + transf.localScale.y / 2, 10);//2
		vert [3] = new Vector3 (transf.position.x - transf.localScale.x / 2, transf.position.y + transf.localScale.y / 2, 10);//3

		
		//Create the triangles using the vertices
		int[] tris = new int[6];
		tris[0] = 0;
		tris[1] = 1;
		tris[2] = 2;
		tris[3] = 0;
		tris[4] = 2;
		tris[5] = 3;
		
		//Create a new mesh and pass down the vertices and triangles
		Mesh mesh = new Mesh();
		mesh.vertices = vert;
		mesh.triangles = tris;
		
		//Make sure mesh filter and mesh renderer componenets are attached
		if (!GetComponent<MeshFilter>())
			obstacle.AddComponent<MeshFilter>();
		
		if (!GetComponent<MeshRenderer>())
			obstacle.AddComponent<MeshRenderer>();
		
		//Pass down the mesh data to mesh filter
		obstacle.GetComponent<MeshFilter>().mesh = mesh;
		//Send material data to mesh renderer
		obstacle.GetComponent<MeshRenderer>().material = mat;
		return obstacle;
	}
}