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
    private Animator anim;

    public Transform movePosition;
    private CharacterController cc;
    private bool start = false;
    public bool canMove;

    public Transform endPosition;
    private void Start()
    {
        cam = Camera.main;
        anim = GetComponentInChildren<Animator>();
        endPosition = GameObject.FindGameObjectWithTag("EndPoint").transform;
    }
    private void FixedUpdate()
    {
        if (canMove)
        {
            GoToFightPosition();
            return;
        }
        if (!canMove)
        {
            if (Input.GetMouseButtonDown(0))
            {
                touchpos = cam.ScreenToViewportPoint(Input.mousePosition);
                start = true;
            }
            if (start)
            {
                Run();
            }
            if (Input.GetMouseButton(0))
            {
                MovePositionXDrag();
            }
            else
            {
                SetMovePositionXPosition();
            }
        }
    }

    private void GoToFightPosition()
    {
        transform.position = Vector3.MoveTowards(transform.position, endPosition.position + new Vector3(0,0,2f), speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, endPosition.position + new Vector3(0, 0, 2f)) < .1f)
        {
            canMove = false;
            anim.SetBool("Running", false);
        }
        return;
    }

    private void Run()
    {
        anim.SetBool("Running", true);
        transform.forward = movePosition.position - transform.position;
        movePosition.position += new Vector3(0, 0, speed * Time.deltaTime);
        transform.Translate(new Vector3(0, 0, speed * Time.deltaTime));
    }

    private void MovePositionXDrag()
    {
        dragPos = cam.ScreenToViewportPoint(Input.mousePosition);
        newPosition = touchpos - dragPos;
        newPosition.x = Mathf.Clamp(newPosition.x, -1f, 1f);
        movePosition.position += new Vector3(-newPosition.x * .3f, 0, 0);
    }

    private void SetMovePositionXPosition()
    {
        movePosition.position = Vector3.MoveTowards(movePosition.position, new Vector3(transform.position.x, 0, movePosition.position.z), speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EndPoint"))
        {
            RoadEnd();
        }
    }
    private void RoadEnd()
    {
        canMove = true;
        start = false;
        cam.GetComponent<CameraController>().canMove = true;
    }
}
