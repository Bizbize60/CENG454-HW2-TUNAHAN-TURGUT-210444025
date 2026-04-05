using UnityEngine; 
 
public class MissileHoming : MonoBehaviour 
{ 
    [SerializeField] private float moveSpeed = 20f; 
    [SerializeField] private float turnSpeed = 5f; 
 
    private Transform target; 
 
    public void SetTarget(Transform newTarget) 
    { 
        target = newTarget;
    } 
 
    void Update() 
    { 
        // TODO (Task 3-F): rotate toward the target and move forward 
	moveToJet();

    } 

    void moveToJet()
    {
     transform.position =  Vector3.MoveTowards(transform.position, target.position, Time.deltaTime * moveSpeed)
    }
} 