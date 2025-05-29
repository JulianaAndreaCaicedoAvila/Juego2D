using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class ZonaMuerteScript : MonoBehaviour
{
    jugadorMovimiento jm;

    void Start()
    {
        jm = FindObjectOfType<jugadorMovimiento>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            jm.Hit();
            jm.ResetPosition();
        }
    }

   
}
