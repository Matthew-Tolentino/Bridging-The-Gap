using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile
{
    public int x;
    public int y;
    public GameObject tile;

    public Tile(int _x, int _y, GameObject _tile) {
        this.x = _x;
        this.y = _y;
        this.tile = _tile;
    }
}
