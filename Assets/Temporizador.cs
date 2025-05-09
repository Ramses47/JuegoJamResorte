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
                tiempoRestante = 0;

            Debug.Log("Tiempo restante: " + Mathf.Ceil(tiempoRestante));
        }

        if (tiempoRestante <= 0 && estaActivo)
        {
            estaActivo = false;
            Debug.Log("¡Tiempo agotado!");
        }

        ActualizarText();
    }

    public void ReiniciarTemporizador()
    {
        tiempoRestante = tiempoInicial;
        estaActivo = true;
        Debug.Log("Temporizador reiniciado.");
    }

    public void DetenerTemporizador()
    {
        estaActivo = false;
        Debug.Log("Temporizador detenido.");
    }

    public void IniciarTemporizador()
    {
        tiempoRestante = tiempoInicial; 
        estaActivo = true;
        Debug.Log("Temporizador iniciado.");
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
        else
        {
            Debug.LogWarning("GameManager no encontrado al cargar el tiempo.");
        }
    }
}
