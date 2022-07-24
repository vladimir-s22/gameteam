using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDrop : MonoBehaviour
{
    public GameObject Canvas;
    private bool isDragging = false;
    private bool isOverPlayerField = false;
    private GameObject playerField;
    private GameObject startParent;
    private Vector2 startPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        Canvas = GameObject.Find("MainCanvas");
    }

    // Update is called once per frame
    void Update()
    {
        if (isDragging)
        {
            transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            transform.SetParent(Canvas.transform, true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isOverPlayerField = true;
        playerField = collision.gameObject;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isOverPlayerField = false;
        playerField = null;
    }

    public void startDrag()
    {
        startParent = transform.parent.gameObject;
        startPosition = transform.position;
        isDragging = true;
    }

    public void endDrag()
    {
        isDragging = false;
        if (isOverPlayerField)
        {
            transform.SetParent(playerField.transform, false);
        } else
        {
            transform.position = startPosition;
            transform.SetParent(startParent.transform, false);
        }
    }
}
