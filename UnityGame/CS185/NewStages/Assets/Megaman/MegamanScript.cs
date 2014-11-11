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
	private int jumpcount = 0;
	private int dropcount = 0;
	private float testJump = 3;
	private float testDrop = 8;

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

		Physics.IgnoreLayerCollision (0, 9, false);
		Debug.Log (dropcount);

		float facing = -1*Input.GetAxis ("Horizontal");
		/*
		if (Input.GetButton ("Fire1") && cc.isGrounded) {
			shooting = true;	
		}
		else { shooting = false; } */
		if (Input.GetButton ("Dash") && cc.isGrounded) {
			dashing = true;
			dir.x += facing * -2;
				}
		else { dashing = false;}
		if (Input.GetButton ("Dash") && !cc.isGrounded) {
			dir.x += facing * -2;
		}


		if (Input.GetButton ("Jump") && jumpcount < 30 ) {
			dir.y=0;
			jumping = true;
			dir.y += testJump;
			testJump += (jumpcount-8)/19;
			//dir.y += jumpSpeed;
			jumpcount++;
			}
		if(Input.GetButtonUp("Jump"))
		   jumpcount = 40;
		if (!cc.isGrounded) {
			if (Input.GetAxis("Vertical") >= 0) {
				Physics.IgnoreLayerCollision(8, 0, dir.y>0); 	
			}
			if(Input.GetAxis("Vertical") <= -.2) {
				dir.y -= 10*Time.deltaTime;
			}

			dir.y -= testDrop * Time.deltaTime;
			if(dropcount < 30) {
				testDrop += dropcount/30;
			}
			else 
				testDrop += .3F;
			dropcount++;
		}
		if(cc.isGrounded) { 
			Physics.IgnoreLayerCollision(8, 0, (Input.GetAxis("Vertical") < 0));
			jumpcount = 0;
			testJump = 2;
			testDrop = 6;
			dropcount = 0;
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
			scale.x = -1*Mathf.Abs (scale.x);
			transform.localScale = scale;
		} else if( facing > 0 ) {
			scale.x = Mathf.Abs(scale.x);
			transform.localScale = scale;
		}

		//dir = transform.TransformDirection (dir);
		cc.Move (dir * Time.deltaTime);
	}

	void OnControllerColliderHit(ControllerColliderHit hit)
	{
		//if(collider.gameObject.name == "Bullet Bill") 
		//{

			if(hit.gameObject.name == "Bullet Bill" )
				Destroy(this.gameObject);
		//}
	}
	
}
