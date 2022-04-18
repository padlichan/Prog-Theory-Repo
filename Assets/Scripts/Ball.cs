using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    float _speed = 10;
    Rigidbody _rigidbody;
    Vector3 _velocity;
    
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.velocity = Vector3.down * _speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Vector3 variance = new Vector3(Random.Range(-0.1f, 0.1f), Random.Range(0, 0.12f));
        _rigidbody.velocity = (Vector3.Reflect(_velocity, collision.contacts[0].normal)+variance).normalized;
    }
    void FixedUpdate()
    {
        _rigidbody.velocity = _rigidbody.velocity.normalized * _speed;
        _velocity = _rigidbody.velocity;
    }
}
