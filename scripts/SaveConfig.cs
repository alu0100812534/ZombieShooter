using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

static class Constants
{
	public const string ExtFile = "zombie"; // extensión de los ficheros de guardado 
}

public static class SaveConfig {
	public static Game SavedGame = new Game();
    //estos métodos al ser estáticos se pueden llamar de cualquier lado
    //Guardamos el juego
    public static void Save() {
		SaveConfig.SavedGame = Game.current;
		BinaryFormatter bf = new BinaryFormatter(); // es necesario si queremos guardarlo en fichero
		//Application.persistentDataPath es un string
		FileStream file = File.Create (Application.persistentDataPath + "/savedConfig." + Constants.ExtFile + ""); //lo puedes llamar cuantas veces quieras
		bf.Serialize(file, SaveConfig.SavedGame);
		file.Close();
	}

	//Cargamos los datos del juego
	public static void Load() {
		if(File.Exists(Application.persistentDataPath + "/savedGames." + Constants.ExtFile + "")) {
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + "/savedConfig." + Constants.ExtFile + "", FileMode.Open);
			SaveConfig.SavedGame = (Game)bf.Deserialize(file);// convertimos el fichero serializado en objeto Game y lo guardamos
			file.Close(); // hay que evitar errores de lectura/Escritura ... cerrandolo correctamente
		}
	}
}