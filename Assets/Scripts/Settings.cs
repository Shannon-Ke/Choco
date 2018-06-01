using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Settings : MonoBehaviour
{
    public Button back;
    void Start()
    {
        back.onClick.AddListener(Back);
    }
    void Back() { SceneManager.LoadScene(GameControl.control.prevScene); }

}
