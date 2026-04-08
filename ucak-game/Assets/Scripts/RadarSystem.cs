using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement; 
using System.Collections;
public class RadarSystem : MonoBehaviour
{
    [SerializeField] private TMP_Text warningMyText;
    [SerializeField] private string enterMessage = "Entered dangerous zone!";
    [SerializeField] private string exitMessage = "";
    [SerializeField] private CanvasGroup canvas;
    [SerializeField] private Transform jet;
    [SerializeField] private GameObject tank;
 
    private bool isInside= false;
    private float timer = 0f;
    private GameObject ActiveMissile;

    private bool hasEnteredDangerZone = false;
    private bool hasExitedDangerZone = false;
    private bool missionFailed = false;
    private bool missionCompleted = false;
 
void Update()
{
    if (isInside)
    {
        timer += Time.deltaTime;
        if (timer > 5.0f) 
        {
            MissileLauncher launcher = tank.GetComponent<MissileLauncher>();
            if (launcher != null)
            {
                launcher.Launch(jet); 
            }
            isInside = false; 
            timer = 0f;
        }
    }
}
    void OnTriggerEnter(Collider other)
    {
        // Sadece Player etiketi olan objeler tetiklesin
        if (!other.CompareTag("Player"))
            return;
 
        if (warningMyText != null)
        {
            SetCanvasOpacity(1.0f);
            warningMyText.text = enterMessage;
            isInside = true;
            hasEnteredDangerZone = true;
        }
    }
 
 
    void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;
 
        if (warningMyText != null)
        {
            SetCanvasOpacity(0.0f);
            warningMyText.text = exitMessage;
            isInside = false;
	    timer = 0f;
	    if(ActiveMissile != null)
           {
              Destroy(ActiveMissile);
	      ActiveMissile = null;

             }
          if (!missionFailed)
            {
               hasExitedDangerZone = true;  
            }
        }
    }
    public void SetMissionFailed()
    {
        missionFailed = true;
    }

    private void SetCanvasOpacity(float alphaValue)
    {
        if (canvas != null)
        {
            canvas.alpha = alphaValue;
        }
    }
  public void getMissile(GameObject Missile){
    ActiveMissile = Missile;

}

public void StartRestartProcess()
    {
        StartCoroutine(WaitAndRestart());
    }

    private IEnumerator WaitAndRestart()
    {
        
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}