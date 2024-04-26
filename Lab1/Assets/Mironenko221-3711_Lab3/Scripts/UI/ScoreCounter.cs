using TMPro;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    public static ScoreCounter Instance { get; private set; }

    [SerializeField] private TMP_Text _view;

    private int _score;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public int Score => _score;

    public void Increase(int value)
    {
        _score += value;

        _view.text = _score.ToString();
    }
}
