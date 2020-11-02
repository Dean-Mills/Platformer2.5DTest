using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController _controller;
    [SerializeField]
    private float _speed;
    [SerializeField]
    private float _gravity;
    [SerializeField]
    private float _jumpHeight;

    private float yVal;
    void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var direction = new Vector3(horizontal, 0, 0);

        if (!_controller.isGrounded)
        {
            yVal -= _gravity;
        }
        else
        {
            if(Input.GetKeyDown(KeyCode.Space))
                yVal = _jumpHeight;
        }
        direction.y = yVal;
        _controller.Move(direction * _speed * Time.deltaTime);
    }
}
