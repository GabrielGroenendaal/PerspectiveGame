using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Timers;
using Tinylytics;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Vector3 = UnityEngine.Vector3;

public class PlayerController : MonoBehaviour
{
    /* Movement Variables */
    public Rigidbody thisRigidBody; // the rigidbody we'll be moving
    public Camera thisCamera;   // the camera
    private float pitch; // the mouse movement up/down
    private float yaw;   // the mouse movement left/right
    private float fpForwardBackward; // input float from  W and S keys
    private float fpStrafe;  // input float from A D keys
    private Vector3 inputVelocity;  // cumulative velocity to move character
    public float velocityModifier;  // velocity of conroller multiplied by this number
    private float timer; // A timer for the jump
    private float verticalLook; 
    
    /* Text and UI Objects */
    private TextMeshPro number; // Displays the current score
    private TextMeshPro totalpills; // Displays the Number of Pills / Total Pills 
    
    /* Stores the UI for different rooms because honestly I'm lazy */
    public TextMeshPro number1;
    public TextMeshPro number2;
    public TextMeshPro number3;
    public TextMeshPro number4;
    public TextMeshPro number5;

    public TextMeshPro totalpills1;
    public TextMeshPro totalpills2;
    public TextMeshPro totalpills3;
    public TextMeshPro totalpills4;
    public TextMeshPro totalpills5;
    
    /* References to Pills */
    public GameObject Pills1;
    public GameObject Pills2;
    public GameObject Pills3;
    public GameObject Pills4;
    public GameObject Pills5;
    
    /* Game Variables */
    public float target; // The number you want to reach. Stored by the room
    private int currentNumberofPills; // How many pills you have eaten so far
    public int maxPills; // How many pills you can eat total
    public float currentNumber; // What your current score is

    /* Booleans */
    public bool isPlaying;
    public bool victory; // Checks to see if Victory has been achieved
    public bool loser;

    /* GameObjects to Reference */
    private GameObject Pills;
    public GameController game;
    public Audience audience;
    public Narrator narrator;
    public AudioSource beep; // A little bleep that plays when you pick up a pill

    
    /* New Variables for Analytics */
    private int currentRoom;
    private bool IsTimingLevel;
    public float TimeForLevel;
    
    private bool IsTimingAttempt;
    public float TimeForAttempt;
    public string AllTimesForAttempt;
    public int numberOfAttempts;
    
    public string PillCombination;
    public string AllPillCombination;

    
    void Start()
    {
        thisRigidBody = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    
    void Update()
    {
        yaw = Input.GetAxis("Mouse X");
        transform.Rotate(0f, yaw, 0f);

        pitch = Input.GetAxis("Mouse Y");
        // sCamera.transform.Rotate(-pitch, 0f, 0f);
       
        verticalLook += -pitch;
        verticalLook = Mathf.Clamp(verticalLook, -80f, 80f);
		
        // actually apply verticalLook to camera's rotation
        thisCamera.transform.localEulerAngles = new Vector3(verticalLook,0f,0f);        

        fpForwardBackward = Input.GetAxis("Vertical");
        fpStrafe = Input.GetAxis("Horizontal");

        inputVelocity = transform.forward * fpForwardBackward;
        inputVelocity += transform.right * fpStrafe;

        if (IsTimingLevel)
        {
            TimeForLevel += Time.deltaTime;
        }

        if (IsTimingAttempt)
        {
            TimeForAttempt += Time.deltaTime;
        }
    }

    
    void FixedUpdate()
    {
        // Following a jump, for 2 seconds you will get upward momentum, basically
        if (timer > 0.0f)
        {
            timer -= Time.deltaTime;
            if (timer >= 1.4f)
            {
                inputVelocity += new Vector3(0f, 1f, 0f);
            }
        }
        
        // Resets the timer if the Jump button is pressed
        if (Input.GetKeyDown(KeyCode.Space) && timer <= 0.0f)
        {
            timer = 2.0f;
        }

        if (Input.GetKeyDown(KeyCode.Backspace) && isPlaying == true && !victory)
        {
            Reset();
        }
        
        thisRigidBody.velocity = inputVelocity * velocityModifier + (Physics.gravity * .69f); // Movement

        if (isPlaying && !loser)
        {
            UpdateText(); // Updates the Scoreboard
            checkVictory(); // Checks to see if Victory has been Achieved
        }
       
    }

    // The code to run when the Player object collides with other junk. Let's go.
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.name == "Blue Pill" && other.GetComponent<Pills>().isActive && currentNumberofPills < maxPills)
        {
            other.GetComponent<Pills>().isActive = false; // Deactivates the Pill 
            other.GetComponent<Pills>().deactivate();
            currentNumberofPills++; // Increments Pills
            currentNumber += 2; // Adjusts Score
            PillCombination = PillCombination + "Blue; ";
            reaction();
        }
        
