using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;
public class GameManager : MonoBehaviour
{
    [Header("Configuración de Juego")]
    public bool isPressed = false;
    public GameObject objetoADestruir;

    public float rotationSpeed = 50f;
    public float tiempo = 10f;
    public List<NivelConfig> niveles;
    public Transform[] posicionesSpawneo;
    public GameObject BotonCompleto;
    public RectTransform canvasRect; 

    [Header("Componentes")]
    private Temporizador temporizador;
    private RandomSpawn randomSpawn;

    [Header("Estado del Juego")]
    public int nivelDificultad = 1;
    public int CantidadDeCirculos = 1;
    public int NumeroErrores = 0;
    public bool derecha = true;
    public bool Perdiste = false;
    public bool SeAcaboElTiempo = false;

    [Header("Eventos")]
    public UnityEvent Error;
    public UnityEvent Acierto;
    public UnityEvent SeAcaboElTiempoEvento;

    [Header("UI")]
    public TextMeshProUGUI Score;
    public int ScoreValue = 0;
    private void Start()
    {
        /*
        ObtenerTransform();
        */

    
        temporizador = GetComponent<Temporizador>();
        randomSpawn = GetComponent<RandomSpawn>();

        if (temporizador == null)
            Debug.LogWarning("Temporizador no encontrado.");
        if (randomSpawn == null)
            Debug.LogWarning("RandomSpawn no encontrado.");

        EstablecerDificultad(); 
        CrearNuevoCirculo();   
    }

    private void Update()
    {
        if (!Perdiste)
        {
            RevisarEntrada();
            RevisarErrores();
            ActualizarTexto();
        }
    }
   
    //Metodo anterior que habia utilizado para fijar las posiciones a travez de un padre y los transforms(hijos), resulto no ser tan eficiente como utilizar el canvas por lo que esta aqui de adorno
    /*private void ObtenerTransform()
    {
        posicionesSpawneo = new Transform[padre.childCount];
        for (int i = 0; i < padre.childCount; i++)
        {
            posicionesSpawneo[i] = padre.GetChild(i);
        }
    }
    */

    void RevisarEntrada()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isPressed)
            {
                
                CirculoCompletado();
                derecha = Random.value > 0.5f;
                ScoreValue=ScoreValue+5;


            }
            else
            {

                NumeroErrores++;
                derecha = Random.value > 0.5f;
                Error.Invoke();
                ScoreValue =ScoreValue-3;
                Debug.Log("Presionaste fuera de tiempo. Errores: " + NumeroErrores);
            }
        }
    }

    void ActualizarTexto()
    {
        ScoreValue = Mathf.Max(0, ScoreValue);
        Score.text = "Score: " + ScoreValue.ToString();
    }
    void MoverBoton()
    {
        Vector2 size = canvasRect.rect.size;

       //Marcando un Limite de 500f px de distancia para que esta madre no se vaya a salir de la vista
        float limiteX = (size.x / 2f) - 500f;
        float limiteY = (size.y / 2f) - 500f;

        float randomX = Random.Range(-limiteX, limiteX);
        float randomY = Random.Range(-limiteY, limiteY);

        Vector3 localPos = new Vector3(randomX, randomY, 0f);

      
        BotonCompleto.transform.position = canvasRect.TransformPoint(localPos);
    }
    

    void RevisarErrores()
    {
        if (NumeroErrores >= 3 && !Perdiste)
        {
            Perdiste = true;
            Debug.Log("¡Has perdido!");
            rotationSpeed = 0f;
            temporizador?.DetenerTemporizador();

        }
        else if (SeAcaboElTiempo)
        {
            Perdiste = true;
            Debug.Log("¡Has perdido!");
            rotationSpeed = 0f;
            temporizador?.DetenerTemporizador();
            SeAcaboElTiempoEvento.Invoke();



        }
    }

    void CirculoCompletado()
    {
        CantidadDeCirculos--;

        if (objetoADestruir != null)
        {
            Destroy(objetoADestruir);
            objetoADestruir = null;
        }

        isPressed = false;

        if (CantidadDeCirculos > 0 && !Perdiste)
        {
            CrearNuevoCirculo();
    
        }
        else if (!Perdiste)
        {
            nivelDificultad++;
            Acierto.Invoke();

            EstablecerDificultad();
            CrearNuevoCirculo();
        }
    }

    void EstablecerDificultad()
    {
        rotationSpeed = Mathf.Min(rotationSpeed + 50f, 600f);
        int index = nivelDificultad - 1;

        if (index >= 0 && index < niveles.Count)
        { 
            var config = niveles[index];
            tiempo = config.tiempo;
            CantidadDeCirculos = config.cantidadDeCirculos;
        }
        else
        {
            tiempo = 5f;
            CantidadDeCirculos = 8;
        }

        temporizador?.CargarTiempo();
        temporizador?.ReiniciarTemporizador();
    }

    void CrearNuevoCirculo()
    {
     

        if (randomSpawn != null)
        {
            randomSpawn.SpawnOnCirclePerimeter();
          
            temporizador?.ReiniciarTemporizador();

            if (nivelDificultad != 1)
            {
                MoverBoton();
            }
        }
    }
}
