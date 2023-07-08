using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToStart : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector2 _startingPos;
    private GameObject _plyr;
    private GameObject _panel;
    void Start()
    {
      _plyr = GameObject.FindGameObjectWithTag("Player");
      _panel = GameObject.FindGameObjectWithTag("InventoryPanel");
      _startingPos = _plyr.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveToStartingPos()
    {
      _plyr.transform.position = _startingPos;
      _plyr.SetActive(false);
      _plyr.SetActive(true);
      _panel.SetActive(true);
    }
}
