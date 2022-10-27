using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// template untuk kelas-kelas yang bisa di interact
public abstract class Interactable : MonoBehaviour
{
    public string promptMessage;

    public void BaseInteract()
    {
        Interact();
    }

    protected virtual void Interact()
    {
        // fungsi kosong untuk di override
    }
}
