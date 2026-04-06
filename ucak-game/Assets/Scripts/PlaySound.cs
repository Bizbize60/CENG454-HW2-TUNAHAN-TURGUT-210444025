using UnityEngine;
 
public class PlaySound : MonoBehaviour
{
    AudioSource source;
 
    void Awake()
    {
        source = GetComponent<AudioSource>();
        source.playOnAwake = false;
    }
 

}
