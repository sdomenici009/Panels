using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InfiniteList : MonoBehaviour {
	
	public GameObject objectsParent;
	GameObject top;
	GameObject bot;
	List<GameObject> objects;
	Vector3 lastPos = Vector3.zero;
	bool vertical;
	public bool selected;
	float height;
	float width;
	float yOffset;
	float leftLimitation;
	float rightLimitation;
	float upLimitation;
	float downLimitation;
	// Use this for initialization
	void Start () {
		//top = GameObject.CreatePrimitive(PrimitiveType.Cube);
		//bot = GameObject.CreatePrimitive(PrimitiveType.Cube);
		lastPos = Input.mousePosition;
		vertical = true;
		selected = false;
		height = 5;
		width = 5;
		objects = new List<GameObject>();
		yOffset = .5f;
		
		//objects.Add(top);
		//objects.Add(bot);
		
		float dist =(transform.position.z - Camera.main.transform.position.z);
 
		leftLimitation = Camera.main.ViewportToWorldPoint(new Vector3(0,0,dist)).x;
		rightLimitation = Camera.main.ViewportToWorldPoint(new Vector3(1,0,dist)).x;
		 
		upLimitation = Camera.main.ViewportToWorldPoint(new Vector3(0,1,dist)).y;
		downLimitation = Camera.main.ViewportToWorldPoint(new Vector3(0,0,dist)).y;
	}
	
	// Update is called once per frame
	void Update () {		
		
		if(selected)
		{	
			if(vertical)
			{
				float delta = (Input.mousePosition.y - lastPos.y)/50f;
				objectsParent.transform.position = new Vector3(objectsParent.transform.position.x, Mathf.Clamp(objectsParent.transform.position.y + delta, downLimitation, upLimitation) , objectsParent.transform.position.z);
			}
			else
			{
				float delta = (Input.mousePosition.x - lastPos.x)/50f;
				objectsParent.transform.position = new Vector3(Mathf.Clamp(objectsParent.transform.position.x + delta, leftLimitation, rightLimitation), objectsParent.transform.position.y, objectsParent.transform.position.z);
			}
		}
		
		if(objects != null)
		{
			for(int i=0; i < objects.Count; i++)
			{
				if(vertical)
				{
					objects[i].SetActive(true);
					bool move = true;
					if(objects[i].GetComponent<Flip>() != null)
					{
						move = !objects[i].GetComponent<Flip>().flip;
					}
					
					if(move)
					{
						objects[i].transform.position = new Vector3(objectsParent.transform.position.x, 
							objectsParent.transform.position.y + objects.Count * objects[i].collider.bounds.size.y - ((yOffset + objects[i].collider.bounds.size.y) * i), 
							objectsParent.transform.position.z);
					}
					
					if(objects[i].transform.position.y > transform.position.y + ((yOffset + objects[i].collider.bounds.size.y) * height)/2)
					{
						objects[i].renderer.material.color = new Color(objects[i].renderer.material.color.r, 
							objects[i].renderer.material.color.b, 
							objects[i].renderer.material.color.g, 
							Mathf.Clamp(objects[i].renderer.material.color.a - (objects[i].transform.position.y - transform.position.y + ((yOffset + objects[i].collider.bounds.size.y) * i+1))/100f, 0, 255f));
					}
					else
					if(objects[i].transform.position.y < transform.position.y - ((yOffset + objects[i].collider.bounds.size.y) * height)/2)
					{
						objects[i].renderer.material.color = new Color(objects[i].renderer.material.color.r, 
							objects[i].renderer.material.color.b, 
							objects[i].renderer.material.color.g, 
							Mathf.Clamp(objects[i].renderer.material.color.a - (-objects[i].transform.position.y - transform.position.y + ((yOffset + objects[i].collider.bounds.size.y) * i+1))/100f, 0, 255f));
					}
					else
					{
							objects[i].renderer.material.color = new Color(objects[i].renderer.material.color.r, 
							objects[i].renderer.material.color.b, 
							objects[i].renderer.material.color.g, 
							1f);
					}
				}
			}
		}
		
		lastPos = Input.mousePosition;
	}
	
	public void AddButton()
	{
		GameObject button = (GameObject)Instantiate(Resources.Load("Button"));
		button.renderer.material.shader = Shader.Find ("Transparent/Diffuse");
		button.SetActive(false);
		objects.Add(button);
		//objects.Insert(objects.Count - 1, button);
	}
}
