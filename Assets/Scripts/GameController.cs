using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public int fallenPins = 0;
    public TextMeshProUGUI textFallenPins;

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Pin"))
        {
            fallenPins++;
            other.tag = "FallenPin";
            textFallenPins.text = fallenPins.ToString();
        }
    }
}
