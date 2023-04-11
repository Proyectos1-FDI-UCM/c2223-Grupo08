using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveScript
{
    #region properties
    /// <summary>
    /// La sala guardada
    /// </summary>
    public static int room = 0;

    /// <summary>
    /// La escena guardada
    /// </summary>
    public static string scene = "Level1";
    #endregion

    #region methods
    /// <summary>
    /// Guarda la partida
    /// </summary>
    /// <param name="currentRoom">Sala a guardar</param>
    /// <param name="sceneName">Escena a guardar</param>
    public static void SaveFile(int currentRoom, string sceneName)
    {
        string destination = Application.persistentDataPath + "/save.dat";
        FileStream file;

        if (File.Exists(destination)) file = File.OpenWrite(destination);
        else file = File.Create(destination);

        GameData data = new GameData(currentRoom, sceneName);
        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(file, data);
        file.Close();
    }

    /// <summary>
    /// Carga la partida
    /// </summary>
    public static void LoadFile()
    {
        string destination = Application.persistentDataPath + "/save.dat";
        FileStream file;

        if (File.Exists(destination)) file = File.OpenRead(destination);
        else
        {
            Debug.LogError("File not found");
            return;
        }

        BinaryFormatter bf = new BinaryFormatter();
        GameData data = (GameData)bf.Deserialize(file);
        file.Close();

        SaveScript.room = data.room;
        SaveScript.scene = data.scene;
    }
    #endregion
}

/// <summary>
/// Datos de la partida a guardar y cargar
/// </summary>
[System.Serializable]
struct GameData
{
    public int room;
    public string scene;

    public GameData(int room, string scene)
    {
        this.room = room;
        this.scene = scene;
    }
}
