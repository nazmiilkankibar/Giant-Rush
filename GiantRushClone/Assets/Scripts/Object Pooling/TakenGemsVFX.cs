using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakenGemsVFX : MonoBehaviour
{
    public GameObject[] takeEffects = new GameObject[20];
    private int currentIndex;
    private void Start()
    {
        for (int i = 0; i < takeEffects.Length; i++)
        {
            takeEffects[i] = transform.GetChild(i).gameObject;
        }
    }
    public void SetActiveVFX(Transform target)
    {
        if (currentIndex >= 20)
        {
            currentIndex = 0;
        }
        takeEffects[currentIndex].SetActive(true);
        takeEffects[currentIndex].transform.position = target.position + Vector3.up * .5f;
        currentIndex++;

    }
}
