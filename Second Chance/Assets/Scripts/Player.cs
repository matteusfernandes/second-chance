using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private float speed;
    [SerializeField] private float runSpeed;

    private Rigidbody2D rig;
    private bool _isRunning;
    private bool _isRolling;
    private bool _isCutting;
    private bool _isDigging;
    private bool _isWatering;
    private float initialSpeed;
    private Vector2 _direction;
    private int _handlingObj;
    private PlayerItems playerItems;
    private bool _isPaused;

    public Vector2 direction {
        get { return _direction; }
        set { _direction = value; }
    }

    public bool isRunning {
        get { return _isRunning; }
        set { _isRunning = value; }
    }

    public int handlingObj
    {
        get { return _handlingObj; }
        set { _handlingObj = value; }
    }

    public bool isRolling {
        get { return _isRolling; }
        set { _isRolling = value; }
    }

    public bool isCutting {
        get { return _isCutting; }
        set { _isCutting = value; }
    }

    public bool isDigging {
        get { return _isDigging; }
        set { _isDigging = value; }
    }

    public bool isWatering {
        get { return _isWatering; }
        set { _isWatering = value; }
    }

    public bool isPaused {
        get { return _isPaused; }
        set { _isPaused = value; }
    }

    private void Start() {
        rig = GetComponent<Rigidbody2D>();
        initialSpeed = speed;
        playerItems = GetComponent<PlayerItems>();
    }

    private void Update() {
        if (!_isPaused)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                _handlingObj = 0;
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                _handlingObj = 1;
            }

            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                _handlingObj = 2;
            }
        
            OnInput();
            OnRun();
            OnRolling();
            OnCutting();
            OnDigging();
            OnWatering();
        }
    }

    private void FixedUpdate() {
        if (!_isPaused)
        {
            OnMove();
        }
    }

    #region Movement
    
    void OnInput() {
        _direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    void OnMove() {
        rig.MovePosition(rig.position + _direction * speed * Time.fixedDeltaTime);
    }

    void OnRun() {
        if (Input.GetKeyDown(KeyCode.LeftShift)) {
            speed = runSpeed;
            _isRunning = true;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift)) {
            speed = initialSpeed;
            _isRunning = false;
        }
    }

    void OnRolling() {
        if (Input.GetMouseButtonDown(1)) {
            _isRolling = true;
        }

        if (Input.GetMouseButtonUp(1)) {
            _isRolling = false;
        }
    }

    void OnCutting()
    {
        if (_handlingObj == 0)
        {
            if (Input.GetMouseButtonDown(0)) {
                _isCutting = true;
                speed = 0;
            }

            if (Input.GetMouseButtonUp(0)) {
                _isCutting = false;
                speed = initialSpeed;
            }
        }
    }

    void OnDigging()
    {
        if (_handlingObj == 1)
        {
            if (Input.GetMouseButtonDown(0)) {
                _isDigging = true;
                speed = 0;
            }

            if (Input.GetMouseButtonUp(0)) {
                _isDigging = false;
                speed = initialSpeed;
            }
        }
    }

    void OnWatering()
    {
        if (_handlingObj == 2)
        {
            if (Input.GetMouseButtonDown(0) && playerItems.currentWater > 0) {
                _isWatering = true;
                speed = 0;
            }

            if (Input.GetMouseButtonUp(0) || playerItems.currentWater <= 0) {
                _isWatering = false;
                speed = initialSpeed;
            }

            if (_isWatering)
            {
                playerItems.currentWater -= 0.01f;
            }
        }
    }

    #endregion
}
