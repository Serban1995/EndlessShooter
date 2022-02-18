using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageArea : MonoBehaviour
{
    [SerializeField] private float deactivateWaitTime = 0.1f;
    private float deactivatetimer;

    [SerializeField] private LayerMask playerLayer;

    private bool canDealDamage;

    [SerializeField] private float damageAmount = 5f;

    private playerHealth playerHealth;

    private void Awake()
    {
        playerHealth = GameObject.FindWithTag(TagManager.PLAYER_TAG).GetComponent<playerHealth>();
        gameObject.SetActive(false);
    }

    private void Update()
    {
        if (Physics2D.OverlapCircle(transform.position, 1f, playerLayer))
        {
            if (canDealDamage)
            {
                canDealDamage = false;
                playerHealth.TakeDamage(damageAmount);
            }
        }
        DeactivateDamageArea();
    }

    void DeactivateDamageArea()
    {
        if (Time.time > deactivatetimer)
        {
            gameObject.SetActive(false);
        }
    }

    public void ResetDeactivateTimer()
    {
        canDealDamage = true;
        deactivatetimer = Time.time + deactivateWaitTime;
    }
}
