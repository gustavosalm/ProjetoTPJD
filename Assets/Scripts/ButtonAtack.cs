using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonAtack : MonoBehaviour
{
    [SerializeField] private GameObject p;
    void Update()
    {
        if (Input.touchCount > 0)
            Destroy(p);
    }
}
