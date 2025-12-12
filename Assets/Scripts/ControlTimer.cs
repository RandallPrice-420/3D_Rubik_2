using UnityEngine;
using UnityEngine.UI;


public class ControlTimer : MonoBehaviour
{
    public Text   TextTime;
    public Toggle ToggleAutoTimer;



    private bool  _isRunning;
    private float _currentTime;


    public void ClearTimer()
    {
        _isRunning   = false;
        _currentTime = 0;
    }


    public void StartTimer()
    {
        _isRunning = true;
    }


    public void StopTimer()
    {
        _isRunning = false;
    }


    public void ToggleTimer()
    {
        _isRunning = !_isRunning;

        //if (_isRunning)
        //{
        //    _isRunning = false;
        //}
        //else
        //{
        //    _isRunning = true;
        //}

    }   // ToggleTimer()



    private string ParseTime(float t)
    {
        int n_min = (int)(t / 60);
        if (n_min > 99)
        {
            return "99' 99\" 99";
        }

        int    n_sec  = (int) (t - n_min * 60);
        int    n_msec = (int)((t - n_min * 60 - n_sec) * 100);
        string s_min  = n_min .ToString();
        string s_sec  = n_sec .ToString();
        string s_msec = n_msec.ToString();

        if (s_min .Length == 1) s_min  = "0" + s_min;
        if (s_sec .Length == 1) s_sec  = "0" + s_sec;
        if (s_msec.Length == 1) s_msec = "0" + s_msec;

        return s_min + "' " + s_sec + "\" " + s_msec;

    }   // FormulaMidL()


    private void Start()
    {
        _isRunning   = false;
        _currentTime = 0;

    }   // Start()


    private void Update()
    {
        if (_isRunning)
        {
            _currentTime += Time.deltaTime;
        }

        TextTime.text = ParseTime(_currentTime);

        if (!ToggleAutoTimer.isOn && Input.anyKeyDown && !_isRunning && _currentTime == 0)
        {
            _isRunning = true;
        }

    }   // Update()


}   // class ControlTimer
