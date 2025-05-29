using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;

public class jugadorMovimiento : MonoBehaviour
{
    //Variable global
    public GameObject BalaPrefab;
    private Rigidbody2D Rigidbody2D;
    private float Horizontal;
    public float Velocidad;
    public float JumpForce;
    private bool Grounded;
    private Animator Animator;
    private float TiempoDelUltimoDisparo;
    private int vidas = 5;
    Vector3 InitPosition ;

    void Start()
    {
        //Para acceder a la posición principal del jugador
        //this: el objeto que tiene el scrpt (jugador)
        InitPosition = this.transform.position;  
        //Lo que hace está función es coger el componente y lo integra al script
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
    }

    void Update()
    {
        //Es para almacenar valores reales, Get es para llamar la función y como paremetro se le pasa un String 
        // Para obtener valores cuando la persona presione una tecla.
        Horizontal = Input.GetAxisRaw("Horizontal") ;

        
        // Para que se gire a la izquierda
        if (Horizontal<0.0f)
        {transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        }
        else if (Horizontal>0.0f )
        {
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

        }

        // La animación de correr, cuando es == 0 no se esta moviendo
        Animator.SetBool("Running", Horizontal != 0.0f);



        //Para poder ver el resultado del rayo
        Debug.DrawRay(transform.position, Vector2.down * 0.1f, Color.red);

        //Es una función que lanza un rayo desde la posición del jugador hacia abajo 
        // SI esto choca con algo es true
        if (Physics2D.Raycast(transform.position,Vector2.down,0.1f))
        {
            Grounded = true;
        }
        else
        {
            Grounded= false;
        }

        //Condicional para el salto 
        if ( Grounded && ( Input.GetKeyDown(KeyCode.W)|| Input.GetKeyDown(KeyCode.UpArrow)))
            {
            Jump();
        }
        // time es para incrementar el tiempo y despues de 0.25 de cada disparo se pueda diaparar de nuevo.
        if (Input.GetKeyDown(KeyCode.Space)&& Time.time > TiempoDelUltimoDisparo + 0.25f)
        {
            Disparar();
            TiempoDelUltimoDisparo= Time.time;  
        }
    }
    private void Jump()
    {
        //Es una funcion que coge el vector y le añade una fuerza verticar acendente 
        Rigidbody2D.AddForce(Vector2.up*JumpForce);
    }

    //Instancia, coge los prefabricados y lo duplica en alguin sitio del mundo
    private void Disparar()
    {
        //Para definir la direccion se hace un vector, y con el local scate nos sirve 
        Vector3 direccion;
        if (transform.localScale.x == 1.0f)
        {
            direccion = Vector2.right;
        }
        else
        {
            direccion = Vector2.left;
        }

        //se hace referencia al objeto que se creo Bala
        //+direccion*0.1f coge el centro del jugador para que la bala no salga de ahí 
        GameObject Bala =  Instantiate(BalaPrefab, transform.position + direccion * 0.1f, Quaternion.identity);
        //Se obtiene el documento del script de la Bala
        Bala.GetComponent<BalaScript>().SetDireccion(direccion);
    }

    //Velocidad del jugador, para trabajar con las fisicas (se actualizan constantemente y no pueden ir en el Update)
    private void FixedUpdate()
    {
        // Necesita un vector "x", "y" que indican izq y der
        //Solo se hace con la "y" porque es la que se mueve horzontal
        Rigidbody2D.velocity = new Vector2 (Horizontal, Rigidbody2D.velocity.y);
    }
    public void Hit()
    {
        vidas -= 1;
        if (vidas == 0) Destroy(gameObject);
    }

    public void UnaVida()
    {
        vidas += 1;
    
    }
    public void AumentoVelocidad()
    {
        Velocidad += 500;
        JumpForce += 350;

    }

    public void ResetPosition()
    {
        //La posicion en la que me encuentro en la zona de muerte va a cambiar a la iniial
        this.transform.position = InitPosition;
    }



}
