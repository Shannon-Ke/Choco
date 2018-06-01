using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneChangeTown : MonoBehaviour
{
    public Button IDButton, moneyButton, shopButton, inventoryButton, settingsButton;
    public CanvasGroup inventory, id;
    void Start()
    {
        IDButton.onClick.AddListener(Id);
        //factoryButton.onClick.AddListener(Factory);
        settingsButton.onClick.AddListener(Settings);
        inventoryButton.onClick.AddListener(Inventory);
        shopButton.onClick.AddListener(Shop);
        Deactivate(inventory);
        Deactivate(id);
    }
    //void Factory() { SceneManager.LoadScene("Factory"); }
    void Settings()
    {
        GameControl.control.prevScene = "Town";
        SceneManager.LoadScene("Settings");
    }
    void Shop() { SceneManager.LoadScene("Store"); }
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
