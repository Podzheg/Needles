using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedleEndCol : MonoBehaviour
{
    private NeedleMovement needle;
    void Awake()
    {
        needle = GetComponentInParent<NeedleMovement>();
    }
    private void OnTriggerEnter2D(Collider2D target)
    {
        if (needle.touchedTheCircle)
            return;

        if (target.tag == "Circle" || target.tag == "NeedleEnd") {
            needle.GotToCircle();
        } else if (target.tag == "NeedleHead") {
            needle.GotToLoosePoint();
        }
    }
}
