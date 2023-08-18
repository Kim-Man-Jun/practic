using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public GameObject tilePrefab;
    public Sprite[] sprites;
    public float[,] Grid;

    public int Vertical, Horizontal, Colunms, Rows;


    // Start is called before the first frame update
    void Start()
    {
        Vertical = (int)Camera.main.orthographicSize;
        Horizontal = Vertical * (Screen.width / Screen.height);
        Colunms = Rows * 2;
        Grid = new float[Colunms, Rows];
        for (int i = 0; i < Colunms; i++)
        {
            for (int j = 0; j < Rows; j++)
            {
                Grid[i, j] = Random.Range(0.0f, 1.0f);
                SpawnTile(i, j, Grid[i, j]);
            }
        }
    }

    private Vector3 GridWorldPosition(int x, int y)
    {
        return new Vector3(x - (Horizontal +10.5f), y - (Vertical - 0.5f));
    }

    private void SpawnTile(int x, int y, float value)
    {
        SpriteRenderer sr = Instantiate(tilePrefab, GridWorldPosition(x, y),
            Quaternion.identity).GetComponent<SpriteRenderer>();
        sr.name = "x : " + x + " y : " + y;
        sr.sprite = sprites[isEdge(x, y)];
        sr.gameObject.layer = 6;
        sr.AddComponent<BoxCollider2D>();
        sr.GetComponent<BoxCollider2D>().isTrigger = true;
    }

    private int isEdge(int x, int y)
    {
        if (y == Rows - 1 && x == 0)
        {
            return 0;
        }
        else if (y == Rows - 1 && x != 0 && x != Colunms - 1)
        {
            return 1;
        }
        else if (y == Rows - 1 && x == Colunms - 1)
        {
            return 2;
        }
        else if (x == 0 && y != 0 && y != Rows - 1)
        {
            return 3;
        }
        else if (x == Colunms - 1 && y != 0 && y != Rows - 1)
        {
            return 5;
        }
        else if (x == 0 && y == 0)
        {
            return 6;
        }
        else if (x != 0 && x != Colunms - 1 && y == 0)
        {
            return 7;
        }
        else if (x == Colunms - 1 && y == 0)
        {
            return 8;
        }
        else
            return 4;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
