using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadNotes : MonoBehaviour
{
    public GameObject player;
    public GameObject noteUI;

    public GameObject pickUpText;

    public AudioSource pickUpSound;

    public bool inReach;

    void Start()
    {
        noteUI.SetActive(false);
        pickUpText.SetActive(false);

        inReach = false;

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            inReach = true;
            pickUpText.SetActive(true);

        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            inReach = false;
            pickUpText.SetActive(false);
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && inReach)
        {
            noteUI.SetActive(true);
            pickUpSound.Play();
            player.GetComponent<FirstPersonController>().enabled = false;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

    }
    public void ExitButton()
    {
        noteUI.SetActive(false);
        player.GetComponent<FirstPersonController>().enabled = true;
    }
}
