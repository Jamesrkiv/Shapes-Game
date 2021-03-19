using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    //Score and Enemies Remaining UI 
    public Text Score;
    public Text remainingEnemies;
    private static int enemyRemains;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        enemyRemains = SpawnManager.enemyCount;
        remainingEnemies.text = enemyRemains.ToString();
    }
}
