using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextUpdater : MonoBehaviour, IInfoUpdater
{

    public Text CountDownText;

    public void UpdateCountDown(int kSeond) {
        CountDownText.text = (kSeond / 1000f).ToString();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

    }
}

public interface IInfoUpdater{
    void UpdateCountDown(int kSeond);
}