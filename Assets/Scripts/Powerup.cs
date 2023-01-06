using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Powerup : MonoBehaviour
{
    //The length the powerup should last
    public float duration;
    //The prefab "PowerupEffect"
    public GameObject effectPrefab;
    //"UI"
    public string uiTag;
    
    GameObject ui;

    // Start is called before the first frame update
    void Start()
    {
        ui = GameObject.FindGameObjectWithTag(uiTag);
    }

    //Run when the player makes contact with the player
    public GameObject Pickup(GameObject player)
    {
        Destroy(gameObject);
        GameObject effect = Instantiate(effectPrefab);
        PowerupEffect effectScript = effect.GetComponent<PowerupEffect>();
        //Sets all of the effect prefab's properties
        effectScript.Player = player;
        effectScript.Sprite = gameObject.GetComponent<SpriteRenderer>().sprite;
        effectScript.Duration = duration;
        effectScript.OnPickup = OnPickup;
        effectScript.OnTimeout = OnTimeout;
        return effect;
    }

    //Defines the OnPickup function that can be overriden
    public virtual void OnPickup(GameObject player)
    {

    }

    //When the powerup times out, mark the UI as dirty
    public virtual void OnTimeout(GameObject player)
    {
        ui.GetComponent<InGameUI>().IsDirty = true;
    }
}
