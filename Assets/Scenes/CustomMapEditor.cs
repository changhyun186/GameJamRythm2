using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(MapEditor))]
public class CustomMapEditor: Editor
{
    MapEditor selected;
    SerializedProperty property;
    SerializedProperty property2;
    void OnEnable()
    {
        if (AssetDatabase.Contains(target))
        {
            selected = null;
        }
        else
        {
            selected = (MapEditor)target;
        }


        property = serializedObject.FindProperty("prefab");
        property2 = serializedObject.FindProperty("cur");
    }

    public override void OnInspectorGUI()
    {
        //트랜지션 새로 생성하고 select함 연걸도 다해주고
        if (GUILayout.Button("NewObs"))
        {
            selected.InstantiateNew();
        }

        EditorGUILayout.PropertyField(property);
        EditorGUILayout.PropertyField(property2);
        serializedObject.ApplyModifiedProperties();
    }
}
