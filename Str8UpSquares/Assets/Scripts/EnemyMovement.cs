using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{

    public float speed = 1f;
    Rigidbody2D rb2d;

    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.gravityScale = 0;
    }

    public void Move(Vector2 input)
    {
        Vector2 pos = rb2d.position + input.normalized * speed * Time.deltaTime;
        pos.Set(Mathf.Clamp(pos.x, -GameController.controller.XBound, GameController.controller.XBound), Mathf.Clamp(pos.y, -GameController.controller.YBound, GameController.controller.YBound));
        rb2d.MovePosition(pos);
    }
}
