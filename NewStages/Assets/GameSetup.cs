using UnityEngine;
using System.Collections;

public class GameSetup : MonoBehaviour
{
		public bool buttonState;
		public string textFieldState;
		public GUIStyle headerStyle;
		public int selectedLevel = -1;

		// Use this for initialization
		void Start ()
		{
				buttonState = true;
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}

		void OnGUI ()
		{
				int xOffset = (Screen.width - 600) / 2;
				int yOffset = (Screen.height - 400) / 2;
		
				Rect pos = new Rect (xOffset, yOffset, 600, 25);
				GUI.Label (pos, "Choose Level", headerStyle);
		
				pos.y += 50;
				pos.height = 175;
				GUI.Box (pos, "");
		
				int x;
				int y;
				int levelNumber = 1;
				
				for (x = 0; x < 3; x++) {
						pos.x = xOffset + 175 + x * 100;
						pos.y = yOffset + 50 + 50;
						pos.width = pos.height = 50;
				
						if (GUI.Button (pos, levelNumber.ToString ())) {
								selectedLevel = levelNumber;
						}
						levelNumber++;
				}
				
		
				pos.x = xOffset + 0;
				pos.y = yOffset + 400;
				pos.width = 600;
				pos.height = 20;
				string levelNameString = "";
				
				switch (selectedLevel) {
				case 1:
						levelNameString = "Green Hills";
						break;
				case 2:
						levelNameString = "Windows Extreme";
						break;
				case 3:
						levelNameString = "Spooky Meadow";
						break;
				default:
						levelNameString = "none";
						break;
				}
				GUI.Label (pos, "Selected level: " + levelNameString + "!");
		}
		
		
		
//				int xOffset = (Screen.width - 150) / 2;
//				int yOffset = (Screen.height / 2) + 50;
//				Rect pos = new Rect (xOffset, yOffset, 150, 20);
//				Rect windowRect = new Rect (xOffset, yOffset, 120, 50);
//				pos.y += 30;
//		
//				if (buttonState) {
//						if (GUI.Button (pos, "Play Game")) {
//				
//								Debug.Log ("Clicked the play game button");
//								windowRect = GUI.Window (0, windowRect, DoMyWindow, "MyWindow");
//							
//								pos.y += 50;
//								pos.height = 350;
//								GUI.Box (pos, "");
//				
//						}
//						pos.y += 30;
//				}
//				
//				
//		
//		}
//		
//		void DoMyWindow(int windowID) {
//		if (GUI.Button(new Rect(10, 20, 100, 20), "Hello World"))
//			print("Got a click");
//		
//	}
		
}
