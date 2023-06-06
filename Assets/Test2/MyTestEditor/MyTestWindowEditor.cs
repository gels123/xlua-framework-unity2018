using UnityEditor;
using UnityEngine;

namespace MyTestEditor
{
    public class MyTestWindowEditor : EditorWindow
    {
        string input = "Hello World";
        bool groupEnabled;
        bool bVal = true;
        float fVal = 1.23f;
        
        [MenuItem("Window/MyWindow")]
        private static void ShowMyWindow()
        {
            // var window = GetWindow<MyTestWindowEditor>();
            var window = GetWindow(typeof(MyTestWindowEditor), true);
            window.titleContent = new GUIContent("My Window");
            window.Show();
        }
        
        private void OnGUI()
        {
            GUILayout.Label("Setting", EditorStyles.boldLabel);
            input = EditorGUILayout.TextField("Text Field", input);
            groupEnabled = EditorGUILayout.BeginToggleGroup("Optional Settings", groupEnabled);
            bVal = EditorGUILayout.Toggle("Toggle", bVal);
            fVal = EditorGUILayout.Slider("Slider", fVal, -3, 3);
            EditorGUILayout.EndToggleGroup();
        }
    }
}