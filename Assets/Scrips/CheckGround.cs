using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkGround : MonoBehaviour
{
  public static bool isGrounded; //debe ser estatico porque sino no te deja invocarlo en otra clase

  public void OnTriggerEnter2D(Collider2D collision)
    {
        isGrounded = true;
        Debug.Log(isGrounded);
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        isGrounded = false;
        Debug.Log(isGrounded);
    }


        /*



    // Detectar cuando el jugador toca el suelo (usando el Tag "Ground")
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("suelo"))
        {
            isGrounded = true;
            Debug.Log("Tocando el suelo");
        }
    }

    // Detectar cuando el jugador deja de tocar el suelo
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("suelo"))
        {
            isGrounded = false;
            Debug.Log("Ya no está en el suelo");
        }
    }
*/

}
