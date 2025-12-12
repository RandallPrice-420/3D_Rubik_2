using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CubeMover : MonoBehaviour
{
    public AudioClip    AudioFinished;
    public AudioClip[]  AudioRot;
    public Transform    CenterCube;
    public ControlTimer Controltimer;
    public CubeStatus   Cubestatus;
    public bool         IsLocked;
    public Transform    RootCube;
    public Text         TextRotationSpeed;



    private AudioSource _audioSource;
    private Transform   _root;
    private Vector3     _rotation;
    private float       _rotation_sum;
    private bool        _shouldDestroy;
    private int         _speedMode;
    private List<float> _speeds;



    private void Start()
    {
        _audioSource      = transform.GetComponent<AudioSource>();
        _audioSource.loop = false;
        _root             = null;
        _rotation_sum     = 0f;
        _speedMode        = 2;
        _speeds           = new List<float>(new float[] { 0.8f, 1.6f, 3.2f, 6.4f, 12.8f, 25.6f, 51.2f });

    }   // Start()


    private void Update()
    {
        if (_root != null)
        {
            if (_shouldDestroy)
            {
                if (_root.childCount > 0)
                {
                    for (int i = 0; i < _root.childCount; i++)
                    {
                        _root.GetChild(i).SetParent(RootCube);
                    }
                }
                else
                {
                    Destroy(_root.gameObject);

                    _root          = null;
                    _shouldDestroy = false;
                }
            }
            else
            {
                _root.Rotate(_rotation);
                _rotation_sum += _rotation.magnitude;

                if (_rotation_sum >= 90f)
                {
                    _rotation_sum = 0f;

                    if (_rotation.x != 0f)
                    {
                        if (_rotation.x < 0f)
                        {
                            _root.eulerAngles = new Vector3(-90f, _root.eulerAngles.y, _root.eulerAngles.z);
                        }
                        else
                        {
                            _root.eulerAngles = new Vector3(90f, _root.eulerAngles.y, _root.eulerAngles.z);
                        }
                    }
                    else if (_rotation.y != 0f)
                    {
                        if (_rotation.y < 0f)
                        {
                            _root.eulerAngles = new Vector3(_root.eulerAngles.x, -90f, _root.eulerAngles.z);
                        }
                        else
                        {
                            _root.eulerAngles = new Vector3(_root.eulerAngles.x, 90f, _root.eulerAngles.z);
                        }
                    }
                    else
                    {
                        if (_rotation.z < 0f)
                        {
                            _root.eulerAngles = new Vector3(_root.eulerAngles.x, _root.eulerAngles.y, -90f);
                        }
                        else
                        {
                            _root.eulerAngles = new Vector3(_root.eulerAngles.x, _root.eulerAngles.y, 90f);
                        }
                    }

                    CleanRoot();

                    string status = Cubestatus.GetStatus();
                    //print(status);

                    if (Cubestatus.isFinished(status))
                    {
                        if (!Controltimer.ToggleAutoTimer.isOn)
                        {
                            Controltimer.ToggleAutoTimer.isOn = true;
                            Controltimer.StopTimer();

                            _audioSource.clip   = AudioFinished;
                            _audioSource.volume = 1.0f;
                            _audioSource.Play();
                        }
                    }
                }
            }
        }

    }   // Update()


    private void MoveCubes(Vector3 axis, bool is90Degree, bool isAll, int _orientation)
    {
        if (IsAvailable())
        {
            _audioSource.clip   = AudioRot[Random.Range(0, AudioRot.Length)];
            _audioSource.volume = 0.25f;
            _audioSource.Play();

            List<Transform> ts = FindCubesInFront(axis, is90Degree, isAll);

            GameObject emptyGO = new();
            _root = emptyGO.transform;

            foreach (Transform t in ts)
            {
                t.SetParent(_root);
            }

            _rotation = _orientation * _speeds[_speedMode] * axis;
        }

    }   // MoveCubes()


    private void CleanRoot()
    {
        if (_root != null)
        {
            _shouldDestroy = true;
        }

    }   // CleanRoot()


    private List<Transform> FindCubesInFront(Vector3 axis, bool is90Degree, bool isAll)
    {
        List<Transform> result = new();

        if (isAll)
        {
            for (int i = 0; i < RootCube.childCount; i++)
            {
                Transform t = RootCube.GetChild(i);
                Vector3   v = t.position - CenterCube.position;

                if (v.magnitude > 1e-4)
                {
                    result.Add(t);
                }
            }
        }
        else
        {
            for (int i = 0; i < RootCube.childCount; i++)
            {
                Transform t = RootCube.GetChild(i);
                Vector3   v = t.position - CenterCube.position;

                if (v.magnitude > 1e-4)
                {
                    float cosine = Vector3.Dot(v, axis) / (v.magnitude * axis.magnitude);

                    if (is90Degree)
                    {
                        cosine = Mathf.Abs(cosine);
                    }

                    if ((!is90Degree) && (cosine > 1e-4))
                    {
                        result.Add(t);
                    }
                    else if (is90Degree && (cosine < 1e-4))
                    {
                        result.Add(t);
                    }
                }
            }
        }

        return result;

    }   // FindCubesInFront()


    public void UpdateRotSpeedText()
    {
        _speedMode += 1;

        if (_speedMode >= _speeds.Count)
        {
            _speedMode = 0;
        }

        TextRotationSpeed.text = "Rotation Speed: " + ((int)(_speeds[_speedMode] * 10)).ToString();

    }   // UpdateRotSpeedText()


    public bool IsAvailable()
    {
        if (_root == null && _shouldDestroy == false)
        {
            return true;
        }
        else
        {
            return false;
        }

    }   // IsAvailable()


    public void Move(string code)
    {
        switch (code)
        {
            case "A_FL":
                MoveCubes(RootCube.forward, false, true, 1);
                break;
            case "A_FR":
                MoveCubes(RootCube.forward, false, true, -1);
                break;
            case "A_RF":
                MoveCubes(RootCube.right, false, true, -1);
                break;
            case "A_RB":
                MoveCubes(RootCube.right, false, true, 1);
                break;
            case "A_UR":
                MoveCubes(RootCube.up, false, true, -1);
                break;
            case "A_UL":
                MoveCubes(RootCube.up, false, true, 1);
                break;
            case "F_L":
                MoveCubes(-RootCube.forward, false, false, -1);
                break;
            case "F_R":
                MoveCubes(-RootCube.forward, false, false, 1);
                break;
            case "Fm_L":
                MoveCubes(-RootCube.forward, true, false, -1);
                break;
            case "Fm_R":
                MoveCubes(-RootCube.forward, true, false, 1);
                break;
            case "B_L":
                MoveCubes(RootCube.forward, false, false, 1);
                break;
            case "B_R":
                MoveCubes(RootCube.forward, false, false, -1);
                break;
            case "R_F":
                MoveCubes(RootCube.right, false, false, -1);
                break;
            case "R_B":
                MoveCubes(RootCube.right, false, false, 1);
                break;
            case "Rm_F":
                MoveCubes(RootCube.right, true, false, -1);
                break;
            case "Rm_B":
                MoveCubes(RootCube.right, true, false, 1);
                break;
            case "L_F":
                MoveCubes(-RootCube.right, false, false, 1);
                break;
            case "L_B":
                MoveCubes(-RootCube.right, false, false, -1);
                break;
            case "U_R":
                MoveCubes(RootCube.up, false, false, -1);
                break;
            case "U_L":
                MoveCubes(RootCube.up, false, false, 1);
                break;
            case "Um_R":
                MoveCubes(RootCube.up, true, false, -1);
                break;
            case "Um_L":
                MoveCubes(RootCube.up, true, false, 1);
                break;
            case "D_R":
                MoveCubes(-RootCube.up, false, false, 1);
                break;
            case "D_L":
                MoveCubes(-RootCube.up, false, false, -1);
                break;
        }

    }   // Move()


}   // class CubeMover
