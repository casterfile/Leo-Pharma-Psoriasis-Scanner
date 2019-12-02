using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoverControl : MonoBehaviour {
	public GameObject Remover;
	private bool isShow = false;
	// Use this for initialization
	void Start () {
		isShow = false;
		Remover.SetActive (false);
	}
	
	// Update is called once per frame
	public void ShowWhenClick () {
		if(AppController.isGelOn == true){
			if(isShow == false){
				isShow = true;
				Remover.SetActive (true);
				AppController.CountCure++;
				print ("AppController.CountCure: "+AppController.CountCure);
			}
		}
	}

	void Update(){
		if (AppController.CountCure == 8) {
			Remover.SetActive (false);
		}
	}
}
