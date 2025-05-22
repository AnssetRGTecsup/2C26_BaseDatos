using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BallController : MonoBehaviour
{
    [Header("UI Components")]
    [SerializeField] private TMP_InputField initVelocityInput;
    [SerializeField] private TMP_InputField timeInput;
    [SerializeField] private TMP_InputField accelerationInput;
    [SerializeField] private TMP_Text distanceTxt;

    [Header("Physics Components")]
    [SerializeField] private Rigidbody2D myRGB2D;
    [SerializeField] private Transform initPosition;

    private float initVelocity;
    private float time;
    private float acceleration;

    private float timeCycle = 0;
    private bool canMove;

    private void Start() {
        this.transform.position = initPosition.position;

        PhysicsGeneralController.instance.onPause += Reset;
        PhysicsGeneralController.instance.onPlay += CalculateValues;
    }
        

    private void OnDisable() {
        PhysicsGeneralController.instance.onPause -= Reset;
        PhysicsGeneralController.instance.onPlay -= CalculateValues;
    }

    private void FixedUpdate() {
        if(!canMove) return;
        myRGB2D.linearVelocity = new Vector2(PhysicsGeneralController.instance.CalculateFinalVelocity(initVelocity, timeCycle, acceleration), 0f);

        timeCycle++;

        if(timeCycle > 100){
            SimpleRest();
        }
    }

    private void CalculateValues(){
        initVelocity = float.Parse(initVelocityInput.text);
        time = float.Parse(timeInput.text);
        acceleration = float.Parse(accelerationInput.text);

        float distance = PhysicsGeneralController.instance.CalculateDistance(initVelocity, time, acceleration);
        distanceTxt.text = distance.ToString("f2");

        Reset();

        canMove = true;
    }

    private void Reset(){
        SimpleRest();
        
        canMove = false;

        timeCycle = 0;
    }

    private void SimpleRest(){
        timeCycle = 0;
        this.transform.position = initPosition.position;
        myRGB2D.linearVelocity = Vector2.zero;
    }
}
