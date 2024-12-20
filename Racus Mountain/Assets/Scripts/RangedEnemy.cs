using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : MonoBehaviour
{
     [SerializeField] private float attackCooldown;
    [SerializeField] private float range;
    [SerializeField] private int dmg;
    private float cooldownTimer = Mathf.Infinity;
    [SerializeField] private float colliderDistance;
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private LayerMask playerLayer;
    [Header("Breath Attack")]
    [SerializeField] private Transform blastpoint;
    [SerializeField] private GameObject[] blastwaves;
    private Health playerHealth;

    private Animator animate;

    private void Awake()
    {
        animate = GetComponent<Animator>();
    }

     void Update()
    {
        cooldownTimer += Time.deltaTime;

        if(PlayerInSight())
        {
            if(cooldownTimer >= attackCooldown)
            {
                //Atttack
                cooldownTimer = 0;
                animate.SetTrigger("meleeAttack");
                //AudioManager.instance.PlaySound(sword);
            }
        }
    }

    private bool PlayerInSight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
        new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z), 0, Vector2.left, 0, playerLayer);


        return hit.collider != null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance, 
        new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));

    }

    private void RangedAttack()
    {
        cooldownTimer = 0;
        blastwaves[0].transform.position = blastpoint.position;
        //blastwaves[0].GetComponent<enemProje
    }
}
