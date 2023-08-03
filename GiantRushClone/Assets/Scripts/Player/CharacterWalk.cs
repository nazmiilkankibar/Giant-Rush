using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class CharacterWalk : MonoBehaviour, IDragHandler, IPointerUpHandler,IPointerDownHandler
{
    public Transform character;
    public Transform child;
    private bool canTurnNormalRot;

    private Vector3 currentAngle;

    //ALINTI
    public void OnDrag(PointerEventData eventData)
    {
        Vector3 pos = character.position;
        pos.x = Mathf.Clamp(pos.x + (eventData.delta.x / 100), -1, 1);
        character.position = pos;

        Quaternion rot = child.rotation;
        rot.y = Mathf.Clamp(rot.y + (eventData.delta.x / 100), -.1f, .1f);
        child.rotation = rot;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        canTurnNormalRot = false;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        canTurnNormalRot = true;
        currentAngle = transform.eulerAngles;
    }
    private void Update()
    {
        if (canTurnNormalRot)
        {
            character.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(Vector3.zero), Time.deltaTime);
        }
    }
}
