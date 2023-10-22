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

public class Crouch : MonoBehaviour
{
    private InputDevice LeftController;
    public InputData inputData;
    public Transform Camera1;
    public float Ypos;
    bool crouching;
    bool haspressed;
    private void Start()
    {
        LeftController = InputDevices.GetDeviceAtXRNode(XRNode.LeftHand);
        float Ypos = Camera1.position.y;
        crouching = false;
    }
    // Update is called once per frame
    void Update()
    {
        // Check input from the left controller.
        CheckControllerInput(LeftController);
    }
    private void CheckControllerInput(InputDevice controller)
    {
        if (inputData._leftController.TryGetFeatureValue(CommonUsages.primary2DAxisClick, out bool LeftButton))
        {
            if (LeftButton)
            {
                if (!crouching&& !haspressed)
                {
                    Ypos = .75f;
                    Vector3 newPosition = new Vector3(Camera1.position.x, Ypos, Camera1.position.z);
                    Camera1.position = newPosition;
                    crouching = true;
                    haspressed= true;
                }
                else if (crouching && !haspressed) 
                {
                    Ypos = 1.25f;
                    Vector3 newPosition = new Vector3(Camera1.position.x, Ypos, Camera1.position.z);
                    Camera1.position = newPosition;
                    crouching = false;
                    haspressed= true;
                }
            }
            else
            {
                haspressed= false;
            }
            }
        }
    }


