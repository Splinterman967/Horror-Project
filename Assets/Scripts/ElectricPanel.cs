using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricPanel : MonoBehaviour
{
    private bool isPlayerNearPanel;
    private ParticleSystem electricParticle;
    [SerializeField] GameObject canvas;
    void Start()
    {
        EventManager.Instance.OnElectricPanelRepair += RepairElectricPanel;

        isPlayerNearPanel = false;
        electricParticle = gameObject.GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerNearPanel && Input.GetKeyDown(KeyCode.E))
        {
            EventManager.Instance.ElectricPanelRepair();
        }
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {

            isPlayerNearPanel = true;
            canvas.SetActive(true);

        }

    }


    private void OnTriggerExit(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            isPlayerNearPanel = false;
            canvas.SetActive(false);
        }

    }
    private void RepairElectricPanel()
    {            
            Debug.Log("PanelRepaired");
            electricParticle.Stop();
            canvas.SetActive(false);

    }
}
