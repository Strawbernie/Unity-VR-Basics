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

public class Extinguisher : MonoBehaviour
{
    [SerializeField] private float amountExtinguishedPerSecond = 1.0f;
    private InputDevice LeftController;
    private InputDevice RightController;
    private bool holdingRight;
    private bool holdingLeft;
    public InputData inputData;
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
            holdingRight = true;
        }
        if (other.transform.tag == "leftHand")
        {
            holdingLeft = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        holdingRight = false;
        holdingLeft = false;
    }
    private void CheckControllerInput(InputDevice controller)
    {
        if (inputData._rightController.TryGetFeatureValue(CommonUsages.triggerButton, out bool Button))
        {
            if (holdingRight && Button)
            {
                PS.SetActive(true);
                if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out RaycastHit hit, 3f)
            && hit.collider.TryGetComponent(out Fire fire))
                {
                    fire.TryExtinguish(amountExtinguishedPerSecond * Time.deltaTime);
                }
            }
        }
        if (inputData._leftController.TryGetFeatureValue(CommonUsages.triggerButton, out bool LeftButton))
        {
            if (holdingLeft && LeftButton)
            {
                PS.SetActive(true);
                if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out RaycastHit hit, 3f)
            && hit.collider.TryGetComponent(out Fire fire))
                {
                    fire.TryExtinguish(amountExtinguishedPerSecond * Time.deltaTime);
                }
            }
            else if (!Button && !LeftButton)
            {
                PS.SetActive(false);
            }
        }
    }
}


