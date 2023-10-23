using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MapData", menuName = "MapData")]
public class MapData : ScriptableObject
{
    public string mapname;
    public int lv;
    public int time;

    [SerializeField] public List<Tile> tiles;
    
}

[System.Serializable]
public class Tile
{
    public int id;
    public GameObject tilesPrefab;
    public int chance;
}

