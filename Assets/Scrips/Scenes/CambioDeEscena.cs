using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioDeEscena : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("adsasdasd");
        if (other.CompareTag("Player"))
        {
            Debug.Log("escena neuva ");
            SceneManager.LoadScene("Cueva");
        }
    }
}
