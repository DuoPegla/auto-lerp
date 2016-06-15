using UnityEngine;
using System.Collections;

public class LerpDemoPosition : MonoBehaviour {

    public Transform StartPosition;
    public Transform EndPosition;
    public float MoveTime = 5f;

    private AutoLerp.Vector3Lerp _lerp;

	// Use this for initialization
	void Start () {
        _lerp = new AutoLerp.Vector3Lerp(StartPosition.position, EndPosition.position, MoveTime);
        _lerp.Start();	
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = _lerp.GetValue();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_lerp.IsPaused())
                _lerp.Resume();
            else
                _lerp.Pause();
        }
	}
}
