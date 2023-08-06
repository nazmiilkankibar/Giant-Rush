using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GainedObjects : MonoBehaviour
{
    public int takenExp;
    public int takenGem;
    public int takenKey;

    [SerializeField] private TextMeshProUGUI takenExpText;
    [SerializeField] private TextMeshProUGUI takenGemText;
    [SerializeField] private TextMeshProUGUI takenKeyText;
    private void Start()
    {
        takenExpText.text = "0";
        takenGemText.text = "0";
        takenKeyText.text = "0";
    }
    public void SetTakenExpText(int count)
    {
        takenExp += count;
        if (takenExp < 0)
        {
            takenExp = 0;
        }
        takenExpText.text = takenExp.ToString();
    }
    public void SetTakenGemText()
    {
        takenGem++;
        takenGemText.text = takenGem.ToString();
    }
    public void SetTakenKeyText()
    {
        takenKey++;
        takenKeyText.text = takenKey.ToString();
    }
}
