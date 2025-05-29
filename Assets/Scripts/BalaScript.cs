using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BalaScript : MonoBehaviour
{
    //Variables globalesss
    private Rigidbody2D Rigidbody2D;
    public float Speed;
    private Vector2 Direccion;
    public AudioClip Sound;

    void Start()
    {
        //Lo que hace está función es coger el componente y lo integra al script
        Rigidbody2D = GetComponent<Rigidbody2D>();
        //Es para que la bala suene cuando se dispare
         Camera.main.GetComponent<AudioSource>().PlayOneShot(Sound);

    }
    private void FixedUpdate()
    {
        //Es para poder modificar la velocidad de la bala 
        Rigidbody2D.velocity = Direccion * Speed;
    }
    //Recibe la direccion y lo que hace es que darle valor 
    public void SetDireccion(Vector2 direccion)
    {
        Direccion = direccion;

    }
    public void DestruirBala()
    {
        // gameObjet es una referencia al objeto que contiene la Bala y lo otro es una función de Unity 
        Destroy(gameObject);
    }
   
    private void OnTriggerEnter2D(Collider2D other)
    {
        EnamigoScript Enemigo = other.GetComponent<EnamigoScript>();
        jugadorMovimiento jugador  = other.GetComponent<jugadorMovimiento>();

        if (Enemigo != null)
        {
            Enemigo.Hit();
        }
        if (jugador != null)
        {
            jugador.Hit();
        }
        DestruirBala();
    }
  
}
