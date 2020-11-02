﻿using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Cube))]
public class CubeEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        Cube cube = (Cube)target;

        GUILayout.BeginHorizontal();
            if (GUILayout.Button("Generate Colour"))
            {
                cube.GenerateColour();
                Debug.Log("Button was pressed");

            }

            if (GUILayout.Button("Reset"))
            {
                cube.Reset();
            }
        GUILayout.EndHorizontal();
    }
}
