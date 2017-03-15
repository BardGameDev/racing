using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {
    public Text timerText;
    public Text winText;

	  private float startTime;
	  private bool finished = false;
    private bool started = true;

    // Use this for initialization
    void Start(){
        startTime = Time.time;
        winText.text = "";
    }
    // Update is called once per frame
    void Update(){
				if(finished){
						return;}
        if (started){
            if (Input.anyKey){
                started = false;
            }
            return;
        }
				float t = Time.time - startTime;
				string minutes = ((int) t/60).ToString();
				string seconds = (t%60).ToString("f2");

				timerText.text = minutes + ":" + seconds;
  		}
		public void Finish(){
        finished = true;
				winText.text = "Finished!";
		}
}
