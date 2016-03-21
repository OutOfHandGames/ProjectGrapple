using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
