using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBeltScroll : MonoBehaviour {

    public float scrollSpeed = -2F;
    private Renderer rend;
    private bool isFiring = false;

    // Use this for initialization
    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isFiring)
        {
            float offset = Time.time * scrollSpeed;
            rend.material.SetTextureOffset("_MainTex", new Vector2(offset, 0));
        }
    }

    public void ScrollAmmo()
    {
        isFiring = true;
    }

    public void StopAmmo()
    {
        isFiring = false;
    }
}
