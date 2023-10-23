using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Collections.ObjectModel;

public class Tile_Script : MonoBehaviour 
{
    [SerializeField] private int id;
    private Collector collector;

    private void Awake()
    {
        collector = GameObject.FindWithTag("Colletor").GetComponent<Collector>();
    }
    private void OnMouseDown()
    {
        collector.TilesArray(id);
        Destroy(gameObject);
    }
}
