using UnityEngine;

public class MarcasError : MonoBehaviour
{
    public GameObject ArregloMarcas;
    private GameObject[] Marcas;
    public int index=0;
    void Start()
    {
        //Aqui estamos obteniendo todos los hijos, para hacer un arreglo de marcas[GameObject]
        int cantidad = ArregloMarcas.transform.childCount;
        Marcas = new GameObject[cantidad];

        for (int i = 0; i <= cantidad; i++)
        {
            Marcas[i] = ArregloMarcas.transform.GetChild(i).gameObject;
        }
    }

    public void ActivadorMarcas()
    {
        Marcas[index].SetActive(true);
        index++;
    }
}