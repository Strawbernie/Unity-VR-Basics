using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.Windows;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Transformers;
using UnityEngine.XR.Interaction.Toolkit.Utilities;
using UnityEngine.XR.Interaction.Toolkit.Utilities.Pooling;

public class Blowtorch : MonoBehaviour
{
    private InputDevice LeftController;
    private InputDevice RightController;
    private bool holdingRight;
    private bool holdingLeft;
    public GameObject PS;
    private void Start()
    {
        RightController = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);
        LeftController = InputDevices.GetDeviceAtXRNode(XRNode.LeftHand);
    }
    public XRGrabInteractable InteractableItem;
    // Update is called once per frame
    void Update()
    {
        // Check input from the left controller.
        CheckControllerInput(LeftController);

        // Check input from the right controller.
        CheckControllerInput(RightController);
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.transform.tag == "rightHand")
        {
            holdingRight= true;
        }
        if (other.transform.tag == "leftHand")
        {
            holdingLeft= true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        holdingRight = false;
        holdingLeft= false;
    }
    private void CheckControllerInput(InputDevice controller)
    {
        if (holdingRight|holdingLeft )
        {
            PS.SetActive(true);
            //Debug.Log("Works");
        }
        else
        {
            PS.SetActive(false);
        }
    }
    }
