using UnityEngine;
using System.Collections;

public class LavaMovement : MonoBehaviour {
	public float speed = 1;
	public float max;
	float initial = 0;
	bool dir = true;
	Vector3 pos;
	int count = 0;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


		if(initial > max) 
		{
			initial = 0;
			dir = !dir;
			StartCoroutine( waitPlz());
			count = 0;
		}
		if( count >299) {
			initial += .1F;
			if(dir) {
				transform.Translate(new Vector3(0, 1*speed*Time.deltaTime,0));
			}
			else {
				transform.Translate(new Vector3(0, -1*speed*Time.deltaTime,0));
			}
		}
		count++;

	}

	IEnumerator waitPlz() 
	{
		yield return new WaitForSeconds(5);
	}

}
