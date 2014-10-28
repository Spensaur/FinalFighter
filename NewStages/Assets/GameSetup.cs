using UnityEngine;
using System.Collections;

public class GameSetup : MonoBehaviour
{
		public bool buttonState;
		public string textFieldState;

		// Use this for initialization
		void Start ()
		{

		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}
	

		void OnGUI ()
		{
		
				int xOffset = (Screen.width - 150) / 2;
				int yOffset = (Screen.height / 2) + 50;
				Rect pos = new Rect (xOffset, yOffset, 150, 20);
				//		Screen.width / 2, (Screen.height / 2) - 10
				pos.y += 30;
		
				if (GUI.Button (pos, "Play Game")) {
						buttonState = true;
						Debug.Log ("Clicked the play game button");
				}
				pos.y += 30;
				
		
		}
}
