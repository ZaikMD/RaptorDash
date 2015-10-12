using UnityEngine;
using System.Collections;
using System.Text.RegularExpressions;

public class LoadLevel : MonoBehaviour 
{
	public Transform GroundTile;
	public Transform BackGroundTile;
	public Transform Player;
	public Transform spotLight;
	public Transform killZone;
	public Transform spike;

	public const string sGroundTile = "1";
	public const string sBackGroundTile = "0";
	public const string sPlayer = "P";
	public const string sSpotLight = "L";
	public const string sBlank = "X";
	public const string sKillZone = "K";
	public const string sSpike = "S";
	// Use this for initialization
	void Start () 
	{
		loadLevel ("/Levels/level1.txt");
	}

	string[][] readFile(string file)
	{
		string text = System.IO.File.ReadAllText (file);
		string[] lines = Regex.Split (text, "\r\n");
		int rows = lines.Length;

		string[][] levelBase = new string[rows][];
		for(int i = 0; i < lines.Length; i ++)
		{
			string[] stringsOfLine = Regex.Split(lines[i], "");
			levelBase[i] = stringsOfLine;
		}

		return levelBase;
	}

	public void loadLevel(string filePath)
	{
		string[][] level = readFile (Application.dataPath + filePath);
		
		for(int y = 0; y < level.Length; y++)
		{
			for(int x = 0; x < level[0].Length; x++)
			{
				switch (level[y][x])
				{
				case sGroundTile:
					Instantiate(GroundTile, new Vector3(x ,-y ,0), Quaternion.identity);
					break;
					
				case sBackGroundTile:
					Instantiate(BackGroundTile, new Vector3(x ,-y ,1), Quaternion.identity);
					break;
					
				case sPlayer:
					Instantiate(BackGroundTile, new Vector3(x ,-y ,1), Quaternion.identity);
					Instantiate(Player, new Vector3(x ,-y ,0), Quaternion.identity);
					break;

				case sBlank:
					break;

				case sSpotLight:
					Instantiate(BackGroundTile, new Vector3(x ,-y ,1), Quaternion.identity);
					Instantiate(spotLight, new Vector3(x ,-y ,0), spotLight.transform.rotation);
					break;

				case sKillZone:
					Instantiate(BackGroundTile, new Vector3(x ,-y ,1), Quaternion.identity);
					Instantiate(killZone, new Vector3 (x,-y, 0), Quaternion.identity);
					break;

				case sSpike:
					Instantiate(spike, new Vector3 (x,-y, 0), Quaternion.identity);
					break;

				}
			}
		}
	}
}

