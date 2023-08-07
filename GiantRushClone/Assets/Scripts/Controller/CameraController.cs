using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform player;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float smoothTime;
    private Vector3 velocity = Vector3.zero;
    public bool canMove;
    public Transform watchFightPosition;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void FixedUpdate()
    {
        if (canMove)
        {
            SetWatchPosition();
        }
        else
        {
            transform.position = Vector3.SmoothDamp(transform.position, player.position + offset, ref velocity, smoothTime * .1f);
        }
    }
    private void SetWatchPosition()
    {
        transform.position = Vector3.MoveTowards(transform.position, watchFightPosition.position, smoothTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(new Vector3(0, -90, 0)), 3 * Time.deltaTime);
    }
}
