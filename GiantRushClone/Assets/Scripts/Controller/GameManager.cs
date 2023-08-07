using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject runningUI;
    [SerializeField] private GameObject fightingUI;

    private PlayerMovement playerMovement;

    [SerializeField] private Image playerHealthBar;
    [SerializeField] private Image enemyHealthBar;
    private void Start()
    {
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }
    public void ChangeUI()
    {
        runningUI.SetActive(false);
        fightingUI.SetActive(true);
    }
    public void PlayerHealthBar(float value)
    {
        playerHealthBar.fillAmount = value;
    }
    public void BossEnemyHealth(float value)
    {
        enemyHealthBar.fillAmount = value;
    }
}
