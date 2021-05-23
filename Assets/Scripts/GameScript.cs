using UnityEngine;
using UnityEngine.UI;

public class GameScript : MonoBehaviour
{
    [SerializeField] private int pointsPerMS = 10;
    [SerializeField] private Text scoreText;
    [SerializeField] private Text highScoreText;
    private int score;
    private int highScore;
    private int counter = 0;
    public static GameScript instance = null;
    void Start()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        InvokeRepeating("AddScore", 0, 0.1f);
        highScore = PlayerPrefs.GetInt("HI ", 0);
        scoreText.text = "0";
    }
    private void Update()
    {
        if (Time.timeScale != 0)
        {
            scoreText.text = "" + score;
        }
    }
    public void DinoHit()
    {
        Time.timeScale = 0;
    }
    private void AddScore()
    {
        score += pointsPerMS;
        counter += 1;
        if (counter > 100) 
            counter = 0;
    }
    private void FixedUpdate()
    {
        if (Time.timeScale != 0)
        {
            if (score > highScore)
            {
                highScore = score;
                PlayerPrefs.SetInt("HI ", highScore);
            }
            highScoreText.text = "HI " + highScore;
        }
    }
    private void GameSpeed()
    {

    }
}
