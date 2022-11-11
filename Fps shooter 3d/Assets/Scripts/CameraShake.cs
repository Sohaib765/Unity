 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    private Animator cameraAnim;

    private void Start()
    {
        cameraAnim = GetComponent<Animator>();
    }

    public void AnimationTrigger()
    {
        cameraAnim.SetTrigger("CameraShake");
    }
    /*public float duration = 0.3f;
    //public bool startShake;
    public AnimationCurve curve;

    public void ShakeCaller(bool startShake)
    {
        if (startShake)
        {
            startShake = false;
            StartCoroutine(Shake());
        }
    }

    public IEnumerator Shake()
    {
        float random = Random.Range(-0.4f, 0.4f);

        Vector3 startPoition = transform.localPosition;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float strength = curve.Evaluate(elapsedTime / duration);
            transform.position = startPoition + Random.insideUnitSphere * random;
            yield return null;
        }

        transform.position = startPoition;
    }*/

}
