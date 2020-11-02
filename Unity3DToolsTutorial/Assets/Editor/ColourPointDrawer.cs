using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(ColorPoint))]
public class ColourPointDrawer : PropertyDrawer
{
    // position -> area of the window we should use to draw property
    // property -> property itself, represented by a SerializedProperty
    // label -> GUIContent that defines the label we should use for the property
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        label = EditorGUI.BeginProperty(position, label, property); // Allow for right clicking on array elements 
        Rect contentPosition = EditorGUI.PrefixLabel(position, label);
        // Detect that we're using two lines by checking the height of position rect
        if (position.height > 16f)
        {
            position.height = 16f; // Set height back to 16 so that colour property stays on one line
            EditorGUI.indentLevel += 1;
            contentPosition = EditorGUI.IndentedRect(position); // Increase indent level by one and apply it to our position
            contentPosition.y += 18f; // Move down a line after property label is drawn 
        }
        contentPosition.width *= 0.75f; // Make only take up 75% of space so that we can fit colour
        int indent = EditorGUI.indentLevel; 
        EditorGUI.indentLevel = 0;// Don't make child fields be indented
        EditorGUI.PropertyField(contentPosition, property.FindPropertyRelative("position"), GUIContent.none); // GUIContent.none gets rid of original label
        contentPosition.x += contentPosition.width;
        contentPosition.width /= 3f;
        EditorGUIUtility.labelWidth = 14f; // Modify label width to fit colour 
        //Add colour 
        EditorGUI.PropertyField(contentPosition, property.FindPropertyRelative("colour"), new GUIContent("C"));
        EditorGUI.EndProperty();

    
        // Reset indenting 
        EditorGUI.indentLevel = indent;
    }
    // Seperate method so that height of drawer can be queried before it is drawn 
    // ie. can be used to determine whether a scrollbar is needed because the content
    // won't fit in the available space
    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return Screen.width < 333 ? (16f + 18f) : 16;
    }
}
