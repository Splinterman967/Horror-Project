using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Door : MonoBehaviour
{

    public int doorID;

    private bool isPlayerNearDoor;
   


    private void Start()
    {
        EventManager.Instance.OnDoorOpen += OpenDoor;
        EventManager.Instance.OnDoorClose += CloseDoor;

        
        isPlayerNearDoor = false;
       
    }

    private void Update()
    {
       
        
       
    }

    private void CheckOpeningDoorConditions(bool doorClosed)
    {
      
     
            if (Input.GetKeyDown(KeyCode.Space) && isPlayerNearDoor)
            {
                if (doorClosed)
                {
                    EventManager.Instance.DoorOpeningTriggered(doorID);
                }
                else
                {
                    EventManager.Instance.DoorClosingTriggered(doorID);
                }

            }
        
       
    }

    private void OnTriggerEnter(Collider other)
    {
     
        if (other.CompareTag("Player"))
        {
            
           isPlayerNearDoor=true;
          
        }
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            bool isDoorClosed=false;

            CheckDoorState(isDoorClosed);
           
        }
       
    }


    private void OnTriggerExit(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            isPlayerNearDoor=false;
        }

    }

    private void CheckDoorState(bool isDoorClosed)
    {
       
        //If door is closed 
        if (gameObject.transform.localEulerAngles.y == 0)
        {
           
            isDoorClosed = true;
           
        }

        //If door is opened 
         if (gameObject.transform.localEulerAngles.y == 90)
        {
         
            isDoorClosed = false;
            
        }

        CheckOpeningDoorConditions(isDoorClosed);

    }
    private void OpenDoor(int id)
    {

        if (id == doorID)
        {
            
                Debug.Log("DoorOpened");

                gameObject.transform.Rotate(new Vector3(0, 90, 0));
            
             
        }
    }

    private void CloseDoor(int id)
    {

        if (id == doorID)
        {           
                Debug.Log("DoorClosed");

                gameObject.transform.Rotate(new Vector3(0,-90, 0));
            
          
        }
          
        
    }
}
