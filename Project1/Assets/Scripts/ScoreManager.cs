using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreManager : MonoBehaviour {

    public Text ScoreText;
    public Player p;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        p.score += Time.deltaTime;
        ScoreText.text ="Score:"+p.score.ToString("F0");
	}
}
