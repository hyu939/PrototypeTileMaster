using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;


public class Collector : MonoBehaviour
{
    //public static Collector Instance;
    public int[] colectTilesId = new int[0];
    private int size;
    [SerializeField]private Score score;
    public Collector_Spawn collector_Spawn;

    [SerializeField] private SpawnTile_Script spawn_Script;
    private int tileCollected = 0;

    void Awake()
    {
        colectTilesId = new int[0];
        score = GameObject.FindWithTag("Spawn").GetComponent<Score>();
        collector_Spawn = GameObject.FindWithTag("Spawn").GetComponent<Collector_Spawn>();
        spawn_Script = GameObject.FindWithTag("Spawn").GetComponent<SpawnTile_Script>();

        //if (Instance == null)
        //{
        //    Instance = this;
        //    DontDestroyOnLoad(gameObject);
        //}
        //else
        //{
        //    Destroy(gameObject);
        //}
    }

    public void TilesArray(int id)
    {
        size++;
        Array.Resize<int>(ref colectTilesId, size);
        colectTilesId[size - 1] = id;

        DestroyCollected();

        // Sắp xếp mảng theo thứ tự tăng dần
        Array.Sort(colectTilesId);

        SpawnObject();

        for (int i = 0; i < colectTilesId.Length; i++)
        {
            // Đếm số lần xuất hiện của phần tử hiện tại
            int count = 1;
            while (i < colectTilesId.Length - 1 && colectTilesId[i] == colectTilesId[i + 1])
            {
                count++;
                i++;
            }

            // Nếu số lần xuất hiện bằng 3, in ra phần tử trùng lặp 3 lần
            if (count == 3)
            {
                Debug.Log("Phần tử trùng lặp 3 lần: " + colectTilesId[i]);
                score.ScorePlus();
                DestroyCollected();

                colectTilesId = colectTilesId.Where(x => x != colectTilesId[i]).ToArray();
                size = size - 3;

                SpawnObject();
            }
        }

        if(size >= 6)
        {
            Debug.Log("GameOver");
        }

        WinCondition();
        
    }

    void DestroyCollected()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("Collected");
        foreach (GameObject obj in objects)
        {
            Destroy(obj);
        }
    }

    void SpawnObject()
    {
        
        for (int j = 0; j < colectTilesId.Length; j++)
        {
            collector_Spawn.SpawnObjectWithTag(colectTilesId[j], j);
        }
    }

    void WinCondition()
    {
        tileCollected++;
        if (tileCollected == spawn_Script.mapData.tiles.Sum(tiles => tiles.chance)*3)
        {
            Debug.Log("WWWWWWWWWWWINNNNNNNNN");
        }
    }

}