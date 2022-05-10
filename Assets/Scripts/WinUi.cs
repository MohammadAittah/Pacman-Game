using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WinUi : MonoBehaviour
{
    public Text win;
    private void Update()
    {
        if (FindObjectOfType<GameManager>().pacWin)
        {
            win.text = "YOU WIN";
        }
        else
        {
            win.text = "";
        }
        
    }
}
