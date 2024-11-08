using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeguirJugadorArea : MonoBehaviour
{
    public float radioBusqueda;
    public LayerMask capaJugador;
    public Transform transformJugador;

    private void Update()
    {
        Collider2D jugadorCollider = Physics2D.OverlapCircle(transform.position, radioBusqueda, capaJugador);

        if (jugadorCollider)
        {
            transformJugador = jugadorCollider.transform;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radioBusqueda);
    }




}
