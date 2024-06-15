using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager Instance { get; private set; }

    
    private void Awake()
    {
        Instance = this;
    }



    [SerializeField] float jumpScareDuration;

    public event Action<int> OnDoorOpen;
    public event Action<int> OnDoorClose;

    public event Action OnElectricPanelRepair;
    public event Action OnFirstJumpScare;
    

    
    public void FirstJumpScare()
    {
        if (OnFirstJumpScare != null)
        {
            OnFirstJumpScare.Invoke();
        }
    }
    public void ElectricPanelRepair()
    {
        if (OnElectricPanelRepair != null)
        {
            OnElectricPanelRepair.Invoke();
        }
    }
    public void DoorOpeningTriggered(int id)
    {
        if (OnDoorOpen != null)
        {
            OnDoorOpen.Invoke(id);
        }
    }

    public void DoorClosingTriggered(int id)
    {
        if (OnDoorClose != null)
        {
            OnDoorClose.Invoke(id);
        }
    }

    IEnumerator JumpScareDuration()
    {
        OnFirstJumpScare.Invoke();
        yield return new WaitForSeconds(jumpScareDuration);
       
        
    }
}
