using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleFour : MonoBehaviour
{
    [SerializeField] private Transform barrier;
    private bool openBarrier;
    private void Update()
    {
        if (openBarrier)
        {
            barrier.rotation = Quaternion.Lerp(barrier.rotation, Quaternion.Euler(new Vector3(0, 0, -90)), 10 * Time.deltaTime);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            openBarrier = true;
        }
    }
}
