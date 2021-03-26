using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class difficultyLevel : MonoBehaviour
{
    public GameObject diff;
    public GameObject diffSettings;
    public int difficulty = 2;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(diff);
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
        diffSettings.SetActive(true);
    }

    public void closeMenu()
    {
        diffSettings.SetActive(false);
    }
}
