using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
   // [SerializeField] List<IEnemy> enemies;
    public void Spawn()
    {
       // IEnemy enemy = Instantiate(enemies[Random.Range(0, enemies.Count)], transform.position, new Quaternion());
    }

    private void Update()
    {
       // IEnemy enemy = Instantiate(enemies[Random.Range(0, enemies.Count)], transform.position, new Quaternion());
        Destroy(gameObject);
    }

}
