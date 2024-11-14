using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpawnController : MonoBehaviour
{
    public GameObject[] cubes;
    public Transform[] points;
    public float beat = (60 / 130) * 2;
    private float timer;

    public AudioSource mainAudio;
    public GameObject mainMenuCanvas;
    public TextMeshProUGUI menuText;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (timer > beat)
        {
            GameObject cube = Instantiate(cubes[Random.Range(0, 2)], points[Random.Range(0, 4)]);
            cube.transform.localPosition = Vector3.zero;
            cube.transform.Rotate(transform.forward, 90 * Random.Range(0, 4));
            timer -= beat;
        }
        timer += Time.deltaTime;

        if (mainAudio != null && !mainAudio.isPlaying)
        {
            FinishGame();
        }
    }

    void FinishGame()
    {
        mainAudio.Stop();

        Time.timeScale = 0;

        mainMenuCanvas.SetActive(true);

        menuText.text = "You Won!";
    }
}
