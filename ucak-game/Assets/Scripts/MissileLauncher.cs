// CENG 454 - HW2 Midterm: Sky-High Prototype II 
// Author: TUNAHAN TURGUT | Student ID: 210444025 
using UnityEngine; 
public class MissileLauncher : MonoBehaviour 
{ 
[SerializeField] private GameObject missilePrefab; 
[SerializeField] private Transform launchPoint; 
    [SerializeField] private AudioSource launchAudioSource; 
 
    private GameObject activeMissile; 
 
    public GameObject Launch(Transform target) 
    { 
        // TODO (Task 3-A): instantiate the missile at launchPoint 
        // TODO (Task 3-B): give the missile its target 
        // TODO (Task 3-C): play launch audio and return the spawned missile 
        return null; 
    } 
 
    public void DestroyActiveMissile() 
    { 
        // TODO (Task 3-D): destroy the current missile safely if one exists 
    } 
}