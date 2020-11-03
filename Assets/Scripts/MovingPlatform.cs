using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField]
    private Transform _targetA;
    [SerializeField]
    private Transform _targetB;
    [SerializeField]
    private float _speed = 1f;

    bool moveToB = true;
    void Update()
    {
        
        if(moveToB)
            transform.position = Vector3.MoveTowards(transform.position, _targetB.position, _speed * Time.deltaTime);
        else
            transform.position = Vector3.MoveTowards(transform.position, _targetA.position, _speed * Time.deltaTime);

        if (Mathf.Abs(transform.position.x - _targetB.position.x) < 0.001)
            moveToB = false;
        if (Mathf.Abs(transform.position.x - _targetA.position.x) < 0.001)
            moveToB = true;
    }
}
