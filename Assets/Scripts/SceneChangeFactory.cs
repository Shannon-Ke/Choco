using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneChangeFactory : MonoBehaviour
{
    public Button IDButton, moneyButton, townButton, storeButton, inventoryButton, settingsButton;
    public CanvasGroup inventory, id;
    void Start()
    {
        IDButton.onClick.AddListener(Id);
        storeButton.onClick.AddListener(Store);
        settingsButton.onClick.AddListener(Settings);
        inventoryButton.onClick.AddListener(Inventory);
        townButton.onClick.AddListener(Map);
        Deactivate(inventory);
        Deactivate(id);
    }
    void Store() { SceneManager.LoadScene("Store"); }
    void Settings()
    {
        GameControl.control.prevScene = "Factory";
        SceneManager.LoadScene("Settings");
    }
    void Map() { SceneManager.LoadScene("Town"); }
    void Inventory()
    {
        if (id.interactable) { Deactivate(id); }
        if (!inventory.interactable) { Activate(inventory); }
        else { Deactivate(inventory); }
    }
    void Id()
    {
        if (inventory.interactable) { Deactivate(inventory); }
        if (!id.interactable) { Activate(id); }
        else { Deactivate(id); }
    }
    public void Deactivate(CanvasGroup canvas)
    {
        canvas.alpha = 0f;
        canvas.interactable = false;
        canvas.blocksRaycasts = false;
    }
    public void Activate(CanvasGroup canvas)
    {
        canvas.alpha = 1f;
        canvas.interactable = true;
        canvas.blocksRaycasts = true;
    }

}
