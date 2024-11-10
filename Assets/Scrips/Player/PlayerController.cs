using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speedMove;
    public float jumpPower;
    public SpriteRenderer sprtRnd;
    public Animator animPlayer;
    public GameObject flechaPrfab;
    public float tiempoDeEspera;
    public GameObject arrowOut;
    public AudioSource audioDisparo;
    public AudioSource sonidoSaltar;
    public UnityEvent loadNewScene;

    private float horizontal;
    private bool isFacingRight = true;
    private Vector2 directionFlecha;
    private float disparoPasado;

    // Referencia al enemigo
    private SeguirJugadorArea seguirJugadorArea;

    void Start()
    {
        // Asumiendo que solo hay un enemigo, obtenemos la referencia al script SeguirJugadorArea.
        seguirJugadorArea = FindObjectOfType<SeguirJugadorArea>();
    }

    void FixedUpdate()
    {
        checkMovement();
    }

    private void checkMovement()
    {
        if (Mathf.Abs(horizontal) != 0f)
        {
            animPlayer.SetBool("isRunning", true);
        }
        else
        {
            animPlayer.SetBool("isRunning", false);
        }

        if (checkGround.isGrounded)
        {
            rb.velocity = new Vector2(horizontal * speedMove, rb.velocity.y);
            animPlayer.SetBool("isGrounded", true);
        }
        else
        {
            animPlayer.SetBool("isGrounded", false);
        }

        rb.velocity = new Vector2(horizontal * speedMove, rb.velocity.y);

        if (!isFacingRight && horizontal > 0f)
        {
            isFacingRight = true;
            sprtRnd.flipX = false;
        }
        else if (isFacingRight && horizontal < 0f)
        {
            isFacingRight = false;
            sprtRnd.flipX = true;
        }
    }

    public void Move(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x;
    }

    public void jump()
    {
        if (checkGround.isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
        }
    }

    public void shootAnimation()
    {
        if (Time.time > disparoPasado + tiempoDeEspera)
        {
            animPlayer.SetTrigger("shoot");
            disparoPasado = Time.time;
            audioDisparo.Play();
        }
    }

    public void Shoot()
    {
        GameObject flecha = Instantiate(flechaPrfab, arrowOut.transform.position, Quaternion.identity);

        if (sprtRnd.flipX)
        {
            directionFlecha = Vector2.left;
        }
        else
        {
            directionFlecha = Vector2.right;
        }

        flecha.GetComponent<arrowController>().setDirection(directionFlecha);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            animPlayer.SetTrigger("death");

            // Llama a MatarJugador en el enemigo para que regrese a su posición inicial
            if (seguirJugadorArea != null)
            {
                seguirJugadorArea.MatarJugador();
            }

            // Opcionalmente, reiniciar la escena
            // SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void ldScene()
    {
        loadNewScene.Invoke();
    }
}
