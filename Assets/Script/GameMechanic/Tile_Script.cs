using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Tile_Script : MonoBehaviour 
{
    private void OnMouseDown()
    {
        Destroy(gameObject);
    }
}
