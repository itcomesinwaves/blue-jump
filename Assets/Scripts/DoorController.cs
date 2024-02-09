using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorController : MonoBehaviour
{
    public string successSceneName = "SuccessScene";

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            KeyCollector keyCollector = other.GetComponent<KeyCollector>();
            if (keyCollector != null && keyCollector.keysToCollect == keyCollector.collectedKeys)
            {
                keyCollector.OpenDoor(); // Call the OpenDoor method from KeyCollector
            }
        }
    }
}