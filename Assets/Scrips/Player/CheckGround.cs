using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkGround : MonoBehaviour
{
  public static bool isGrounded; //debe ser estatico porque sino no te deja invocarlo en otra clase

  private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("suelo")) {
            isGrounded = true;
        }
        

    }

    private void OnTriggerExit2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("suelo"))
        {
            isGrounded = false;
        }
        
       
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
