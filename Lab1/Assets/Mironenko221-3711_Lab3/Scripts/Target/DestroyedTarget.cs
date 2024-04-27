using System.Collections;
using UnityEngine;

public class CrashingTarget : MonoBehaviour
{
    [SerializeField] private GameObject _impulseSphere;

    private IEnumerator Start()
    {
        transform.rotation = Quaternion.Euler(Random.Range(0, 360), transform.eulerAngles.y, transform.eulerAngles.z);

        yield return new WaitForSeconds(0.5f);

        _impulseSphere.SetActive(false);
    }
}
