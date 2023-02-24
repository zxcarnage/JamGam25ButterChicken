using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuWindow : MonoBehaviour
{
    [SerializeField] private Credits _credits;
    
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void ShowCredits()
    {
        if(_credits.gameObject.activeInHierarchy)
            _credits.gameObject.SetActive(false);
        else
            _credits.gameObject.SetActive(true);
    }
}
