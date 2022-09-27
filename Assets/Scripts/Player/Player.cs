using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float runSpeed;

    private float initialSpeed;
    private bool _isRunning;
    private bool _isRolling;
    private bool _isCutting;
    private Rigidbody2D rg;
    private Vector2 _direction;

    public bool isRolling
    {
        get { return _isRolling; }
        set { _isRolling = value; }
    }

    public bool isRunning
    {
        get { return _isRunning; }
        set { _isRunning = value; }
    }

    public Vector2 direction
    {
        get { return _direction; }
        set { _direction = value; }
    }

    public bool isCutting { 
        get { return _isCutting; }
        set { _isCutting = value;  }
    }

    private void Awake()
    {
        rg = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        speed = 5;
        runSpeed = 8;

        rg = GetComponent<Rigidbody2D>();
        initialSpeed = speed;
    }

    private void Update()
    {
        OnInput();
        OnRun();
        OnRolling();
        onCutting();
    }

    private void FixedUpdate()
    {
        OnMove();
    }

    #region Movement

    void onCutting()
    {

        if (Input.GetMouseButtonDown(0))
        {
            isCutting = true;
            speed = 0f;

        }

        if (Input.GetMouseButtonUp(0))
        {
            isCutting = false;
            speed = initialSpeed;

        }


    }

    void OnInput()
    {
        _direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    void OnMove()
    {
        rg.MovePosition(rg.position + _direction * speed * Time.fixedDeltaTime);
    }

    void OnRun()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = runSpeed;

            _isRunning = true;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            _isRunning = false;
            speed = initialSpeed;
        }
    }

    void OnRolling()
    {
        if (Input.GetMouseButtonDown(1))
        {
            _isRolling = true;
        }

        if (Input.GetMouseButtonUp(1))
        {
            _isRolling = false;
        }
    }

    #endregion
}
