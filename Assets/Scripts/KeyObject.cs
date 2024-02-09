using UnityEngine;

public class KeyObject : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            KeyCollector keyCollector = other.GetComponent<KeyCollector>();
            if (keyCollector != null)
            {
                keyCollector.CollectKey(gameObject); // Pass the key GameObject as an argument
            }
        }
    }
}