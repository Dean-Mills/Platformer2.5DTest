using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController _controller;
    private UIManager _uIManager;
    [SerializeField]
    private Transform _startPos;
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
    [SerializeField]
    private int nLives = 3;
    void Start()
    {
        _controller = GetComponent<CharacterController>();
        _uIManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        if (_uIManager == null) Debug.LogError("Could not find an instance of the ui manager on the canvas");
        _uIManager.UpdateLives(nLives);
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

    public void PlayerFalling()
    {
        if(nLives >= 1)
        {
            nLives = nLives -1;
            _controller.enabled = false;
            transform.position = _startPos.position;
            _uIManager.UpdateLives(nLives);
            StartCoroutine(ReEnable());
        }
        else
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
    }
    public void OnCollectablePickup()
    {
        nNumCollectable += 1;
        _uIManager.UpdateCollectableCount(nNumCollectable);
    }

    IEnumerator ReEnable()
    {
        yield return new WaitForSeconds(0.1f);
        _controller.enabled = true;
    }
}
