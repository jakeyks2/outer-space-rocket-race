using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundParallax : MonoBehaviour
{
    //Stores the player. Set in the Editor
    public GameObject player;
    //Where the background should be on the y axis
    public float yOffset;
    //The speed at which the background should move
    public float parallaxSpeed;

    //The material renderer
    MeshRenderer meshRenderer;

    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(Mathf.Max(player.transform.position.x, 0), yOffset);
        //Sets the offset of the texture to the player's position with a multiplicative offset. Creates a parallax effect as the player moves
        Vector2 offset = new Vector2(Mathf.Max(player.transform.position.x, 0) * parallaxSpeed, 0);
        meshRenderer.sharedMaterial.SetTextureOffset("_MainTex", offset);
    }
}
