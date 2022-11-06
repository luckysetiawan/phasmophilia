using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// template untuk kelas-kelas yang bisa di interact
public abstract class Interactable : MonoBehaviour
{
    // tambah kurang InteractionEvent ke game object
    public bool useEvents;
    [SerializeField]
    public string promptMessage;

    public void BaseInteract()
    {
        if (useEvents)
            GetComponent<InteractionEvent>().OnInteract.Invoke();
        Interact();
    }

    protected virtual void Interact()
    {
        // fungsi kosong untuk di override
    }
}
