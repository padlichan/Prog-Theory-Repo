using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private GameManager _gameManager;

    float _speed = 7;
    Rigidbody _rigidbody;
    Vector3 _velocity;
    
    void Start()
    {
        
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.velocity = Vector3.down * _speed;
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void FixedUpdate()
    {
        MoveBall();

        if (transform.position.y < -6)
        {
            _gameManager.GameOver();
            
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        Vector3 variance = new Vector3(Random.Range(-0.1f, 0.1f), Random.Range(0, 0.12f));
        _rigidbody.velocity = (Vector3.Reflect(_velocity, collision.contacts[0].normal) + variance).normalized;
    }

    private void MoveBall()
    {
        _rigidbody.velocity = _rigidbody.velocity.normalized * _speed;
        _velocity = _rigidbody.velocity;
    }

}
