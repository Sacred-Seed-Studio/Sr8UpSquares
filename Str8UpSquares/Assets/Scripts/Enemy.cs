using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(EnemyMovement))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class Enemy : MonoBehaviour
{
    Rigidbody2D rb2d;
    EnemyMovement movement;
    Vector2 input;
    public int damageToDo = 1;

    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.gravityScale = 0;
        movement = GetComponent<EnemyMovement>();
        StartCoroutine(ChangeInput());
    }

    void Update()
    {
        movement.Move(input);
    }

    IEnumerator ChangeInput()
    {
        while (true)
        {
            input.Set(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
            yield return new WaitForSeconds(1f);
        }
        yield return null;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.tag);
        if (other.tag == "Player")
        {
            //kill the player
            GameController.controller.player.TakeDamage(damageToDo);
        }
        else if (other.tag == "Bullet")
        {
            gameObject.SetActive(false);
        }
    }
}
