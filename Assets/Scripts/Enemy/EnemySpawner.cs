using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Enemy
{
    public GameObject enemyPrefab;
    public GameObject[] patrolPoints;
}

public class EnemySpawner : MonoBehaviour
{
    public Enemy[] enemy;
    public List<GameObject> enemies;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.RefEnemySpawner(this);

        enemies = new List<GameObject>();

        for (int i = 0; i < enemy.Length; i++)
        {
            GameObject newEnemy = Instantiate(enemy[i].enemyPrefab, enemy[i].patrolPoints[0].transform.position, Quaternion.identity);
            enemies.Add(newEnemy);

            newEnemy.GetComponent<IEnemy>().InitializePatrolSize(enemy[i].patrolPoints.Length);

            for (int j = 0; j < enemy[i].patrolPoints.Length; j++)
            {
                newEnemy.GetComponent<IEnemy>().AssignPatrolPoints(enemy[i].patrolPoints[j], j);
            }
        }
    }

    public void ClearEnemy()
    {
        for (int i = 0; i < enemies.Count; i++)
        {
            Destroy(enemies[i]);
        }
        enemies.Clear();
    }
}
