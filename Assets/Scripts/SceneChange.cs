using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour {
    public Button enterButton, settingsButton;
	void Start () {
        enterButton.onClick.AddListener(Enter);
        settingsButton.onClick.AddListener(Settings);
	}
    void Enter() { SceneManager.LoadScene("Store"); }
    void Settings() { SceneManager.LoadScene("Settings"); }
}
