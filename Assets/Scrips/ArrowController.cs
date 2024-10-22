using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowController : MonoBehaviour
{
    public float speedArrow;
    public float vidaFlecha;


    private Vector2 direccionFlecha;
    private float tiempoDeVida = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        movimientoFlecha();
    }
    private void movimientoFlecha() {
        transform.Translate(direccionFlecha * speedArrow * Time.fixedDeltaTime); // delta time es un controlador que controla el tiempo que pasara desde el disparo de un frame a otro 
        if (direccionFlecha == Vector2.right)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        tiempoDeVida +=  Time.fixedDeltaTime;

        if (tiempoDeVida >=vidaFlecha) 
        {
            Destroy(gameObject);
        }
    }
    public void setDirection(Vector2 direccion) {

      

        direccionFlecha = direccion;
    }
}
