using UnityEngine;

public class PowerUp : MonoBehaviour
{
     public float speedBoost = 1.5f; 

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball")) 
        {
            Rigidbody ballRb = other.GetComponent<Rigidbody>();

            if (ballRb != null)
            {
                
                ballRb.linearVelocity *= speedBoost;
            }

           
            Destroy(gameObject);
        }
    }
}
