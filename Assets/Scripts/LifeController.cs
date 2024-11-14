using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LifeController : MonoBehaviour
{
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI menuText;
    public GameObject mainMenuCanvas;
    private int lives = 5;

    void Start()
    {
        UpdateLivesText();
        mainMenuCanvas.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Cube"))
        {
            lives--;
            UpdateLivesText();

            Destroy(other.gameObject);

            if (lives <= 0)
            {
                EndGame();
            }
        }
    }

    private void UpdateLivesText()
    {
        livesText.text = "Lives: " + lives;
    }

    private void EndGame()
    {
        mainMenuCanvas.SetActive(true);
        Time.timeScale = 0;
        menuText.text = "Game Over";
    }
}
