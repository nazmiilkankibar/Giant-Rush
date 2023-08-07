using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeableCharacterVFX : MonoBehaviour
{
    public GameObject[] destroyEffect = new GameObject[20];
    private int currentIndex;
    private void Start()
    {
        for (int i = 0; i < destroyEffect.Length; i++)
        {
            destroyEffect[i] = transform.GetChild(i).gameObject;
        }
    }
    public void SetActiveVFX(Transform target)
    {
        if (currentIndex >= 20)
        {
            currentIndex = 0;
        }
        destroyEffect[currentIndex].SetActive(true);
        destroyEffect[currentIndex].transform.position = target.position + Vector3.up * .5f;
        currentIndex++;
        
    }
}
