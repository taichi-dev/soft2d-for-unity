using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RendererDataWarning : MonoBehaviour
{
    public GameObject warningText;

    private void Start()
    {
        warningText.SetActive(false);
    }
}
