using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecievedItem : Singleton<RecievedItem>
{
    private void Update()
    {
        PlayerController.Instance.RaiseItem();
    }

    public void SetActive()
    {
        gameObject.SetActive(true);
    }

    public void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