        if (other.transform.name == "Yellow Pill" && other.GetComponent<Pills>().isActive && currentNumberofPills < maxPills)
        {
            other.GetComponent<Pills>().isActive = false;
            other.GetComponent<Pills>().deactivate();
            currentNumberofPills++; // Increments Pills
            currentNumber = currentNumber * 3; // Adjusts Score
            PillCombination = PillCombination + "Yellow; ";
            reaction();
        }
        
        if (other.transform.name == "Green Pill" && other.GetComponent<Pills>().isActive && currentNumberofPills < maxPills)
        {
            other.GetComponent<Pills>().isActive = false;
            other.GetComponent<Pills>().deactivate();
            currentNumberofPills++; // Increments Pills
            currentNumber = currentNumber / 2; // Adjusts Score
            PillCombination = PillCombination + "Green; ";
            reaction();
        }
        
        if (other.transform.name == "Red Pill" && other.GetComponent<Pills>().isActive && currentNumberofPills < maxPills)
        {
            other.GetComponent<Pills>().isActive = false;
            other.GetComponent<Pills>().deactivate();
            currentNumberofPills++; // Increments Pills
            currentNumber -= 3; // Adjusts Score
            PillCombination = PillCombination + "Red; ";
            reaction();
        }
        
        if (other.transform.name == "Pink Pill" && other.GetComponent<Pills>().isActive && currentNumberofPills < maxPills)
        {
            other.GetComponent<Pills>().isActive = false;
            other.GetComponent<Pills>().deactivate();
            currentNumberofPills++; // Increments Pills
            currentNumber = currentNumber * -2; // Adjusts Score
            PillCombination = PillCombination + "Pink; ";
            reaction();
        }
        
    }

    // Code for resetting the whole game board. This is accomplished by referencing the "Pills" in the Room gameobject.
    private void Reset()
    {
        currentNumberofPills = 0;
        currentNumber = 0;
        victory = false;
        Pills[] pillas = Pills.GetComponentsInChildren<Pills>();
        
        // Moves through the Array and Resets them
        for (int i = 0; i < pillas.Length; i++)
        {
            pillas[i].reset();
        }

        isPlaying = true;
        loser = false;
        IsTimingAttempt = true;
    }

    // Simple Code to Update the Scoreboard Text
    private void UpdateText()
    {
        totalpills.text = currentNumberofPills.ToString() + " / " + maxPills;
        number.text = currentNumber.ToString();
    }

    // Simple Code that Checks to see if a Victory has been Achieved
    private void checkVictory()
    {
        if ((target == currentNumber) && (maxPills == currentNumberofPills))
        {
            victory = true;
            IsTimingLevel = false;
            UpdateAnalytics();
        }

        if ((target != currentNumber) && (maxPills == currentNumberofPills))
        {
            audience.playClip(3);
            narrator.playClip(8);
            UpdateTimeAttempts();
            loser = true;
        }
    }

    // Code for setting the game rules for each area
    public void setRoom1()
    {
        number = number1;
        totalpills = totalpills1;
        Pills = Pills1;
        maxPills = 1;
        target = 2;
        
        currentRoom = 1;
        IsTimingLevel = true;
        Reset();
    }
    
    public void setRoom2()
    {
        number = number2;
        totalpills = totalpills2;
        Pills = Pills2;
        maxPills = 2;
        target = 1;
        
        currentRoom = 2;
        IsTimingLevel = true;
        Reset();
        game.lighting.ActivateAllLights();
     
    }
    
    public void setRoom3()
    {
        number = number3;
        totalpills = totalpills3;
        Pills = Pills3;
        maxPills = 3;
        target = 3;
        
        currentRoom = 3;
        IsTimingLevel = true;
        Reset();
    }
    
    public void setRoom4()
    {
        number = number4;
        totalpills = totalpills4;
        Pills = Pills4;
        maxPills = 4;
        target = 0;
        
        currentRoom = 4;
        IsTimingLevel = true;
        Reset();
    }
    
    public void setRoom5()
    {
        number = number5;
        totalpills = totalpills5;
        Pills = Pills5;
        maxPills = 4;
        target = 1;

        currentRoom = 5;
        IsTimingLevel = true;
        IsTimingAttempt = false;
        TimeForAttempt = 0;
        Reset();
    }

    public void reaction()
    {
        beep.Play();
        audience.RandomReaction();
        narrator.RandomReaction();
    }

    public void UpdateAnalytics()
    {
        UpdateTimeAttempts();
        
        if (currentRoom == 1)
        {
            /* Tinylytics.AnalyticsManager.LogCustomMetric("TimeSpentLevel1", TimeForLevel.ToString()); // Updates the metric for how long the entire level took
            Tinylytics.AnalyticsManager.LogCustomMetric("TimesOnEachAttemptLevel1", AllTimesForAttempt); // Updates the metric with the list of times
            Tinylytics.AnalyticsManager.LogCustomMetric("AttemptsLevel1", numberOfAttempts.ToString()); // Updates the metrics with the number of attempts
            Tinylytics.AnalyticsManager.LogCustomMetric("PillCombination1", AllPillCombination);*/

            GameObject.Find("Level 1: Time Spent").GetComponent<Tinylytics_MetricWidget>().OnCustomTrigger();
            GameObject.Find("Level 1: # of Attempts").GetComponent<Tinylytics_MetricWidget>().OnCustomTrigger();
            GameObject.Find("Level 1: Time per Attempt").GetComponent<Tinylytics_MetricWidget>().OnCustomTrigger();
            GameObject.Find("Level 1: Pill Combination Attempts").GetComponent<Tinylytics_MetricWidget>().OnCustomTrigger();
        }
        
        else if (currentRoom == 2)
        {
            Tinylytics.AnalyticsManager.LogCustomMetric("TimeSpentLevel2", TimeForLevel.ToString()); // Updates the metric for how long the entire level took
            Tinylytics.AnalyticsManager.LogCustomMetric("TimesOnEachAttemptLevel2", AllTimesForAttempt); 
            Tinylytics.AnalyticsManager.LogCustomMetric("AttemptsLevel2", numberOfAttempts.ToString());
            Tinylytics.AnalyticsManager.LogCustomMetric("PillCombination2", AllPillCombination);
            
            GameObject.Find("Level 2: Time Spent").GetComponent<Tinylytics_MetricWidget>().OnCustomTrigger();
            GameObject.Find("Level 2: # of Attempts").GetComponent<Tinylytics_MetricWidget>().OnCustomTrigger();
            GameObject.Find("Level 2: Time per Attempt").GetComponent<Tinylytics_MetricWidget>().OnCustomTrigger();
            GameObject.Find("Level 2: Pill Combination Attempts").GetComponent<Tinylytics_MetricWidget>().OnCustomTrigger();
        }
        
        else if (currentRoom == 3)
        {
            /* Tinylytics.AnalyticsManager.LogCustomMetric("TimeSpentLevel3", TimeForLevel.ToString()); // Updates the metric for how long the entire level took
            Tinylytics.AnalyticsManager.LogCustomMetric("TimesOnEachAttemptLevel3", AllTimesForAttempt);
            Tinylytics.AnalyticsManager.LogCustomMetric("AttemptsLevel3", numberOfAttempts.ToString());
            Tinylytics.AnalyticsManager.LogCustomMetric("PillCombination3", AllPillCombination); */
            
            GameObject.Find("Level 3: Time Spent").GetComponent<Tinylytics_MetricWidget>().OnCustomTrigger();
            GameObject.Find("Level 3: # of Attempts").GetComponent<Tinylytics_MetricWidget>().OnCustomTrigger();
            GameObject.Find("Level 3: Time per Attempt").GetComponent<Tinylytics_MetricWidget>().OnCustomTrigger();
            GameObject.Find("Level 3: Pill Combination Attempts").GetComponent<Tinylytics_MetricWidget>().OnCustomTrigger();
        }
        
        else if (currentRoom == 4)
        {
            /* Tinylytics.AnalyticsManager.LogCustomMetric("TimeSpentLevel4", TimeForLevel.ToString()); // Updates the metric for how long the entire level took
            Tinylytics.AnalyticsManager.LogCustomMetric("TimesOnEachAttemptLevel4", AllTimesForAttempt);
            Tinylytics.AnalyticsManager.LogCustomMetric("AttemptsLevel4", numberOfAttempts.ToString());
            Tinylytics.AnalyticsManager.LogCustomMetric("PillCombination4", AllPillCombination); */
            
            GameObject.Find("Level 4: Time Spent").GetComponent<Tinylytics_MetricWidget>().OnCustomTrigger();
            GameObject.Find("Level 4: # of Attempts").GetComponent<Tinylytics_MetricWidget>().OnCustomTrigger();
            GameObject.Find("Level 4: Time per Attempt").GetComponent<Tinylytics_MetricWidget>().OnCustomTrigger();
            GameObject.Find("Level 4: Pill Combination Attempts").GetComponent<Tinylytics_MetricWidget>().OnCustomTrigger();
        }
        
        else if (currentRoom == 5)
        {
            /* Tinylytics.AnalyticsManager.LogCustomMetric("TimeSpentLevel5", TimeForLevel.ToString()); // Updates the metric for how long the entire level took
            Tinylytics.AnalyticsManager.LogCustomMetric("TimesOnEachAttemptLevel5", AllTimesForAttempt);
            Tinylytics.AnalyticsManager.LogCustomMetric("AttemptsLevel5", numberOfAttempts.ToString());
            Tinylytics.AnalyticsManager.LogCustomMetric("PillCombination5", AllPillCombination); */
            
            GameObject.Find("Level 5: Time Spent").GetComponent<Tinylytics_MetricWidget>().OnCustomTrigger();
            GameObject.Find("Level 5: # of Attempts").GetComponent<Tinylytics_MetricWidget>().OnCustomTrigger();
            GameObject.Find("Level 5: Time per Attempt").GetComponent<Tinylytics_MetricWidget>().OnCustomTrigger();
            GameObject.Find("Level 5: Pill Combination Attempts").GetComponent<Tinylytics_MetricWidget>().OnCustomTrigger();
        }

        IsTimingLevel = false;
        TimeForLevel = 0;
        numberOfAttempts = 0;
        AllPillCombination = "";
        AllTimesForAttempt = "";
    }

    public void UpdateTimeAttempts()
    {
        AllTimesForAttempt = AllTimesForAttempt + TimeForAttempt + "; ";
        AllPillCombination = AllPillCombination + PillCombination + "\n";
        PillCombination = "";
        IsTimingAttempt = false;
        TimeForAttempt = 0;
        numberOfAttempts++;
    }
}
