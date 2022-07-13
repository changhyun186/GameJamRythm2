using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StartSceneManager : MonoBehaviour
{
    public UnityEvent onPresstoStart;
    private void Update()
    {
        if (Input.anyKeyDown)
        {
            onPresstoStart?.Invoke();
        }

    }
}
