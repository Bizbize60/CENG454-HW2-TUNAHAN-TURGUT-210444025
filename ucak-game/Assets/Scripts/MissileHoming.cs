using UnityEngine; 
 
public class MissileHoming : MonoBehaviour 
{ 
    [SerializeField] private float moveSpeed = 20f; 
    [SerializeField] private float turnSpeed = 5f; 
 
    private Transform target; 
 
    public void SetTarget(Transform newTarget) 
    { 
        // TODO (Task 3-E): cache the aircraft transform 
    } 
 
    void Update() 
    { 
        // TODO (Task 3-F): rotate toward the target and move forward 
    } 
} 