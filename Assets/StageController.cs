using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
public class StageController : MonoBehaviour
{
    public GameObject BlackPan;
    public int index = -1;
    public StartSceneBallController ballController;
    public StartSceneCameraController cameraController;
    public List<StageElement> stages;
    StageElement CurStage;
    public GameObject effect;

    private void Start()
    {
        Invoke(nameof(SetUsable), 4);
    }

    public bool isUsable;
    public void SetUsable()
    {
        isUsable = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (!isUsable) return;
        if(Input.GetKeyDown(KeyCode.A)|| Input.GetKeyDown(KeyCode.LeftArrow))
        {
            index--;
            index = Mathf.Clamp(index,0, stages.Count);
            BallMove(index);
        }
        if(Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            index++;
            index = Mathf.Clamp(index, 0, stages.Count);
            BallMove(index);
        }
        if(Input.GetKeyDown(KeyCode.Return) || Input.GetMouseButtonDown(0))
        {
            if (CurStage == null) return;
            BlackPan.transform.GetComponent<RectTransform>().DOAnchorPosX(0, 1);
            Invoke(nameof(LoadScene), 1);
        }
    }
    public void LoadScene()
    {
        SceneManager.LoadScene(CurStage.SceneName);
    }

    public AudioClip[] moveSounds;
    public void BallMove(int i)
    {
        AudioManager.Instance.Play(moveSounds[Random.Range(0, moveSounds.Length)],MixerChannel.Effect);
        Instantiate(effect, ballController.transform.position, Quaternion.identity);
        CurStage = stages[i];
        StageElement stage = stages[i];
        Sequence sequence = DOTween.Sequence();
        sequence.Append(ballController.transform.DOMoveX(stage.transform.position.x, 1));
        sequence.Join(ballController.transform.DOMoveY(stage.transform.position.y, 1));
    }
}
