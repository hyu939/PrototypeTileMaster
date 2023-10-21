using UnityEngine;

[CreateAssetMenu(fileName = "MapData", menuName = "MapData")]
public class MapData : ScriptableObject
{
    public string mapname;
    public int lv;
    public int time;

    [SerializeField]
    public Tile[] tile;
}

[System.Serializable]
public class Tile
{
    public int id;
    public Mesh mesh;
    public int chance;
}