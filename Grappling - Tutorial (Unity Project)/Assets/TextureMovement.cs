using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureMovement : MonoBehaviour
{
    public float scrollSpeed = 0.05f;
    Renderer rend;
    // Start is called before the first frame update
    void Start()
    {
        rend =  GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveThis = -1*Time.time * scrollSpeed;
        rend.material.SetTextureOffset("_MainTex",new Vector2(moveThis,0));
    }
}
