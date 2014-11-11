using UnityEngine;
using System.Collections;

public class p1ScoreCounter : MonoBehaviour {

	public float p1Score;
	public float p1ScoreIncrementer;
	public GUIText p1ScoreGUI;
	public GameObject playerUno;


	// Use this for initialization
	void Start () {
		p1Score = 0;
		p1ScoreIncrementer = 1;
	}
	
	// Update is called once per frame
	void Update () {
		if(playerUno.activeInHierarchy)
			p1Score = p1Score + p1ScoreIncrementer;
		setScore ();

	}

	void setScore(){
		p1ScoreGUI.text =p1Score.ToString ();
	}
}
