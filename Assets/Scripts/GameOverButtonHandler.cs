using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverButtonHandler : MonoBehaviour
{
    public void RestartGame()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
