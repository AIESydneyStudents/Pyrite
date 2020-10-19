using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Enemy")]
public class EnemyData : ScriptableObject
{
    public string enemyName;
    public string description;
    public GameObject enemyModel;
    public int health = 1;
    public float patrolSpeed = 3f;
    public float chaseSpeed = 6f;
    public float detectRange = 10f;
    public int damage = 1;
    public bool canChase;
    public bool canPatrol;
    public bool canShoot;

}
