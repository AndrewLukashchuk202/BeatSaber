using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class MainMenuManager : MonoBehaviour
{

    [Header("Menu Objects")]
    public GameObject mainMenu;
    public bool IsStaticMenu = true;

    [Header("Menu Position")]
    public Transform playerHead;
    public float spawnDistance = 2;
   
    public InputActionProperty showButton;
    
    [Header("Sounds")]
    public AudioClip menuItemHover;
    public AudioClip menuMusic;

    public AudioSource musicAudioSource;
    public AudioSource effectAudioSource;

    private void Start()
    {
        if (musicAudioSource == null)
        {
            Debug.LogError("MusicAudioSource not set in MainMenu.cs");
        }

        if (effectAudioSource == null)
        {
            Debug.LogError("EffectAudioSource not set in MainMenu.cs");
        }

        musicAudioSource.clip = menuMusic;
        musicAudioSource.Play();

        QualitySettings.vSyncCount = 1;
    }

    private void Update()
    {
        if (showButton.action.WasPerformedThisFrame())
        {
            if (!IsStaticMenu) 
            {
                mainMenu.SetActive(!mainMenu.activeSelf);
            }            
        }

        // Make the menu appear infront of the player
        mainMenu.transform.position = playerHead.position + new Vector3(playerHead.forward.x, 0, playerHead.forward.z).normalized * spawnDistance;

        // Rotate the menu to always face the player
        mainMenu.transform.LookAt(new Vector3(playerHead.position.x, mainMenu.transform.position.y, playerHead.transform.position.z));
        mainMenu.transform.forward *= -1;
    }

    public void PlayMenuHover()
    {
        effectAudioSource.PlayOneShot(menuItemHover);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;       
        #endif

        Application.Quit();
    }
}
