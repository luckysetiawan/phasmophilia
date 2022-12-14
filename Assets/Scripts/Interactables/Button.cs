using UnityEngine;
using UnityEngine.Events;

public class Button : Interactable
{
    [SerializeField]
    private GameObject door;
    private bool doorOpen;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    protected override void Interact()
    {
        doorOpen = !doorOpen;
        door.GetComponent<Animator>().SetBool("isOpen", doorOpen);
    }
}
