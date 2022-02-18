using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
   public static EnemySpawner instance;

   [SerializeField] private GameObject enemyPrefab;

   private GameObject newEnemy;

   [SerializeField] private Transform[] spawnPosition;

   [SerializeField] private int enemySpawnLimit = 10;
   
   [SerializeField]
   private List<GameObject> spawnEnemies = new List<GameObject>();

   [SerializeField] private float minSpawnTime = 2f, maxSpawnTime = 5f;

   private void Awake()
   {
      if (instance == null)
         instance = this;
   }

   private void Start()
   {
      Invoke("SpawnEnemy", Random.Range(minSpawnTime, maxSpawnTime));
   }

   void SpawnEnemy()
   {
      if(spawnEnemies.Count == enemySpawnLimit)
         return;

      newEnemy = Instantiate(enemyPrefab, spawnPosition[Random.Range(0, spawnPosition.Length)].position,
         Quaternion.identity);
      
      spawnEnemies.Add(newEnemy);
      
      Invoke("SpawnEnemy", Random.Range(minSpawnTime, maxSpawnTime));
   }

   public void EnemyDied(GameObject enemy)
   {
      spawnEnemies.Remove(enemy);
   }
}
