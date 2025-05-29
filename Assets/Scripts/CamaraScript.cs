using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraScript : MonoBehaviour
{

    public GameObject Jugador;

    void Update()
    {
        //Si se muere la camara manda error, por eso si el jugaro existe se ejecuta el codigo
        if (Jugador != null)
        {
            Vector3 position = transform.position;
            position.x = Jugador.transform.position.x;
            transform.position = position;
        }
    }
}
