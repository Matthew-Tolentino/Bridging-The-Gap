using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// [ExecuteInEditMode]
public class MapGenerator : MonoBehaviour
{
    [Header("Visuals")]
    public bool autoUpdate;

    public int row, col;

    [SerializeField] GameObject tile;

    Map map;

    public void GenerateMap() {
        // Destroy the last map before rendering new one
        if (map != null) map.Clear();

        map = new Map(row, col);

        // Generating tiles
        float tileRatio = tile.transform.localScale.x / 114.41f;
        float rowMultiplier = tileRatio * 1.75f;
        float colMultiplier = tileRatio * 2f;

        GameObject new_Tile = null;
        for (int r = 0; r < row; ++r) {
            for (int c = 0; c < col; ++c) {
                if (r % 2 == 0) {
                    new_Tile = Instantiate(tile, new Vector3(c * colMultiplier, 0, r * rowMultiplier), tile.transform.rotation);
                } else {
                    new_Tile = Instantiate(tile, new Vector3(c * colMultiplier + tileRatio, 0, r * rowMultiplier), tile.transform.rotation);
                }
                new_Tile.transform.parent = transform;

                new_Tile.name = "Tile_" + r + "_" + c;

                map.level[r,c] = new Tile(r, c, new_Tile);

                map.level[r,c].SpawnIn();
            }
        }
    }

    public void ClearMap() {
        // Delete all refrences to map data structure
        map.Clear();

        // Delete all children under map generator
        // Need to save children to list so that deleting iterator doesn't skip every other child
        List<Transform> childrenList = new List<Transform>();
        foreach (Transform child in transform) {
            childrenList.Add(child);
        }

        foreach (Transform child in childrenList) {
            DestroyImmediate(child.gameObject);
        }
    }

    void OnValidate() {
        if (row < 0) row = 0;
        if (col < 0) col = 0;
    }
}
