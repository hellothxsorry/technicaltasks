using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationCollectable : MonoBehaviour
{
    Vector3 minScale;
    public Vector3 maxScale;
    public float speed = 2f;
    public float duration = 2f;

    IEnumerator Start()
    {
        minScale = transform.localScale;
        yield return LerpScale(minScale, maxScale, duration);
        yield return LerpScale(maxScale, minScale, duration);
        Destroy(this.gameObject);
    }

    public IEnumerator LerpScale(Vector3 a, Vector3 b, float time)
    {
        float i = 0.0f;
        float rate = (1.0f / time) * speed;

        while (i < 1.0f)
        {
            i += Time.deltaTime * rate;
            transform.localScale = Vector3.Lerp(a, b, i);
            yield return null;
        }
    }
}
