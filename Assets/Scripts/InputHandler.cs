using UnityEngine;
using System.Collections;

public class InputHandler : MonoBehaviour {
	
	RaycastHit hit;
	
	// Use this for initialization
	void Start () {
		hit = new RaycastHit();
	}
	
	// Update is called once per frame
	void Update () {
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		
		if(Input.GetMouseButtonDown(0))
		{
			if(Physics.Raycast(ray, out hit))
			{
				Debug.Log("HIT!");
				
				Flip hitFlip = hit.transform.GetComponent<Flip>();
				
				if(hitFlip != null)
				{
					hitFlip.flip = true;
				}
			}
		}
	}
}
