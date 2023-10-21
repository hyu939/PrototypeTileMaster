using UnityEngine;
using UnityEditor;
using System.Diagnostics;


public class MapData_EditorWindow : EditorWindow
{

    protected SerializedObject serializedObject;
    protected SerializedProperty serializedProperty;

    protected MapData[] mapData;
    protected string selectedPropertyPach;
    protected string selectedProperty;

    private Vector2 scrollPosition = Vector2.zero;



    [MenuItem("MyTab/mapData")]
    protected static void ShowWindow()
    {
        GetWindow<MapData_EditorWindow>("mapData");
    }



    private void OnGUI()
    {
        mapData = GetAllInstances<MapData>();
        serializedObject = new SerializedObject(mapData[0]);

        EditorGUILayout.BeginHorizontal();

        EditorGUILayout.BeginVertical("box", GUILayout.MaxWidth(150), GUILayout.ExpandHeight(true));

        DrawSliderBar(mapData);

        EditorGUILayout.EndVertical();
        EditorGUILayout.BeginVertical("box", GUILayout.ExpandHeight(true));
        scrollPosition = EditorGUILayout.BeginScrollView(scrollPosition);

        if (selectedProperty != null)
        {
            for (int i = 0; i < mapData.Length; i++)
            {
                if (mapData[i].mapname == selectedProperty)
                {
                    serializedObject = new SerializedObject(mapData[i]);
                    //serializedProperty = serializedObject.GetIterator();
                    //serializedProperty.NextVisible(true);
                    //DrawProperties(serializedProperty);

                    SerializedProperty tilesProperty = serializedObject.FindProperty("tiles");

                    EditorGUILayout.PropertyField(serializedObject.FindProperty("mapname"));
                    EditorGUILayout.PropertyField(serializedObject.FindProperty("lv"));
                    EditorGUILayout.PropertyField(serializedObject.FindProperty("time"));

                    EditorGUILayout.Space();

                    for(int j = 0; j < mapData[i].tiles.Count; j++)
                    {

                        SerializedProperty tileProperty = tilesProperty.GetArrayElementAtIndex(j);
                        SerializedProperty idProperty = tileProperty.FindPropertyRelative("id");
                        SerializedProperty gameObjectProperty = tileProperty.FindPropertyRelative("gameObject");
                        SerializedProperty chanceProperty = tileProperty.FindPropertyRelative("chance");

                        EditorGUILayout.PropertyField(idProperty);
                        EditorGUILayout.PropertyField(gameObjectProperty);
                        EditorGUILayout.PropertyField(chanceProperty);

                        EditorGUILayout.Space();
                    }
                }
            }
            
        }
        else
        {
            EditorGUILayout.LabelField("select an item from the list");
        }

        EditorGUILayout.EndScrollView();
        EditorGUILayout.EndVertical();
        EditorGUILayout.EndHorizontal();

        Apply();
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





    protected void DrawProperties(SerializedProperty p)
    {

        while (p.NextVisible(false))
        {
            EditorGUILayout.PropertyField(p, true);

        }


    }



    protected void DrawSliderBar(MapData[] prop)
    {
        foreach (MapData p in prop)
        {
            if (GUILayout.Button(p.mapname))
            {
                selectedPropertyPach = p.mapname;
            }
        }

        if (!string.IsNullOrEmpty(selectedPropertyPach))
        {
            selectedProperty = selectedPropertyPach;
        }

        if (GUILayout.Button("new Map"))
        {
            MapData newMapData = MapData.CreateInstance<MapData>();
            CreateMapData newMapDataWindow = GetWindow<CreateMapData>("New Map");
            newMapDataWindow.newMapData = newMapData;

        }
    }

    protected void Apply()
    {
        serializedObject.ApplyModifiedProperties();
    }
}
