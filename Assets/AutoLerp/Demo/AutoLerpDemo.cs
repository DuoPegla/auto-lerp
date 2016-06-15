using UnityEngine;
using System.Collections;

public class AutoLerpDemo : MonoBehaviour {

    public float time = 5f;

    public float FloatStartValue;
    public float FloatEndValue;
    public float FloatCurrentValue;

    public Vector2 Vector2StartValue;
    public Vector2 Vector2EndValue;
    public Vector2 Vector2CurrentValue;

    public Vector3 Vector3StartValue;
    public Vector3 Vector3EndValue;
    public Vector3 Vector3CurrentValue;

    public Quaternion QuaternionStartValue;
    public Quaternion QuaternionEndValue;
    public Quaternion QuaternionCurrentValue;

    public Color ColorStartValue;
    public Color ColorEndValue;
    public Color ColorCurrentValue;

    public Color32 Color32StartValue;
    public Color32 Color32EndValue;
    public Color32 Color32CurrentValue;


    private AutoLerp.FloatLerp _floatLerp;
    private AutoLerp.Vector2Lerp _vector2Lerp;
    private AutoLerp.Vector3Lerp _vector3Lerp;
    private AutoLerp.QuaternionLerp _quaternionLerp;
    private AutoLerp.ColorLerp _colorLerp;
    private AutoLerp.Color32Lerp _color32Lerp;

    // Use this for initialization
    void Start () {
        _floatLerp = new AutoLerp.FloatLerp(FloatStartValue, FloatEndValue, time);
        _floatLerp.Start();

        _vector2Lerp = new AutoLerp.Vector2Lerp(Vector2StartValue, Vector2EndValue, time);
        _vector2Lerp.Start();

        _vector3Lerp = new AutoLerp.Vector3Lerp(Vector3StartValue, Vector3EndValue, time);
        _vector3Lerp.Start();

        _quaternionLerp = new AutoLerp.QuaternionLerp(QuaternionStartValue, QuaternionEndValue, time);
        _quaternionLerp.Start();

        _colorLerp = new AutoLerp.ColorLerp(ColorStartValue, ColorEndValue, time);
        _colorLerp.Start();

        _color32Lerp = new AutoLerp.Color32Lerp(Color32StartValue, Color32EndValue, time);
        _color32Lerp.Start();
    }
	
	// Update is called once per frame
	void Update () {
        FloatCurrentValue = _floatLerp.GetValue();
        Vector2CurrentValue = _vector2Lerp.GetValue();
        Vector3CurrentValue = _vector3Lerp.GetValue();
        QuaternionCurrentValue = _quaternionLerp.GetValue();
        ColorCurrentValue = _colorLerp.GetValue();
        Color32CurrentValue = _color32Lerp.GetValue();
    }
}
