using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Speedtext : MonoBehaviour {

    public Player p;
    public Animator anim;
    public Text SpeedText;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(p.SpeedIncreaseText==true)
        {
            SpeedText.enabled=(true);
            anim.SetTrigger("TextAnim");
        }
	}
    public void DisableText()
    {
        p.SpeedIncreaseText = false;
        SpeedText.enabled=false;
    }
}
