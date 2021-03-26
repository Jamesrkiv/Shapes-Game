using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class difficultyLevel : MonoBehaviour
{
    public GameObject diff;
    public GameObject diffSettings;
    public GameObject softClick;
    public int difficulty = 2;

    private AudioSource soft;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(diff);
        soft = softClick.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void diffEasy()
    {
        difficulty = 1;
        closeMenu();
    }

    public void diffReg()
    {
        difficulty = 2;
        closeMenu();
    }

    public void diffHard()
    {
        difficulty = 3;
        closeMenu();
    }

    public void openMenu()
    {
        soft.Play();
        diffSettings.SetActive(true);
    }

    public void closeMenu()
    {
        soft.Play();
        diffSettings.SetActive(false);
    }
}
