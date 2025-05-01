using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public float playerReach = 3f;
    Interactable currentInterable;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && currentInterable != null)  //Venstre click
        {
            currentInterable.Interact();
        }
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
                if (currentInterable && newInteractable != currentInterable)
                {
                    currentInterable.DisableOutline();
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
        currentInterable = newInteractable;
        currentInterable.EnableOutline();

    }

    void DisableCurrentInteractable()
    {
        if (currentInterable)
        {
            currentInterable.DisableOutline();
            currentInterable = null;
        }
    }
}