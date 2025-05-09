using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AnimacionUI : MonoBehaviour
{
    [SerializeField] private GameObject minimenu;
    [SerializeField] private GameObject FondoNegro;
    [SerializeField] private GameObject SalirM;

    public void AtivarMiniMenu()
    {
        LeanTween.moveY(minimenu.GetComponent<RectTransform>(), -400, 1f).setEase(LeanTweenType.easeOutElastic);
    }

    public void AbrirMenu()
    {
        LeanTween.scale(SalirM.GetComponent<RectTransform>(), new Vector3(1, 1, 1), 0.5f).setDelay(0.5f).setEase(LeanTweenType.easeInBack);
        LeanTween.alpha(FondoNegro.GetComponent<RectTransform>(), 0.5f, 1f);
    }

    public void CerrarMenu()
    {
        LeanTween.scale(SalirM.GetComponent<RectTransform>(), new Vector3(0, 0, 0), 0.5f);
        LeanTween.alpha(FondoNegro.GetComponent<RectTransform>(), 0.5f, 1f);
    }
}
