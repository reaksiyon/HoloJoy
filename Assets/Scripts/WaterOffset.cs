using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterOffset : MonoBehaviour
{
    public bool water;

    public float speed = 0.3f;


    private Renderer _renderer;

    private Vector2 _startValue;

    void Start()
    {
        _renderer = GetComponent<Renderer>();

        if (_renderer)
        {
            _startValue = _renderer.material.GetTextureOffset("_MainTex");
        }
    }

    void Update()
    {
        if (_renderer == null)
            return;

        float offset = Time.time * speed;

        if (water == true)
        {
            _renderer.material.SetTextureOffset("_MainTex", new Vector2(0, offset));
        }
        else
        {
            _renderer.material.SetTextureOffset("_MainTex", new Vector2(0, offset * -1.0f));
        }

    }

    private void OnDisable()
    {
        if (_renderer == null)
            return;

        _renderer.material.SetTextureOffset("_MainTex", _startValue);
    }

}
