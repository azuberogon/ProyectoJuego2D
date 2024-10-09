using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowController : MonoBehaviour
{
    public float speedArrow;


    private Vector2 direccionFlecha;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(direccionFlecha * speedArrow *Time.fixedDeltaTime); // delta time es un controlador que controla el tiempo que pasara desde el disparo de un frame a otro 
    
    }

    public void setDirection(Vector2 direccion) {

      

        direccionFlecha = direccion;
    }
}
