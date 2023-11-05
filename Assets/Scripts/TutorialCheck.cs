using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Transformers;
using UnityEngine.XR.Interaction.Toolkit.Utilities;
using UnityEngine.XR.Interaction.Toolkit.Utilities.Pooling;

public class TutorialCheck : MonoBehaviour
{
    public OxygenManager oxygenManager;
    public DamagedWall DW;
    public Fire fire;
    public GameObject fire1;
    public GameObject wall;
    public HealthController healthController;
    public GameObject CrouchTutorial;
    public GameObject GrabTutorial;
    public GameObject UseTutorial;
    private InputDevice LeftController;
    private InputDevice RightController;
    public InputData inputData;
    bool shownGrab = false;
    bool shownCrouch = false;
    private void Start()
    {
        CrouchTutorial.SetActive(true);
        DW.inTutorial = true;
        fire.inTutorial = true;
        healthController.inTutorial = true;
        RightController = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);
        LeftController = InputDevices.GetDeviceAtXRNode(XRNode.LeftHand);
    }
    // Update is called once per frame
    void Update()
    {
        if (DW.repaired && !oxygenManager.NoOxygen && !fire.isLit)
        {
            SceneManager.LoadScene("SampleScene");
        }
        if (!oxygenManager.NoOxygen)
        {
            fire1.SetActive(true);
            wall.SetActive(true);
        }
        // Check input from the left controller.
        CheckControllerInput(LeftController);

        // Check input from the right controller.
        CheckControllerInput(RightController);
    }
    private void CheckControllerInput(InputDevice controller)
    {
        if (shownCrouch && !shownGrab && inputData._rightController.TryGetFeatureValue(CommonUsages.gripButton, out bool Button)) 
        {
            if (Button)
            {
                shownGrab = true;
                GrabTutorial.SetActive(false);
                UseTutorial.SetActive(true);
            }
        }
        if (shownCrouch && !shownGrab && inputData._leftController.TryGetFeatureValue(CommonUsages.gripButton, out bool LeftButton))
        {
            if(LeftButton)
            {
                shownGrab = true;
                GrabTutorial.SetActive(false);
                UseTutorial.SetActive(true);
            }
        }
        if (shownGrab && inputData._rightController.TryGetFeatureValue(CommonUsages.triggerButton, out bool UseButton))
        {
            if(UseButton)
            {
                UseTutorial.SetActive(false);
            }
        }
        if (shownGrab && inputData._leftController.TryGetFeatureValue(CommonUsages.triggerButton, out bool UseLButton))
        {
            if(UseLButton)
            {
                UseTutorial.SetActive(false);
            }
        }
        if (!shownCrouch && inputData._leftController.TryGetFeatureValue(CommonUsages.primary2DAxisClick, out bool JoyButton))
        {
            if(JoyButton)
            {
                shownCrouch = true;
                CrouchTutorial.SetActive(false);
                GrabTutorial.SetActive(true);
            }
        }
    }
}
