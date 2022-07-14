using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class StartTip : MonoBehaviour
{
    public Image ang = null;

    private void Start()
    {
        StartCoroutine(sibval());
    }

    IEnumerator sibval()
    {
        yield return new WaitForSeconds(1f);

        ang.DOFade(0, 2f);
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("StartScene");
    }
}
