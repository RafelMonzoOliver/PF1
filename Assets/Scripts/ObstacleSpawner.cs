using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _obstacle;
    [SerializeField] private float _spawnCooldown;
    [FormerlySerializedAs("isSpawning")] public bool _isSpawning;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!_isSpawning)
        {
            SpawnEnemmy();
        }
    }

    void SpawnEnemmy()
    {
        _isSpawning = true;
        Vector3 randompos = new Vector3(Random.Range(-5f, 5f), 10f, 0f);
        Instantiate(_obstacle, randompos, Quaternion.identity);
        StartCoroutine(CooldownSpawn());
    }

    IEnumerator CooldownSpawn()
    {
        yield return new WaitForSeconds(_spawnCooldown);
        _isSpawning = false;
    }
}
