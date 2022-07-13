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
        var instance = (HitObstacle)PrefabUtility.InstantiatePrefab(mirrorObstacle,transform);
        //var instance = Instantiate(mirrorObstacle, transform);
        instance.transform.position = cur.transform.position;
        cur.nextObstacle = instance;
        cur = instance;
        Selection.activeObject = cur;
        
    }
    public void InstantiatePortal()
    {
        var instance = (HitObstacle)PrefabUtility.InstantiatePrefab(portal, transform);
        instance.transform.position = cur.transform.position;
        cur.nextObstacle = instance;
        cur = instance;
        Selection.activeObject = cur;

        var instanceL = (GameObject)PrefabUtility.InstantiatePrefab(portL, transform);
        instanceL.transform.position = cur.transform.position;
        ((RingObstacle)cur).leftOut = instanceL.transform.Find("Point");


        var instanceR = (GameObject)PrefabUtility.InstantiatePrefab(portR, transform);
        instanceR.transform.position = cur.transform.position;
        ((RingObstacle)cur).rightOut = instanceR.transform.Find("Point");
    }

    public void InstanatiateTwoDir()
    {
        var instance = (HitObstacle)PrefabUtility.InstantiatePrefab(twoDir, transform);
        instance.transform.position = cur.transform.position;
        cur.nextObstacle = instance;
        cur = instance;
        Selection.activeObject = cur;
    }

    public void InstantiateSpinner()
    {
        var instance = (HitObstacle)PrefabUtility.InstantiatePrefab(spinner, transform);
        instance.transform.position = cur.transform.position;
        cur.nextObstacle = instance;
        cur = instance;
        Selection.activeObject = cur;
    }

    //public GameObject childer;
    //[ContextMenu("asdds")]
    //public void sefdfgsasgf()
    //{
    //    for(int i=0;i<transform.childCount;i++)
    //    {
    //        var tr = transform.GetChild(i);

    //        Instantiate(childer, tr);
    //    }
    //}
    //[ContextMenu("dfasf")]
    //public void KIller()
    //{
    //    for (int i = 0; i < transform.childCount; i++)
    //    {
    //        var tr = transform.GetChild(i).GetChild(2);
    //        Destroy(tr.gameObject);
    //    }
    //}
}
