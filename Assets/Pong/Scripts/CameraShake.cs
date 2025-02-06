using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour
{

    public float shakeDuration = 0.3f;
    public float shakeMagnitude = 0.2f;

    private Vector3 originalPosition;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        originalPosition = transform.position;
    }

   public void Shake(){
       StartCoroutine(Shakes());
   }
    IEnumerator Shakes()
    {
        float elapsedTime = 0f;

        while (elapsedTime < shakeDuration)
        {
            float xOffset = Random.Range(-1f, 1f) * shakeMagnitude;
            float yOffset = Random.Range(-1f, 1f) * shakeMagnitude;

            transform.localPosition = originalPosition + new Vector3(xOffset, yOffset, 0);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.localPosition = originalPosition; // Reset position
    }

}
