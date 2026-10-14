using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private GameObject startPanel;   
    [SerializeField] private TMP_Text scoreText;       
    [SerializeField] private TMP_Text highScoreText;
    [SerializeField] private TMP_Text lastScoreText;

    private int score;
    private int highScore;
    private const string HighScorePref = "HighScore";

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        highScore = PlayerPrefs.GetInt(HighScorePref, 0);
        lastScoreText.text = "Last score: —";
        Time.timeScale = 0f;
        ShowStartPanel();
    }

    public void StartGame()
    {
        score = 0;
        UpdateScoreText();
        startPanel.SetActive(false);
        scoreText.gameObject.SetActive(true);
        Time.timeScale = 1f;
    }

    public void GameOver()
    {
        Time.timeScale = 0f;
        lastScoreText.text = "Last score: " + score;
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt(HighScorePref, highScore); 
        }

        ShowStartPanel();
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreText();
    }

    private void ShowStartPanel()
    {
        startPanel.SetActive(true);
        scoreText.gameObject.SetActive(false);
        highScoreText.text = "High score: " + highScore;
    }

    private void UpdateScoreText()
    {
        scoreText.text = score.ToString();
    }
}