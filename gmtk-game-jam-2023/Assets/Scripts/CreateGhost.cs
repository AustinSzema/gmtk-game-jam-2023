using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CreateGhost : MonoBehaviour
{

    private GameObject _ghost;
    [SerializeField] private int count = 5;
    private int _originalCount;
    private GameObject[] _pool;

    public GameObject real;

    private GameObject _current;

    private bool _holding;

    [SerializeField]
    private TMP_Text countText;
    
    // Start is called before the first frame update
    void Start()
    {
      _originalCount = count;
      _pool = new GameObject[count];
      for (int i = 0; i < count; i++)
      {
        _current = Instantiate(real);
        _current.GetComponent<MoveObstacle>().movable = true;
        _current.GetComponent<MoveObstacle>().deletable = true;
        _current.GetComponent<MoveObstacle>().parentButton = this;
        _current.SetActive(false);
        _pool[i] = _current;
      }
      this.gameObject.GetComponent<Image>().sprite = real.GetComponent<SpriteRenderer>().sprite;
      _holding = false;
      _ghost = GameObject.Instantiate(real, new Vector2(0, 0), Quaternion.identity);
      _ghost.gameObject.SetActive(false);
      countText.text = count.ToString();
    }

    // Update is called once per frame
    void Update()
    {
      if (Input.GetKeyUp(KeyCode.Mouse0) && _holding && count > 0)
      {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _current = _pool[count - 1];
        _current.transform.position = mousePos;
        Debug.Log("I have been dropped!");
        _holding = false;
        _ghost.gameObject.SetActive(false);
        _current.gameObject.SetActive(true);
        count--;
        countText.text = count.ToString();
      }

      if (_holding)
      {
        Debug.Log("I am being held!");
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _ghost.gameObject.SetActive(true);
        _ghost.transform.SetPositionAndRotation(mousePos, Quaternion.identity);
      }
    }

    public void Pickup()
    {
      Debug.Log("I've been clicked!");
      Debug.Log("The mouse's position is: " + Camera.main.ScreenToWorldPoint(Input.mousePosition) + "and my position is: " + this.transform.position);
      if (count > 0)
      {
        _holding = true;  
      }
      
    }

    public void DeleteObject(GameObject go)
    {
      Debug.Log("Delete Object was called");
      go.SetActive(false);
      count++;
      GameObject[] newPool = new GameObject[_originalCount];
      int i = 0;
      int j = 0;

      for (i = 0; i < _originalCount; i++)
      {
        if (_pool[i].activeSelf)
        {
          newPool[j] = _pool[i];
          j++;
        } 
      }
      
      for (i = 0; i < _originalCount; i++)
      {
        if (!(_pool[i].activeSelf))
        {
          newPool[j] = _pool[i];
          j++;
        } 
      }

      _pool = newPool;
      countText.text = count.ToString();

    }
}
