using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundParallax : MonoBehaviour
{
    //Stores the player. Set in the Editor
    public GameObject player;
    public float yOffset;
    public float parallaxSpeed;

    MeshRenderer meshRenderer;

    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //Sets the position of the camera to the player's position with a multiplicative offset. Creates a parallax effect as the player moves
        transform.position = new Vector2(Mathf.Max(player.transform.position.x, 0), 0);
        Vector2 offset = new Vector2(Mathf.Max(player.transform.position.x, 0) * parallaxSpeed, yOffset);
        meshRenderer.sharedMaterial.SetTextureOffset("_MainTex", offset);
    }
}
