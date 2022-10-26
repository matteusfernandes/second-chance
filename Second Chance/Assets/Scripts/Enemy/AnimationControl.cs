using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControl : MonoBehaviour
{
    [SerializeField] private Transform attackPoint;
    [SerializeField] private float radius;
    [SerializeField] private LayerMask playerLayer;

    private Animator anim;
    private PlayerAnim playerAnim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        playerAnim = FindObjectOfType<PlayerAnim>();
    }

    public void PlayAnim(int value)
    {
        anim.SetInteger("transition", value);
    }

    public void Attack()
    {
        Collider2D hit = Physics2D.OverlapCircle(attackPoint.position, radius, playerLayer);

        if (hit != null)
        {
            playerAnim.OnHit();
        }
        else
        {}
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position, radius);
    }
}
