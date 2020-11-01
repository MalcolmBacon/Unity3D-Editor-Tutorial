using UnityEngine;
using UnityEditor;

public class ExampleWindow : EditorWindow
{
    Color color;
    [MenuItem("Window/Colourizer")]
    public static void ShowWindow()
    {
        // If window isn't shown, create one
        // If it is, focus on it
        GetWindow<ExampleWindow>("Colourizer");
    }
    private void OnGUI() {
        // Window code 
        // Use GUILayout for labels, spaces between properties and buttons
        GUILayout.Label("Colour the selected objects!", EditorStyles.boldLabel);

        color = EditorGUILayout.ColorField("Colour", color);
        if (GUILayout.Button("Colourize!"))
        {
            Colorize();
        }
    }
    void Colorize()
    {
        // Loop through all currently selected objects
        foreach (GameObject obj in Selection.gameObjects)
        {
            Renderer renderer = obj.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.sharedMaterial.color = color;
            }
        }
    }
}
