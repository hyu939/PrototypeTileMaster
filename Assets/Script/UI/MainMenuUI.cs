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
    public int currentLV;

    private void Awake()
    {
        LoadFileSave();
    }
    public void PlayButton()
    {
        playbtCount++;
        if(playbtCount == 3)
        {
            SceneManager.LoadScene(1);

        }
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

    void LoadFileSave()
    {
        // Đọc file JSON 
        string json = File.ReadAllText(Application.dataPath + "/SaveDataFile.json");

        // Tạo đối tượng SaveData và gán giá trị lấy được
        SaveData data = JsonUtility.FromJson<SaveData>(json);
        volumeSlider.value = data.save_Volume;
        currentLV = data.save_currenLV;
        int displaylv = currentLV + 1;
        displayLV.text = (displaylv).ToString();
        Debug.Log("LOAD");
        Debug.Log(json);
    }
}
