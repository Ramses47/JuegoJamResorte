using UnityEngine;

public class VerificarPuntero : MonoBehaviour
{
    GameManager gameManager;


    private void OnTriggerEnter(Collider other)
    {
      
        gameManager.isPressed = true;
        gameManager.objetoADestruir = gameObject;
    }

    private void OnTriggerExit(Collider other)
    {
    
        gameManager.isPressed = false;
        gameManager.objetoADestruir = null;
    }

    private void Start()
    {
        gameManager = Object.FindFirstObjectByType<GameManager>();
    }


}
