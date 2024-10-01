using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkGround : MonoBehaviour
{
    public static bool isGrounded; //debe ser estatico porque sino no te deja invocarlo en otra clase

    public void OnTriggerEnter2D(Collider2D collision)
    {
        isGrounded = true;
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        isGrounded = false;
    }
}
