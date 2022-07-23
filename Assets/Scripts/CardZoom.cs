using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardZoom : MonoBehaviour
{
    public GameObject Canvas;

    private GameObject zoomCard;

    public void Awake()
    {
        Canvas = GameObject.Find("MainCanvas");
    }

    public void onHoverEnter()
    {
        if(Input.GetMouseButtonDown(1))
        {
            zoomCard = Instantiate(gameObject, new Vector2(Canvas.transform.position.x - 550, Canvas.transform.position.y), Quaternion.identity);
            zoomCard.transform.SetParent(Canvas.transform, false);
            zoomCard.layer = LayerMask.NameToLayer("Zoom");

            RectTransform rect = zoomCard.GetComponent<RectTransform>();
            rect.sizeDelta = new Vector2(240, 360);
        }
    }

    public void onHoverExit()
    {
        Destroy(zoomCard);
    }
}
