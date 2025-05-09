using TMPro;
using UnityEngine;

public class Temporizador : MonoBehaviour
{
    private float tiempoInicial;
    private float tiempoRestante;
    private bool estaActivo = true;

    public TextMeshProUGUI texto;
    GameManager gameManager;

    void Start()
    {
        gameManager = Object.FindFirstObjectByType<GameManager>();
        CargarTiempo();
        IniciarTemporizador();
    }

    void Update()
    {
        if (estaActivo && tiempoRestante > 0)
        {
            tiempoRestante -= Time.deltaTime;

            if (tiempoRestante < 0)
            {
                tiempoRestante = 0;
                gameManager.SeAcaboElTiempo = true;
            }
        }

        if (tiempoRestante <= 0 && estaActivo)
        {
            estaActivo = false;
        }

        ActualizarText();
    }

    public void ReiniciarTemporizador()
    {
        tiempoRestante = tiempoInicial;
        estaActivo = true;

    }

    public void DetenerTemporizador()
    {
        estaActivo = false;
 
    }

    public void IniciarTemporizador()
    {
        tiempoRestante = tiempoInicial; 
        estaActivo = true;
    }

    void ActualizarText()
    {
        texto.text = Mathf.Ceil(tiempoRestante).ToString();
    }

    public void CargarTiempo()
    {
        if (gameManager != null)
        {
            tiempoInicial = gameManager.tiempo;
        }
        else{ }
    }
}
