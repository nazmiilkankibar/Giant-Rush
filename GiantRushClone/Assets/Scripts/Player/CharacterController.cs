using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    
    public float speed;
    
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
        takeableCharacterVFX = GameObject.FindGameObjectWithTag("TakeableCharacterVFX").GetComponent<TakeableCharacterVFX>();
        gainedObjects = GameObject.FindGameObjectWithTag("GainedObjects").GetComponent<GainedObjects>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("TakeableCharacter"))
        {
            if (currentColor == other.GetComponent<TakeableCharacter>().currentColor)
            {
                IncreaseScale(other);
            }
            else
            {
                ReduceScaleWithWrongColor(other);
            }
        }
        else if (other.CompareTag("Obstacle"))
        {
            ReduceScaleWithObstacle();
        }
        else if (other.CompareTag("Gem"))
        {
            TakeGem(other);
        }

    }

    private void TakeGem(Collider other)
    {
        other.gameObject.SetActive(false);
        takenGemVFX.SetActiveVFX(transform);
        gainedObjects.SetTakenGemText();
    }

    private void IncreaseScale(Collider other)
    {
        child.localScale += Vector3.one * .02f;
        other.gameObject.SetActive(false);
        takeableCharacterVFX.SetActiveVFX(other.transform);
        takenLevelTexts.SetActiveText(transform, "+1");
        gainedObjects.SetTakenExpText(1);
    }

    private void ReduceScaleWithWrongColor(Collider other)
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

    private void ReduceScaleWithObstacle()
    {
        if (child.localScale.x > .5f)
        {
            child.localScale -= Vector3.one * .1f;
            if (child.localScale.x < .5f)
            {
                child.localScale = Vector3.one * .5f;
            }
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
