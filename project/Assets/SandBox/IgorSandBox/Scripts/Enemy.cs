using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyData enemyData;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(enemyData.patrolSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
