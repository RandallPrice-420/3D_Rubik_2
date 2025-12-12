using UnityEngine;
using UnityEngine.UI;


public class ControlCameraBackground : MonoBehaviour
{
    public float ChangingSpeed255;
    public Image ImageBackground;
    public float MinimumValue255;



    private float _changingSpeed;
    private float _minimumValue;
    private int   _stage;



    private void Start()
    {
        _stage                = 0;
        _changingSpeed        = ChangingSpeed255 / 255f;
        _minimumValue         = MinimumValue255  / 255f;
        ImageBackground.color = new Color(_minimumValue, 1f, 1f);

    }   // private 


    private void Update()
    {
        Color color = new(ImageBackground.color.r, ImageBackground.color.g, ImageBackground.color.b);
        // Debug.Log(color);

        switch (_stage)
        {
            case 0:
                color.b -= Time.deltaTime * _changingSpeed;

                if (color.b <= _minimumValue)
                {
                    color.b = _minimumValue;
                    AddOne2Stage();
                }

                ImageBackground.color = color;
                break;

            case 1:
                color.r += Time.deltaTime * _changingSpeed;

                if (color.r >= 1)
                {
                    color.r = 1;
                    AddOne2Stage();
                }

                ImageBackground.color = color;
                break;

            case 2:
                color.g -= Time.deltaTime * _changingSpeed;

                if (color.g <= _minimumValue)
                {
                    color.g = _minimumValue;
                    AddOne2Stage();
                }

                ImageBackground.color = color;
                break;

            case 3:
                color.b += Time.deltaTime * _changingSpeed;

                if (color.b >= 1)
                {
                    color.b = 1;
                    AddOne2Stage();
                }

                ImageBackground.color = color;
                break;

            case 4:
                color.r -= Time.deltaTime * _changingSpeed;

                if (color.r <= _minimumValue)
                {
                    color.r = _minimumValue;
                    AddOne2Stage();
                }

                ImageBackground.color = color;
                break;

            case 5:
                color.g += Time.deltaTime * _changingSpeed;

                if (color.g >= 1)
                {
                    color.g = 1;
                    AddOne2Stage();
                }

                ImageBackground.color = color;
                break;
        }

    }   // Update()


    private void AddOne2Stage()
    {
        _stage += 1;
        if (_stage > 5) _stage = 0;

    }   // AddOne2Stage()


}   // class ControlCameraBackground
