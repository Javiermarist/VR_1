using System;
using UnityEngine;

public class PanelBola : MonoBehaviour
{
    private Camera camaraPpal;

    private void Start()
    {
        camaraPpal = Camera.main;
    }

    private void Update()
    {
        if (camaraPpal != null)
        {
            transform.LookAt(camaraPpal.transform);
            transform.Rotate(0, 160, 0);
        }
    }
}
