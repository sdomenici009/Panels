using UnityEngine;
using System.Collections;

public class ButtonUVMap : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		GenerateUV();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void GenerateUV(){
		Mesh theMesh;
		theMesh = transform.GetComponent<MeshFilter>().mesh;
		 
		// Now store a local reference for the UVs
		Vector2[] theUVs = new Vector2[theMesh.uv.Length];
		theUVs = theMesh.uv;
		 
		// set UV co-ordinates
		theUVs[1] = new Vector2(0f, 1f);
		theUVs[0] = new Vector2(0.5f, 1f);
		theUVs[3] = new Vector2(0f, 0.5f);
		theUVs[2] = new Vector2(0.5f, 0.5f);
		
		theUVs[11] = new Vector2(0.51f, 1f);
		theUVs[10] = new Vector2(1f, 1f);
		theUVs[7] = new Vector2(0.51f, 0.5f);
		theUVs[6] = new Vector2(1f, 0.5f);

		theUVs[15] = new Vector2(0f, 0.49f);
		theUVs[13] = new Vector2(1f, 0.49f);
		theUVs[12] = new Vector2(0f, 0f);
		theUVs[14] = new Vector2(1f, 0f);
		
		theUVs[4] = new Vector2(0f, 0.49f);
		theUVs[5] = new Vector2(1f, 0.49f);
		theUVs[8] = new Vector2(0f, 0f);
		theUVs[9] = new Vector2(1f, 0f);
		
		theUVs[23] = new Vector2(1f, 0.49f);
		theUVs[21] = new Vector2(1f, 0f);
		theUVs[20] = new Vector2(0f, 0.49f);
		theUVs[22] = new Vector2(0f, 0f);
		
		theUVs[19] = new Vector2(1f, 0.49f);
		theUVs[17] = new Vector2(1f, 0f);
		theUVs[16] = new Vector2(0f, 0.49f);
		theUVs[18] = new Vector2(0f, 0f);
		 
		// Assign the mesh its new UVs
		theMesh.uv = theUVs;
	}
}
