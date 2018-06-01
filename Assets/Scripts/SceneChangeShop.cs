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
    public CanvasGroup input, submitButton;
    public Button submit;
    public InputField userInput;
    void Start()
    {
        IDButton.onClick.AddListener(Id);
        factoryButton.onClick.AddListener(Factory);
        settingsButton.onClick.AddListener(Settings);
        inventoryButton.onClick.AddListener(Inventory);
        townButton.onClick.AddListener(Map);
        Deactivate(inventory);
        Deactivate(id);
        Deactivate(input);
        Deactivate(submitButton);
        submit.onClick.AddListener(Submit);
    }
    private void Update()
    {
        if (!GameControl.control.started) {
            Activate(input);
            Activate(submitButton);
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
        Deactivate(input);
        Deactivate(submitButton);
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
