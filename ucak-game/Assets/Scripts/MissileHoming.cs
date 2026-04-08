using UnityEngine; 
using TMPro;
public class MissileHoming : MonoBehaviour 
{ 
    [SerializeField] private float moveSpeed = 20f; 
    [SerializeField] private float turnSpeed = 5f; 
    private Transform target; 
    private RadarSystem radar;
    private AudioSource failedsound;
    public TMP_Text mission_failed;

     void Start()
    {
        
        failedsound = GetComponent<AudioSource>();
    }

    public void SetTarget(Transform newTarget) 
    { 
        target = newTarget;
    } 

    public void SetRadarReference(RadarSystem radarRef) {
    radar = radarRef;
    } 
 
    void Update() 
    { 
        // TODO (Task 3-F): rotate toward the target and move forward 
	if (target == null) 
        {
        return; 
        }
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

 void OnTriggerEnter(Collider other)
 {
   if(!other.CompareTag("Player")) 
   {
     return;
    }
  
   SetTextOpacity(1.0f);
   mission_failed.text = "                         Mission Failed!";
   if (radar != null)
    {   
        failedsound.Play();
        radar.SetMissionFailed();
        radar.StartRestartProcess(); 
    }

   Destroy(gameObject);

 }



public void SetTextReference(TMP_Text targetText) {
    mission_failed = targetText;
}


private void SetTextOpacity(float opacity)
{
    if (mission_failed != null)
    {
        Color c = mission_failed.color;
        c.a = opacity; 
        mission_failed.color = c;
    }
}

} 