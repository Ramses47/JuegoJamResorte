using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AnimacionUI : MonoBehaviour
{
    [SerializeField] private GameObject minimenu;

    public void AtivarMiniMenu()
    {
        LeanTween.moveY(minimenu.GetComponent<RectTransform>(), -400, 1f).setEase(LeanTweenType.easeOutElastic);
    }
}
