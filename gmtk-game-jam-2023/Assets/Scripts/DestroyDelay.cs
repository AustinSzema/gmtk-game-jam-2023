using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyDelay : MonoBehaviour
{
    [SerializeField] private float timeUntilDestroy = 2f;

    void Start()
    {
        Destroy(gameObject, timeUntilDestroy);
    }
}
