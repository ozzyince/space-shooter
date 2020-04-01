using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text _scoreText;
    [SerializeField] private Text _gameOverText;
    [SerializeField] private Text _restartText;
    [SerializeField] private Image _livesImg;
    [SerializeField] private Sprite[] _livesSprites;

    private bool _gameOver = false;
    private GameManager _gameManager;

    private void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }

    public void SetScore(int score)
    {
        _scoreText.text = "Score: " + score.ToString();
    }

    public void SetLives(int lives)
    {
        _livesImg.sprite = _livesSprites[lives];
        if (lives < 1)
        {
            _gameManager.GameOver();
            _gameOverText.gameObject.SetActive(true);
            _restartText.gameObject.SetActive(true);
        }
    }
}
