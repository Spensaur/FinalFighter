using UnityEngine;
using System.Collections;

public class BlastScript : MonoBehaviour {
	Animator anim;
	Vector3 pos;
	public Transform projectile;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown ("z")) {

		    //&& (GameObject.FindGameObjectsWithTag("Blast").Length < 4)) {

			Instantiate (projectile, transform.position, transform.rotation );

		}


	}


}
