using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BacksoundMaster : MonoBehaviour
{
    public static BacksoundMaster instance;
    public bool audioPlayed { get; set; } = true;

    public AudioSource SourceAudio;

    public void OnEnable() {
      if (instance == null) {
        instance = this;
        DontDestroyOnLoad(this.gameObject); 
      } else {
        Destroy(gameObject);
      }
    }
}






















