using UnityEngine;

public class MarcasError : MonoBehaviour
{
    public GameObject ArregloMarcas;
    private GameObject[] Marcas;
    public int index = 0;

    void Start()
    {

        int cantidad = ArregloMarcas.transform.childCount;
        Marcas = new GameObject[cantidad];

        for (int i = 0; i < cantidad; i++)
        {
            Marcas[i] = ArregloMarcas.transform.GetChild(i).gameObject;
        }
    }

    public void ActivadorMarcas()
    {
        if (index < Marcas.Length)
        {
            Marcas[index].SetActive(true);
            index++;
        }
        else
        {
        }
    }
}
