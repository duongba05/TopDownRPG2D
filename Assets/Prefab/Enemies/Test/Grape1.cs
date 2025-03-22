using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Grape1 : MonoBehaviour, IEnemy
{
    [SerializeField] private GameObject grapeProjectilePrefab;

    private Animator myAnimator;
    private SpriteRenderer spriteRenderer;

    readonly int ATTACK_HASH = Animator.StringToHash("Attack");

    private void Awake()
    {
        myAnimator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Attack()
    {
        myAnimator.SetTrigger(ATTACK_HASH);

        if (transform.position.x - PlayerController.Instance.transform.position.x < 0)
        {
            spriteRenderer.flipX = false;
        }
        else
        {
            spriteRenderer.flipX = true;
        }
    }

    public void SpawnProjectileAnimEvent()
    {
        StartCoroutine(TimeSpawn(3,0.5f));
    }
    IEnumerator TimeSpawn(int count, float delay)
    {
        for(int i = 0; i<= count; i++)
        {
            Instantiate(grapeProjectilePrefab, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(delay);
        }

    }
}
