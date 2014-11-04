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
				
				
				pos.x += 500;
				pos.width = 100;
				
				
				if (GUI.Button (pos, "Click to play!")) {
						print ("Got a click");
						switch (levelNameString) {
						case "Green Hills":
								Application.LoadLevel ("MarioLevel");
								break;
						case "Windows Extreme":
								Application.LoadLevel ("DesktopLevel");
								break;
						default:
								break;
						}
				}
				
		}
	
}
