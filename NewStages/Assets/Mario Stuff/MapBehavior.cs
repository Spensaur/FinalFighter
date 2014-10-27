using UnityEngine;
using System.Collections;

public class MapBehavior : MonoBehaviour {
	Vector3 pos;
	Quaternion rot;
	public float away = 0;
	public Transform Bullet, SmallBullet, LargeBullet;
	bool spawn = false;


	// Use this for initialization
	void Start () {
	}

	
	// Update is called once per frame
	void Update () {

		/*
		pos = transform.position;
		pos.x += 10;
		pos.z -= away;
		int num = Random.Range (0, 55);

		if(spawn == false) {Instantiate (SmallBullet, pos, rot);
			spawn = true; 
		}
		else {
			StartCoroutine(waitPlz ());
			spawn = false;
		}



		
		if (num <= 30 )
		{
			
			//StartCoroutine( spawnEnemy(SmallBullet, 1));
		}
		else if (num > 30 && num <= 45)
		{
			//Bullet = (GameObject)Resources.Load ("BBBe", typeof(GameObject));
			//spawnEnemy(Bullet, 10);
		}
		else 
		{
			//LargeBullet = (GameObject)Resources.Load ("BBBe", typeof(GameObject));
			//spawnEnemy(LargeBullet, 20);
		}
*/

	}
	IEnumerator waitPlz () {
		yield return new WaitForSeconds(10);
	}


	IEnumerator spawnEnemy(Transform enemy, float waitTime)
	{
		yield return new WaitForSeconds(waitTime);
		Instantiate (enemy, pos, rot);
		
	}

}
