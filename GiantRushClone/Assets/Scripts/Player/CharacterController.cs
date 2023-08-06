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
    [SerializeField] private TakenLevelTexts takenLevelTexts;
    [SerializeField] private TakenGemsVFX takenGemVFX;
    [SerializeField] private Material[] materials = new Material[3];
    private Transform child;
    private GainedObjects gainedObjects;
    private void Start()
    {
        child = transform.GetChild(0).transform;
        anim = GetComponentInChildren<Animator>();
        takeableCharacterVFX = GameObject.FindGameObjectWithTag("TakeableCharacterVFX").GetComponent<TakeableCharacterVFX>();
        gainedObjects = GameObject.FindGameObjectWithTag("GainedObjects").GetComponent<GainedObjects>();
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
                child.localScale += Vector3.one * .02f;
                other.gameObject.SetActive(false);
                takeableCharacterVFX.SetActiveVFX(other.transform);
                takenLevelTexts.SetActiveText(transform, "+1");
                gainedObjects.SetTakenExpText(1);
            }
            else
            {
                if (child.localScale.x > .51f)
                {
                    child.localScale -= Vector3.one * .02f;
                }
                other.gameObject.SetActive(false);
                takeableCharacterVFX.SetActiveVFX(other.transform);
                takenLevelTexts.SetActiveText(transform, "-1");
                gainedObjects.SetTakenExpText(-1);
            }
        }
        else if (other.CompareTag("Obstacle"))
        {
            if (child.localScale.x > .1f)
            {
                child.localScale -= Vector3.one * .1f;
            }
        }
        else if (other.CompareTag("Gem"))
        {
            other.gameObject.SetActive(false);
            takenGemVFX.SetActiveVFX(transform);
            gainedObjects.SetTakenGemText();
        }
    }
    public void ChangeColor(string colorName)
    {
        switch (colorName)
        {
            case "Red":
                currentColor = CurrentColor.Red;
                child.GetChild(0).GetComponent<Renderer>().material = materials[0];
                child.GetChild(1).GetComponent<Renderer>().material = materials[0];
                break;
            case "Green":
                currentColor = CurrentColor.Green;
                child.GetChild(0).GetComponent<Renderer>().material = materials[1];
                child.GetChild(1).GetComponent<Renderer>().material = materials[1];
                break;
            case "Blue":
                currentColor = CurrentColor.Blue;
                child.GetChild(0).GetComponent<Renderer>().material = materials[2];
                child.GetChild(1).GetComponent<Renderer>().material = materials[2];
                break;
            default:
                break;
        }
    }
}
