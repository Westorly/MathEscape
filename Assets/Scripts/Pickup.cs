using UnityEngine;

public class Pickup : MonoBehaviour
{
    bool isHolding = false;

    [SerializeField]
    float throwForce = 600f;
    [SerializeField]
    float maxDistance = 3f;
    float distance;

    TempParent tempParent;
    Rigidbody rb;
    Vector3 objectPos;
    Outline outline; // Reference to Outline component

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        tempParent = TempParent.Instance;
        outline = GetComponent<Outline>(); // Get the Outline component
        if (outline != null)
        {
            outline.enabled = false; // Disable outline by default
        }
        else
        {
            Debug.LogWarning("Outline component not found on " + gameObject.name);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isHolding)
            Hold();
    }

    private void OnMouseDown()
    {
        // Pickup the object when the mouse is clicked on it
        distance = Vector3.Distance(this.transform.position, tempParent.transform.position);

        if (tempParent != null)
        {
            if (distance <= maxDistance)
            {
                isHolding = true;
                rb.useGravity = false;
                rb.detectCollisions = true;
                rb.isKinematic = false;
                this.transform.SetParent(tempParent.transform);
                DisableHighlight(); // Remove highlight when picked up
            }
        }
        else
        {
            Debug.Log("TempParent item not found in the scene");
        }
    }

    private void OnMouseUp()
    {
        // Release the object when the mouse is released
        Drop();
    }

    private void OnMouseExit()
    {
        // Remove highlight when the mouse exits
        Drop();
        DisableHighlight();
    }

    private void OnMouseEnter()
    {
        // Highlight the object when the mouse enters
        EnableHighlight();
    }

    private void Hold()
    {
        // Set a fixed offset relative to the camera or player
        Vector3 targetPos = tempParent.transform.position + tempParent.transform.forward * 1.5f; // Adjust the multiplier for the right distance

        // Calculate the distance and drop if too far
        distance = Vector3.Distance(this.transform.position, targetPos);
        if (distance >= maxDistance)
        {
            Drop();
        }

        // Smoothly move towards the target position (camera's forward direction)
        float speed = 10f; // Adjust to control how fast the object follows the target
        this.transform.position = Vector3.Lerp(this.transform.position, targetPos, Time.deltaTime * speed);

        // Throw the object when the Q key is pressed
        if (Input.GetKeyDown(KeyCode.Q) && isHolding)
        {
            Throw();
        }
    }


    private void Drop()
    {
        // Release the object when the mouse is released
        if (isHolding)
        {
            rb.useGravity = true;
            rb.detectCollisions = true;
            rb.isKinematic = false;
            this.transform.SetParent(null);
            isHolding = false;
        }
    }

    private void Throw()
    {
        rb.useGravity = true;
        rb.detectCollisions = true;
        rb.isKinematic = false;
        this.transform.SetParent(null);
        isHolding = false;

        // Apply the throw force in the direction the parent (usually camera or player) is facing
        Vector3 throwDirection = (tempParent.transform.forward + Vector3.up).normalized;
        rb.AddForce(tempParent.transform.forward * throwForce);
    }

    // Enable highlight by enabling the Outline component
    private void EnableHighlight()
    {
        if (outline != null)
        {
            outline.enabled = true;
        }
    }

    // Disable highlight by disabling the Outline component
    private void DisableHighlight()
    {
        if (outline != null)
        {
            outline.enabled = false;
        }
    }
}
