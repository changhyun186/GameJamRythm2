using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
#if UNITY_EDITOR
[CustomEditor(typeof(HitObstacle), true), CanEditMultipleObjects]
public class CustomMapEditor : Editor
{
    HitObstacle selected;
    SerializedProperty property;
    SerializedProperty property2, property3, property4, property5, property6, property7;
    void OnEnable()
    {
        if (AssetDatabase.Contains(target))
        {
            selected = null;
        }
        else
        {
            selected = (HitObstacle)target;
        }
        property = serializedObject.FindProperty("breakParticle");
        property2 = serializedObject.FindProperty("breakPrefab");
        property3 = serializedObject.FindProperty("nextObstacle");
        //property = serializedObject.FindProperty("mirrorObstalce");
        //property2 = serializedObject.FindProperty("arch");
        //property3 = serializedObject.FindProperty("twoDir");
        //property4 = serializedObject.FindProperty("spinner");
        //property5 = serializedObject.FindProperty("portal");
        //property6 = serializedObject.FindProperty("portL");
        //property7 = serializedObject.FindProperty("portR");

    }

    public override void OnInspectorGUI()
    {
        //트랜지션 새로 생성하고 select함 연걸도 다해주고
        if (GUILayout.Button("Mirror"))
        {
            var editor = FindObjectOfType<MapEditor>();
            editor.InstantiateMirror();
        }
        if (GUILayout.Button("Portal"))
        {
            var editor = FindObjectOfType<MapEditor>();
            editor.InstantiatePortal();
        }
        if (GUILayout.Button("Spinner"))
        {
            var editor = FindObjectOfType<MapEditor>();
            editor.InstantiateSpinner();
        }
        if (GUILayout.Button("TwoDir"))
        {
            var editor = FindObjectOfType<MapEditor>();
            editor.InstanatiateTwoDir();
        }

        EditorGUILayout.PropertyField(property);
        EditorGUILayout.PropertyField(property2);
        EditorGUILayout.PropertyField(property3);
        //EditorGUILayout.PropertyField(property2);
        //EditorGUILayout.PropertyField(property3);
        //EditorGUILayout.PropertyField(property4);
        //EditorGUILayout.PropertyField(property5);
        //EditorGUILayout.PropertyField(property6);
        //EditorGUILayout.PropertyField(property7);
        serializedObject.ApplyModifiedProperties();
    }
}
#endif
