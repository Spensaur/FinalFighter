using UnityEngine;
using System.Collections;

public class Player2Script : MonoBehaviour {
	Animator anim;
	CharacterController cc;
	private Vector3 dir;
	public float speed = 3;
	public float dropspeed = 4;
	public float jumpSpeed = 1;
	private bool isJumping = false;
	private bool isKicking = false;
	
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		cc = GetComponent<CharacterController> ();
	}
	
	// Update is called once per frame
	void Update () {
		
		Vector3 scale = transform.localScale;
		dir.x = -1*Input.GetAxis ("Horizontal") * speed;
		dir = transform.TransformDirection (dir);

		float facing = -1*Input.GetAxis ("Horizontal");

		if (!cc.isGrounded) {
			if (Input.GetAxis("Vertical") >= 0) {	Physics.IgnoreLayerCollision(8, 0, dir.y>0); 	}
			
			dir.y -= dropspeed * Time.deltaTime;
		}


		if(cc.isGrounded) { 
			Physics.IgnoreLayerCollision(8, 0, (Input.GetAxis("Vertical") < 0));
			isJumping = false; 
		}
		if (Input.GetButton ("Jump") && cc.isGrounded) {
			dir.y=0;
			isJumping = true;
			dir.y += (jumpSpeed*7.0f);
		}

		if (Input.GetButton ("Shoot") && cc.isGrounded) {
			isKicking = true;	
		}else { 
			isKicking = false; 
		}

		anim.SetFloat ("speed", Mathf.Abs (facing));
		anim.SetBool ("isRunning", facing != 0);
		anim.SetBool ("isJumping", isJumping);
		anim.SetBool ("isKicking", isKicking);

		if( facing < 0 ) {
			scale.x = -1;
			transform.localScale = scale;
		} else if( facing > 0 ) {
			scale.x = 1;
			transform.localScale = scale;
		}
		
		cc.Move (dir * Time.deltaTime);
	}
}
