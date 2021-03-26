using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameEnd : MonoBehaviour
{
    public GameObject GameOverUI;
    public GameObject GameWinUI;
    public GameObject BackgroundMusic;
    public Text timerText;

    private bool haveLost = false; // For tracking whether the gameover UI is enabled
    private bool haveWon = false; // For tracking whether the gamewin UI is enabled
    private AudioSource bckgrnd;

    private float elapsedTime = 0.0f; // Timer

    // Start is called before the first frame update
    void Start()
    {
        GameOverUI.SetActive(false);
        GameWinUI.SetActive(false);
        bckgrnd = BackgroundMusic.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        haveLost = GameOverUI.activeSelf; // Checks if UI elements active
        haveWon = GameWinUI.activeSelf;

        if (!haveLost && !haveWon) timer();

        if (haveWon)
        {
            elapsedTime = Mathf.Round(elapsedTime * 100) / 100; // Rounds to 2 decimals
            bckgrnd.Stop(); // Stops music

            timerText.text = elapsedTime.ToString() + "s";
        }

        if (haveLost) bckgrnd.Stop(); // Stops music
    }

    public void startGame()
    {
        SceneManager.LoadScene(1);
    }

    public void closeGame()
    {
        Application.Quit();
    }

    private void timer()
    {
        elapsedTime += Time.deltaTime;
    }
}
