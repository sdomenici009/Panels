using UnityEngine;
using System.Collections;

public class Flip : MonoBehaviour {
	
	public bool flip = false;
	float speed = 10f;
	float dir = 1;
	float xAng = 180f;
	
	void Start () {
	}
	
	public void Update () {
		if(flip)
		{	
			if((dir > 0 && transform.rotation.x >= 1f) || (dir < 0 && transform.rotation.x <= 0f))
			{
				dir = -dir;
				flip = false;
			}
			else
			{
				transform.Rotate(new Vector3(dir*speed, 0 ,0));
			}
		}
	}
}
