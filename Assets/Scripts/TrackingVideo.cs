using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class TrackingVideo : MonoBehaviour
{
    public VideoPlayer video;
    public GameObject VideoPlay, VideoMute;

    Slider tracker;

    bool on_drag = false;

    // Start is called before the first frame update
    void Start()
    {
        tracker = GetComponent<Slider>();
        VideoPlay.SetActive(true);
        VideoMute.SetActive(false);
        video.Stop();
        video.Play();
    }

    public void VideoToggle() {
        bool tmpCond = (VideoPlay.activeSelf) ? false : true;
        VideoPlay.SetActive(tmpCond);
        VideoMute.SetActive(!tmpCond);
        if (tmpCond)
          video.Play();
        else
          video.Pause();
    }

    public void OnDrag() {
      on_drag = true;
    }

    public void OnUp() {
      on_drag = false;
      float frame = (float)tracker.value * (float)video.frameCount;
      video.frame = (long)frame;
    }

    // Update is called once per frame
    void Update()
    {
       if (video.isPlaying && !on_drag) {
         tracker.value = (float) video.frame / (float)video.frameCount;
       } 
    }
}
