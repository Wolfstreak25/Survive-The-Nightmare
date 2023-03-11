using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyPool : ObjectPool<EnemyController>
{
    private EnemyView enemyPrefab;
    private EnemyModel enemyModel;
    public EnemyController GetPlayer(EnemyObject enemy)
    {
        enemyModel = new EnemyModel(enemy);
        enemyPrefab = enemy.View;
        return GetItem();
    }
    protected override EnemyController CreateItem()
    {
        EnemyController enemyController = new EnemyController(enemyModel, enemyPrefab);
        return enemyController;
    }
}