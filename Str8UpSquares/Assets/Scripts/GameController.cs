using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameController : MonoBehaviour
{

    public static GameController controller;
    public Color[] colors;

    private float xBound = 2f, yBound = 2f;
    public float XBound
    {
        get { return xBound - playerSize / 2f; }
        set { xBound = value; }
    }
    public float YBound
    {
        get { return yBound - playerSize / 2f; }
        set { yBound = value; }
    }
    public int playerSize = 1;

    public Player player;

    void Awake()
    {
        if (controller == null)
        {
            controller = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (controller != this)
        {
            Destroy(gameObject);
        }

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    public IEnumerator EndGame()
    {
        player.gameObject.SetActive(false);
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Main");
        yield return null;
    }
}
