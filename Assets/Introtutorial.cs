using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Transformers;
using UnityEngine.XR.Interaction.Toolkit.Utilities;
using UnityEngine.XR.Interaction.Toolkit.Utilities.Pooling;

public class Introtutorial : MonoBehaviour
{
    public GameObject MoveTutorial;
    public GameObject RotateTutorial;
    private InputDevice LeftController;
    private InputDevice RightController;
    public InputData inputData;
    bool shownMove = false;
    // Start is called before the first frame update
    void Start()
    {
        MoveTutorial.SetActive(true);
        RightController = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);
        LeftController = InputDevices.GetDeviceAtXRNode(XRNode.LeftHand);
    }

    // Update is called once per frame
    void Update()
    {
        // Check input from the left controller.
        CheckControllerInput(LeftController);

        // Check input from the right controller.
        CheckControllerInput(RightController);
    }
    private void CheckControllerInput(InputDevice controller)
    {
        if (shownMove && inputData._rightController.TryGetFeatureValue(CommonUsages.primary2DAxisTouch, out bool Button))
        {
            if (Button)
            {
                RotateTutorial.SetActive(false);
            }
        }
        if (!shownMove && inputData._leftController.TryGetFeatureValue(CommonUsages.primary2DAxisTouch, out bool LeftButton))
        {
            if (LeftButton)
            {
                shownMove = true;
                MoveTutorial.SetActive(false);
                RotateTutorial.SetActive(true);
            }
        }
    }
}
