using UnityEngine;
public class EnemyService : Singleton<EnemyService>
{
    [SerializeField] private EnemyList ObjectList;
    [SerializeField] private Transform[] spawn;
    private EnemyController enemy;
    private EnemyPool pool;
    private int enemyWave = 1;
    private int enemyCount = 0;
    private int deathCount = 0;
    private void OnDisable()
    {
        EventManagement.Instance.OnEnemyDeath -= EnemyDeaths;
    }
    private void Start()
    {
        EventManagement.Instance.OnEnemyDeath += EnemyDeaths;
        pool = this.gameObject.GetComponent<EnemyPool>();
        EnemyWaves(enemyWave);
    }
    private void PlayerSpawn(int i)
    {
        enemy = pool.GetPlayer(ObjectList.Enemy[i]);
        enemy.ActivateEnemy(spawn);
    }
    private void EnemyWaves(int currentWave)
    {
        enemyCount = 1;//increasing enemy by wave number not implemented yet
        switch (currentWave)
        {
            case 1:
                enemyCount = 1;
                break;
            case 2:
                enemyCount = 2;
                break;
            case 3:
                enemyCount = 3;
                break;
            case 4:
                enemyCount = 4;
                break;
            case 5:
                enemyCount = 5;
                break;
            case 6:
                enemyCount = 6;
                break;
            default:
                break;
        }
        for (int i = 1; i <= enemyCount; i++)
        {
            PlayerSpawn(Random.Range(0, ObjectList.Enemy.Length));
        }
    }
    public void EnemyDeaths()
    {
        deathCount ++;
        if(deathCount == enemyCount)
        {
            EventManagement.Instance.WaveComplete(enemyWave);
            EnemyWaves(enemyWave += 1);
            deathCount = 0;
        }
    }
}