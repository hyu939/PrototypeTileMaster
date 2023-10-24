using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;


public class SaveData
{
    public int save_currenLV;
    public float save_Volume;
}

public class SaveLoad : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private int currentLV;
    [SerializeField] private SpawnTile_Script spawnTiles;
    protected MapData[] mapData;

    private void Awake()
    {
        mapData = GetAllInstances<MapData>();
        LoadJson();
        spawnTiles.mapData = mapData[currentLV];
    }
    public void SaveJson()
    {
        // Tạo đối tượng SaveData và gán giá trị
        SaveData data = new SaveData();
        data.save_Volume = volumeSlider.value;
        data.save_currenLV = currentLV;

        // Chuyển đối tượng SaveData thành chuỗi JSON
        string json = JsonUtility.ToJson(data, true);

        // Lưu chuỗi JSON vào file
        File.WriteAllText(Application.dataPath + "/SaveDataFile.json", json);
        Debug.Log("SAVE");
        Debug.Log(json);
    }

    public void LoadJson()
    {
        // Đọc file JSON 
        string json = File.ReadAllText(Application.dataPath + "/SaveDataFile.json");

        // Tạo đối tượng SaveData và gán giá trị lấy được
        SaveData data = JsonUtility.FromJson<SaveData>(json);
        volumeSlider.value = data.save_Volume;
        currentLV = data.save_currenLV;
        Debug.Log("LOAD");
        Debug.Log(json);
    }

    public void NextLVSave()
    {
        if (currentLV == 3)
            currentLV = 0;
        else
            currentLV++;

        SaveJson();
        LoadJson();
    }


    public static T[] GetAllInstances<T>() where T : MapData
    {
        string[] guids = AssetDatabase.FindAssets("t:" + typeof(T).Name);
        T[] a = new T[guids.Length];
        for (int i = 0; i < guids.Length; i++)
        {
            string path = AssetDatabase.GUIDToAssetPath(guids[i]);
            a[i] = AssetDatabase.LoadAssetAtPath<T>(path);
        }

        return a;

    }
}
