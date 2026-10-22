using System;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    [SerializeField] private float _damage;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject, 4f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<DroneController>().TakeDamage(_damage);
        }
        Destroy(gameObject);
    }
}
