using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverMenu : MonoBehaviour
{
    public static GameOverMenu Instance { get; private set; }

    [SerializeField] private GameObject _panel;
    [SerializeField] private Button _restartButton;

    [Space]

    [SerializeField] private TMP_Text _scoreView;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;

        _restartButton.onClick.AddListener(RestartLevel);
    }

    public void GameOver()
    {
        Time.timeScale = 0f;

        _panel.SetActive(true);
        _scoreView.text = "Score: " + ScoreCounter.Instance.Score.ToString();
    }

    private void RestartLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
