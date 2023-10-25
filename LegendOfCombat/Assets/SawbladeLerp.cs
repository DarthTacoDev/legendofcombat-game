using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawbladeLerp : MonoBehaviour
{
    public Transform startPos, endPos;
    public bool repeatable = false;
    public float speed = 1.0f;  
    public float duration = 3.0f;  
    float startTime, totalDistance;
 
    IEnumerator Start()
    {
        startTime = Time.time;
        totalDistance = Vector3.Distance(startPos.position, endPos.position);

        while (repeatable)
        {
            yield
            return RepeatLerp(startPos.position, endPos.position, duration);
            yield
            return RepeatLerp(endPos.position, startPos.position, duration);
        }
    }

    void Update()
    {
        if (!repeatable)
        {
            float currentDuration = (Time.time - startTime) * speed;
            float journeyFraction = currentDuration / totalDistance;
            this.transform.position = Vector3.Lerp(startPos.position, endPos.position, Mathf.SmoothStep(0, 1, journeyFraction));
        }
    }
    public IEnumerator RepeatLerp(Vector3 a, Vector3 b, float time)
    {
        float i = 0.0f;
        float rate = (1.0f / time) * speed;
        while (i < 1.0f) {
            i += Time.deltaTime * rate;
            this.transform.position = Vector3.Lerp(a, b, Mathf.SmoothStep(0, 1, i));
            yield
            return null;
        }
    }

}
