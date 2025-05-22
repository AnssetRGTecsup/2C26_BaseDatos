using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PhysicsGeneralController : MonoBehaviour
{
    public static PhysicsGeneralController instance { get; private set; }

    [SerializeField] private Button pauseBtn;
    [SerializeField] private Button playBtn;
    [SerializeField] private Button exitBtn;

    public UnityAction onPause;
    public UnityAction onPlay;

    private void Awake() {
        if(instance != null && instance != this){
            Destroy(this);
        }

        instance = this;
    }

    private void Start() {
        pauseBtn.onClick.AddListener(() => PauseFunction());
        playBtn.onClick.AddListener(() => PlayFunction());
        exitBtn.onClick.AddListener(() => ExitFunction());
    }

    //d = v0 t + (a t^2 /2)
    public float CalculateDistance(float initVelocity, float time, float acceleration){
        float distance = initVelocity * time + (Mathf.Pow(time,2) * acceleration)/2;
        return distance;
    }

    //vf = v0 + a*t
    public float CalculateFinalVelocity(float initVelocity, float time, float acceleration){
        float finalVelocity = initVelocity + acceleration * time;
        return finalVelocity;
    }

    public void PauseFunction(){
        onPause?.Invoke();
    }

    public void PlayFunction(){
        onPlay?.Invoke();
    }

    public void ExitFunction(){
        pauseBtn.onClick.RemoveListener(() => PauseFunction());
        playBtn.onClick.RemoveListener(() => PlayFunction());
        exitBtn.onClick.RemoveListener(() => ExitFunction());
        
        Application.Quit();
    }
}
