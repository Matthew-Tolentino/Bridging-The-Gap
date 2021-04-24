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

    Map map = null;

    // Start is called before the first frame update
    void Awake()
    {
        GenerateMap();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GenerateMap() {
        // Destroy the last map before rendering new one
        if (map != null) map.Clear();

        map = new Map(row, col);

        GameObject new_Tile = null;
        for (int r = 0; r < row; ++r) {
            for (int c = 0; c < col; ++c) {
                if (r % 2 == 0) {
                    new_Tile = Instantiate(tile, new Vector3(c * 2, 0, r * 1.75f), tile.transform.rotation);
                } else {
                    new_Tile = Instantiate(tile, new Vector3(c * 2 + 1, 0, r * 1.75f), tile.transform.rotation);
                }
                new_Tile.transform.parent = transform;

                map.level[r,c] = new Tile(r, c, new_Tile);
            }
        }
    }

    public void ClearMap() {
        map.Clear();
    }

    void OnValidate() {
        if (row < 0) row = 0;
        if (col < 0) col = 0;
    }
}
