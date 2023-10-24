using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;


public class SaveLoad : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private int currentLV  = 0;
    [SerializeField] private float volumeValue;
    [SerializeField] private SpawnTile_Script spawnTiles;
    [SerializeField] private MapData[] mapData;

    private void Awake()
    {
        LoadData();
        spawnTiles.mapData = mapData[currentLV];
    }

    public void SaveData()
    {
        string filePath = Application.persistentDataPath + "/data.bin";

        using (BinaryWriter writer = new BinaryWriter(File.Open(filePath, FileMode.Create)))
        {
            writer.Write(currentLV);
            writer.Write(volumeValue);
        }

        Debug.Log("Data saved!");
    }


    public void LoadData()
    {
        string filePath = Application.persistentDataPath + "/data.bin";

        if (File.Exists(filePath))
        {
            using (BinaryReader reader = new BinaryReader(File.Open(filePath, FileMode.Open)))
            {
                currentLV = reader.ReadInt32();
                volumeValue = reader.ReadSingle();

                volumeSlider.value = volumeValue;
            }

            Debug.Log("Data loaded!");
            Debug.Log(filePath);
        }
        else
        {
            Debug.Log("No saved data found!");
            SaveData();
        }
    }

    public void Slider()
    {
        volumeValue = volumeSlider.value;
    }

    public void NextLVSave()
    {
        if (currentLV == 2)
            currentLV = 0;
        else
            currentLV++;

        SaveData();
        LoadData();
    }

}
