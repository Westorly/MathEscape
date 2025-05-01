using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public float playerReach = 3f;
    Interactable currentInteractable;

    // Update is called once per frame
    void Update()
    {
        CheckInteration();
        /*
        if (Input.GetKeyDown(KeyCode.Mouse0) && currentInteractable != null)  //Venstre click
        {
            currentInteractable.Interact();
        }
        */
    }

    void CheckInteration()
    {
        RaycastHit hit;
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);

        if (Physics.Raycast(ray, out hit, playerReach))
        {
            if (hit.collider.tag == "Interactable")
            {
                Interactable newInteractable = hit.collider.GetComponent<Interactable>();
                //if there is a currentinterable and it is not the new one
                if (currentInteractable && newInteractable != currentInteractable)
                {
                    currentInteractable.DisableOutline();
                }


                if (newInteractable.enabled)
                {
                    SetNewCurrentInteractable(newInteractable);
                }
                else //if the interactable is disabled
                {
                    DisableCurrentInteractable();
                }
            }
            else //if not an interactable
            {
                DisableCurrentInteractable();
            }


        }
        else //if nothing is in reach
        {
            DisableCurrentInteractable();
        }
    }

    void SetNewCurrentInteractable(Interactable newInteractable)
    {
        currentInteractable = newInteractable;
        currentInteractable.EnableOutline();

    }

    void DisableCurrentInteractable()
    {
        if (currentInteractable)
        {
            currentInteractable.DisableOutline();
            currentInteractable = null;
        }
    }
}