/// Credit playemgames 
/// Sourced from - http://forum.unity3d.com/threads/sprite-icons-with-text-e-g-emoticons.265927/

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI.Extensions;
using System.Collections.Generic;

public class HrefManager : MonoBehaviour
{
	//public GameObject cardUp;

	public List<HyperLinkDetails> hyperLinkDetails = new List<HyperLinkDetails> ();

	void Start ()
	{
//		Debug.Log ("I am in the start method");
		gameObject.GetComponent<TextPic> ().onHrefClick.AddListener (OnHrefClick);
		//Application.OpenURL ("unity3d.com");

	}

	void OnDisable ()
	{
		gameObject.GetComponent<TextPic> ().onHrefClick.RemoveListener (OnHrefClick);
	}

	private void OnHrefClick (string hrefName)
	{
//        Debug.Log("Click on the " + hrefName);
		if (hrefName == "Bahamadia") {
			//cardUp.GetComponent<Button> ().enabled = true;
			//	Application.OpenURL("https://www.youtube.com/watch?v=JIxNPJqKGS4");
			//	Debug.Log ("Clicked on bahamadia");
			//	Debug.Log ("Application.OpenURL (\"unity3d.com/learn\");\t");
			//Application.OpenURL ("http://unity3d.com/learn");
		    
		}

		switch (hrefName) {
		case"Bahamadia": 
			Application.OpenURL ("https://www.youtube.com/watch?v=JIxNPJqKGS4");
			break;
		case"Rapsody": 
			Application.OpenURL ("https://www.youtube.com/watch?v=kR2TQoTKxxA");
			break;
		case"Jean": 
			Application.OpenURL ("https://www.youtube.com/watch?v=jFz6ECvaiqQ");
			break;
		case"Tupac": 
			Debug.Log ("Tupac Hit");
			Application.OpenURL ("https://www.youtube.com/watch?v=RLtE4ll9h3c");

			break;
		case"shot": 
			Application.OpenURL ("https://www.youtube.com/watch?v=vf8OlkOV4CQ");
			break;
		case"college": 
			Application.OpenURL ("https://www.youtube.com/watch?v=d2fmBdJkl5k");
			break;
		case"Still": 
			Application.OpenURL ("https://www.youtube.com/watch?v=9PfXvi-thwk");
			break;
		case"Cleaning": 
			Application.OpenURL ("https://www.youtube.com/watch?v=RQ9_TKayu9s");
			break;

		case"Stan": 
			Application.OpenURL ("https://www.youtube.com/watch?v=WU9DzMhdeEo&spfreload=10");
			break;
		case"One": 
			Application.OpenURL ("https://www.youtube.com/watch?v=hxce_qvhi5I");
			break;
		
		case"Fallen": 
			Application.OpenURL ("https://www.youtube.com/watch?v=S8gD-jFZDg0");
			break;
		
		case"Love": 
			Application.OpenURL ("https://www.youtube.com/watch?v=4pzTT17uKo8");
			break;
		case"Will": 
			Application.OpenURL ("https://www.youtube.com/watch?v=jW3PFC86UNI");
			break;
		case"Ruled": 
			Application.OpenURL ("https://www.youtube.com/watch?v=NW55FRXlPEs");
			break;

		case"Feel": 
			Application.OpenURL ("https://www.youtube.com/watch?v=MYwndYSA6-U");
			break;
		case"Krs": 
			Application.OpenURL ("https://www.youtube.com/watch?v=h1vKOchATXs&spfreload=10");
			break;

		case"Outta": 
			Application.OpenURL ("https://www.youtube.com/watch?v=TMZi25Pq3T8");
			break;
		case"Kool": 
			Application.OpenURL ("https://www.youtube.com/watch?v=kFvbSU1eCt0");
			break;

		case"Great": 
			Application.OpenURL ("");
			break;
		case"Remedy": 
			Application.OpenURL ("https://www.youtube.com/watch?v=qGN9QHVzR7M");
			break;
		case"Unity": 
			Application.OpenURL ("https://www.youtube.com/watch?v=f8cHxydDb7o");
			break;
		case"Happiness": 
			Application.OpenURL ("https://www.youtube.com/watch?v=pSNyC3pdxJk\t");
			break;
		case"Gratitude": 
			Application.OpenURL ("https://www.youtube.com/watch?v=5uV6ONGe0qM");
			break;
		case"Be": 
			Application.OpenURL ("https://www.youtube.com/watch?v=BvGbmEuV_lA");
			break;
		case"Missing": 
			Application.OpenURL ("https://www.youtube.com/watch?v=mM0-ZU8njdo");
			break;
		case"Life": 
			Application.OpenURL ("https://www.youtube.com/watch?v=W69SSLfRJho");
			break;
		case"Daddy": 
			Application.OpenURL ("https://www.youtube.com/watch?v=VNankr0tZHk");
			break;
		case"Dance": 
			Application.OpenURL ("https://www.youtube.com/watch?v=LOODXc8BdS4");
			break;

		case"Gang": 
			Application.OpenURL ("https://www.youtube.com/watch?v=bFmiKodg1tc");
			break;
		case"Destruction": 
			Application.OpenURL ("https://www.youtube.com/watch?v=jxyYP_bS_6s");
			break;
		case"Cream": 
			Application.OpenURL ("https://www.youtube.com/watch?v=PBwAxmrE194");
			break;
		case"Bible": 
			Application.OpenURL ("https://www.youtube.com/watch?v=Fel0z3FbKBc");
			break;
		case"Kick": 
			Application.OpenURL ("https://www.youtube.com/watch?v=Gl83mI69nX4");
			break;

		case"Chuck": 
			Application.OpenURL ("https://www.youtube.com/watch?v=2WHe5fxS3dA");
			break;
		case"krsOne": 
			Application.OpenURL ("https://www.youtube.com/watch?v=5sQVSfM-AjA");
			break;
		case"Capital": 
			Application.OpenURL ("https://www.youtube.com/watch?v=ZG5yWFEk2Bs");
			break;
		
		case"": 
			Application.OpenURL ("");
			break;
		}
		for (int i = 0; i < hyperLinkDetails.Count; i++) {
			if (hyperLinkDetails [i].hyperlinkName == hrefName) {

				//	UiManager.Instance.hrefDetailRect.SetActive (true);
				//	UiManager.Instance.closeButton.SetActive(true);
				//	UiManager.Instance.hrefDetailText.text = hyperLinkDetails [i].hyperlinkDescription;
				break;
			}
		}
	}
}

[System.Serializable]
public class HyperLinkDetails
{
	public string hyperlinkName;
	public string hyperlinkDescription;
}
