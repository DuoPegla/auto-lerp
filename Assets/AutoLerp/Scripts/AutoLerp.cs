using UnityEngine;
using System.Collections;
using System;

namespace AutoLerp
{
    public abstract class TimedLerp<T>
    {
        protected enum AutoLerpState
        {
            Ready, Lerping, Paused, Done
        }

        protected T _startValue;
        protected T _endValue;
        protected float _lerpTime;

        protected float _lerpTimer;
        protected T _lerpValue;
        protected AutoLerpState _lerpState;

        protected float _deltaTime;
        protected float _lastUpdateTime;

        /// <summary>
        /// Creates instance of TimedLerp class
        /// </summary>
        /// <param name="startValue">Start value for lerp</param>
        /// <param name="endValue">End value for lerp</param>
        /// <param name="time">Time in seconds to lerp from startValue to endValue</param>
        public TimedLerp(T startValue, T endValue, float time)
        {
            _startValue = startValue;
            _endValue = endValue;
            _lerpTime = time;

            _lerpTimer = 0f;
            _lerpValue = startValue;
            _lerpState = AutoLerpState.Ready;
            _lastUpdateTime = 0f;
        }

        /// <summary>
        /// Starts lerping. Resets values to start.
        /// </summary>
        public void Start()
        {
            _lerpTimer = 0f;
            _lerpValue = _startValue;
            _lerpState = AutoLerpState.Lerping;
        }

        /// <summary>
        /// Pauses lerp if lerping. Use Resume() to continue
        /// </summary>
        public void Pause()
        {
            if (_lerpState == AutoLerpState.Lerping)
                _lerpState = AutoLerpState.Paused;

        }

        /// <summary>
        /// Resumes paused lerp.
        /// </summary>
        public void Resume()
        {
            if (_lerpState == AutoLerpState.Paused)
            {
                _lerpState = AutoLerpState.Lerping;
                _lastUpdateTime = Time.time;
            }
        }

        /// <summary>
        /// Updates internal lerp time and value
        /// </summary>
        /// <returns>Lerped value based on time</returns>
        public T GetValue()
        {
            if (_lerpState != AutoLerpState.Lerping)
                return _lerpValue;

            UpdateDeltaTime();

            _lerpTimer += _deltaTime;
            if (_lerpTimer >= _lerpTime)
            {
                _lerpState = AutoLerpState.Done;
                _lerpValue = _endValue;
                return _lerpValue;
            }

            _lerpValue = Lerp();
            return _lerpValue;
        }

        /// <summary>
        /// Checks if AutoLerp is done lerping
        /// </summary>
        /// <returns>True if done lerping, False otherwise</returns>
        public bool IsDone()
        {
            return _lerpState == AutoLerpState.Done;
        }

        /// <summary>
        /// Checks if AutoLerp is paused
        /// </summary>
        /// <returns>True if lerping is paused, False otherwise</returns>
        public bool IsPaused()
        {
            return _lerpState == AutoLerpState.Paused;
        }

        public float GetProgress()
        {
            return _lerpTimer / _lerpTime;
        }

        /// <summary>
        /// Implements neccessary lerp method for each type
        /// Should return lerped value between _startValue and _endValue based
        /// on ratio between _lerpTimer and _lerpTime
        /// </summary>
        /// <returns>Lerped value based on time</returns>
        protected abstract T Lerp();

        /// <summary>
        /// Updates delta time from last call of the GetValue method
        /// </summary>
        private void UpdateDeltaTime()
        {
            _deltaTime = Time.time - _lastUpdateTime;
            _lastUpdateTime = Time.time;
        }
    }

    public class FloatLerp : TimedLerp<float>
    {
        public FloatLerp(float startValue, float endValue, float time) : base(startValue, endValue, time)
        { }

        protected override float Lerp()
        {
            return Mathf.Lerp(_startValue, _endValue, _lerpTimer / _lerpTime);
        }
    }

    public class Vector2Lerp : TimedLerp<Vector2>
    {
        public Vector2Lerp(Vector2 startValue, Vector2 endValue, float time) : base(startValue, endValue, time)
        { }

        protected override Vector2 Lerp()
        {
            return Vector2.Lerp(_startValue, _endValue, _lerpTimer / _lerpTime);
        }
    }

    public class Vector3Lerp : TimedLerp<Vector3>
    {
        public Vector3Lerp(Vector3 startValue, Vector3 endValue, float time) : base(startValue, endValue, time)
        { }

        protected override Vector3 Lerp()
        {
            return Vector3.Lerp(_startValue, _endValue, _lerpTimer / _lerpTime);
        }
    }

    public class QuaternionLerp : TimedLerp<Quaternion>
    {
        public QuaternionLerp(Quaternion startValue, Quaternion endValue, float time) : base(startValue, endValue, time)
        { }

        protected override Quaternion Lerp()
        {
            return Quaternion.Lerp(_startValue, _endValue, _lerpTimer / _lerpTime);
        }
    }

    public class ColorLerp : TimedLerp<Color>
    {
        public ColorLerp(Color startValue, Color endValue, float time) : base(startValue, endValue, time)
        { }

        protected override Color Lerp()
        {
            return Color.Lerp(_startValue, _endValue, _lerpTimer / _lerpTime);
        }
    }

    public class Color32Lerp : TimedLerp<Color32>
    {
        public Color32Lerp(Color32 startValue, Color32 endValue, float time) : base(startValue, endValue, time)
        { }

        protected override Color32 Lerp()
        {
            return Color32.Lerp(_startValue, _endValue, _lerpTimer / _lerpTime);
        }
    }
}
