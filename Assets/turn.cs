using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turn : MonoBehaviour
{
    private float timer = 0;
    [SerializeField] private GameObject turnObj;
    float rotationz;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        turnObj.transform.rotation = Quaternion.Euler(new Vector3(0, 0, rotationz));
        timer += Time.deltaTime;
        if(timer >= 0.001f)
        {
            rotationz -= 0.003f;
            Debug.Log($"{rotationz}");
        }
    }
}
