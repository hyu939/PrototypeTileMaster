using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector_Spawn : MonoBehaviour
{
    private SpawnTile_Script spawnTile;
    public Transform[] spawnLocal;
    private Collector collector;


    private void Awake()
    {
        spawnTile = GetComponent<SpawnTile_Script>();
        collector = GameObject.FindWithTag("Colletor").GetComponent<Collector>();

    }
    public void SpawnObjectWithTag(int id, int slot)
    {
        GameObject newObject = Instantiate(spawnTile.mapData.tiles[id].tilesPrefab, spawnLocal[slot].position, spawnLocal[slot].rotation);
        newObject.tag = "Collected";
    }

    //public void SpawnObjectAfterDestroy(int id, int slot)
    //{
    //    for (int i = 0; i < spawnTile.mapData.tiles.Count; i++)
    //    {
    //        if (collector.colectTilesId[id] == spawnTile.mapData.tiles[id].id)
    //        {
    //            GameObject newObject = Instantiate(spawnTile.mapData.tiles[id].tilesPrefab, spawnLocal[slot].position, spawnLocal[slot].rotation);
    //            newObject.tag = "Collected";
    //        }
    //    }

    //}

    public void SpawnObjectAfterDestroy(int id, int slot)
    {
        for (int i = 0; i < collector.colectTilesId.Length; i++)
        {
            GameObject newObject = Instantiate(spawnTile.mapData.tiles[id].tilesPrefab, spawnLocal[slot].position, spawnLocal[slot].rotation);
            newObject.tag = "Collected";
        }

    }
}
