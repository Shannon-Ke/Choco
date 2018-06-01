using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.UI;

public class GameControl : MonoBehaviour {
    public static GameControl control;
    public string username;
    public int money;
    public string prevScene;
  
    void Awake()
    {
        if (control == null) {
            DontDestroyOnLoad(gameObject);
            control = this;
        } else if (control != this) {
            Destroy(gameObject);
        }

    }
    private void OnDisable()
    {
        if (File.Exists(Application.persistentDataPath + "playerInfo.dat"))
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
            PlayerData data = new PlayerData();

            data.username = username;
            data.money = money;
           
            binaryFormatter.Serialize(file, data);
            file.Close();

        }
    }
    private void OnEnable()
    {
        if (File.Exists(Application.persistentDataPath + "playerInfo.dat"))
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
            PlayerData data = (PlayerData)binaryFormatter.Deserialize(file);
            file.Close();

            username = data.username;
            money = data.money;

        } else {
            
            FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");
            file.Close();

        }
    }

    //private void OnGUI()
    //{
    //    if (user != null) {
    //        Debug.Log(username);
    //        user.text = username;
    //    }
    //}

}

class PlayerData {
    public string username;
    public int money;

}