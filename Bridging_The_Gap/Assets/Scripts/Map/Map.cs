using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map
{
    public int rows;
    public int cols;
    public Tile[,] level;

    public Map(int _rows, int _cols) {
        this.rows = _rows;
        this.cols = _cols;
        level = new Tile[_rows, _cols];
    }

    public void Clear() {
        for (int i = 0; i < rows; ++i) {
            for (int j = 0; j < cols; ++j) {
                // Check if in playmode to determine how to destroy tiles
                if (Application.isPlaying) 
                    UnityEngine.Object.Destroy(level[i, j].tile);
                else
                    UnityEngine.Object.DestroyImmediate(level[i, j].tile);
            }
        }
    }
}
