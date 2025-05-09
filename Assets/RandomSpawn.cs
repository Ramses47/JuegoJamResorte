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
        instanceRect.anchoredPosition = centerRect.anchoredPosition + new Vector2(x, y);
    }
}
