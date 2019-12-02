using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AppController : MonoBehaviour {
	private GameObject FinishScene,ScarDetected,ScanningAnim,Start_Button,Scanning_Button,Gel_On,Scar1,Scar2,Scar3,Psoriasis_Text,TimerGO;
	public static bool isGelOn = false;
	public static int CountCure = 0;
	float timeLeft = 0.0f;
	public Text Timer;
	// Use this for initialization
	void Start () {
		isGelOn = false;
		CountCure = 0;
		timeLeft = 0.0f;



		Psoriasis_Text =GameObject.Find ("Psoriasis_Text"); 
		Psoriasis_Text.SetActive (true);
		TimerGO =GameObject.Find ("Timer"); 
		TimerGO.SetActive (false);

		Gel_On = GameObject.Find ("Gel_On");
		Scar1 = GameObject.Find ("Scar1");
		Scar2 = GameObject.Find ("Scar2");
		Scar3 = GameObject.Find ("Scar3");
		Scar1.SetActive (true);
		Scar2.SetActive (false);
		Scar3.SetActive (false);

		FinishScene = GameObject.Find ("FinishScene");
		FinishScene.SetActive (false);

		ScarDetected = GameObject.Find ("ScarDetected");
		ScarDetected.SetActive (false);

		ScanningAnim = GameObject.Find ("ScanningAnim");
		Start_Button = GameObject.Find ("Start_Button");
		Scanning_Button = GameObject.Find ("Scanning_Button");
		Scanning_Button.SetActive (false);
		ScanningAnim.SetActive (false);
	}


	
	// Update is called once per frame
	void Update () {
		if(CountCure == 8){
			Psoriasis_Text.SetActive (false);
			TimerGO.SetActive (true);

			timeLeft += Time.deltaTime;
			int timeTemp = Mathf.RoundToInt (timeLeft);
//			if(timeTemp >= 10)
//			{
//				Timer.text = "" + timeTemp;
//			}else if(timeTemp < 10 && timeTemp >= 0){
//				
//			}
			Timer.text = "Day " + timeTemp;

			if(timeTemp == 2){
				Scar1.SetActive (false);
				Scar2.SetActive (true);
				Scar3.SetActive (false);
			}
			if(timeTemp == 4){
				Scar1.SetActive (false);
				Scar2.SetActive (false);
				Scar3.SetActive (true);
			}
			if(timeTemp == 6){
				Scar1.SetActive (false);
				Scar2.SetActive (false);
				Scar3.SetActive (false);
			}

			if(timeTemp == 7){
				//Timer.text = "00:0" + timeTemp;
				FinishScene.SetActive (true);
				ScarDetected.SetActive (false);
			}
		}
	}

	public void FuncButton(string FuncName){
		if(FuncName == "ScanningStart"){ScanningStart();}//{StartCoroutine(ScanningStart(3));}
		if(FuncName == "FuncGelOff"){FuncGelOff();}

		if(FuncName == "Restart"){Restart();}
		if(FuncName == "ShowScar"){FuncShowScar();}
	}

	void ScanningStart()
	{
		Scanning_Button.SetActive (true);
		Start_Button.SetActive (false);
		ScanningAnim.SetActive (true);
	}

	void FuncGelOff(){
		Gel_On.SetActive (true);
		isGelOn = true;
	}

	public void Restart(){
		Application.LoadLevel("Scene_01");
	}

	public void FuncShowScar(){
		ScarDetected.SetActive (true);
		Scanning_Button.SetActive (false);
		Start_Button.SetActive (false);
		ScanningAnim.SetActive (false);
		Gel_On.SetActive (false);
	}
}
