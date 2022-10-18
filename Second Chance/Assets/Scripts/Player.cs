using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;

    private Rigidbody2D rig;
    private Vector2 _direction;

    private void Start() {
        rig = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        OnInput();
    }

    private void FixedUpdate() {
        OnMove();
    }

    #region Movement
    
    void OnInput() {
        _direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    void OnMove() {
        rig.MovePosition(rig.position + _direction * speed * Time.fixedDeltaTime);
    }

    #endregion
}
