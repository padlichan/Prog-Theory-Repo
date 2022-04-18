using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrongBrick : Brick
{
    
    // Start is called before the first frame update
    void Start()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        _renderer = GetComponent<Renderer>();
        _brickMaterial = _renderer.sharedMaterial;
        hitPoints = 3;
        points = 50;
        _brickMaterial = _renderer.sharedMaterial;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        hitPoints--;

        if (hitPoints <= 0)
        {
            DestroySelf();
        }

        ChangeMaterial(hitMaterial);
        Invoke("RestoreMaterial", 0.05f);
    }

    protected private override void DestroySelf()
    {
        Debug.Log("Explosion VFX, SFX "+points);
        base.DestroySelf();
    

    }

  
}
