using UnityEngine;

public class RotationScript : MonoBehaviour
{



    GameManager gameManager;
    void Start()
    {
        gameManager = Object.FindFirstObjectByType<GameManager>();
    }

  
    void Update()
    {
        int RotationDirection;
        if (gameManager.derecha)
        {
            RotationDirection = -1;
        }
        else
        {
            RotationDirection = 1;

        }

        transform.Rotate(0f, 0f, (RotationDirection * gameManager.rotationSpeed) * Time.deltaTime);
    }
}
