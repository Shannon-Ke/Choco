using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Settings : MonoBehaviour
{
    public Button back;
    public Button restart;
    void Start()
    {
        back.onClick.AddListener(Back);
        restart.onClick.AddListener(Restart);
    }
    void Back() { SceneManager.LoadScene(GameControl.control.prevScene); }
    void Restart() { GameControl.control.DeleteFile(); SceneManager.LoadScene("MainMenu"); }
}
