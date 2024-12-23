using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonActions : MonoBehaviour
{
    /*public GameObject settings;*/
    public GameObject AudioPlay, AudioMute;

    public GameObject Home, Course1, Course2, Course3, Video;

    public enum Page { Home, Course1, Course2, Course3, Video, }
    public enum Button { AudioPlay, AudioMute, }

    public void GoTo(Page pageEnum) {
        this.Home.SetActive(false);
        this.Video.SetActive(false);
        this.Course1.SetActive(false);
        this.Course2.SetActive(false);
        this.Course3.SetActive(false);

        switch (pageEnum)
        {
            case Page.Home:
               this.Home.SetActive(true); 
               break;
            case Page.Course1:
               this.Course1.SetActive(true); 
               break;
            case Page.Course2:
               this.Course2.SetActive(true); 
               break;
            case Page.Course3:
               this.Course3.SetActive(true); 
               break;
            case Page.Video:
               this.Video.SetActive(true); 
               break;
            default:
               break;
        }
    }

    public void AudioToggle() {
        bool tmpCond = (AudioPlay.activeSelf) ? false : true;
        AudioPlay.SetActive(tmpCond);
        AudioMute.SetActive(!tmpCond);
        if (tmpCond)
          BacksoundMaster.instance.SourceAudio.UnPause();
        else BacksoundMaster.instance.SourceAudio.Pause();
        BacksoundMaster.instance.audioPlayed = tmpCond;
    }
    // Start is called before the first frame update
    void Start()
    {
        /*settings.SetActive(false);*/
        this.ToHome();
        var audioPlayed = BacksoundMaster.instance.audioPlayed;
        AudioPlay.SetActive(audioPlayed);
        AudioMute.SetActive(!audioPlayed);
        BacksoundMaster.instance.audioPlayed = false;
    }

    public void Mute() {
        AudioPlay.SetActive(false);
        AudioMute.SetActive(true);
        BacksoundMaster.instance.SourceAudio.Pause();
    }
    
    public void UnMute() {
        AudioPlay.SetActive(true);
        AudioMute.SetActive(false);
        BacksoundMaster.instance.SourceAudio.UnPause();
        BacksoundMaster.instance.audioPlayed = true;
    }

    public void ToQuiz() {
        SceneManager.LoadScene("QuizFIX");
    }

    public void ToVideo() {
        this.GoTo(Page.Video);
        BacksoundMaster.instance.SourceAudio.Pause();
    }

    public void ToHome() {
        this.GoTo(Page.Home);
    }

    public void ToCourse1() {
        this.GoTo(Page.Course1);
    }

    public void ToCourse2() {
        this.GoTo(Page.Course2);
    }

    public void ToCourse3() {
        this.GoTo(Page.Course3);
    }

    void Update() {
        if (Input.GetKey(KeyCode.Escape)) {
            if (Video.activeSelf) {
                this.GoTo(Page.Course3);
                if (BacksoundMaster.instance.audioPlayed)
                    this.UnMute();
            }
        }
    }
}
