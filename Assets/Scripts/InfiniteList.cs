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
	}
	
	// Update is called once per frame
	void Update () {				
		if(selected)
		{	
			if(vertical)
			{
				float delta = (Input.mousePosition.y - lastPos.y)/50f;
				objectsParent.transform.position = new Vector3(objectsParent.transform.position.x, objectsParent.transform.position.y + delta , objectsParent.transform.position.z);
				//objectsParent.transform.position = new Vector3(objectsParent.transform.position.x, Mathf.Clamp(objectsParent.transform.position.y + delta, downLimitation, upLimitation) , objectsParent.transform.position.z);
			}
			else
			{
				float delta = (Input.mousePosition.x - lastPos.x)/50f;
				objectsParent.transform.position = new Vector3(objectsParent.transform.position.x + delta, objectsParent.transform.position.y, objectsParent.transform.position.z);
				//objectsParent.transform.position = new Vector3(Mathf.Clamp(objectsParent.transform.position.x + delta, leftLimitation, rightLimitation), objectsParent.transform.position.y, objectsParent.transform.position.z);
			}
		}
		
		if(objects != null)
		{
			for(int i=0; i < objects.Count; i++)
			{				
				if(vertical)
				{
					float max =-Mathf.Infinity;
					float min =Mathf.Infinity;
					
					foreach(GameObject button in objects)
					{	
						if(button.GetComponent<Button>().listPos > max)
							max = button.GetComponent<Button>().listPos;
						
						if(button.GetComponent<Button>().listPos < min)
							min = button.GetComponent<Button>().listPos;
					}
					
					if(objects[i].renderer.material.color.a <= 0)
					{
					    if(objects[i].transform.position.y > transform.position.y + ((yOffset + objects[i].collider.bounds.size.y) * height)/2 
							&& objects[i].GetComponent<Button>().listPos == min)
						{	
							if(!(objectsParent.transform.position.y + height * (yOffset + objects[i].collider.bounds.size.y)/2 - ((yOffset + objects[i].collider.bounds.size.y) * (max + 1)) 
								< transform.position.y - ((yOffset + objects[i].collider.bounds.size.y) * height)/2))
							{
								objects[i].GetComponent<Button>().textParent.GetComponent<TextMesh>().text = (max + 1).ToString();
								objects[i].GetComponent<Button>().listPos = max + 1;
							}
						}
						
						if(objects[i].transform.position.y < transform.position.y - ((yOffset + objects[i].collider.bounds.size.y) * height)/2
							&& objects[i].GetComponent<Button>().listPos == max)
						{
							if(!(objectsParent.transform.position.y + height * (yOffset + objects[i].collider.bounds.size.y)/2 - ((yOffset + objects[i].collider.bounds.size.y) * (min - 1)) 
								> transform.position.y + ((yOffset + objects[i].collider.bounds.size.y) * height)/2))
							{
								objects[i].GetComponent<Button>().textParent.GetComponent<TextMesh>().text = (min - 1).ToString();
								objects[i].GetComponent<Button>().listPos = min - 1;
							}
						}
					}
					
					objects[i].SetActive(true);
					bool move = true;
					if(objects[i].GetComponent<Flip>() != null)
					{
						move = !objects[i].GetComponent<Flip>().flip;
					}
					
					if(move)
					{
						objects[i].transform.position = new Vector3(objectsParent.transform.position.x, 
							objectsParent.transform.position.y + height * (yOffset + objects[i].collider.bounds.size.y)/2 - ((yOffset + objects[i].collider.bounds.size.y) * objects[i].GetComponent<Button>().listPos), 
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
	
	public void AddButton(GameObject button)
	{
		button.transform.parent = objectsParent.transform;
		float max =-Mathf.Infinity;
		
		foreach(GameObject button2 in objects)
		{
			if(button2.GetComponent<Button>().listPos > max)
				max = button2.GetComponent<Button>().listPos;
		}
		
		if(objects.Count == 0)
		{
			button.GetComponent<Button>().listPos = 0;
			button.GetComponent<Button>().textParent.GetComponent<TextMesh>().text = (0).ToString();
		}
		else
		{
		button.GetComponent<Button>().listPos = max + 1;
		button.GetComponent<Button>().textParent.GetComponent<TextMesh>().text = (max + 1).ToString();
		}

		button.renderer.material.shader = Shader.Find ("Transparent/Diffuse");
		button.renderer.material.color = new Color(objects.Count*2f/10f, objects.Count*2f/10f, objects.Count*2f/10f);

		button.SetActive(false);
		objects.Add(button);

	}
}
