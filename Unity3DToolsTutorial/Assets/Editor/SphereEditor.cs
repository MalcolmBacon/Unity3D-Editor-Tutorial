using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Sphere))]
public class SphereEditor : Editor
{
    public override void OnInspectorGUI()
    {
        Sphere sphere = (Sphere)target;

        GUILayout.Label("Oscillates around a base size");
        // Add slider
        sphere.baseSize = EditorGUILayout.Slider("Size", sphere.baseSize, 0.1f, 0.2f);

        sphere.transform.localScale = Vector3.one * sphere.baseSize;
    }
}
