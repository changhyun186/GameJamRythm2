using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BackGroundScript : MonoBehaviour
{
    private enum RotateType
    {
        LEFT = 0,
        RIGHT,
        SIDE,
    }

    [SerializeField] private RotateType rotateType;

    Image obj;

    float timer = 0;

    [SerializeField] private int count = 0;
    int i = 1;
    bool isrotation = false;
    [SerializeField] private float curAngle;
    [SerializeField] private float tarAngle;
    float timeCounter = 0;

    Vector3 scale;

    // Start is called before the first frame update
    void Start()
    {
        obj = GetComponent<Image>();
        curAngle = transform.localRotation.eulerAngles.z;
        //Debug.Log($"{transform.rotation.eulerAngles.z}");
        scale = transform.localScale;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Pumping();
        Switcher();
        Rotation();
    }

    void Pumping()
    {
        timer += Time.deltaTime;
        if (timer >= 0.0001f)
        {
            obj.transform.localScale += new Vector3(0.005f, 0.005f, 0.005f) * i * scale.x;
            timer = 0;
        }
        if(obj.transform.localScale.x > scale.x * 1.15f)
        {
            i = -1;
        }
        if (obj.transform.localScale.x < scale.x * 0.9f)
        {
            i = 1;
            count++;
        }
    }

    void Switcher()
    {
        switch ((int)rotateType)
        {
            case 0:
                Rotate(2, 90);
                break;
            case 1:
                Rotate(2, -90);
                break;
            case 2:
                Rotate(1, 1);
                break;
        }
    }

    void Rotate(int _count, int dir)
    {
        if (count == _count)
        {
           //transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
            
            isrotation = true;
            curAngle += 90; //0
            timeCounter = 0;
            tarAngle = curAngle + dir; //dir
            count = 0;
        }
    }

    void Rotation()
    {
        if(isrotation)
        {
            transform.localRotation = Quaternion.Slerp(Quaternion.Euler(new Vector3(0, 0, curAngle)), Quaternion.Euler(new Vector3(0, 0, tarAngle)), timeCounter);
            timeCounter += Time.deltaTime;
        }
        //if(transform.rotation.z >= tarAngle)
        //{
        //    isrotation = false;
        //}

        //if(tarAngle >= curAngle)
        //{
        //    transform.rotation = Quaternion.Euler(new Vector3(0, 0, (int)transform.rotation.z));
        //    isrotation = false;
        //    timeCounter = 0f;
        //}
    }
}
