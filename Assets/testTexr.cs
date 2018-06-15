using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class testTexr : MonoBehaviour {
	
	int i =0;
	public Text Txt;
	String [] data = new string[100];
	List<String> words = new List<string>();

	void Start(){
		Debug.Log ("Start ");
		data = new string[100];
		//Txt.txt = " "
	
		data = Txt.text.ToString ().Split (' ');
		Debug.Log (data.Length);
//		Debug.Log (data[44]);
		foreach(string s in data){


			words.Add (s);
			if(s=="Bahamadia,"){


			}
			Debug.Log (words[i]);
			i++;

		}
	


	
	}

	void OnGUI(){

		if (GUI.Button (new Rect (100f, 50f, 150f, 50f), "Bahamdia")) {
			Debug.Log ("bUTTON clicked");

		}	


	}


}
