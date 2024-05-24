using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelButton : MonoBehaviour
{
    [SerializeField] private string _name;

    public void OpenLevel()
    {
        SceneManager.LoadScene(_name);
    }
}
