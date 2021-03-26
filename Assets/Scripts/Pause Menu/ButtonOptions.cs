using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonOptions : MonoBehaviour
{
    public GameObject softClick;
    private AudioSource soft;

    // Start is called before the first frame update
    void Start()
    {
        soft = softClick.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void quitGame()
    {
        soft.Play();
        Application.Quit();
    }

    public void playGame()
    {
        soft.Play();
        SceneManager.LoadScene(1);
    }
}
