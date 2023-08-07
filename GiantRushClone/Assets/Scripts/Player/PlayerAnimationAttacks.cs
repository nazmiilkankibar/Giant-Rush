using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationAttacks : MonoBehaviour
{
    private BossController boss;
    private void Start()
    {
        boss = GameObject.FindGameObjectWithTag("Boss").GetComponent<BossController>();
    }
    public void Damage()
    {
        boss.TakeDamage();
    }
}
