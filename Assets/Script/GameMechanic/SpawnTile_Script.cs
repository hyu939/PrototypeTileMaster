
using UnityEngine;


public class SpawnTile_Script : MonoBehaviour
{
    public MapData mapData;


    private void Start()
    {
        for (int i = 0; i < mapData.tiles.Count; i++)
        {
            for (int j = 0; j < mapData.tiles[i].chance*3; j++)
            {
                SpawnRandomTiles(i, new Vector3(Random.Range(-1.5f, 1.5f), Random.Range(1f, 3f), Random.Range(-1.5f, 1.5f)));
            }
        }
    }

    private void SpawnRandomTiles(int i, Vector3 position)
    {
        Instantiate(mapData.tiles[i].gameObject, position, Quaternion.identity, transform);
    }

}