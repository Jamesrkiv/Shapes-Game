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
    private static int enemyRemains;

    public GameObject player;
    private HealthPoints playerHP;

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
    }
}
