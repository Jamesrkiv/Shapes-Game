using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnd : MonoBehaviour
{
    public GameObject GameOverUI;
    public GameObject BackgroundMusic;

    private bool isOn = false; // For tracking whether the gameover UI is enabled

    // Start is called before the first frame update
    void Start()
    {
        GameOverUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        isOn = GameOverUI.activeSelf;
        if (isOn)
        {
            BackgroundMusic.GetComponent<AudioSource>().Stop(); // Stops music
        }
    }

    public void startGame()
    {
        SceneManager.LoadScene(1);
    }

    public void closeGame()
    {
        Application.Quit();
    }
}
