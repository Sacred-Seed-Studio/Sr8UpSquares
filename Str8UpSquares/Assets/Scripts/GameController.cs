using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{

    public static GameController controller;
    public Color[] colors;

    private float xBound = 2f, yBound = 2f;
    public float XBound { get { return xBound - playerSize / 2f; } }
    public float YBound { get { return yBound - playerSize / 2f; } }
    public int playerSize = 1;

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
    }
}
