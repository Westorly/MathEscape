using UnityEngine;

public class TempParentScript : MonoBehaviour
{
    public static TempParentScript Instance { get; private set; }

    public void Awake(){
        if(Instance == null){
            Instance = this;
        }
        else{
            Destroy(this);
        }
    }
}
