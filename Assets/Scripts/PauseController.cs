using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;

public class PauseController : MonoBehaviour
{
    public GameObject mainMenuCanvas;
    public GameObject settingsCanvas;
    public string mainLevelSceneName = "MainLevel";
    private bool isPaused = false;
    private XRNode inputSource = XRNode.RightHand;

    // Debounce variables
    public float menuToggleCooldown = 0.5f;
    private float lastMenuToggleTime = -1f; 
    private bool wasButtonPressed = false; 

    void Start()
    {
        isPaused = mainMenuCanvas.activeSelf;
        Time.timeScale = isPaused ? 0 : 1;
        settingsCanvas.SetActive(false);
    }

    void Update()
    {
        bool isButtonCurrentlyPressed = IsMenuButtonPressed();

        if (isButtonCurrentlyPressed && !wasButtonPressed &&
            (Time.unscaledTime - lastMenuToggleTime >= menuToggleCooldown))
        {
            TogglePauseMenu();
            lastMenuToggleTime = Time.unscaledTime; 
        }

        wasButtonPressed = isButtonCurrentlyPressed;
    }

    private bool IsMenuButtonPressed()
    {
        InputDevice device = InputDevices.GetDeviceAtXRNode(inputSource);

        bool menuPressed = false;
        if (device.TryGetFeatureValue(CommonUsages.menuButton, out menuPressed) && menuPressed)
        {
            return true;
        }

        bool primaryButtonPressed = false;
        if (device.TryGetFeatureValue(CommonUsages.primaryButton, out primaryButtonPressed) && primaryButtonPressed)
        {
            return true;
        }

        return false;
    }

    private void TogglePauseMenu()
    {
        isPaused = !isPaused;
        mainMenuCanvas.SetActive(isPaused);
        Time.timeScale = isPaused ? 0 : 1;
        Debug.Log($"Pause Menu Toggled: {isPaused} at time: {Time.unscaledTime}");
    }

    public void OnStartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(mainLevelSceneName);
    }

    public void OnCloseGame()
    {
        Application.Quit();
    }

    public void OnOpenSettings()
    {
        mainMenuCanvas.SetActive(false);
        settingsCanvas.SetActive(true);
    }

    public void OnBackToMainMenu()
    {
        settingsCanvas.SetActive(false);
        mainMenuCanvas.SetActive(true);
    }
}