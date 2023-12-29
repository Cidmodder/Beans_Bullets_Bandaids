using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class commanderAI : MonoBehaviour
{

    public List<GameObject> enemySpawnPoints;
    public List<GameObject> allySpawnPoints;
    public List<GameObject> objectives;
    public List<GameObject> enemyobjectives;
    public List<GameObject> allyobjectives;
    public List<GameObject> enemyUnits;
    public List<GameObject> allyUnits;

    public List<GameObject> spawnedEnemies;
    public List<GameObject> spawnedAllies;

    public float enemySpawnTime;
    public float allySpawnTime;
    public int wave;


    // Start is called before the first frame update
    void Start()
    {
        enemySpawnTime = 5;
        allySpawnTime = 10;
        wave = 1;

        
    }

    public void setWave(int wave)
    {
        this.wave = wave;
    }

    // Update is called once per frame
    void Update()
    {
        enemySpawnTime -= Time.deltaTime;
        allySpawnTime -= Time.deltaTime;

        if (wave == 1)
        {
            
            if (enemySpawnTime <= 0)
            {
                int enemyIndex = Random.Range(0, 3);
                int objectiveIndex = Random.Range(0, 3);
                enemySpawnTime = 20;

                GameObject enemy = Instantiate(enemyUnits[0], enemySpawnPoints[enemyIndex].transform.position, Quaternion.identity);
                enemyUnits.Add(enemy);
                enemy.gameObject.GetComponent<unitAI>().setObjective(objectives[objectiveIndex]);

            }

            if (allySpawnTime <= 0)
            {
                int allyIndex = Random.Range(0, 2);
                int objectiveIndex = Random.Range(0, 3);
                allySpawnTime = 25;
                GameObject ally = Instantiate(allyUnits[0], allySpawnPoints[allyIndex].transform.position, Quaternion.identity);
                allyUnits.Add(ally);
                ally.gameObject.GetComponent<unitAI>().setObjective(objectives[objectiveIndex]);
               
            }

        }

        if(wave == 2)
        {
            if (enemySpawnTime <= 0)
            {
                int enemyIndex = Random.Range(0, 5);
                int objectiveIndex = Random.Range(0, 3);
                enemySpawnTime = 20;
                GameObject enemy = Instantiate(enemyUnits[0], enemySpawnPoints[enemyIndex].transform.position, Quaternion.identity);
                enemyUnits.Add(enemy);
                enemy.gameObject.GetComponent<unitAI>().setObjective(objectives[objectiveIndex]);
                
            }

            if (allySpawnTime <= 0)
            {
                int allyIndex = Random.Range(0, 2);
                int objectiveIndex = Random.Range(0, 3);
                allySpawnTime = 25;
                GameObject ally = Instantiate(allyUnits[0], allySpawnPoints[allyIndex].transform.position, Quaternion.identity);
                allyUnits.Add(ally);
                ally.gameObject.GetComponent<unitAI>().setObjective(objectives[objectiveIndex]);
               
            }


        }


        if (wave == 3)
        {
            if (enemySpawnTime <= 0)
            {

                int enemyIndex = Random.Range(0, 7);
                int objectiveIndex = Random.Range(0, 3);
                enemySpawnTime = 20;
                GameObject enemy = Instantiate(enemyUnits[0], enemySpawnPoints[enemyIndex].transform.position, Quaternion.identity);
                enemyUnits.Add(enemy);
                enemy.gameObject.GetComponent<unitAI>().setObjective(objectives[objectiveIndex]);
               
            }

            if (allySpawnTime <= 0)
            {
                int allyIndex = Random.Range(0, 2);
                int objectiveIndex = Random.Range(0, 3);
                allySpawnTime = 25;
                GameObject ally = Instantiate(allyUnits[0], allySpawnPoints[allyIndex].transform.position, Quaternion.identity);
                allyUnits.Add(ally);
                ally.gameObject.GetComponent<unitAI>().setObjective(objectives[objectiveIndex]);
                
            }


        }

    }
}
