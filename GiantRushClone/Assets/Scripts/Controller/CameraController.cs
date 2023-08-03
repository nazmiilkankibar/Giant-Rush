using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform player;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float smoothTime;
    private Vector3 velocity = Vector3.zero;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void LateUpdate()
    {
        //transform.position = Vector3.Lerp(transform.position, player.position + offset, speed * Time.deltaTime);
        transform.position = Vector3.SmoothDamp(transform.position, player.position + offset, ref velocity, smoothTime);
    }
}
