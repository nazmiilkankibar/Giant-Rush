using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    private PlayerMovement playerMovement;
    private Animator anim;
    private float timer;

    private GameManager gm;
    public float maxHealth;
    private float currentHealth;
    private void Start()
    {
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        anim = GetComponent<Animator>();
        timer = Random.Range(.5f, 2f);
        currentHealth = maxHealth;
    }
    private void Update()
    {
        if (playerMovement.fighting)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                Attack();
            }
        }
    }
    private void Attack()
    {
        int randomPunchIndex = Random.Range(0, 2);
        switch (randomPunchIndex)
        {
            case 0:
                anim.SetTrigger("Left Punch");
                break;
            case 1:
                anim.SetTrigger("Right Punch");
                break;
            default:
                break;
        }
        
        timer = Random.Range(.5f, 2f);
    }
    public void Damage()
    {
        playerMovement.TakeDamage();
    }
    public void TakeDamage()
    {
        currentHealth -= 10;
        gm.BossEnemyHealth(currentHealth / maxHealth);
    }
}
