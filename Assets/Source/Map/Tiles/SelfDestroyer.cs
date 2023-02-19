using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestroyer : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(DestroyIfOnSoil());
    }

    private IEnumerator DestroyIfOnSoil()
    {
        yield return new WaitForSecondsRealtime(0.01f);

        Collider[] colliders = Physics.OverlapBox(transform.position, new Vector3(0.1f, 1, 0.1f));

        foreach (var collider in colliders)
        {
            if (collider.TryGetComponent(out Soil tile))
            {
                Destroy(gameObject);
                break;
            }
        }
    }
}
