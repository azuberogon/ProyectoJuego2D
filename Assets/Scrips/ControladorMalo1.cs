using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorMalo1 : MonoBehaviour
{
    public GameObject player;
    public Rigidbody2D rb;
    public float speedmalo;

    private bool maloAttackin = false;
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
        maloAttackin = true;
    
    }

    private void followingPlayer() {
        if (maloAttackin)
        {//falat si esta a la izquierda el personaje que se mueva a la izquierda si esta a la derecha que se mueva a la derecha 
            rb.velocity = new Vector2(-1f * speedmalo, 0);
        }
    }
}
