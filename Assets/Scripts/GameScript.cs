using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameScript : MonoBehaviour
{
    [SerializeField] private int pointsPerMS = 10;
    [SerializeField] private Text scoreText;
    [SerializeField] private Text highScoreText;
    [SerializeField] GameObject restartButton;
    private int score;
    private int highScore;
    private bool gameStopped;
    [SerializeField] private float timeToBoost = 10f;
    [SerializeField] private float boost = 0.020f;
    private float nextBoost;
    public static GameScript instance = null;

    private void Start()
    {
        restartButton.SetActive(false);
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
        Time.timeScale = 1f;
        InvokeRepeating("AddScore", 0, 0.1f);
        highScore = PlayerPrefs.GetInt("HI ", 0);
        scoreText.text = "0";
        gameStopped = false;
    }
    private void Update()
    {
        if (!gameStopped)
        {
            scoreText.text = "" + score;
        }
        if (Time.unscaledTime > nextBoost && !gameStopped)
            BoostTime();
    }
    public void DinoHit()
    {
        Time.timeScale = 0;
        gameStopped = true;
        restartButton.SetActive(true);
    }
    private void AddScore()
    {
        score += pointsPerMS;
    }
    private void FixedUpdate()
    {
        if (!gameStopped)
        {
            if (score > highScore)
            {
                highScore = score;
                PlayerPrefs.SetInt("HI ", highScore);
            }
            highScoreText.text = "HI " + highScore;
        }
    }
    void BoostTime()
    {
        nextBoost = Time.unscaledTime + timeToBoost;
        Time.timeScale += boost;
    }
    public void RestartGame()
    {
        SceneManager.LoadScene("Game");
    }
}
