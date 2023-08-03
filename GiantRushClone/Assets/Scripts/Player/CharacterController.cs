using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private bool start = false;
    public float speed;
    private Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            start = true;
        }
        if (start)
        {
            gameObject.transform.Translate(0, 0, speed * Time.deltaTime);
            anim.SetBool("Running", true);
        }
    }
}
