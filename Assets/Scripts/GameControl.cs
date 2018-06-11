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
    public float time = 0.0f;
    void Awake()
    {
        if (control == null) {
            DontDestroyOnLoad(gameObject);
            control = this;
        } else if (control != this) {
            Destroy(gameObject);
        }
        SaveFile();
        LoadFile();

    }
    public void SaveFile()
    {
        string destination = Application.persistentDataPath + "/playerInfo.dat";
        FileStream file;

        if (File.Exists(destination)) {
            file = File.OpenWrite(destination);
        }
        else {
            file = File.Create(destination);
        }
        Debug.Log(Application.persistentDataPath);
        PlayerData data = new PlayerData(username, money);

        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(file, data);
        file.Close();
        //if (File.Exists(Application.persistentDataPath + "playerInfo.dat"))
        //{
        //    //BinaryFormatter binaryFormatter = new BinaryFormatter();
        //    //FileStream file = File.OpenWrite(Application.persistentDataPath + "/playerInfo.dat");
        //    //PlayerData data = new PlayerData();

        //    //data.username = username;
        //    //data.money = money;
           
        //    //binaryFormatter.Serialize(file, data);
        //    //file.Close();
        //    string destination = Application.persistentDataPath + "/playerInfo.dat";
        //    FileStream file;

        //    if (File.Exists(destination)) file = File.OpenWrite(destination);
        //    else file = File.Create(destination);

        //    PlayerData data = new PlayerData();
        //    data.username = username;
        //    data.money = money;
        //    BinaryFormatter bf = new BinaryFormatter();
        //    bf.Serialize(file, data);
        //    file.Close();
        //}
    }
    public void LoadFile()
    {
        if (File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream file = File.OpenRead(Application.persistentDataPath + "/playerInfo.dat");
            PlayerData data = (PlayerData)binaryFormatter.Deserialize(file);
            file.Close();
            Debug.Log(data.username + " loaded file");
            username = data.username;
            money = data.money;

        } else {
            
            FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");
            Debug.Log("no file");

            file.Close();

        }
    }
    public void DeleteFile() {
        File.Delete(Application.persistentDataPath + "/playerInfo.dat");
        username = null;
        money = 0;
    }
    private void Update()
    {
        time += Time.deltaTime;
        if (time >= 60.0f) { timerEnded(); }
    }
    void timerEnded() {
        time = 0.0f;
    }

    //private void OnGUI()
    //{
    //    if (user != null) {
    //        Debug.Log(username);
    //        user.text = username;
    //    }
    //}

}
[System.Serializable]
class PlayerData {
    public string username;
    public int money;
    public PlayerData(string user, int moolah) {
        username = user;
        money = moolah;
    }
}