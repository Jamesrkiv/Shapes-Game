using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnManager : MonoBehaviour
{
    public GameObject powerUpPrefab; // Powerup
    public GameObject healthPack;
    public GameObject cashPrefab;
    public GameObject enemyPrefab;   // Enemy
    public float spawnRange = 9;

    public Text waveNum; // Current wave number
    public int maxRound; // Round to make it to

    public static int enemyCount;
    private int waveNumber = 1;

    public bool gameOver = false;

    private float cashRespawnTime = 10;

    public Shop shopManager;

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(waveNumber);
        SpawnPowerup();
        InvokeRepeating("SpawnCash", 5, cashRespawnTime);
    }

    // Update is called once per frame
    void Update()
    {
        gameOver = !GameObject.Find("Player");
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        if (enemyCount == 0 && !gameOver && waveNumber != maxRound)
        {
            waveNumber++;
            shopManager.showMenu();         //Shows buy menu
            if(shopManager.gameObject.activeSelf == false)
            {
                shopManager.closeMenu();
            }
            SpawnEnemyWave(waveNumber);
            SpawnPowerup();                //<-Spawns Healthpack on new Round
        }

        else if (waveNumber == maxRound && enemyCount == 0)
        {

            // WIN HERE <<<

            Debug.Log("You win!");
        }
        else if (gameOver)
        {

            // GAMEOVER HERE <<<

            Debug.Log("You lose!");
        }
    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        return new Vector3(spawnPosX, 0, spawnPosZ);
    }

    void SpawnEnemyWave(int enemiesToSpawn)
    {
        waveNum.text = enemiesToSpawn.ToString() + "/" + maxRound;

        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
    }

    void SpawnPowerup()
    {
        Instantiate(powerUpPrefab, GenerateSpawnPosition(), powerUpPrefab.transform.rotation);
        Instantiate(healthPack, GenerateSpawnPosition(), healthPack.transform.rotation);
    }

    void SpawnCash()
    {
        Instantiate(cashPrefab, GenerateSpawnPosition(), cashPrefab.transform.rotation);
    }

    public void closeShop()
    {
        shopManager.closeMenu();
    }
}
