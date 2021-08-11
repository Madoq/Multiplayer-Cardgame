using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragCard : MonoBehaviour
{
    private bool isDragging = false;
    private GameObject startParent;
    private Vector2 startPosition;
    private GameObject dropZone;
    private bool isOverDropZone;

    public GameObject Canvas;
        void Start()
    {
        Canvas = GameObject.Find("Main Canvas");
        dropZone = GameObject.Find("DropZone");
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        isOverDropZone = true;
        dropZone = collision.gameObject;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        
        isOverDropZone = false;
        dropZone = null;
    }

    public void StartDrag()
    {
        isDragging=true;
        startParent = transform.parent.gameObject;
        startPosition = transform.position;
    }
    public void EndDrag()
    {
        isDragging = false;
        if(isOverDropZone)
        {
            transform.SetParent(dropZone.transform, false);
            
        }
        else
        {
            transform.position = startPosition;
            transform.SetParent(startParent.transform,false);
        }
    }
    void Update()
    {
        if(isDragging)
        {
            transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            transform.SetParent(Canvas.transform,true);
        }
    }
}
