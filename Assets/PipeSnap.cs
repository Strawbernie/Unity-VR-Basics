using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PipeSnap : MonoBehaviour
{
    public enum Type { Straight, Round, Cross, Tshape, Null }

    public Type type;

    private int typeIndex;
    private XRSocketInteractor interactor;
    private Transform gfx;
    public bool correctPiece;

    private void Start()
    {
        interactor = GetComponent<XRSocketInteractor>();
        gfx = transform.GetChild(0);

        switch (type)
        {
            case Type.Straight: typeIndex = 0; break;
            case Type.Round:    typeIndex = 1; break;
            case Type.Cross:    typeIndex = 2; break;
            case Type.Tshape:   typeIndex = 3; break;
            case Type.Null:     typeIndex = 4; break;
        }

        if (typeIndex == 4) correctPiece = true;
    }

    public void OnSnapPipe()
    {
        if (interactor.GetOldestInteractableSelected() != null && interactor.GetOldestInteractableSelected().transform.TryGetComponent(out Pipe pipe))
        {
            gfx.transform.rotation = pipe.SnapToDesire();
            if (pipe.typeIndex == typeIndex) correctPiece = true;
            else correctPiece = false;
        }
    }

    public void RemovePipe()
    {
        if (typeIndex == 4) correctPiece = true;
    }
}
