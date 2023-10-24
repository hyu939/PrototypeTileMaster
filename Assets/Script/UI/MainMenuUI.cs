using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenuUI : MonoBehaviour
{
    private int playbtCount=0;
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private TextMeshProUGUI displayLV;

    private int currentLV  = 0;
    private float volumeValue;

    private void Awake()
    {
        LoadData();
    }
    public void PlayButton()
    {
        playbtCount++;
        if(playbtCount == 3)
        {
            SceneManager.LoadScene(1);
            SaveData();
        }
    }

    public void Slider()
    {
        volumeValue = volumeSlider.value;
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
                int displaylv = currentLV + 1;
                displayLV.text = (displaylv).ToString();
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
}
