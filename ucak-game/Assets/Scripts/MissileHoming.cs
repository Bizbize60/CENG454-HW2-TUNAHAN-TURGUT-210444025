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
	rotateToJet();
    } 

    void moveToJet()
    {
     transform.position =  Vector3.MoveTowards(transform.position, target.position, Time.deltaTime * moveSpeed);
    }

   void rotateToJet()  //StackOverFlow fix usage for rotation 
   {
     
     Vector3 direction = target.position - transform.position;
     if (direction != Vector3.zero) {
     Quaternion rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * turnSpeed);
     transform.rotation = rotation;
     }
   }
} 