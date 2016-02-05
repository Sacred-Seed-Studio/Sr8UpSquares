using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(SpriteRenderer))]
public class Player : MonoBehaviour
{
    PlayerMovement movement;
    SpriteRenderer sr;

    Vector2 input;
    Vector2 shootInput;
    GameObject bullet;

    public List<Bullet> bullets;
    int bulletPoolSize = 25;
    int topBullet;
    float shootDelay = 0.35f, lastShootTime;

    public int health = 10;

    void Awake()
    {
        bullet = Resources.Load<GameObject>("Prefabs/bullet");
        movement = GetComponent<PlayerMovement>();
        sr = GetComponent<SpriteRenderer>();
        CreateBullets();
    }

    void CreateBullets()
    {
        bullets = new List<Bullet>();
        for (int i = 0; i < bulletPoolSize; i++)
        {
            bullets.Add(Instantiate<GameObject>(bullet).GetComponent<Bullet>());
            bullets[i].name = "Bullet" + i;
            bullets[i].transform.SetParent(transform);
            bullets[i].gameObject.SetActive(false);
        }
    }


    void Update()
    {
        shootInput.Set(Input.GetAxisRaw("HorizontalRight"), Input.GetAxisRaw("VerticalRight"));
        input.Set(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        if ((Mathf.Abs(shootInput.x) > 0 || Mathf.Abs(shootInput.y) > 0) && Time.time > lastShootTime)
        {
            Fire();
        }
    }

    void FixedUpdate()
    {
        movement.Move(input);
    }

    void Fire()
    {
        //generate a bullet
        //Instantiate(bullet);
        bullets[topBullet].ResetBullet(transform.position, shootInput);
        bullets[topBullet].gameObject.SetActive(true);
        topBullet++;
        if (topBullet >= bullets.Count) topBullet = 0;
        lastShootTime = Time.time + shootDelay;
    }

    public void TakeDamage(int d)
    {
        health -= d;
        if (health < 0)
        {
            health = 0;
            StartCoroutine(GameController.controller.EndGame());
        }
    }
}
