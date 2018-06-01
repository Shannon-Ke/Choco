using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneChangeShop : MonoBehaviour
{
    public static SceneChangeShop toggle;
    public Button IDButton, moneyButton, townButton, factoryButton, inventoryButton, settingsButton;
    public CanvasGroup inventory, id;
    public CanvasGroup input, submitButton, gray;
    public Button submit;
    public InputField userInput;
    public Text user;
    void Start()
    {
        IDButton.onClick.AddListener(Id);
        factoryButton.onClick.AddListener(Factory);
        settingsButton.onClick.AddListener(Settings);
        inventoryButton.onClick.AddListener(Inventory);
        townButton.onClick.AddListener(Map);
        submit.onClick.AddListener(Submit);
        Deactivate(inventory);
        Deactivate(id);
        Deactivate(input);
        Deactivate(gray);
        Deactivate(submitButton);
    }
    private void Update()
    {
        if (string.Equals(GameControl.control.username, "")) {
            Activate(input);
            Activate(submitButton);
            Activate(gray);
        } else {
            user.text = GameControl.control.username;
        }

    }
    void Factory() { SceneManager.LoadScene("Factory"); }
    void Settings() {
        GameControl.control.prevScene = "Store";
        SceneManager.LoadScene("Settings"); 
    }
    void Map() { SceneManager.LoadScene("Town"); }
    void Inventory() {
        if (id.interactable) { Deactivate(id); }
        if (!inventory.interactable) { Activate(inventory); }
        else { Deactivate(inventory); }
    }
    void Id() {
        if (inventory.interactable) { Deactivate(inventory); }
        if (!id.interactable) { Activate(id); }
        else { Deactivate(id); }
    }
    void Submit()
    {
        GameControl.control.username = userInput.text;
        user.text = GameControl.control.username;
        Deactivate(input);
        Deactivate(submitButton);
        Deactivate(gray);
    }
    public void Deactivate(CanvasGroup canvas) {
        canvas.alpha = 0f;
        canvas.interactable = false;
        canvas.blocksRaycasts = false;
    }
    public void Activate (CanvasGroup canvas) {
        canvas.alpha = 1f;
        canvas.interactable = true;
        canvas.blocksRaycasts = true;
    }

}
