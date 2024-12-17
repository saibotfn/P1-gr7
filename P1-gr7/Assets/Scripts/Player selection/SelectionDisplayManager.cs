using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectionDisplayManager : MonoBehaviour
{
    public Button[] characterButtons;   // Buttons for selecting characters
    public Button[] carButtons;         // Buttons for selecting cars
    public GameObject displayPanel;     // Panel containing all animation display GameObjects
    public Button startButton;          // Button to start the game

    private int selectedCharacterIndex = -1; // Index of the selected character
    private int selectedCarIndex = -1;       // Index of the selected car

    void Start()
    {
        // Initially hide UI elements (display panel and start button)
        displayPanel.SetActive(false);
        startButton.gameObject.SetActive(false);

        // Assign listeners to character buttons
        for (int i = 0; i < characterButtons.Length; i++)
        {
            int index = i; // Cache index to avoid closure issues in the loop
            characterButtons[i].onClick.AddListener(() => SelectCharacter(index));
        }

        // Assign listeners to car buttons
        for (int i = 0; i < carButtons.Length; i++)
        {
            int index = i; // Cache index to avoid closure issues
            carButtons[i].onClick.AddListener(() => SelectCar(index));
        }
    }

    // Triggered when a character button is clicked
    void SelectCharacter(int index)
    {
        // Hide the checkmark for the previously selected character, if any
        if (selectedCharacterIndex != -1)
        {
            characterButtons[selectedCharacterIndex].transform.GetChild(0).gameObject.SetActive(false); // Assuming the checkmark is the first child
        }

        selectedCharacterIndex = index; // Update selected character
        PlayerSelections.instance.character = selectedCharacterIndex;

        Debug.Log($"Character {index} selected");

        // Show the checkmark for the newly selected character
        characterButtons[selectedCharacterIndex].transform.GetChild(0).gameObject.SetActive(true);

        UpdateDisplay();
    }

    // Triggered when a car button is clicked
    void SelectCar(int index)
    {
        // Hide the checkmark for the previously selected car, if any
        if (selectedCarIndex != -1)
        {
            carButtons[selectedCarIndex].transform.GetChild(0).gameObject.SetActive(false); // Assuming the checkmark is the first child
        }

        selectedCarIndex = index; // Update selected car
        PlayerSelections.instance.car = selectedCarIndex;


        Debug.Log($"Car {index} selected");

        // Show the checkmark for the newly selected car
        carButtons[selectedCarIndex].transform.GetChild(0).gameObject.SetActive(true);

        UpdateDisplay();
    }

    // Updates the display panel to show the selected character and car animation
    void UpdateDisplay()
    {
        if (selectedCharacterIndex != -1 && selectedCarIndex != -1) // Both character and car are selected
        {
            displayPanel.SetActive(true); // Show the display panel
            startButton.gameObject.SetActive(true); // Enable the start button

            // Hide all child GameObjects under the displayPanel
            foreach (Transform child in displayPanel.transform)
            {
                child.gameObject.SetActive(false);
            }

            // Calculate the name of the corresponding GameObject
            string gameObjectName = $"Char{selectedCharacterIndex}&Car{selectedCarIndex}";

            // Find and activate the correct GameObject
            Transform selectedObject = displayPanel.transform.Find(gameObjectName);
            if (selectedObject != null)
            {
                selectedObject.gameObject.SetActive(true); // Show the corresponding animation display
                Debug.Log($"Displaying {gameObjectName}");
            }
            else
            {
                Debug.LogError($"GameObject {gameObjectName} not found under DisplayPanel!");
            }
        }
        else
        {
            // Hide the display panel and start button if selections are incomplete
            displayPanel.SetActive(false);
            startButton.gameObject.SetActive(false);
        }
    }

    // Loads the game scene
    void StartGame()
    {
        //PlayerPrefs.SetInt("SelectedCharacter", selectedCharacterIndex);
        //PlayerPrefs.SetInt("SelectedCar", selectedCarIndex);

        Debug.Log("character index selected:"+selectedCharacterIndex);
        Debug.Log("car index selected:"+selectedCarIndex);

        PlayerSelections.instance.character = selectedCharacterIndex;
        PlayerSelections.instance.car = selectedCarIndex;



        SceneManager.LoadScene("OneDirection");
    }
}