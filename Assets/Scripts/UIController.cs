using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    //UI Elements
    public Text Score;
    public Text remainingEnemies;
    public Text HP;
    public GameObject player;
    public GameObject pauseMenu;

    private static int enemyRemains;
    private HealthPoints playerHP;
    private bool paused = false;

    // Start is called before the first frame update
    void Start()
    {
        playerHP = player.GetComponent<HealthPoints>();
    }

    // Update is called once per frame
    void Update()
    {
        HP.text = playerHP.hp.ToString();
        enemyRemains = SpawnManager.enemyCount;
        remainingEnemies.text = enemyRemains.ToString();

        if (Input.GetKeyDown("escape") && !paused)
        {
            paused = true;
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
        }
        else if (Input.GetKeyDown("escape"))
        {
            paused = false;
            Time.timeScale = 1;
            pauseMenu.SetActive(false);
        }
    }
}
