using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardKey : MonoBehaviour
{

    [SerializeField]
    private bool isPlayer = false;

    [SerializeField]
    public bool active = false;

    public AudioClip se;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale > 0)
        {
            if (isPlayer && !active)
            {
                if (Input.GetKeyDown(KeyCode.X) || Input.GetKey("joystick button 0"))
                {
                    audioSource.PlayOneShot(se);
                    active = true;
                }
            }

            if (active == true && audioSource.isPlaying == false)
            {
                gameObject.SetActive(false);
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("Player")){
            isPlayer = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isPlayer = false;
        }
    }
}