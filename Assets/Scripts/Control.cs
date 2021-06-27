using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    public AudioClip collisionSfx;
    private AudioSource audioSource;

    private float h = 0.0f; //horizontal
    private float v = 0.0f; //vertical
    private float r = 0.0f;

    private float moveSpeed = 3.0f;
    private float rotationSpeed = 100.0f;

    private Transform playerTr;

    public Transform camTr;
    public float toggleAngleLow = 20.0f;
    public float toggleAngleMax = 30.0f;



    // Start is called before the first frame update
    void Start()
    {
        playerTr = GetComponent<Transform>();
        audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        /*
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        r = Input.GetAxis("Mouse X");
        
        playerTr.Translate(new Vector3(h, 0, v) * moveSpeed * Time.deltaTime);
        playerTr.Rotate(new Vector3(0, r, 0) * rotationSpeed * Time.deltaTime);
        */
        if(camTr.eulerAngles.x >= toggleAngleLow && camTr.eulerAngles.x < toggleAngleMax)
        {
            Vector3 forword = camTr.TransformDirection(Vector3.forward);
            playerTr.Translate(forword * moveSpeed * Time.deltaTime);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Pavements")
        { 
            audioSource.PlayOneShot(collisionSfx, 1.0f);
        }
    }
}
