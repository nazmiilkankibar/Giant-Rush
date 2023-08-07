using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementTest : MonoBehaviour
{
    [SerializeField] private float speed;
    private Vector2 touchpos;
    private Vector2 dragPos;
    private Camera cam;
    Vector3 newPosition;

    public Transform movePosition;

    private bool start = false;
    private void Start()
    {
        cam = Camera.main;
    }
    private void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            touchpos = cam.ScreenToViewportPoint(Input.mousePosition);
            start = true;
        }
        if (Input.GetMouseButton(0))
        {
            dragPos = cam.ScreenToViewportPoint(Input.mousePosition);
            newPosition = touchpos - dragPos;
            newPosition.x = Mathf.Clamp(newPosition.x, -1f, 1f);
            movePosition.position += new Vector3(-newPosition.x * .3f, 0, 0);
        }
        else
        {
            movePosition.position = Vector3.MoveTowards(movePosition.position, new Vector3(transform.position.x, 0, movePosition.position.z), speed * Time.deltaTime);
        }
        if (start)
        {
            transform.forward = movePosition.position - transform.position;
            movePosition.position += new Vector3(0, 0, speed * Time.deltaTime);
            transform.Translate(new Vector3(0, 0, speed * Time.deltaTime));
        }
    }
}
