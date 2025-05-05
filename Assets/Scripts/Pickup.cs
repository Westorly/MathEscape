using UnityEngine;

public class Pickup : MonoBehaviour
{
    bool isHolding = false;

    [SerializeField]
    float throwForce = 600f;
    [SerializeField]
    float minDistance = 3f;
    float distance;

    TempParent tempParent;
    Rigidbody rb;
    Vector3 objectPos;

    
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        tempParent = TempParent.Instance;


    }

    // Update is called once per frame
    void Update()
    {
        if(isHolding){
            Hold();
        }

        
    }

    private void OnMouseDown()
    {
        //pikcup the object when the mouse is clicked on it
        if (tempParent != null){
            isHolding = true;
            rb.useGravity = false;
            rb.detectCollisions = false;

            this.transform.SetParent(tempParent.transform);
        }
        else{
            Debug.Log("TempParent item not found in the scene");
        }
    }

    private void OnMouseUp(){
        //release the object when the mouse is released
        
    }

    private void OnMouseExit(){
        //release the object when the mouse is released
       
    }

    private void Hold(){
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        if(Input.GetMouseButtonDown(1)){
            //throw
        }
        
    }

}
