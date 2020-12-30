using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
   public Transform enemyPrefab;
   public Transform spawnPoint;
   public float timeBetweenWaves = 30f;
   public Text waveCountdownText;
    public float countdown = 10f;
    private int waveNumber = 1;
   void Update(){
       if(countdown <= 0f){
           StartCoroutine(SpawnWave());
           countdown = timeBetweenWaves;
       }
       
       countdown -= Time.deltaTime;

       countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);
 //Mathf.Round(countdown).ToString()
        waveCountdownText.text = string.Format("{0:00.00}",countdown);
          }

   IEnumerator SpawnWave(){
       PlayerStats.Rounds++;
       Debug.Log("Wave Incomming!");
      int numOfEnemies = waveNumber * waveNumber +1;

    for (int i = 0; i < numOfEnemies; i++)
    {
        SpawnEnemy();
        yield return new WaitForSeconds(0.2f);
    }
       waveNumber++;
   }

    void SpawnEnemy(){
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);

    }
}
