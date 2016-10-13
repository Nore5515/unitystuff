using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
public class SaveLoad : MonoBehaviour
{
	//public static class saveLoad 
	//{
	
		public static List<Game> savedGames = new List<Game>();
	
		//it's static so we can call it from anywhere
		public static void Save() 
		{
			savedGames.Add(Game.current);

			BinaryFormatter bf = new BinaryFormatter();

			//Application.persistentDataPath is a string, so if you wanted you can put that into debug.log if you want to know where save games are located

			FileStream file = File.Create (Application.persistentDataPath + "/savedGames.gd"); //you can call it anything you want

			bf.Serialize(file, savedGames);

			file.Close();
		}   
	
		public static void Load() {
			if(File.Exists(Application.persistentDataPath + "/savedGames.gd")) {

				BinaryFormatter bf = new BinaryFormatter();

				FileStream file = File.Open(Application.persistentDataPath + "/savedGames.gd", FileMode.Open);

				savedGames = (List<Game>)bf.Deserialize(file);

				file.Close();
			}
		}
	//}
}