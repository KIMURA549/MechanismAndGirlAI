using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Button : MonoBehaviour
{
    [SerializeField]
    GameObject Door_Left;
    [SerializeField]
    GameObject Door_Right;

    [SerializeField]
    GimmickButton button;
    
    [SerializeField]
    float speed = 3.0f;

    [SerializeField]
    float move = 5.0f;

    float dleft_pos, dright_pos;

    [SerializeField]
    private bool moveZ = false; //Z軸方向に移動

    public AudioClip se;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        if (moveZ == true)
        {
            dleft_pos = Door_Left.transform.position.z;
            dright_pos = Door_Right.transform.position.z;
        }
        else
        {
            dleft_pos = Door_Left.transform.position.x;
            dright_pos = Door_Right.transform.position.x;
        }
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale > 0)
        {
            if (button.active == true)
            {
                Open();
            }
            else
            {
                Close();
            }
        }
    }

    void Open()
    {
        if (moveZ)
        {
            if (dleft_pos + move > Door_Left.transform.position.z)
            {
                Door_Left.transform.position += Vector3.forward * speed * Time.deltaTime;
            }
            if (dright_pos - move < Door_Right.transform.position.z)
            {
                Door_Right.transform.position += Vector3.back * speed * Time.deltaTime;
            }

            if(dleft_pos + move > Door_Left.transform.position.z|| dright_pos - move < Door_Right.transform.position.z)
            {

                if (audioSource.isPlaying == false)
                {
                    audioSource.PlayOneShot(se);
                }
            }
            else
            {
                audioSource.Stop();
            }
        }
        else
        {
            if (dleft_pos - move < Door_Left.transform.position.x)
            {
                Door_Left.transform.position += Vector3.left * speed * Time.deltaTime;
            }
            if (dright_pos + move > Door_Right.transform.position.x)
            {
                Door_Right.transform.position += Vector3.right * speed * Time.deltaTime;
            }

            if(dleft_pos - move < Door_Left.transform.position.x|| dright_pos + move > Door_Right.transform.position.x)
            {
                if (audioSource.isPlaying == false)
                {
                    audioSource.PlayOneShot(se);
                }
            }
            else
            {
                audioSource.Stop();
            }
        }
    }

    void Close()
    {
        if (moveZ)
        {
            if (dleft_pos < Door_Left.transform.position.z)
            {
                Door_Left.transform.position -= Vector3.forward * speed * Time.deltaTime;
            }
            if (dright_pos > Door_Right.transform.position.z)
            {
                Door_Right.transform.position -= Vector3.back * speed * Time.deltaTime;
            }

            if (dleft_pos < Door_Left.transform.position.z || dright_pos > Door_Right.transform.position.z)
            {
                if (audioSource.isPlaying == false)
                {
                    audioSource.PlayOneShot(se);
                }
            }
            else
            {
                audioSource.Stop();
            }
        }
        else
        {
            if (dleft_pos > Door_Left.transform.position.x)
            {
                Door_Left.transform.position -= Vector3.left * speed * Time.deltaTime;
            }
            if (dright_pos < Door_Right.transform.position.x)
            {
                Door_Right.transform.position -= Vector3.right * speed * Time.deltaTime;
            }


            if (dleft_pos > Door_Left.transform.position.x || dright_pos < Door_Right.transform.position.x)
            {
                if (audioSource.isPlaying == false)
                {
                    audioSource.PlayOneShot(se);
                }
            }
            else
            {
                audioSource.Stop();
            }
        }
    }
}
