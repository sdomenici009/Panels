using UnityEngine;
using System.Collections;

public class Flip : MonoBehaviour {
	
	float rotation = .1f;
	float orginTime = 1f;
	float timer;
	bool flip = false;
	// Use this for initialization
	void Start () {
		timer = orginTime;
	}
	
	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;
		
		if(flip)
		{
			transform.rotation = new Quaternion(Mathf.Clamp(transform.rotation.x + rotation, 0, 360), transform.rotation.y, transform.rotation.z, transform.rotation.w);
		}
		
		if(timer < 0)
		{
			timer = orginTime;
			
			if(flip)
			{
				flip = false;
			}
			else
			{
				flip = true;
				rotation = -rotation;
			}
		}
	}
}
