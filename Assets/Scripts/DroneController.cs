using System;
using System.Collections;
using UnityEngine;

public class DroneController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float speed;
    private Rigidbody rb;
    
    [Header("HP")]
    [SerializeField] private float bateria;
    private bool isDamaged;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
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
        
        if(bateria <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void LateUpdate()
    {
        Movement();
    }

    void Movement()
    {
        float movX = Input.GetAxis("Horizontal");
        float movY = Input.GetAxis("Vertical");

        //Vector3 velocidad = rb.linearVelocity;
        transform.Translate(movX * speed * Time.deltaTime, 0 , movY * speed * Time.deltaTime);
        //rb.linearVelocity = velocidad;
    }

    void Ascende()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    void Descend()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }

    void TakeDamage(float damage)
    {
        isDamaged = true;
        bateria -= damage;
        StartCoroutine(DamageCooldown());
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle" && !isDamaged)
        {
            TakeDamage(1);
        }
    }

    IEnumerator DamageCooldown()
    {
        yield return new WaitForSeconds(1);
        isDamaged = false;
    }
}
