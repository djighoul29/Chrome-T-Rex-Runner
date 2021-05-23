using UnityEngine;
using UnityEngine.UI;

public class GameScript : MonoBehaviour
{
    [SerializeField] private int pointsPerMS = 10;
    [SerializeField] private Text scoreText;
    [SerializeField] private Text highScoreText;
    private int score;
    private int highScore;
    private bool gameStopped;
    [SerializeField] private float timeToBoost = 10f;
    [SerializeField] private float boost = 0.020f;
    private float nextBoost;
    public static GameScript instance = null;

    private void Start()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

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
}
