using UnityEngine;

public class VerificarPuntero : MonoBehaviour
{
    GameManager gameManager;


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Puntero dentro del collider");
        gameManager.isPressed = true;
        gameManager.objetoADestruir = gameObject;
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Puntero fuera del collider");
        gameManager.isPressed = false;
        gameManager.objetoADestruir = null;
    }

    private void Start()
    {
        gameManager = Object.FindFirstObjectByType<GameManager>();
    }


}
