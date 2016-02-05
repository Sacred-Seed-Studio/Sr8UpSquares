using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
public class Bullet : MonoBehaviour
{
    public float speed = 10f;

    Rigidbody2D rb2d;
    CircleCollider2D col;

    Vector2 input = Vector2.up;
    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.gravityScale = 0;
        col = GetComponent<CircleCollider2D>();
        col.isTrigger = true;
    }   

    void OnEnable()
    {
        Debug.Log("Bullet enabled");
    }

    void Update()
    {
        Move();
    }

    public void Move()
    {
        Vector2 pos = rb2d.position + input.normalized * speed * Time.deltaTime;
        Vector2 pos2 = new Vector2(Mathf.Clamp(pos.x, -GameController.controller.XBound, GameController.controller.XBound), Mathf.Clamp(pos.y, -GameController.controller.YBound, GameController.controller.YBound));
        if (pos.x != pos2.x || pos.y != pos2.y) gameObject.SetActive(false);
        rb2d.MovePosition(pos);
    }

    public void ResetBullet(Vector2 newFirePosition, Vector2 direction)
    {
        rb2d.velocity = Vector2.zero;
        transform.position = newFirePosition;
        input = direction;
    }

}
