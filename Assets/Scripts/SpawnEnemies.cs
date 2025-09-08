using System.Collections;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    [SerializeField] private GameObject enemy1; 
    [SerializeField] private GameObject enemy2;
    [SerializeField] private GameObject enemy3;
     private float spawnRate;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }
    IEnumerator SpawnEnemy()
    {       
        while (true)
        {
            spawnRate = Random.Range(6, 12);
            yield return new WaitForSeconds(spawnRate);
            int chance = Random.Range(0, 5);
            if (chance < 3)
            {
                Instantiate(enemy1, transform.position, Quaternion.identity);
            }
            else if (chance > 3)
            {
                Instantiate(enemy2, transform.position, Quaternion.identity);
            }
            else
            {
                Instantiate(enemy3, transform.position, Quaternion.identity);
            }            
        }
    }
}
