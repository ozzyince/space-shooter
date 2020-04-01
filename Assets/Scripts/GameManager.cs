using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private bool _isGameOver = false;

    void Update()
    {
        if (_isGameOver && Input.GetKeyDown(KeyCode.R))
            SceneManager.LoadScene(1);
    }

    public void GameOver()
    {
        _isGameOver = true;
    }
}
