using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnaVidaScript : MonoBehaviour
{
    jugadorMovimiento jm;
    public GameObject UnaVida;
    void Start()
    {
        jm = FindObjectOfType<jugadorMovimiento>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            jm.UnaVida();
            Destroy(gameObject);
        }
    }


}
