using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameScript : MonoBehaviour
{
    [SerializeField] private int pointsPerMS = 10;
    [SerializeField] private Text scoreText;
    [SerializeField] private Text highScoreText;
    [SerializeField] GameObject restartButton;
    [SerializeField] GameObject audioPlayer;
    private int score;
    private int highScore;
    private bool gameStopped;
    [SerializeField] private float timeToBoost = 10f;
    [SerializeField] private float boost = 0.03f;
    private float nextBoost;
    public static GameScript instance = null; 
    private AudioClip hitSound;
    private AudioSource audioSrc;
    public static bool PLAY = true;

    private void Start()
    {
        audioPlayer.SetActive(PLAY);
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
        hitSound = Resources.Load<AudioClip>("hit");
        audioSrc = GetComponent<AudioSource>();
    }
    private void Update()
    {
        if (!gameStopped)
        {
            scoreText.text = "" + score; // Score counter
        }

        if (Time.unscaledTime > nextBoost && !gameStopped) // booster
            BoostTime();

        if (Input.GetKeyDown(KeyCode.M) && !PLAY)       // <- Mute music
        {
            PLAY = true;
            audioPlayer.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.M) && PLAY)
        {
            PLAY = false;
            audioPlayer.SetActive(false);
        }                                               // <-

        if (gameStopped && Input.GetKeyDown(KeyCode.Z)) // Reset highscore
        {
            PlayerPrefs.SetInt("HI ", 0);
        }
    }
    public void DinoHit()
    {
        audioSrc.PlayOneShot(hitSound);
        Time.timeScale = 0;
        gameStopped = true;
        restartButton.SetActive(true);
        audioPlayer.SetActive(false);
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
