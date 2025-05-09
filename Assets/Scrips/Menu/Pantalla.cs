using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Pantalla : MonoBehaviour
{
    public Toggle toggle;
    public TMP_Dropdown resolutionsDrop;
    Resolution[] resolutions;

    
    void Start()
    {
        if (Screen.fullScreen)
        {
            toggle.isOn = true; 
        }
        else
        {
            toggle.isOn = false; 
        }
        RevisarResolucion();
    }

    public void ActivarPantallaCompleta(bool pantallaCompleta)
    {
        Screen.fullScreen = pantallaCompleta;
    }

    public void RevisarResolucion()
    {
        resolutions = Screen.resolutions;
        resolutionsDrop.ClearOptions();
        List<string> opciones = new List<string>();
        int resolutionsA = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string opcion = resolutions[i].width + " x " + resolutions[i].height;
            opciones.Add(opcion);

            if(Screen.fullScreen && resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                resolutionsA = i;
            }
        }
        resolutionsDrop.AddOptions(opciones);
        resolutionsDrop.value = resolutionsA;
        resolutionsDrop.RefreshShownValue();
    }

    public void CambiarResolucion(int indiceResolucion) 
    {
        Resolution resolution = resolutions[indiceResolucion];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

}
