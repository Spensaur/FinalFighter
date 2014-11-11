using UnityEngine;
using System.Collections;

public class PlatformMovement : MonoBehaviour {
	public string axis;
	public float speed = 1;
	public float max;
	float initial = 0;
	bool dir = true;
	Vector3 pos;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		pos = transform.position;

		if (axis == "Vertical")
		{
			if(initial > max) 
			{
				initial = 0;
				dir = !dir;
			}
			initial += .1F;
			if(dir) {
				//pos.y -= speed*Time.deltaTime;
				transform.Translate(new Vector3(0, -1*speed*Time.deltaTime,0));
			}
			else {
				//pos.y += speed*Time.deltaTime;
				transform.Translate(new Vector3(0, speed*Time.deltaTime,0));
			}
		}
		else if (axis == "Horizontal")
		{
			if(initial > max) 
			{
				initial = 0;
				dir = !dir;
			}
			initial += .1F;
			if(dir) {
				//pos.y -= speed*Time.deltaTime;
				transform.Translate(new Vector3(1*speed*Time.deltaTime, 0,0));
			}
			else {
				//pos.y += speed*Time.deltaTime;
				transform.Translate(new Vector3(-1*speed*Time.deltaTime, 0,0));
			}
		}

	}
}
