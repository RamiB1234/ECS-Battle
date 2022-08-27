using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButtonMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("EmptyECS");
    }
}
