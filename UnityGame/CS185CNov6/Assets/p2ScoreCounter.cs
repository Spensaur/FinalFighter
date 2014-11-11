using UnityEngine;
using System.Collections;

public class p2ScoreCounter : MonoBehaviour {

	public float p2Score;
	public float p2ScoreIncrementer;
	public GUIText p2ScoreGUI;
	public GameObject playerDos;
	
	
	// Use this for initialization
	void Start () {
		p2Score = 0;
		p2ScoreIncrementer = 1;
	}
	
	// Update is called once per frame
	void Update () {
		if (playerDos.activeInHierarchy)
			p2Score = p2Score + p2ScoreIncrementer;
		setScore ();
			
	}
			
	void setScore(){
		p2ScoreGUI.text =p2Score.ToString ();

	}
}
	
	