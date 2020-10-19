using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData")]
public class EnemyData : ScriptableObject
{
    public string enemyName;
    public string description;
    public GameObject enemyModel;
    public int health = 1;
    public float speed = 2f;
    public float detectRange = 10f;
    public int damage = 1;
}
