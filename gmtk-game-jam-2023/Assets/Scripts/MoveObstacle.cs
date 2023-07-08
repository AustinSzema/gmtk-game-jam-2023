using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObstacle : MonoBehaviour
{
    public bool movable = false;
    [SerializeField] private bool deletable = false;

    private bool _holding = false;
    // Start is called before the first frame update
    void Start()
    {
      _holding = false;
    }

    // Update is called once per frame
    void Update()
    {
      if (_holding)
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
      _holding = true;
    }
  
}
