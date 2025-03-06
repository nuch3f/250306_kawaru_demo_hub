using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy
{
    public int enemyId;
    public string enemyImg;
    public string enemyType;
    public bool enemyWeak;

    // コンストラクタ
    public Enemy(
        int enemyId,
        string enemyImg,
        string enemyType,
        bool enemyWeak
        )
    {
        EnemyId = enemyId;
        EnemyImg = enemyImg;
        EnemyType = enemyType;
        EnemyWeak = enemyWeak;
    }

    // プロパティ
    public int EnemyId;
    public string EnemyImg;
    public string EnemyType;
    public bool EnemyWeak;

}
