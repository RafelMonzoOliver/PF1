using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

public class DroneController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float _speed;
    
    [Header("HP")]
    [SerializeField] private float _bateria;
    private bool _isDamaged;
    
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        { 
            Ascende();
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            Descend();
        }
        
        if(_bateria <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void LateUpdate()
    {
        //En LateUpdate te aseguras de que los Input.GetKey no produzcan errores en el movimiento basico
        Movement();
    }

    void Movement()
    {
        float movX = Input.GetAxis("Horizontal");
        float movY = Input.GetAxis("Vertical");

        transform.Translate(movX * _speed * Time.deltaTime, 0 , movY * _speed * Time.deltaTime);
    }

    void Ascende()
    {
        transform.Translate(Vector3.up * _speed * Time.deltaTime);
    }

    void Descend()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
    }

    public void TakeDamage(float damage)
    {
        _isDamaged = true;
        _bateria -= damage;
        StartCoroutine(DamageCooldown());
    }
    

    IEnumerator DamageCooldown()
    {
        yield return new WaitForSeconds(1);
        _isDamaged = false;
    }
}
