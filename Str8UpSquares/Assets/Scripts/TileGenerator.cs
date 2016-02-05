using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TileGenerator : MonoBehaviour
{
    GameObject colorTilePrefab;
    public int x = 4;
    public int y = 4;

    List<ColorTile> tiles;


    void Awake()
    {
        colorTilePrefab = Resources.Load<GameObject>("Prefabs/ColorTile");
    }

    void Start()
    {
        GameController.controller.XBound = x / 2f;
        GameController.controller.YBound = y / 2f;
        GenerateTiles();
    }

    void GenerateTiles()
    {
        int c = 0;
        tiles = new List<ColorTile>();
        for (int i = 0; i < x; i++)
        {
            for (int k = 0; k < y; k++)
            {
                tiles.Add(Instantiate<GameObject>(colorTilePrefab).GetComponent<ColorTile>());
                tiles[i * x + k].name = "Tile" + i + k;
                tiles[i * x + k].transform.position = new Vector2(i-x/2f+GameController.controller.playerSize/2f, k-y/2f+ GameController.controller.playerSize /2f);
                tiles[i * x + k].transform.SetParent(transform);
                c++;
            }
        }
    }

}
