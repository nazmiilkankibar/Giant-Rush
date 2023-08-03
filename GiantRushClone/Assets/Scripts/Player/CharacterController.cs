using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private bool start = false;
    public float speed;
    private Animator anim;
    public CurrentColor currentColor;
    private TakeableCharacterVFX takeableCharacterVFX;
    private void Start()
    {
        anim = GetComponent<Animator>();
        takeableCharacterVFX = GameObject.FindGameObjectWithTag("TakeableCharacterVFX").GetComponent<TakeableCharacterVFX>();
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
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("TakeableCharacter"))
        {
            if (currentColor == other.GetComponent<TakeableCharacter>().currentColor)
            {
                transform.localScale += Vector3.one * .01f;
                other.gameObject.SetActive(false);
                takeableCharacterVFX.SetActiveVFX(other.transform);
            }
        }
    }
}
