using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObstacle : MonoBehaviour
{
    public bool movable = false;
    public bool deletable = false;
    public CreateGhost parentButton;

    private bool _holding = false;
    // Start is called before the first frame update
    void Start()
    {
      _holding = false;
    }

    // Update is called once per frame
    void Update()
    {
      
      
      if (_holding && GameController.editing)
      {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        this.gameObject.transform.position = mousePos;
      }


    }
    
    private void OnMouseUp()
    {
      _holding = false;
    }

    private void OnMouseDown()
    {
      if (movable)
      {
        _holding = true;    
      }
    
    }

    private void OnMouseOver()
    { 
      if (Input.GetKeyDown(KeyCode.Mouse1) && deletable && GameController.editing)
      {
        if (!parentButton)
        {
          Debug.Log("If you are manually setting an object in the scene as deletable, you must also manually" +
                    "assign it a parent button in the inspector"); 
        }
        else
        {
          parentButton.DeleteObject(this.gameObject);
        } 
      }
    }
}
