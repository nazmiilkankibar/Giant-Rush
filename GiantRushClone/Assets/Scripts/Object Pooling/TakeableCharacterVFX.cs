using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeableCharacterVFX : MonoBehaviour
{
    public GameObject[] destroyEffect = new GameObject[10];
    private void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            destroyEffect[i] = transform.GetChild(i).gameObject;
        }
    }
    public void SetActiveVFX(Transform target)
    {
        for (int i = 0; i < destroyEffect.Length - 1; i++)
        {
            if (!destroyEffect[i].activeSelf)
            {
                destroyEffect[i].transform.position = target.position + Vector3.up * .5f;
                destroyEffect[i].SetActive(true);
                break;
            }
        }
    }
}
