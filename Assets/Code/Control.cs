using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{ 
    private void Start()
    {
        this.GetComponent<Material>().color = new Color(1.0f, 1.0f, 1.0f, 0);
    }
}
