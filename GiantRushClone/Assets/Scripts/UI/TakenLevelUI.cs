using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakenLevelUI : MonoBehaviour
{
    public Transform parent;
    private void Update()
    {
        transform.rotation = Quaternion.Euler(Vector3.back);
    }
    private void OnEnable()
    {
        Invoke("SetDisable", 1);
    }
    private void SetDisable()
    {
        transform.parent = parent;
        transform.gameObject.SetActive(false);
    }
}
