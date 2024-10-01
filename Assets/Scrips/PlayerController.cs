using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class player : MonoBehaviour
{

    public Rigidbody2D rb;
    public float speedMove;
    public float jumpPower;
    public SpriteRenderer sprtRnd;

    private float horizontal;
    private bool isFacingRight = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        //horizontal = x 0f 0 fuerza 
        

        rb.velocity = new Vector2(horizontal * speedMove, rb.velocity.y);

        if (!isFacingRight && horizontal > 0f)
        { // la condicion evalua si va a la izquierda o hacia la derecha (si la componenete x es mayor que cero se desplaza a la derecha )
            isFacingRight = true;
            sprtRnd.flipX = false;
        }
        else if (isFacingRight && horizontal < 0f) {
            isFacingRight = false;
            sprtRnd.flipX = true;
        }
    }

    public void Move(InputAction.CallbackContext context) // el context --> relaciona el inputPlayer con este atributo context
    { 
        horizontal = context.ReadValue<Vector2>().x;

    } 
}
