using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class TpwSlider : NetworkBehaviour {


	Text sliderText;
	CustomMultiplayerSettings cms;
	Slider slider;


	void Start(){
		Debug.Log ("Start Called");
		cms = FindObjectOfType<CustomMultiplayerSettings> ();
		sliderText = GetComponentInChildren<Text> ();
		slider = GetComponent<Slider> ();
		sliderText.text = slider.value.ToString ();
	}

	public void SliderOnChange(){
		Debug.Log ("SliderOnChange Called");
		int currentValue = Mathf.FloorToInt (slider.value);
		sliderText.text = currentValue.ToString ();
		CmdSetPtwValue (currentValue);
	}

	[Command]
	void CmdSetPtwValue(int value){
		Debug.Log ("CmdSetPtwValue Called");
		cms.Points2Win = value;
		RpcSynctheSlider (value);
	}

	[ClientRpc]
	void RpcSynctheSlider(int value){
		Debug.Log ("RpcSynctheSlider Called");
		sliderText.text = value.ToString ();
		slider.value = value;
	}

}
