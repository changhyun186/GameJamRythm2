using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MapEditor : MonoBehaviour
{
    public MirrorObstacle mirrorObstacle;
    public PipeObstacle arch;
    public PipeObstacle twoDir;
    public SpinObstacle spinner;
    public RingObstacle portal;
    public GameObject portL,portR;

    public HitObstacle cur;
    public void InstantiateMirror()
    {
        //var instance = (HitObstacle)PrefabUtility.InstantiatePrefab(mirrorObstacle,transform);
        var instance = Instantiate(mirrorObstacle, transform);
        instance.transform.position = cur.transform.position;
        cur.nextObstacle = instance;
        cur = instance;
        Selection.activeObject = cur;
        
    }
    public void InstantiatePortal()
    {
        var instance = Instantiate(portal, transform);
        instance.transform.position = cur.transform.position;
        cur.nextObstacle = instance;
        cur = instance;
        Selection.activeObject = cur;

        var instanceL = Instantiate(portL, transform);
        instanceL.transform.position = cur.transform.position;
        ((RingObstacle)cur).leftOut = instanceL.transform.Find("Point");


        var instanceR = Instantiate(portR, transform);
        instanceR.transform.position = cur.transform.position;
        ((RingObstacle)cur).rightOut = instanceR.transform.Find("Point");
    }

    public void InstanatiateTwoDir()
    {
        var instance = Instantiate(twoDir, transform);
        instance.transform.position = cur.transform.position;
        cur.nextObstacle = instance;
        cur = instance;
        Selection.activeObject = cur;
    }

    public void InstantiateSpinner()
    {
        var instance = Instantiate(spinner, transform);
        instance.transform.position = cur.transform.position;
        cur.nextObstacle = instance;
        cur = instance;
        Selection.activeObject = cur;
    }
}
