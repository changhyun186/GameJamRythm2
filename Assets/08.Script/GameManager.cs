using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoSingleTon<GameManager>
{
    public HitObstacle curHitObstacle;
    public PlayerCircle player;
    public int CountAmount = 6;
    public TMP_Text countText;
    public GameObject deathParticle;
    public string NextSceneName;
    private void Start()
    {
        curHitObstacle.SetIsCurTarget(true);
        StartCoroutine(countCor());
    }

    IEnumerator countCor()
    {
        WaitForSeconds wait = new WaitForSeconds(0.6f);
        int temp = CountAmount;
        countText.text = CountAmount.ToString();
        for(int i = 0; i < temp; i++)
        {
            yield return wait;
            CountAmount--;
            if (CountAmount <= 0)
            {
                Destroy(countText.gameObject);
                player.isStart = true;
            }
            else
                countText.text = CountAmount.ToString();
            
        }
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.D))
        {
            if(player.isEalryHit)
            {
                player.EalryKeyType = KeyType.D;
                return;
            }
            if (!player.isKeyDownAble)
            {
                Die();
                return;
            }
            OnKeyDDown();
        }
        else if (Input.GetKeyDown(KeyCode.K))
        {
            if (player.isEalryHit)
            {
                player.EalryKeyType = KeyType.K;
                return;
            }
            if (!player.isKeyDownAble)
            {
                Die();
                return;
            }
            OnKeyKDown();
        }
    }

    public void OnKeyKDown()
    {
        curHitObstacle.OnRightKeyDown();
        player.StopCor();
        curHitObstacle.Break();
        CameraEffect.Instance.toTarget();
    }

    public void OnKeyDDown()
    {
        curHitObstacle.OnLeftKeyDown();
        player.StopCor();
        curHitObstacle.Break();
        CameraEffect.Instance.toTarget();
    }

    public void Complete()
    {
        Invoke(nameof(LoadNextScene), 1);
    }
    void LoadNextScene()
    {
        SceneManager.LoadScene(NextSceneName);
    }
    public void Die()
    {
        var particle = Instantiate(deathParticle, player.transform.position, Quaternion.identity);
        Destroy(player.gameObject);
        Invoke(nameof(LoadCurScene), 0.5f);
    }

    void LoadCurScene() => UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
}
