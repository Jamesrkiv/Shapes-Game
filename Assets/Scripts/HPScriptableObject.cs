using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MaxHP Setting")]
public class HPScriptableObject : ScriptableObject
{
    //Player and Enemies Max Health
    public int playerMaxHP;
    public int enemyMaxHP;
    public int StartingPlayerMaxHP;
}
