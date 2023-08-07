using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
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
    public bool fighting;
    public bool canMove;

    public Transform endPosition;

    private GameManager gm;
    public float maxHealth;
    private float currentHealth;
    private BossController boss;
    private void Start()
    {
        cam = Camera.main;
        anim = GetComponentInChildren<Animator>();
        endPosition = GameObject.FindGameObjectWithTag("EndPoint").transform;
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        boss = GameObject.FindGameObjectWithTag("Boss").GetComponent<BossController>();
        currentHealth = maxHealth;
    }
    private void FixedUpdate()
    {
        if (canMove)
        {
            GoToFightPosition();
            return;
        }
        if (!canMove && !fighting)
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
        if (fighting)
        {
            
            Fighting();
        }
    }

    private void GoToFightPosition()
    {
        transform.position = Vector3.MoveTowards(transform.position, endPosition.position + new Vector3(0,0,2f), speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, endPosition.position + new Vector3(0, 0, 2f)) < .1f)
        {
            gm.ChangeUI();
            canMove = false;
            fighting = true;
            anim.SetBool("Running", false);
            anim.SetBool("FightingIdle", true);
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
    private void Fighting()
    {
        if (Input.GetMouseButtonDown(0))
        {
            int randomPunch = Random.Range(0, 2);
            switch (randomPunch)
            {
                case 0:
                    anim.SetTrigger("LeftPunch");
                    break;
                case 1:
                    anim.SetTrigger("RightPunch");
                    break;
                default:
                    break;
            }
        }
    }
    public void Damage()
    {
        boss.TakeDamage();
    }
    public void TakeDamage()
    {
        currentHealth -= 10;
        gm.PlayerHealthBar(currentHealth / maxHealth);
    }
}
