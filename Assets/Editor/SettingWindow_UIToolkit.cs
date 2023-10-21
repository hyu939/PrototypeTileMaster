using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class SettingWindow_UIToolkit : EditorWindow
{
    [SerializeField]
    private VisualTreeAsset m_VisualTreeAsset = default;

    [MenuItem("Window/UI Toolkit/SettingWindow_UIToolkit")]
    public static void ShowExample()
    {
        SettingWindow_UIToolkit wnd = GetWindow<SettingWindow_UIToolkit>();
        wnd.titleContent = new GUIContent("SettingWindow_UIToolkit");
    }

    public void CreateGUI()
    {
        // Each editor window contains a root VisualElement object
        VisualElement
            root = rootVisualElement;

        // VisualElements objects can contain other VisualElement following a tree hierarchy.
        VisualElement label = new Label("Hello World! From C#");
        root.Add(label);

        // Instantiate UXML
        VisualElement labelFromUXML = m_VisualTreeAsset.Instantiate();
        root.Add(labelFromUXML);
    }
}
