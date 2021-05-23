using UnityEngine;

public class GameScript : MonoBehaviour
{
    public static GameScript instance = null;
    void Start()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }
    public void DinoHit()
    {
        Time.timeScale = 0;
    }
}
