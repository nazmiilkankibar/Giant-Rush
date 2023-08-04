using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    public enum CurrentColor { Red, Green, Blue}
    public CurrentColor currentColor;
    [SerializeField] private Material[] materials = new Material[3];
    private void Start()
    {
        switch (currentColor)
        {
            case CurrentColor.Red:
                transform.GetComponent<MeshRenderer>().material = materials[0];
                break;
            case CurrentColor.Green:
                transform.GetComponent<MeshRenderer>().material = materials[1];
                break;
            case CurrentColor.Blue:
                transform.GetComponent<MeshRenderer>().material = materials[2];
                break;
            default:
                break;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            switch (currentColor)
            {
                case CurrentColor.Red:
                    other.GetComponent<CharacterController>().ChangeColor("Red");
                    break;
                case CurrentColor.Green:
                    other.GetComponent<CharacterController>().ChangeColor("Green");
                    break;
                case CurrentColor.Blue:
                    other.GetComponent<CharacterController>().ChangeColor("Blue");
                    break;
                default:
                    break;
            }
        }
    }
}
