using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{   
    public int hitPoints { get; protected set; }
    public int points { get; protected set; }

    [SerializeField] protected Material hitMaterial;
    private protected Material _brickMaterial;
    private protected Renderer _renderer;

    private protected GameManager _gameManager;

    void Start()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        _renderer = GetComponent<Renderer>();
        _brickMaterial = _renderer.sharedMaterial;
        hitPoints = 2;
        points = 10;
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

    protected private virtual void DestroySelf()
    {
        _gameManager.UpdateScore(points);
        Destroy(gameObject);
    }

    protected void ChangeMaterial(Material material)
    {
        _renderer.sharedMaterial = material;
    }

    protected void RestoreMaterial()
    {
        _renderer.sharedMaterial = _brickMaterial;
    }
}
