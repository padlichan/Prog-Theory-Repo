using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{   
    public int hitPoints { get; private set; }
    public static int points { get; private set; }

    [SerializeField] Material hitMaterial;
    private Material _brickMaterial;
    private Renderer _renderer;

    void Start()
    {
        _renderer = GetComponent<Renderer>();
        _brickMaterial = _renderer.sharedMaterial;
        hitPoints = 2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        hitPoints--;
        //Score points

        if(hitPoints <= 0)
        {
            DestroySelf();
        }

        ChangeMaterial(hitMaterial);
        Invoke("RestoreMaterial",0.05f);

    }

    public virtual void DestroySelf()
    {
        Destroy(gameObject);
    }

    public virtual void ChangeMaterial(Material material)
    {
        _renderer.sharedMaterial = material;
    }

    public virtual void RestoreMaterial()
    {
        _renderer.sharedMaterial = _brickMaterial;
    }
}
