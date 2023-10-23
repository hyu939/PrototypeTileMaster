using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Tile_Script : MonoBehaviour 
{
    [SerializeField] private int id;

    private void OnMouseDown()
    {
        Collector.Instance.TilesArray(id);
        Destroy(gameObject);
    }
}
