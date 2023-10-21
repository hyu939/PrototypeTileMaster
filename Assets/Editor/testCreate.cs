using UnityEngine;
using UnityEditor;



public class testCreate : EditorWindow
{
    private SerializedObject serializedObject;
    private SerializedProperty serializedProperty;

    protected MapData[] mapData;
    public MapData newMapData;

    private void OnGUI()
    {

        serializedObject = new SerializedObject(newMapData);
        serializedProperty = serializedObject.GetIterator();
        serializedProperty.NextVisible(true);
        DrawProperties(serializedProperty);
        if (GUILayout.Button("save"))
        {
            mapData = GetAllInstances<MapData>();
            if (newMapData.mapname == null)
            {
                newMapData.mapname = "hero" + (mapData.Length + 1);
            }
            AssetDatabase.CreateAsset(newMapData, "Assets/Script/Map/MapData_Map" + (mapData.Length + 1) + ".asset");
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
            Close();
        }

        Apply();
    }

    protected void DrawProperties(SerializedProperty p)
    {

        while (p.NextVisible(false))
        {
            EditorGUILayout.PropertyField(p, true);

        }
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

    protected void Apply()
    {
        serializedObject.ApplyModifiedProperties();
    }
}