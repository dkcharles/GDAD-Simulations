
using UnityEngine;

public class Food : MonoBehaviour
{
    public float minLifetime = 10f;  // Minimum lifetime of the food
    public float maxLifetime = 30f;  // Maximum lifetime of the food

    private void Start()
    {
        // Start the despawn timer with a random lifetime
        Invoke("DestroyFood", Random.Range(minLifetime, maxLifetime));
    }

    private void DestroyFood()
    {
        // Check if the food object still exists (it might have been eaten)
        if (gameObject != null)
        {
            Destroy(gameObject);
        }
    }
}