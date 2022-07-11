using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCircle : MonoBehaviour
{
    public Rigidbody rb;
    public float speed;
    public bool isKeyDownAble;
    Coroutine downAble;
    public Vector3 targetDir;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(!isKeyDownAble)
        transform.Translate(Vector3.forward * speed,Space.Self);
        else
        {
            rb.velocity = Vector3.zero;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(transform.position, transform.forward);
    }

    private void OnCollisionEnter(Collision collision)
    {
        print("dafd");
        if (collision.gameObject.tag == "Mirror")
        {
            if (downAble != null)
                StopCor();
            downAble = StartCoroutine(KeyDownAbleCor());
            print("hit0");
            CameraEffect.Instance.cameraToCircle();
            Vector3 dir = Vector3.Reflect(transform.forward, collision.transform.up);
            Debug.DrawRay(collision.contacts[0].point, dir * 100, Color.gray, 10);
            targetDir = dir;
        }        
    }

    public float keyDownableSec;
    IEnumerator KeyDownAbleCor()
    {
        isKeyDownAble = true;

        yield return new WaitForSeconds(keyDownableSec);
        isKeyDownAble = false;
        print("die");

    }
    public void Die()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }
    public void StopCor()
    {
        StopCoroutine(downAble);
    }
}
