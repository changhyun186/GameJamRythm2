using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoSingleTon<GameManager>
{

    public GameObject GuildLine;
    public bool isGuildeLine;
    public AudioClip countDown;
    public GameObject Canvas2;
    public GameObject Canvas;
    public HitObstacle curHitObstacle;
    public PlayerCircle player;
    public int CountAmount = 6;
    public TMP_Text countText;
    public GameObject deathParticle;
    public string NextSceneName;
    public AudioSource music;
    public Toggle toggle;


    public Setting setting;
    public bool isHard;
    

    private void Start()
    {
        HardMode();
        if(isHard)
        {
            MapEditor.Instance.ColorRemove();
        }
        curHitObstacle.SetIsCurTarget(true);
        StartCoroutine(countCor());
        Canvas.SetActive(true);
        Canvas2.SetActive(true);
    }

    IEnumerator countCor()
    {
        WaitForSeconds wait = new WaitForSeconds(0.6f);
        int temp = CountAmount;
        countText.text = CountAmount.ToString();
        for(int i = 0; i < temp; i++)
        {
            yield return wait;
            if(countDown!=null)
            AudioManager.Instance.Play(countDown, MixerChannel.Effect);
            CountAmount--;
            if (CountAmount <= 0)
            {
                Destroy(countText.gameObject);
                player.isStart = true;
                if(music!=null)
                music.Play();
            }
            else
                countText.text = CountAmount.ToString();
            
        }
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            setting.gameObject.SetActive(!setting.gameObject.activeSelf);
            bool isOn = setting.gameObject.activeSelf;
            if(isOn)
            {
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
            }
        }
        if (!player.isStart) return;
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

    Coroutine directionCheckCor;
    public void OnKeyKDown() 
    {
        curHitObstacle.OnRightKeyDown();
        player.StopCor();
        curHitObstacle.Break();
        CameraEffect.Instance.toTarget();
        if (directionCheckCor != null)
            StopCoroutine(directionCheckCor);
        directionCheckCor = StartCoroutine(CheckRightDirectionCor(curHitObstacle));
    }
    IEnumerator CheckRightDirectionCor(HitObstacle hitObstacle)
    {
        //yield return new WaitForSeconds(0.5f);
        while(true)
        {
            if (hitObstacle.nextObstacle != null)
            {
                var hitPos = hitObstacle.transform.position;
                float distanceA = Vector3.Distance(player.transform.position, hitPos);
                yield return new WaitForSeconds(0.3f);
                float distanceB = Vector3.Distance(player.transform.position, hitPos);
                if (distanceB > distanceA)
                {
                    Die();
                    print("die");
                }
                print(distanceB + " " + distanceA);
            }

            yield return new WaitForSeconds(1f);
        }


    }

    public void OnKeyDDown()
    {
        curHitObstacle.OnLeftKeyDown();
        player.StopCor();
        curHitObstacle.Break();
        CameraEffect.Instance.toTarget();
        if(directionCheckCor!=null)
            StopCoroutine(directionCheckCor);
        directionCheckCor = StartCoroutine(CheckRightDirectionCor(curHitObstacle));
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
        Invoke(nameof(LoadCurScene), 2);
        if(music!=null)
        music.Stop();
    }

    public void HardMode()
    {
        toggle.isOn = PlayerPrefs.GetInt("Hard", 0) == 1?true:false;
        isHard = !toggle.isOn;
    }
    public void SetHardMode(bool isOn)
    {
        PlayerPrefs.SetInt("Hard", isOn ? 1 : 0);
        HardMode();
        if(setting.gameObject.activeSelf)
        {
            Die();
            TimeScaleReset();
        }
    }
    public void TimeScaleReset()
    {
        Time.timeScale = 1;
    }
    public void LoadCurScene() => UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
}
