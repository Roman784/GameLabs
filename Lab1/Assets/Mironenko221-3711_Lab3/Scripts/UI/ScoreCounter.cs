using TMPro;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    public static ScoreCounter Instance { get; private set; }

    [SerializeField] private TMP_Text _view;
    [SerializeField] private TMP_Text _bestScoreView;

    private int _score;
    public int Score => _score;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public void Increase(int value)
    {
        _score += value;

        _view.text = _score.ToString();
    }

    public void UpdateBestScore(int value)
    {
        _bestScoreView.text = value.ToString();
    }
}
