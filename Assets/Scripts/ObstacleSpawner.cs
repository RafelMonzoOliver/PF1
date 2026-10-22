using System.Collections;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _obstacle;
    [SerializeField] private float spawnCooldown;
    public bool isSpawning;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isSpawning)
        {
            SpawnEnemmy();
        }
    }

    void SpawnEnemmy()
    {
        isSpawning = true;
        Vector3 randompos = new Vector3(Random.Range(-5f, 5f), 10f, 0f);
        Instantiate(_obstacle, randompos, Quaternion.identity);
        StartCoroutine(CooldownSpawn());
    }

    IEnumerator CooldownSpawn()
    {
        yield return new WaitForSeconds(spawnCooldown);
        isSpawning = false;
    }
}
