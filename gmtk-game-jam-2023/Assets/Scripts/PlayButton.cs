using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButton : MonoBehaviour
{
    private AutoMove _plyr;
    // Start is called before the first frame update
    void Start()
    {
      _plyr = GameObject.FindGameObjectWithTag("Player").GetComponent<AutoMove>();
    }

    public void Pressed()
    {
      _plyr.Play(); 
    }
        
}
