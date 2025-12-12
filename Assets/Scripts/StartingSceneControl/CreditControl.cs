using UnityEngine;
using UnityEngine.EventSystems;


public class CreditControl : MonoBehaviour
{
    public Transform Credit;


    public void CallOutCredit()
    {
        Transform theTip = Instantiate(Credit);

        theTip.SetParent(GameObject.FindGameObjectWithTag("MainCanvas").transform, false);

        theTip.position   = EventSystem.current.currentSelectedGameObject.transform.position;
        theTip.localScale = Vector3.zero;

    }   // CallOutCredit()


}   // class CreditControl
