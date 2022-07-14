using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Setting : MonoSingleTon<Setting>
{
    public void GoHome()
    {
        SceneManager.LoadScene("StartScene");
        Time.timeScale = 1;
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
