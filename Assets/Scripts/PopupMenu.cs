using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.Collections.Generic;

public class PopupMenu : MonoBehaviour
{
    public GameObject popupMenuPrefab; 
    public GameObject buttonPrefab;
    private GameObject popupMenuInstance;
    private List<Button> buttons = new List<Button>();



    /* **NOTE** Keeping this here to show a template of how to code a popup menu
    // Shows menu on right click
    void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            ShowPopupMenu(new List<(string, Action)>
            {
                ("Button1", () => Debug.Log("Button1 clicked")),
                ("Button2", () => Debug.Log("Button2 clicked")),
                ("Button3", () => Debug.Log("Button3 clicked")),
                // Can add more buttons here
            });
        }
    }
    */

    // Show menu with dynamic buttons
    public void ShowPopupMenu(List<(string buttonText, Action buttonAction)> buttonConfigs)
    {
        if(popupMenuInstance != null)
        {
            Destroy(popupMenuInstance);
        }

        // Instantiate
        popupMenuInstance = Instantiate(popupMenuPrefab, transform);
        popupMenuInstance.transform.position = Input.mousePosition;

        // Clear previous
        buttons.Clear();

        // Create new buttons
        foreach(var config in buttonConfigs)
        {
            // Instantiate
            GameObject buttonObj = Instantiate(buttonPrefab, popupMenuInstance.transform);
            Button button = buttonObj.GetComponent<Button>();
            
            // Set TMP component
            TextMeshProUGUI buttonText = buttonObj.GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = config.buttonText;

            // Add button action
            button.onClick.AddListener(() => config.buttonAction());

            buttons.Add(button);
        }

        // Adjust size of menu based on button count
        RectTransform rectTransform = popupMenuInstance.GetComponent<RectTransform>();
        rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, buttons.Count * 30);
    }

    // Hide popup menu
    public void HidePopupMenu()
    {
        if(popupMenuInstance != null)
        {
            Destroy(popupMenuInstance);
        }
    }
}
