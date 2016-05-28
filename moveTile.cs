using UnityEngine;
using System.Collections;

public class moveTile : MonoBehaviour {

    public float scrollSpeed = 0.5F;

    private Renderer rend;
    public bool xAxis = true;

    void Start()
    {
        rend = GetComponent<Renderer>();
       

    }
    void Update()
    {
        if (xAxis)
        {
           float offset = Time.time * scrollSpeed;
           rend.material.SetTextureOffset("_MainTex", new Vector2(offset, 0));
        }
        else
        {

            float offset = Time.time * scrollSpeed;
            rend.material.SetTextureOffset("_MainTex", new Vector2(0, offset));

        }

    }
}
