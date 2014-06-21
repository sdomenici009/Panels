using UnityEngine;
using System.Collections;

public class Card : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Mesh theMesh;
		theMesh = transform.GetComponent<MeshFilter>().mesh;
		 
		// Now store a local reference for the UVs
		Vector2[] theUVs = new Vector2[theMesh.uv.Length];
		theUVs = theMesh.uv;
		 
		// set UV co-ordinates
		theUVs[7] = new Vector2(0f, 46f/1395f);
		theUVs[6] = new Vector2(900f/1845f, 46/1395f);
		theUVs[11] = new Vector2(0f, 1f);
		theUVs[10] = new Vector2(900f/1845f, 1f);
		
		theUVs[2] = new Vector2(901f/1845f, 1f);
		theUVs[3] = new Vector2(1800f/1845f, 1f);
		theUVs[0] = new Vector2(901f/1845f, 46f/1395f);
		theUVs[1] = new Vector2(1800f/1845f, 46f/1395f);

		theUVs[15] = new Vector2(0f, 0f);
		theUVs[13] = new Vector2(900f/1845f, 0f);
		theUVs[12] = new Vector2(0f, 45f/1395f);
		theUVs[14] = new Vector2(900f/1845f, 45f/1395f);
		
		theUVs[4] = new Vector2(0f, 0f);
		theUVs[5] = new Vector2(900f/1845f, 0f);
		theUVs[8] = new Vector2(0f, 45f/1395f);
		theUVs[9] = new Vector2(900f/1845f, 45f/1395f);
		
		theUVs[23] = new Vector2(1801f/1845f, 1f);
		theUVs[21] = new Vector2(1f, 1f);
		theUVs[20] = new Vector2(1801f/1845f, 45f/1395f);
		theUVs[22] = new Vector2(1f, 45f/1395f);
		
		theUVs[19] = new Vector2(1801f/1845f, 1f);
		theUVs[17] = new Vector2(1f, 1f);
		theUVs[16] = new Vector2(1801f/1845f, 45f/1395f);
		theUVs[18] = new Vector2(1f, 45f/1395f);
		 
		// Assign the mesh its new UVs
		theMesh.uv = theUVs;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
