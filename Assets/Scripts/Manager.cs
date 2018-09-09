using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Manager : MonoBehaviour {

    public Countdowner myCountdowner;

    public Coroutine OnlyOneCountdown;

    // Use this for initialization
    void Start () {
        controllTarget = GetComponent<CylinderPosition>();

        myTextUpdater.AddSecondBtn.onClick.AddListener (delegate {
            AddMillisecond();
            myTextUpdater.ShrinkBtn();

            if (OnlyOneCountdown != null)
                StopCoroutine(OnlyOneCountdown);
            OnlyOneCountdown = StartCoroutine(WaitUnpress());

        });

        //myTextUpdater.AddSecondBtn.OnPointerExit().ad
    }

    private void Update()
    {
        if(OnlyOneCountdown == null)
            UserInputUpdate();
    }

    IEnumerator WaitUnpress()
    {
        yield return new WaitForSeconds(1f);
        OnlyOneCountdown = null;
    }

    public void AddMillisecond(int _msec = 1000)
    {
        myCountdowner.AddTime(_msec);
    }
}
