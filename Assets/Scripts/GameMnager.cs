using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMnager : MonoBehaviour
{
    public Text _scoreText;
    public GameObject _gameoverPanel;
    public int _score = 0;
    private bool _isGameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        _score = 0; 
        _isGameOver = false;
        _gameoverPanel.SetActive(false);
        UpdateScoreText();
    }

    // Update is called once per frame
    void Update()
    {
        if (_isGameOver)
        {
            if (Input.GetButton("Space"))
            {
                RestartGame();
            }
        }
    }
    public void AddScore(int point)
    {
        _score += point;
        UpdateScoreText ();
    } 
    void UpdateScoreText()
    {
        _scoreText.text = "Score" + "\n" +_score.ToString();
    }
    public void GameOver()
    {
        _isGameOver = true;
        _gameoverPanel.SetActive(true);
        Invoke("LoadGameOverSene", 2f);
    }
    public void LoadGameOverScene()
    {
        SceneManager.LoadScene("GameOverScene");
    }
    void RestartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }
}
