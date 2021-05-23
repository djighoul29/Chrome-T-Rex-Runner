using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    [SerializeField] GameObject Ground1;
    [SerializeField] GameObject Ground2;
    private void Start()
    {
        Ground2.SetActive(false);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) ||
            Input.GetKeyDown(KeyCode.UpArrow) ||
            Input.GetKeyDown(KeyCode.W))
        {
            Ground1.SetActive(false);
            Ground2.SetActive(true);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Ground2"))
            SceneManager.LoadScene("Game");
    }
}
