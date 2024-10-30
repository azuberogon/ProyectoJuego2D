using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorMalo1 : MonoBehaviour
{
    public GameObject player;
    public Rigidbody2D rb;
    public float speedmalo;
    public Animator animPlayer;

    private bool maloAttacking = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
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
