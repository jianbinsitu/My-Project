using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

[System.Serializable]
public class spawn{
    public int numbEnemy = 20;
    public float spawnInterval = 2f;
    public GameObject Enemyprefab;
    public GameObject Enemyprefab1;
    public GameObject Enemyprefab2;
}

public class SpawnEnemy : MonoBehaviour
{
    public spawn[] waves;
    private static int enemyspawned = 0;
    public int timeBetweenWaves = 5;
    private float lastSpawnTime;
    private GameUI UI;

    public int E
    {
        get
        {
            return enemyspawned;
        }

        set
        {
            enemyspawned = value;
        }
    }

    void Start()
    {
        lastSpawnTime = Time.time;
        UI = GameObject.Find("GameManagerUI").GetComponent<GameUI>();
    }

    void Update()
    {
        int x = Random.Range(0, 3);
        int currentwave = UI.Waves;
        if (currentwave == 5 || currentwave == 10 || currentwave == 15)
        {
            x = 0;
        }
        if (currentwave < waves.Length)
        {
            float timeInterval = Time.time - lastSpawnTime;
            float spawnInterval = waves[currentwave].spawnInterval;
            if(((enemyspawned == 0 && timeInterval > timeBetweenWaves) || timeInterval > spawnInterval) && enemyspawned < waves[currentwave].numbEnemy)
            {
                lastSpawnTime = Time.time;
                if (x == 0)
                {
                    GameObject clone = (GameObject)Instantiate(waves[currentwave].Enemyprefab);
                    clone.transform.position = transform.position;
                }
                else if (x == 1)
                {
                    GameObject clone = (GameObject)Instantiate(waves[currentwave].Enemyprefab1);
                    clone.transform.position = transform.position;
                }
                else if (x == 2)
                {
                    GameObject clone = (GameObject)Instantiate(waves[currentwave].Enemyprefab2);
                    clone.transform.position = transform.position;
                }
                enemyspawned++;
            }
            if(enemyspawned == waves[currentwave].numbEnemy && GameObject.FindGameObjectWithTag("enemy") == null)
            {
                UI.Waves++;
                enemyspawned = 0;
                lastSpawnTime = Time.time;
            }
        }
        else
        {
            UI.youWin = true;
            SceneManager.LoadScene(6);
        }

    }

}

