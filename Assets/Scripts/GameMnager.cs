using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMnager : MonoBehaviour
{
    public Text _scoreTxet;
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
        _scoreTxet.text = "Score" + _score.ToString();
    }
    public void GameOver()
    {
        _isGameOver = true;
        _gameoverPanel.SetActive(true);
    }
    void RestartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }
}
