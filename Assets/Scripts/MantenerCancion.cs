using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MantenerCancion : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
