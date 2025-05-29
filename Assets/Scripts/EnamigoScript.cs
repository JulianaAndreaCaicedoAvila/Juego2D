using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class EnamigoScript : MonoBehaviour
{
    public GameObject BalaPrefab;
    public GameObject Jugador;
    private float TiempoDelUltimoDisparo;
    private int vidas = 3;


    void Update()
    {
        // Cuando se muere se suguie llamando algo que no esta por eso si es nulo retorna
        if (Jugador==null)return ;

        //La posicion del judagor menos la juagador del eneminod (la pos de que desde el jugador hasta el enemigo)
        Vector3 direccion = Jugador.transform.position - transform.position;

        //Para que voltee segun donde este el jugador

        if (direccion.x >= 0.0f)
        {transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }else
        { transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f); }

       
        //Es para que dispare segun la distancia y se pone el valor absoluto para eviatar negativos
        float distacia = Mathf.Abs(Jugador.transform.position.x - transform.position.x);

        if (distacia < 1.0f && Time.time > TiempoDelUltimoDisparo + 0.25f) { 
            Disparar();
            TiempoDelUltimoDisparo = Time.time; }

     }

    private void Disparar()
    {
        Vector3 direccion = new Vector3(transform.localScale.x, 0.0f, 0.0f);
        GameObject Bala = Instantiate(BalaPrefab, transform.position + direccion * 0.1f, Quaternion.identity);
        //Se obtiene el documento del script de la Bala
        Bala.GetComponent<BalaScript>().SetDireccion(direccion);

    }

    public void Hit()
    {
        vidas -= 1;
        if (vidas == 0) Destroy(gameObject);
    }



}
