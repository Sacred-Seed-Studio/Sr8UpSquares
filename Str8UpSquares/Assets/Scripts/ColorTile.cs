using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class ColorTile : MonoBehaviour
{
    BoxCollider2D col;
    int currentColor;
    SpriteRenderer sr;

    void Awake()
    {
        col = GetComponent<BoxCollider2D>();
        col.isTrigger = true;
        sr = GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        sr.color = GameController.controller.colors[currentColor];
        currentColor++;
        currentColor = currentColor % GameController.controller.colors.Length;
    }
}
