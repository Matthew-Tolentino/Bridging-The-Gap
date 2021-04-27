using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile
{
    public int x;
    public int y;
    public GameObject tile;

    public float smoothTime = 1f;
    Vector3 velocity = Vector3.zero;

    public Tile(int _x, int _y, GameObject _tile) {
        this.x = _x;
        this.y = _y;
        this.tile = _tile;
    }

    // public void SpawnIn() {
    //     Vector3 original_position = tile.transform.position;
    //     tile.transform.position = new Vector3(tile.transform.position.x, tile.transform.position.y - 20, tile.transform.position.z);

    //     StartCoroutine(original_position);
    // }

    public IEnumerator SpawnIn() {

        Vector3 original_position = tile.transform.position;
        tile.transform.position = new Vector3(tile.transform.position.x, tile.transform.position.y - 100, tile.transform.position.z);

        while (tile.transform.position.y < original_position.y) {
            tile.transform.position = new Vector3(tile.transform.position.x, tile.transform.position.y + 1, tile.transform.position.z);
            yield return null;
        }
    }
}
