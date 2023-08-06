using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LevelCounter : MonoBehaviour
{
    [SerializeField] private Image levelBar;
    [SerializeField] private Transform endPos;
    [SerializeField] private Transform player;

    private float maxDistance;
    private void Start()
    {
        endPos = GameObject.FindGameObjectWithTag("LevelCounter").transform.GetChild(1);
        player = GameObject.FindGameObjectWithTag("Player").transform;
        levelBar = transform.GetChild(1).GetComponent<Image>();
        maxDistance = endPos.position.z;
    }
    private void Update()
    {
        levelBar.fillAmount = Mathf.Abs(player.position.z) / maxDistance;
    }
}
