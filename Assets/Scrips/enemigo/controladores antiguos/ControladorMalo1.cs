using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorMalo1 : MonoBehaviour
{
    public GameObject player;
    public Rigidbody2D rb;
    public float speedmalo;
    public Animator animPlayer;
    
    public Transform player2;
    public float detectionRadius = 5.0f;
    public float speed = 2.0f;

    //private Rigidbody2D rb;
    private Vector2 movement;


    private bool maloAttacking = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player2.position);
        if (distanceToPlayer < detectionRadius)
        {
            Vector2 direccion = (player2.position - transform.position).normalized;
            movement = new Vector2(direccion.x, 0);

        }
        else {
            movement = Vector2.zero;
        
        }
        rb.MovePosition(rb.position + movement * speed * Time.deltaTime);
        followingPlayer();
    }


    public void attack() {
        maloAttacking = true;
    
    }

    private void followingPlayer() {
        if (maloAttacking)
        {//falat si esta a la izquierda el personaje que se mueva a la izquierda si esta a la derecha que se mueva a la derecha 
            rb.velocity = new Vector2(-1f * speedmalo, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Flecha"))
        {
            animPlayer.SetTrigger("Death");


        }

    }

    public void death()
    {
        Destroy(gameObject);
    }
}
