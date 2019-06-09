using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

// IngredientDrawer
[CustomPropertyDrawer(typeof(BoolVariable))]
[CustomPropertyDrawer(typeof(IntVariable))]
// [CustomPropertyDrawer(typeof(IntArrayVariable))]
[CustomPropertyDrawer(typeof(FloatVariable))]
[CustomPropertyDrawer(typeof(StringVariable))]
[CustomPropertyDrawer(typeof(Vector2Variable))]
[CustomPropertyDrawer(typeof(Vector3Variable))]
[CustomPropertyDrawer(typeof(ColorVariable))]
public class VariablePropDrawer : PropertyDrawer
{

    /// <summary>
    /// Options to display in the popup to select constant or variable.
    /// </summary>
    private readonly string[] popupOptions =
        { "Use Reference", "Use Variable" };

    /// <summary> Cached style to use to draw the popup button. </summary>
    private GUIStyle popupStyle;

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        if (popupStyle == null)
        {
            popupStyle = new GUIStyle(GUI.skin.GetStyle("PaneOptions"));
            popupStyle.imagePosition = ImagePosition.ImageOnly;
        }

        label = EditorGUI.BeginProperty(position, label, property);
        position = EditorGUI.PrefixLabel(position, label);

        EditorGUI.BeginChangeCheck();

        // Get properties
        SerializedProperty useReference = property.FindPropertyRelative("useReference");
        SerializedProperty localValue = property.FindPropertyRelative("localValue");
        SerializedProperty reference = property.FindPropertyRelative("serializedReference");

        // Calculate rect for configuration button
        Rect buttonRect = new Rect(position);
        buttonRect.yMin += popupStyle.margin.top;
        buttonRect.width = popupStyle.fixedWidth + popupStyle.margin.right;
        position.xMin = buttonRect.xMax;

        // Store old indent level and set it to 0, the PrefixLabel takes care of it
        int indent = EditorGUI.indentLevel;
        EditorGUI.indentLevel = 0;

        int result = EditorGUI.Popup(buttonRect, useReference.boolValue ? 0 : 1, popupOptions, popupStyle);

        useReference.boolValue = result == 0;
        if (useReference.boolValue)
        {
            EditorGUI.PropertyField(position, reference, GUIContent.none);
            if (!(reference.objectReferenceValue is ReferenceBase))
            {
                reference.objectReferenceValue = null;
            }
        }
        else
        {
            EditorGUI.PropertyField(position, localValue, GUIContent.none);
        }

        if (EditorGUI.EndChangeCheck()) property.serializedObject.ApplyModifiedProperties();

        EditorGUI.indentLevel = indent;
        EditorGUI.EndProperty();
    }
}
