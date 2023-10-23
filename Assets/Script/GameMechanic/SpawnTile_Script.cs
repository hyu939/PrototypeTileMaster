using System.Collections.Generic;
using UnityEngine;


public class SpawnTile_Script : MonoBehaviour
{
    public MapData mapData;

    private void Awake()
    {
        for (int i = 0; i < mapData.tiles.Count; i++)
        {
            for (int j = 0; j < mapData.tiles[i].chance*3; j++)
            {
                SpawnRandomTiles(i, new Vector3(Random.Range(-0.45f, 0.45f), Random.Range(1f, 3f), Random.Range(-1f, 1f)));
            }
        }
    }

    private void SpawnRandomTiles(int i, Vector3 position)
    {
        GameObject gameObject = Instantiate(mapData.tiles[i].tilesPrefab, position, Quaternion.identity, transform);
        Tile_Script tiles = gameObject.GetComponent<Tile_Script>();
        tiles.id = i;
    }

}
