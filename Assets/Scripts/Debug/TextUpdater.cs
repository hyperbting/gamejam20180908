using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextUpdater : MonoBehaviour, IInfoUpdater
{
    public Manager myManager;
    public Text CountDownText;

    public Button AddSecondBtn;
    public int btnShrinkFactor;
    public int btnEnlargeFactor;
    private RectTransform AddSecondBtnRectT;


    // Use this for initialization
    void Start () {
    btnShrinkFactor = 1;
    btnEnlargeFactor = 1;
    AddSecondBtnRectT  = AddSecondBtn.GetComponent<RectTransform>();

    }
	
	// Update is called once per frame
	void Update () {

    }


    public void UpdateCountDown(int kSeond)
    {
        CountDownText.text = (kSeond / 1000f).ToString();
    }

    public void ShrinkBtn()
    {

        Rect oldRect = AddSecondBtnRectT.rect;
        oldRect.width -= btnShrinkFactor;
        // TODO: make sure range constraint

        AddSecondBtnRectT.sizeDelta = new Vector2(oldRect.width, oldRect.height);
    }

    public void EnlargeBtn()
    {
        Rect oldRect = AddSecondBtnRectT.rect;
        oldRect.width += btnEnlargeFactor;
        // TODO: make sure range constraint

        AddSecondBtnRectT.sizeDelta = new Vector2(oldRect.width, oldRect.height);
    }
}

public interface IInfoUpdater{
    void UpdateCountDown(int kSeond);

}