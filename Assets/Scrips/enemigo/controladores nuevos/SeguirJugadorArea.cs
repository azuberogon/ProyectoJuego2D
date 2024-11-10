using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeguirJugadorArea : MonoBehaviour
{
    /*public float radioBusqueda;
    public LayerMask capaJugador;
    public Transform transformJugador;
    public EstadosMovimiento estadoActual;
    public float velocidadMovimiento;
    public float distanciaMaxima;
    public Vector3 puntoInicial;
    public bool mirandoDerecha;


    public enum EstadosMovimiento
    {
        Esperando,
        Siguiendo,
        Volviendo
    }
    private void Start()
    {
        puntoInicial = transform.position;
    }


    private void FixedUpdate()
    {


        switch (estadoActual)
        {
            case EstadosMovimiento.Esperando:
                EstadoDeEspera();
                break;
            case EstadosMovimiento.Siguiendo:
                EstadoSiguiendo();
                break;
            case EstadosMovimiento.Volviendo:
                Estadovolviendo();

                break;
        }



        
    }


    private void EstadoDeEspera() 
    {
        Collider2D jugadorCollider = Physics2D.OverlapCircle(transform.position, radioBusqueda, capaJugador);

        if (jugadorCollider)
        {
            transformJugador = jugadorCollider.transform;
            estadoActual = EstadosMovimiento.Siguiendo;
        }

    }
    private void EstadoSiguiendo()
    {
        if (transformJugador == null)
        {
            estadoActual = EstadosMovimiento.Volviendo;
            return;
        }

        transform.position = Vector2.MoveTowards(transform.position, transformJugador.position, velocidadMovimiento * Time.deltaTime);

        GirarAObjetivo(transformJugador.position);

        if (Vector2.Distance(transform.position, puntoInicial) > distanciaMaxima ||
            Vector2.Distance(transform.position, transformJugador.position) > distanciaMaxima)
        {
            estadoActual = EstadosMovimiento.Volviendo;
            transformJugador = null;
        }

    }
    private void Estadovolviendo() 
    {
        transform.position = Vector2.MoveTowards(transform.position, puntoInicial, velocidadMovimiento * Time.deltaTime);

        GirarAObjetivo(puntoInicial);
        
        if (Vector2.Distance(transform.position, puntoInicial)<0.1f) {
            estadoActual = EstadosMovimiento.Esperando;

        }
    }
    private void GirarAObjetivo(Vector3 objetivo)
    {
        if (objetivo.x > transform.position.x && !mirandoDerecha)
        {
            Girar();
        }
        else if (objetivo.x < transform.position.x && mirandoDerecha)
        {
            Girar();
        }
    }

    private void Girar()
    {
        mirandoDerecha = !mirandoDerecha;
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
    }



    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;//esto veras el color de rojo el area de ataque 
        Gizmos.DrawWireSphere(transform.position, radioBusqueda);
        Gizmos.DrawWireSphere(puntoInicial, distanciaMaxima);
    }*/




    public float radioBusqueda;
    public LayerMask capaJugador;
    public Transform transformJugador;
    public EstadosMovimiento estadoActual;
    public float velocidadMovimiento;
    public float distanciaMaxima;
    public Vector3 puntoInicial;
    public bool mirandoDerecha;

    public enum EstadosMovimiento
    {
        Esperando,
        Siguiendo,
        Volviendo
    }

    private void Start()
    {
        puntoInicial = transform.position;
    }

    private void FixedUpdate()
    {
        switch (estadoActual)
        {
            case EstadosMovimiento.Esperando:
                EstadoDeEspera();
                break;
            case EstadosMovimiento.Siguiendo:
                EstadoSiguiendo();
                break;
            case EstadosMovimiento.Volviendo:
                Estadovolviendo();
                break;
        }
    }

    private void EstadoDeEspera()
    {
        Collider2D jugadorCollider = Physics2D.OverlapCircle(transform.position, radioBusqueda, capaJugador);

        if (jugadorCollider)
        {
            transformJugador = jugadorCollider.transform;
            estadoActual = EstadosMovimiento.Siguiendo;
        }
    }

    private void EstadoSiguiendo()
    {
        if (transformJugador == null)
        {
            estadoActual = EstadosMovimiento.Volviendo;
            return;
        }

        transform.position = Vector2.MoveTowards(transform.position, transformJugador.position, velocidadMovimiento * Time.deltaTime);
        GirarAObjetivo(transformJugador.position);

        if (Vector2.Distance(transform.position, puntoInicial) > distanciaMaxima ||
            Vector2.Distance(transform.position, transformJugador.position) > distanciaMaxima)
        {
            estadoActual = EstadosMovimiento.Volviendo;
            transformJugador = null;
        }
    }

    private void Estadovolviendo()
    {
        transform.position = Vector2.MoveTowards(transform.position, puntoInicial, velocidadMovimiento * Time.deltaTime);
        GirarAObjetivo(puntoInicial);

        if (Vector2.Distance(transform.position, puntoInicial) < 0.1f)
        {
            estadoActual = EstadosMovimiento.Esperando;
        }
    }

    private void GirarAObjetivo(Vector3 objetivo)
    {
        if (objetivo.x > transform.position.x && !mirandoDerecha)
        {
            Girar();
        }
        else if (objetivo.x < transform.position.x && mirandoDerecha)
        {
            Girar();
        }
    }

    private void Girar()
    {
        mirandoDerecha = !mirandoDerecha;
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
    }

    // Método para manejar la muerte del jugador
    public void MatarJugador()
    {
        transformJugador = null;  // El enemigo deja de seguir al jugador
        estadoActual = EstadosMovimiento.Volviendo;  // Cambia el estado a Volviendo para regresar a la zona inicial
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radioBusqueda);
        Gizmos.DrawWireSphere(puntoInicial, distanciaMaxima);
    }
}






