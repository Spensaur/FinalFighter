using UnityEngine;
using System.Collections;

public class MegamanScript : MonoBehaviour {

	public float speed = 3;
	public float dropspeed = 4;
	public float jumpSpeed = 1;
	bool jumping = false;
	bool dashing = false;
	bool shooting = false;
	private Vector3 dir;

	Animator anim;
	CharacterController cc;

	void Start () {
		anim = GetComponent<Animator> ();
		cc = GetComponent<CharacterController> ();
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 scale = transform.localScale;

		dir.x = -1*Input.GetAxis ("Horizontal") * speed;
		dir = transform.TransformDirection (dir);
		anim.SetBool ("Jump", jumping==true);

		float facing = -1*Input.GetAxis ("Horizontal");
		if (Input.GetButton ("Fire1") && cc.isGrounded) {
			shooting = true;	
		}
		else { shooting = false; }
		if (Input.GetButton ("Dash") && cc.isGrounded) {
			dashing = true;
			dir.x += facing * -2;
				}
		else { dashing = false;}
		if (Input.GetButton ("Dash") && !cc.isGrounded) {
			dir.x += facing * -2;
		}


		if (Input.GetButton ("Jump") && cc.isGrounded) {
			dir.y=0;
			jumping = true;
			dir.y += (jumpSpeed*1.5f);
			}
		if (!cc.isGrounded) {
			if (Input.GetAxis("Vertical") >= 0) {	Physics.IgnoreLayerCollision(8, 0, dir.y>0); 	}

			dir.y -= dropspeed * Time.deltaTime;
		}
		if(cc.isGrounded) { 
			Physics.IgnoreLayerCollision(8, 0, (Input.GetAxis("Vertical") < 0));
			jumping = false; 
		}
		//pos.x += currSpeed * Time.deltaTime;
		//transform.position = pos;

		anim.SetFloat ("Speed", Mathf.Abs (facing));
		anim.SetBool ("SpeedIsZero", facing == 0);
		anim.SetBool ("Ground", cc.isGrounded);
		anim.SetBool ("IsDashing", dashing);
		anim.SetBool ("IsShooting", shooting);


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
