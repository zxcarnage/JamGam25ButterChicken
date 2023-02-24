using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverWindow : MonoBehaviour
{
    [SerializeField] private Customer _customer;
    [SerializeField] private GameOverObjects _objects;

    private Image _panelImage;

    private void Start()
    {
        _panelImage = GetComponent<Image>();
        HideGameoverWindow();
    }

    private void HideGameoverWindow()
    {
        _panelImage.raycastTarget = false;
        _objects.gameObject.SetActive(false);
        _panelImage.color = _panelImage.color * new Color(1, 1, 1, 0);
    }

    private void OnEnable()
    {
        _customer.CustomerLeaved += ShowGameOver;
    }

    private void ShowGameOver()
    {
        _panelImage.raycastTarget = true;
        _panelImage.color = _panelImage.color + new Color(0, 0, 0, 1);
        transform.GetChild(0).gameObject.SetActive(true);
    }

    private void OnDestroy()
    {
        _customer.CustomerLeaved -= ShowGameOver;
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
