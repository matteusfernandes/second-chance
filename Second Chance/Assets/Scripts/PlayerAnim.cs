using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    [Header("Attack Settings")]
    [SerializeField] private float recoveryTime = 1f;
    [SerializeField] private Transform attackPoint;
    [SerializeField] private float radius;
    [SerializeField] LayerMask enemyLayer;

    private Player player;
    private Animator anim;
    private Casting cast;
    private bool isHitting;
    private float timeCount;

    void Start()
    {
        player = GetComponent<Player>();
        anim = GetComponent<Animator>();
        cast = FindObjectOfType<Casting>();
    }

    void Update()
    {
        OnMove();
        OnRun();
        OnCutting();
        OnDigging();
        OnWatering();
        OnAttacking();

        if (isHitting)
        {
            timeCount += Time.deltaTime;

            if (timeCount >= recoveryTime)
            {
                isHitting = false;
                timeCount = 0f;
            }
        }

    }

    #region Movement

    void OnMove() {
        if (player.direction.sqrMagnitude > 0) {
            if (player.isRolling) {
                anim.SetTrigger("isRoll");
            } else {
                anim.SetInteger("transition", 1);
            }
        } else {
            anim.SetInteger("transition", 0);
        }

        if (player.direction.x > 0) {
            transform.eulerAngles = new Vector2(0, 0);
        }

        if (player.direction.x < 0) {
            transform.eulerAngles = new Vector2(0, 180);
        }
    }

    void OnRun() {
        if (player.isRunning) {
            anim.SetInteger("transition", 2);
        }
    }

    void OnCutting() {
        if (player.isCutting) {
            anim.SetInteger("transition", 3);
        }
    }

    void OnDigging() {
        if (player.isDigging) {
            anim.SetInteger("transition", 4);
        }
    }

    void OnWatering() {
        if (player.isWatering) {
            anim.SetInteger("transition", 5);
        }
    }

    public void OnCastingStarted()
    {
        anim.SetTrigger("isCasting");
        player.isPaused = true;
    }

    public void OnCastingEnded()
    {
        cast.OnCasting();
        player.isPaused = false;
    }

    public void OnHammeringStarted()
    {
        anim.SetBool("hammering", true);
    }

    public void OnHammeringEnded()
    {
        anim.SetBool("hammering", false);
    }

    public void OnHit()
    {
        if (!isHitting)
        {
            anim.SetTrigger("hit");
            isHitting = true;
        }
    }
    
    void OnAttacking() {
        if (player.isAttacking) {
            anim.SetInteger("transition", 6);
        }
    }
    
    #endregion

    #region Attack

    public void OnAttack()
    {
        Collider2D hit = Physics2D.OverlapCircle(attackPoint.position, radius, enemyLayer);

        if (hit != null)
        {
            hit.GetComponentInChildren<AnimationControl>().OnHit();
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position, radius);
    }

    #endregion
}
