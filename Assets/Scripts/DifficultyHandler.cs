using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyHandler : MonoBehaviour
{
    public HPScriptableObject enemyHP;
    public GameObject enemy;
    private GameObject diff;

    private int difficultyLvl;

    // Start is called before the first frame update
    void Start()
    {
        diff = GameObject.Find("DifficultyLevel");

        if (diff != null)
        {
            difficultyLvl = diff.GetComponent<difficultyLevel>().difficulty;
            switch (difficultyLvl)
            {
                case 1:
                    enemyHP.enemyMaxHP = 50;
                    enemyHP.StartingPlayerMaxHP = 100;
                    enemyHP.playerMaxHP = 100;
                    enemy.GetComponent<HealthPoints>().MaxHP = enemyHP;
                    break;

                case 2:
                    enemyHP.enemyMaxHP = 75;
                    enemyHP.StartingPlayerMaxHP = 100;
                    enemyHP.playerMaxHP = 100;
                    enemy.GetComponent<HealthPoints>().MaxHP = enemyHP;
                    break;

                case 3:
                    enemyHP.enemyMaxHP = 100;
                    enemyHP.StartingPlayerMaxHP = 100;
                    enemyHP.playerMaxHP = 100;
                    enemy.GetComponent<HealthPoints>().MaxHP = enemyHP;
                    break;
            }
        }
        else Debug.Log("Difficulty failed to load");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
