using System;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    [SerializeField] private float _damage;

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
        //El tag se asegura que esta tocando al jugador
        if (other.tag == "Player")
        {
            other.GetComponent<DroneController>().TakeDamage(_damage);
        }
        Destroy(gameObject);
    }
}
