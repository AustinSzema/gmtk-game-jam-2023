using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButton : MonoBehaviour
{
    private AutoMove _plyr;

    private GameObject _panel;
    // Start is called before the first frame update
    void Start()
    {
      _plyr = GameObject.FindGameObjectWithTag("Player").GetComponent<AutoMove>();
      _panel = GameObject.FindGameObjectWithTag("InventoryPanel");
    }

    public void Pressed()
    {
      _panel.SetActive(false);
      _plyr.Play(); 
    }
        
}
