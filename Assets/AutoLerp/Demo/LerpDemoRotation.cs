using UnityEngine;
using System.Collections;

public class LerpDemoRotation : MonoBehaviour {

    public Vector3 StartRotation;
    public Vector3 EndRotation;
    public float MoveTime = 5f;

    private AutoLerp.QuaternionLerp _lerp;

    // Use this for initialization
    void Start()
    {
        _lerp = new AutoLerp.QuaternionLerp(Quaternion.Euler(StartRotation), Quaternion.Euler(EndRotation), MoveTime);
        _lerp.Start();
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = _lerp.GetValue();
    }
}
