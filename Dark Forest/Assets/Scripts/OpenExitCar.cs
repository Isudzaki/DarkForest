using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenExitCar : MonoBehaviour
{
    public GameObject carCamera, playCamera, Exit, man;
    private bool player = false, inCar = false;

    private void Start()
    {
        GetComponent<MoveCar>().enabled = false;
        carCamera.SetActive(false);
        playCamera.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            player = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            player = false;
        }
    }

    private void Update()
    {
        if (player == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                man.SetActive(false);
                inCar = true;
                GetComponent<MoveCar>().enabled = true;
                carCamera.SetActive(true);
                playCamera.SetActive(false);
            }
        }

        if (inCar == true)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                man.SetActive(true);
                man.transform.position = Exit.transform.position;
                inCar = false;
                GetComponent<MoveCar>().enabled = false;
                carCamera.SetActive(false);
                playCamera.SetActive(true);
            }
        }
    }

}

