using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Powerup : MonoBehaviour
{
    public float duration;
    public GameObject effectPrefab;
    public string uiTag;
    
    GameObject ui;

    // Start is called before the first frame update
    void Start()
    {
        ui = GameObject.FindGameObjectWithTag(uiTag);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject Pickup(GameObject player)
    {
        Destroy(gameObject);
        GameObject effect = Instantiate(effectPrefab);
        PowerupEffect effectScript = effect.GetComponent<PowerupEffect>();
        effectScript.Player = player;
        effectScript.Sprite = gameObject.GetComponent<SpriteRenderer>().sprite;
        effectScript.Duration = duration;
        effectScript.OnPickup = OnPickup;
        effectScript.OnTimeout = OnTimeout;
        return effect;
    }

    public virtual void OnPickup(GameObject player)
    {

    }

    public virtual void OnTimeout(GameObject player)
    {
        ui.GetComponent<InGameUI>().IsDirty = true;
    }
}
