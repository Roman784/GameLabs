using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverMenu : MonoBehaviour
{
    public static GameOverMenu Instance { get; private set; }

    public bool IsGameOver {  get; private set; }

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

        IsGameOver = false;
    }

    public void GameOver()
    {
        if (IsGameOver) return;
        IsGameOver = true;

        Time.timeScale = 0f;

        _panel.SetActive(true);
        _scoreView.text = "Score: " + ScoreCounter.Instance.Score.ToString();

        SaveBestScore();
    }

    private void RestartLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
    }

    private void SaveBestScore()
    {
        int currentScore = ScoreCounter.Instance.Score;
        int levelNumber = Bootstrap.Instance.LevelNumber;
        int savedScore = Repository.Instance.GetBestScore(levelNumber);

        if (savedScore < currentScore)
        {
            Repository.Instance.UpdateScoreAsync(levelNumber, currentScore);
        }
    }
}
