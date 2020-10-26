using UnityEngine;
using System.Collections;
using TMPro;
//using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public Transform Enemy;

    public Transform spawnPoint;

    public float timeBetweenWaves = 5.0f;
    private float countdown = 2.0f;

    public TextMeshProUGUI waveCountdownText;
    public TextMeshProUGUI waveIndexText;
    private int waveIndex = 0;

    //Every 5 seconds the new wave will start
    void Update ()
    {
        if (countdown <= 0.0f)
        {
            PlayerStats.userScore += 100;
            PlayerStats.userMoney += waveIndex * 25;
            //To start the function as it's a coroutine
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
            waveIndexText.text = "Wave: "+ waveIndex.ToString();
        }

        countdown -= Time.deltaTime;
        //Added Countdown timer to the ui this is what updates it
        waveCountdownText.text ="Next wave in: "+ Mathf.Floor(countdown).ToString();
    }
    //Coroutine function, using this so that enemies don't spawn on top of eachother each wave
    IEnumerator SpawnWave()
    {
        //Increase the wave count
        waveIndex++;
        for (int i = 0; i < waveIndex; i++)
        {
            //Spawns enemy
            SpawnEnemy();
            //Every 0.5 seconds new enemy will spawn
            yield return new WaitForSeconds(0.5f);
        }
       
        //waveIndex++;
    }
    //Spawn Enemy function we can set which enemy we want to spawn, set the spawn position and rotation 
    void SpawnEnemy()
    {
        Instantiate(Enemy, spawnPoint.position, spawnPoint.rotation);
    }
}
