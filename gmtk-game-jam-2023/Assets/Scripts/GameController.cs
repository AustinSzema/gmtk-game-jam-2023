using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController gc { get; private set; }

    public static bool editing = true;
    
    // Start is called before the first frame update

    private void Awake()
    {
      if (gc != null && gc != this)
      {
        Destroy(this);
      }
      else
      {
        gc = this;
      }
      
    }
}
