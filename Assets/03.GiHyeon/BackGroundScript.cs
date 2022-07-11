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

    // Start is called before the first frame update
    void Start()
    {
        obj = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        Pumping();
        Switcher();
        Rotation();
    }

    void Pumping()
    {
        timer += Time.deltaTime;
        if (timer >= 0.008f)
        {
            obj.transform.localScale += new Vector3(0.01f, 0.01f, 0.01f) * i;
            timer = 0;
        }
        if(obj.transform.localScale.x > 1.15f)
        {
            i = -1;
        }
        if (obj.transform.localScale.x < 0.9f)
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
                Rotate(4, 90);
                break;
            case 1:
                Rotate(4, -90);
                break;
            case 2:
                Rotate(2, 1);
                break;
        }
    }

    void Rotate(int _count, int dir)
    {
        if (count == _count)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
            Debug.Log("ÃÊ±âÈ­µÊ");
            isrotation = true;
            curAngle = 0;
            timeCounter = 0;
            tarAngle = dir;
            count = 0;
        }
    }

    void Rotation()
    {
        if(isrotation)
        {
            Debug.Log("½ÇÇàµÊ");
            transform.rotation = Quaternion.Slerp(Quaternion.Euler(new Vector3(0, 0, curAngle)), Quaternion.Euler(new Vector3(0, 0, tarAngle)), timeCounter);
            timeCounter += Time.deltaTime;
        }
        if(transform.rotation.z >= tarAngle)
        {
            isrotation = false;
        }
        //if(tarAngle >= curAngle)
        //{
        //    transform.rotation = Quaternion.Euler(new Vector3(0, 0, (int)transform.rotation.z));
        //    isrotation = false;
        //    timeCounter = 0f;
        //}
    }
}
