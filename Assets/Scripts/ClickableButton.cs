using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ClickableButton : MonoBehaviour, IPointerClickHandler
{
    /*
      This script is used to allow the user to right-click a UI button
    */

    private CardDisplay _cd;

    private void Start()
    {
        _cd = gameObject.GetComponentInParent<CardDisplay>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right && CardManager.instance.CheckStock())
        {
            Debug.Log("Right-Click");
            _cd.StockCard();
        }
    }
}
