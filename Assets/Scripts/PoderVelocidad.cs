using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoderVelocidad : MonoBehaviour
{
    public GameObject AumentoVelocidad;
    private float TiempoDePoder;

    jugadorMovimiento jm;

    void Start()
    {
        jm = FindObjectOfType<jugadorMovimiento>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        TiempoDePoder =10;

        if (collision.gameObject.CompareTag("Player")&& Time.time > TiempoDePoder + 0.50f)
        {
            TiempoDePoder = Time.time;
            jm.AumentoVelocidad();
            Destroy(gameObject);
             
         }
      
    }

}
