using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    public static ScreenShake instance;
    [SerializeField]
    private float duration = 0.5f;
    [SerializeField]
    public bool start = false;
    [SerializeField]
    private AnimationCurve curve;
    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (start)
        {
            start = false;
            StartCoroutine(ShakeScreen());
        }
    }

    IEnumerator ShakeScreen()
    {
        Vector3 startPosition = transform.position;
        float timePassed = 0f;
        while (timePassed < duration)
        {
            timePassed += Time.deltaTime;
            float strength = curve.Evaluate(timePassed / duration);
            transform.position = startPosition + Random.insideUnitSphere * strength;
            yield return null;
        }
        transform.position = startPosition;
    }
}
