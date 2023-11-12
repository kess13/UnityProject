using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public GameObject[] FirstGroup;
    public GameObject[] SecondGroup;
    public Button button;
    public Material normal;
    public Material transperent;
    public bool CanPush;// to regulate button can be pushed if block is not in another block
    private void OnTriggerEnter(Collider other)
    {
        if (CanPush)
        {
            if (other.CompareTag("Cube") || other.CompareTag("Player"))
            {
                foreach (GameObject first in FirstGroup)
                {
                    first.GetComponent<Renderer>().material = normal;
                    first.GetComponent<Collider>().isTrigger = false;
                }
                foreach (GameObject second in SecondGroup)
                {
                    second.GetComponent<Renderer>().material = transperent;
                    second.GetComponent<Collider>().isTrigger = true;
                }
                GetComponent<Renderer>().material = transperent;
                button.GetComponent<Renderer>().material = normal;
                button.CanPush = true;
            }
        }
    }

}
