using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController _controller;
    private UIManager _uIManager;
    [SerializeField]
    private float _speed;
    [SerializeField]
    private float _gravity;
    [SerializeField]
    private float _jumpHeight;
    private float yVal = 0f;
    private bool bDoubleJumpReady = false;
    [SerializeField]
    private int nNumCollectable = 0;
    void Start()
    {
        _controller = GetComponent<CharacterController>();
        _uIManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        if (_uIManager == null) Debug.LogError("Could not find an instance of the ui manager on the canvas");
    }

    // Update is called once per frame
    void Update()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var direction = new Vector3(horizontal, 0, 0);

        if (!_controller.isGrounded)
        {
            yVal -= _gravity;
            if(Input.GetKeyDown(KeyCode.Space) && bDoubleJumpReady)
            {
                yVal += _jumpHeight;
                bDoubleJumpReady = false;
            }
        }
        else
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                yVal = _jumpHeight;
                bDoubleJumpReady = true;
            }
        }
        direction.y = yVal;
        _controller.Move(direction * _speed * Time.deltaTime);
    }

    public void OnCollectablePickup()
    {
        nNumCollectable += 1;
        _uIManager.UpdateCollectableCount(nNumCollectable);
    }
}
