using UnityEngine;
using System.Collections;

public class BlastMovement : MonoBehaviour {
	public float speed = 2;
	Vector3 pos;
	float start = 1;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float facing = -1*Input.GetAxis ("Horizontal");
		start = facing;
		Vector3 scale = transform.localScale;

		if( facing < 0 ) {
			scale.x = -1;
			transform.localScale = scale;
		} else if( facing > 0 ) {
			scale.x = 1;
			transform.localScale = scale;
		}


		pos = transform.position;
		pos.x += facing*speed*Time.deltaTime;
		//transform.position = pos;
		transform.Translate (new Vector3 (speed*Time.deltaTime*(-1*transform.forward.z), 0, 0));
	
	}

	void OnCollisionEnter (Collision hit) 
	{
			Destroy (this.gameObject);

	}
}
