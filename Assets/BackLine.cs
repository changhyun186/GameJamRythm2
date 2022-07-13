using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackLine : MonoBehaviour
{
    public Material material;
    public float FadeSpeed;
    private void Start()
    {
        material = new Material(material);
        GetComponent<Renderer>().material = material;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        var color = material.color;
        color.a = Mathf.Clamp(color.a- FadeSpeed,0,1);
        material.color = color;
    }
}
