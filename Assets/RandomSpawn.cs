using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    public GameObject prefab;
    public float radius = 100f;
    public GameObject CentroDelCirculo;

    void Start()
    {

    }

    public void SpawnOnCirclePerimeter()
    {
        RectTransform centerRect = CentroDelCirculo.GetComponent<RectTransform>();

        float angle = Random.Range(0f, Mathf.PI * 2);

        float x = Mathf.Cos(angle) * radius;
        float y = Mathf.Sin(angle) * radius;

        GameObject instance = Instantiate(prefab, centerRect.parent);

        RectTransform instanceRect = instance.GetComponent<RectTransform>();

        Vector2 spawnPos = centerRect.anchoredPosition + new Vector2(x, y);
        instanceRect.anchoredPosition = spawnPos;

   
        Vector2 direction = centerRect.anchoredPosition - spawnPos;

     
        float angleDeg = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

      
        instanceRect.rotation = Quaternion.Euler(0, 0, angleDeg - 90f);

        //Ahora el collid(flecha apunta directamente hacia el centro del circulo)
    }

}
