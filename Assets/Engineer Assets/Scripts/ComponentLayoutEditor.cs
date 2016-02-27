/*  Script: ComponentLayoutEditor.cs
    Author: Zackary Hoyt

    Description:
    Overwrites the Unity Editor for the following components:
        ObjectBehavior.cs - Serializes the array of traits.

    Most of this script is designed to not be loaded whenever the project is being built, as
    the UnityEditor directive is not supported outside of the editor environment. Therefore,
    it is entirely 'functionless.'
*/

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

#if UNITY_EDITOR 
using UnityEditor;
//      ObjectBehavior
[CustomEditor(typeof(ObjectBehavior))]
[CanEditMultipleObjects]
public class ObjectBehaviorEditor : Editor
{
    SerializedProperty traits;
    void OnEnable() { traits = serializedObject.FindProperty("traits"); }

    Vector2 scrollBarPos = new Vector2();
    public override void OnInspectorGUI()
    {
        // Update the serializedProperty - always do this in the beginning of OnInspectorGUI.
        serializedObject.Update();

        //  Begin Scroll Bar
        EditorGUILayout.BeginVertical();
        scrollBarPos = EditorGUILayout.BeginScrollView(scrollBarPos);

        //  Display Serialized Values
        for (int i = 0; i < ObjectBehavior.TRAITS_SIZE; i++)
            traits.GetArrayElementAtIndex(i).boolValue = EditorGUILayout.ToggleLeft(ObjectBehavior.traitNames[i], traits.GetArrayElementAtIndex(i).boolValue);

        //  End Scroll Bar
        EditorGUILayout.EndScrollView();
        EditorGUILayout.EndVertical();

        // Apply changes to the serializedProperty - always do this in the end of OnInspectorGUI.
        serializedObject.ApplyModifiedProperties();
    }
}
#endif
