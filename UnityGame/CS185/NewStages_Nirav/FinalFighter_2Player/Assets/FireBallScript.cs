using UnityEngine;
using System.Collections;

public class FireBallScript : MonoBehaviour {

	Vector3 pos;
	public float speed = 1;
	public float multiplier = 1;
	public bool reroute;
	int count = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Physics.IgnoreLayerCollision (0, 8, true);
		Physics.IgnoreLayerCollision (0, 9, true);
		pos = transform.position;
		
		if (pos.z > 6) {
			pos.z = -6;
			
			if(reroute == true) 
			{
				if(Random.Range(0,30) > 10) 
				{
					pos.x = Random.Range(-3.0F,-1.0F); 
				}
				else { pos.x = Random.Range(-1.0F, 0.0F); }
				
				
			}
			
			transform.position = pos;
		}
		
		
		
		transform.Translate (new Vector3 (0, speed*Time.deltaTime, 0));
		count++;
	}
}
