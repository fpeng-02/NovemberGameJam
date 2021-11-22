using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    
    Dictionary<string, AudioSource> audioSources;
    // Start is called before the first frame update
    void Start()
    {
        audioSources = new Dictionary<string, AudioSource>();
        
        foreach(Transform child in transform){
            audioSources[child.GetComponent<AudioSource>().name] = child.GetComponent<AudioSource>();
            Debug.Log(child.GetComponent<AudioSource>().name);
        }

        

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playAudio(string audioName){
        audioSources[audioName].Play();
    }

    public void stopAudio(string audioName){
        audioSources[audioName].Stop();
    }
}
