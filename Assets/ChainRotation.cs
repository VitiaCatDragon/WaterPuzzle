using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainRotation : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    
    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if(_rigidbody2D.velocity == Vector2.zero)
            _rigidbody2D.velocity = new Vector2(7f, 0f);
    }
}
