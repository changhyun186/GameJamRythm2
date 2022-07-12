using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class OnHitEffect : MonoBehaviour
{
    Renderer _renderer;
    Material material;
    private void Start()
    {
        _renderer = GetComponent<Renderer>();
        var mat =_renderer.material;
        material = new Material(mat);
        _renderer.material = material;
        material = _renderer.material;
        transform.DOScale(100, 10);
        material.DOFade(0, 1);
        Destroy(gameObject,5);
    }
}
