using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MapEditor : MonoBehaviour
{
    public HitObstacle prefab;

    public HitObstacle cur;
    public void InstantiateNew()
    {
        var instance = Instantiate(prefab, transform);
        instance.transform.position = cur.transform.position;
        cur.nextObstacle = instance;
        cur = instance;
        
    }
}
