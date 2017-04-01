using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class Block : MonoBehaviour
{
    public Vector2 index;

    public List<Vector2> positions = new List<Vector2>();
    public bool backGround = true;
    public uint tileType;

    private Vector2 gridSize = new Vector2(1, 1);
    private bool xFlip, yFlip;

    void Start()
    {
    }

    public void Initialize(int x, int y, bool b, uint tileType, int xGridsize = 1, int yGridsize = 1)
    {
        index = new Vector2(x, y);
        positions.Add(index);
        backGround = b;
        this.tileType = tileType;
        // Read the bit stored for flipping a tile horizontally.
        xFlip = (this.tileType & (1 << 31)) != 0;
        // Read the bit stored for flipping a tile vertically.
        yFlip = (this.tileType & (1 << 30)) != 0;

        // Remove both bits which store rotation from the tileType.
        this.tileType &= ~((uint)1 << 31);
        this.tileType &= ~((uint)1 << 30);

        transform.localScale = new Vector3(xFlip ? -1 : 1, yFlip ? -1 : 1, 0);
        gridSize = new Vector2(xGridsize, yGridsize);
    }

    public Vector2 GridSize
    {
        get { return gridSize; }
        set { gridSize = value; }
    }

    public bool X_Flipped
    {
        get { return xFlip; }
    }

    public bool Y_Flipped
    {
        get { return yFlip; }
    }
}
