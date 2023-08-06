using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TakenLevelTexts : MonoBehaviour
{
    public GameObject[] takenLevelTexts = new GameObject[20];
    private int currentIndex;
    private GameObject textObject;
    private void Start()
    {
        for (int i = 0; i < takenLevelTexts.Length; i++)
        {
            takenLevelTexts[i] = transform.GetChild(i).gameObject;
        }
    }
    public void SetActiveText(Transform target, string text)
    {
        textObject = takenLevelTexts[currentIndex];
        textObject.SetActive(true);
        textObject.GetComponentInChildren<TextMeshProUGUI>().text = text;
        textObject.transform.position = target.position + new Vector3(Random.Range(-.1f,.1f), Random.Range(.9f,1.1f), -.1f);
        textObject.transform.parent = target;
        textObject.GetComponent<TakenLevelUI>().parent = this.transform;
        currentIndex++;
        if (currentIndex >= 20)
        {
            currentIndex = 0;
        }
    }
}
