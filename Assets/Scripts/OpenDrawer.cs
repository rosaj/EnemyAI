using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class OpenDrawer : MonoBehaviour
{
    public Animator ANI;

    public GameObject openText;
    public GameObject closedText;

    public AudioSource openSound;
    public AudioSource closeSound;

    private bool open;

    private bool inReach;


    void Start()
    {
        openText.SetActive(false);
        closedText.SetActive(false);

        ANI.SetBool("open", false);
        ANI.SetBool("close", false);

        open = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MainCamera") && !open)
        {
            inReach = true;
            openText.SetActive(true);
        }

        else if (other.CompareTag("MainCamera") && open)
        {
            inReach = true;
            closedText.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            inReach = false;
            openText.SetActive(false);
            closedText.SetActive(false);
        }
    }

    void Update()
    {
        if (!open && inReach && Input.GetKeyDown(KeyCode.E))
        {
            openSound.Play();
            ANI.SetBool("open", true);
            ANI.SetBool("close", false);
            open = true;
            openText.SetActive(false);
            inReach = false;
        }

        else if (open && inReach && Input.GetKeyDown(KeyCode.Q))
        {
            closeSound.Play();
            ANI.SetBool("open", false);
            ANI.SetBool("close", true);
            open = false;
            closedText.SetActive(false);
            inReach = false;
        }

    }
}
