using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPhoto : MonoBehaviour
{
    private void Start()
    {
        Destroy(gameObject,10);
    }
}