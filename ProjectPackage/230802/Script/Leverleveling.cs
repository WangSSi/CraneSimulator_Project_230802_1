using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leverleveling : MonoBehaviour
{
    public GameObject Button_Top_Model;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerHand"))
        {
            //Use a button as a trigger to affect something 
            Button_Top_Model.transform.position = transform.position - Vector3.up * 0.001f; ;
            SubHookCableSpawn.Leveling_the_Hooks = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("PlayerHand"))
        {
            //Use a button as a trigger to affect something 
            Button_Top_Model.transform.position = transform.position;
            
        }
    }
}
