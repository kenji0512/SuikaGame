using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
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
    //void Update()
    //{
    //    if (_isGameOver)
    //    {
    //        if (Input.GetButton("Space"))
    //        {
    //            RestartGame();
    //        }
    //    }
    //}
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
        //_gameoverPanel.SetActive(true);
        Invoke("LoadGameOverSene", 0.1f);
        LoadGameOverScene();
    }
    public void LoadGameOverScene()
    {
        SceneManager.LoadScene("LoadGameOverSene");
    }
    //void RestartGame()
    //{
    //    UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    //}
}
