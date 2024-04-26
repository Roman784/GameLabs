using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField, Range(0, 60)] private float _time;

    [Space]

    [SerializeField] private TMP_Text _view;

    private void Update()
    {
        if (_time > 0)
        {
            _time -= Time.deltaTime;
            UpdateView();
        }
        else
        {
            GameOverMenu.Instance.GameOver();
        }
    }

    private void UpdateView()
    {
        int seconds = Mathf.RoundToInt(_time);

        _view.text = "Time: " + seconds.ToString();
    }
}
