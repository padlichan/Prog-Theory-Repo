using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody _rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();   
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MoveToMousePos();
        
    }

    private void MoveToMousePos()
    {
        Vector3 ScreenPos = new Vector3(Input.mousePosition.x, 0, 50);
        Vector3 WorldPos = new Vector3(Camera.main.ScreenToWorldPoint(ScreenPos).x, transform.position.y, transform.position.z);
        _rigidbody.MovePosition(WorldPos);
    }
}
