using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Timers;
using TMPro;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class PlayerController : MonoBehaviour
{
    public Rigidbody thisRigidBody; // the rigidbody we'll be moving
    public Camera thisCamera;   // the camera

    public float pitch; // the mouse movement up/down
    public float yaw;   // the mouse movement left/right

    public float fpForwardBackward; // input float from  W and S keys
    public float fpStrafe;  // input float from A D keys

    public Vector3 inputVelocity;  // cumulative velocity to move character
    public float velocityModifier;  // velocity of conroller multiplied by this number

    
    private float timer;
    private bool victory;
    
    public GameObject Room;

    public TextMeshPro number;
    public TextMeshPro totalpills;
    public TextMeshProUGUI poof;
    
    public float target;
    public int currentNumberofPills;
    public int maxPills;
    public float currentNumber;

    public AudioSource beep;
    

    
    void Start()
    {
        thisRigidBody = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
     
        yaw = Input.GetAxis("Mouse X");
        transform.Rotate(0f, yaw, 0f);

        pitch = Input.GetAxis("Mouse Y");
        thisCamera.transform.Rotate(-pitch, 0f, 0f);

        fpForwardBackward = Input.GetAxis("Vertical");
        fpStrafe = Input.GetAxis("Horizontal");

        inputVelocity = transform.forward * fpForwardBackward;
        inputVelocity += transform.right * fpStrafe;
    }

    
    void FixedUpdate()
    {
        if (timer > 0.0f)
        {
            timer -= Time.deltaTime;
            if (timer >= 1.4f)
            {
                inputVelocity += new Vector3(0f, 1f, 0f);
            }
        }
        
        if (Input.GetKeyDown(KeyCode.Space) && timer <= 0.0f)
        {
            timer = 2.0f;
        }
        thisRigidBody.velocity = inputVelocity * velocityModifier + (Physics.gravity * .69f);
        UpdateText();
        checkVictory();
    }

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.name == "Blue Pill" && other.GetComponent<Pills>().isActive && currentNumberofPills < maxPills)
        {
            other.GetComponent<Pills>().isActive = false;
            other.GetComponent<Pills>().deactivate();
            currentNumberofPills++;
            currentNumber += 2;
            beep.Play();
        }
        
        if (other.transform.name == "Yellow Pill" && other.GetComponent<Pills>().isActive && currentNumberofPills < maxPills)
        {
            other.GetComponent<Pills>().isActive = false;
            other.GetComponent<Pills>().deactivate();
            currentNumberofPills++;
            currentNumber = currentNumber * 3;
            beep.Play();
        }
        
        if (other.transform.name == "Green Pill" && other.GetComponent<Pills>().isActive && currentNumberofPills < maxPills)
        {
            other.GetComponent<Pills>().isActive = false;
            other.GetComponent<Pills>().deactivate();
            currentNumberofPills++;
            currentNumber = currentNumber / 2;
            beep.Play();
        }
        
        if (other.transform.name == "Red Pill" && other.GetComponent<Pills>().isActive && currentNumberofPills < maxPills)
        {
            other.GetComponent<Pills>().isActive = false;
            other.GetComponent<Pills>().deactivate();
            currentNumberofPills++;
            currentNumber -= 3;
            beep.Play();
        }
        
        if (other.transform.name == "Cylinder (6)")
        {
            Reset();
            beep.Play();
        }
        
        if (other.transform.name == "Cylinder (11)" && victory)
        {
            poof.text = "You win!";
        }
        
    }

    
    private void Reset()
    {
        currentNumberofPills = 0;
        currentNumber = 0;
        poof.text = "Okay let's go!";
        Pills[] pillas = Room.GetComponentsInChildren<Pills>();
        for (int i = 0; i < pillas.Length; i++)
        {
            pillas[i].isActive = true;
            pillas[i].reset();
        }
    }

    
    private void UpdateText()
    {
        totalpills.text = currentNumberofPills.ToString() + " / " + maxPills;
        number.text = currentNumber.ToString();
    }

    
    private void checkVictory()
    {
        if ((target == currentNumber) && (maxPills == currentNumberofPills))
        {
            victory = true;
            poof.text = "You won, hooray!";
        }

        if ((target != currentNumber) && (maxPills == currentNumberofPills))
        {
            poof.text = "Go to the turquoise portal pad to reset!";
        }
    }
}
