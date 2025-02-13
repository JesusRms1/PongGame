using UnityEngine;

public class ColorChange : MonoBehaviour
{
     private Renderer groundRenderer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        groundRenderer = GetComponent<Renderer>();

         InvokeRepeating(nameof(RandomColor), 0f, 2f);
        
    }

    // Update is called once per frame
    void RandomColor()
    {
         Color newColor = new Color(Random.value, Random.value, Random.value);
         groundRenderer.material.color = newColor;
    }
}
