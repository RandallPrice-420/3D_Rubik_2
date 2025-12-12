using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CtrlKeyMouse : MonoBehaviour
{
    public ControlMode cmode;
    public CubeMover cubemover;
    public CanvasRaycastBlocker crb;
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
        if (cmode.mode == 0 && !CustomAlgoBbleAnim.GetBool("isOpen")) {
            // Check for mouse input
            if (Input.GetMouseButtonDown(0) && !crb.isHittingUI()) {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit)) {
                    switch (hit.transform.name) {
                        case "Arrow_F1":
                            cubemover.Move("L_B");
                            break;
                        case "Arrow_F2":
                            cubemover.Move("Rm_B");
                            break;
                        case "Arrow_F3":
                            cubemover.Move("R_B");
                            break;
                        case "Arrow_F4":
                            cubemover.Move("Um_L");
                            break;
                        case "Arrow_F50":
                            cubemover.Move("A_UL");
                            break;
                        case "Arrow_F51":
                            cubemover.Move("A_UR");
                            break;
                        case "Arrow_F6":
                            cubemover.Move("Um_R");
                            break;
                        case "Arrow_F7":
                            cubemover.Move("L_F");
                            break;
                        case "Arrow_F8":
                            cubemover.Move("Rm_F");
                            break;
                        case "Arrow_F9":
                            cubemover.Move("R_F");
                            break;
                        case "Arrow_R1":
                            cubemover.Move("D_L");
                            break;
                        case "Arrow_R2":
                            cubemover.Move("Um_L");
                            break;
                        case "Arrow_R3":
                            cubemover.Move("U_L");
                            break;
                        case "Arrow_R4":
                            cubemover.Move("Fm_R");
                            break;
                        case "Arrow_R50":
                            cubemover.Move("A_FR");
                            break;
                        case "Arrow_R51":
                            cubemover.Move("A_FL");
                            break;
                        case "Arrow_R6":
                            cubemover.Move("Fm_L");
                            break;
                        case "Arrow_R7":
                            cubemover.Move("D_R");
                            break;
                        case "Arrow_R8":
                            cubemover.Move("Um_R");
                            break;
                        case "Arrow_R9":
                            cubemover.Move("U_R");
                            break;
                        case "Arrow_U1":
                            cubemover.Move("B_R");
                            break;
                        case "Arrow_U2":
                            cubemover.Move("Fm_R");
                            break;
                        case "Arrow_U3":
                            cubemover.Move("F_R");
                            break;
                        case "Arrow_U4":
                            cubemover.Move("Rm_B");
                            break;
                        case "Arrow_U50":
                            cubemover.Move("A_RB");
                            break;
                        case "Arrow_U51":
                            cubemover.Move("A_RF");
                            break;
                        case "Arrow_U6":
                            cubemover.Move("Rm_F");
                            break;
                        case "Arrow_U7":
                            cubemover.Move("B_L");
                            break;
                        case "Arrow_U8":
                            cubemover.Move("Fm_L");
                            break;
                        case "Arrow_U9":
                            cubemover.Move("F_L");
                            break;
                    }
                }
            } else if (Input.GetKeyDown(KeyCode.A)) {
                cubemover.Move("A_UL");
            } else if (Input.GetKeyDown(KeyCode.D)) {
                cubemover.Move("A_UR");
            } else if (Input.GetKeyDown(KeyCode.W)) {
                cubemover.Move("A_RB");
            } else if (Input.GetKeyDown(KeyCode.S)) {
                cubemover.Move("A_RF");
            } else if (Input.GetKeyDown(KeyCode.Q)) {
                cubemover.Move("A_FL");
            } else if (Input.GetKeyDown(KeyCode.E)) {
                cubemover.Move("A_FR");
            }
        }
    }
}
