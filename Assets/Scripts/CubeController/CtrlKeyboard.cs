using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CtrlKeyboard : MonoBehaviour
{
    public ControlMode cmode;
    public CubeMover cubemover;
    public Transform CustomAlgoBble;

    Animator CustomAlgoBbleAnim;

    // Start is called before the first frame update
    void Start()
    {
        CustomAlgoBbleAnim = CustomAlgoBble.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (cmode.mode == 1 && !CustomAlgoBbleAnim.GetBool("isOpen")) {
            if (Input.GetKeyDown(KeyCode.A)) {
                if (Input.GetKey(KeyCode.I)) {
                    cubemover.Move("U_L");
                } else if (Input.GetKey(KeyCode.Comma)) {
                    cubemover.Move("D_L");
                } else if (Input.GetKey(KeyCode.K)) {
                    cubemover.Move("Um_L");
                } else {
                    cubemover.Move("A_UL");
                }
            } else if (Input.GetKeyDown(KeyCode.D)) {
                if (Input.GetKey(KeyCode.I)) {
                    cubemover.Move("U_R");
                } else if (Input.GetKey(KeyCode.Comma)) {
                    cubemover.Move("D_R");
                } else if (Input.GetKey(KeyCode.K)) {
                    cubemover.Move("Um_R");
                } else {
                    cubemover.Move("A_UR");
                }
            } else if (Input.GetKeyDown(KeyCode.W)) {
                if (Input.GetKey(KeyCode.J)) {
                    cubemover.Move("L_B");
                } else if (Input.GetKey(KeyCode.L)) {
                    cubemover.Move("R_B");
                } else if (Input.GetKey(KeyCode.K)) {
                    cubemover.Move("Rm_B");
                } else {
                    cubemover.Move("A_RB");
                }
            } else if (Input.GetKeyDown(KeyCode.S)) {
                if (Input.GetKey(KeyCode.J)) {
                    cubemover.Move("L_F");
                } else if (Input.GetKey(KeyCode.L)) {
                    cubemover.Move("R_F");
                } else if (Input.GetKey(KeyCode.K)) {
                    cubemover.Move("Rm_F");
                } else {
                    cubemover.Move("A_RF");
                }
            } else if (Input.GetKeyDown(KeyCode.Q)) {
                if (Input.GetKey(KeyCode.I)) {
                    cubemover.Move("B_L");
                } else if (Input.GetKey(KeyCode.Comma)) {
                    cubemover.Move("F_L");
                } else if (Input.GetKey(KeyCode.K)) {
                    cubemover.Move("Fm_L");
                } else {
                    cubemover.Move("A_FL");
                }
            } else if (Input.GetKeyDown(KeyCode.E)) {
                if (Input.GetKey(KeyCode.I)) {
                    cubemover.Move("B_R");
                } else if (Input.GetKey(KeyCode.Comma)) {
                    cubemover.Move("F_R");
                } else if (Input.GetKey(KeyCode.K)) {
                    cubemover.Move("Fm_R");
                } else {
                    cubemover.Move("A_FR");
                }
            }
        }
    }
}
