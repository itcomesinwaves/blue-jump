using UnityEngine;
using UnityEngine.SceneManagement;

public class KeyCollector : MonoBehaviour
{
    public int collectedKeys { get; private set; } = 0;
    public int keysToCollect = 3;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Key"))
        {
            CollectKey(other.gameObject);
        }
        else if (other.CompareTag("Door") && CanOpenDoor())
        {
            OpenDoor();
        }
    }

    public void CollectKey(GameObject key)
    {
        collectedKeys++;
        // Add any additional logic for key collection (e.g., disable the key GameObject, play an animation)
        Destroy(key);
        // key.SetActive(false); // Uncomment this line if you want to disable the key GameObject
    }

    public bool CanOpenDoor()
    {
        return collectedKeys >= keysToCollect;
    }

    public void OpenDoor()
    {
        // Transition to the success scene
        SceneManager.LoadScene("SuccessScene");
    }
}