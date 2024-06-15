using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTriggers : MonoBehaviour
{

    private void Start()
    {
    }
    private void OnTriggerEnter(Collider other)
    {
       if(other.gameObject.CompareTag("Monster"))
        {
            EventManager.Instance.FirstJumpScare();

           
        }
    }


}
