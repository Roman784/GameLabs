using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool IsPaused;

    [SerializeField] private GameObject _panel;

    private void Awake()
    {
        IsPaused = false;
        ClosePanel();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!IsPaused) OpenPanel();
            else ClosePanel();
        }
    }

    public void OpenPanel()
    {
        _panel.SetActive(true);
        IsPaused = true;
        Time.timeScale = 0f;
    }

    public void ClosePanel()
    {
        _panel.SetActive(false);
        IsPaused = false;
        Time.timeScale = 1f;
    }

    public void OpenMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
