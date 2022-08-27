using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    public bool battleStarted = false;

    public void StartBattle()
    {
        battleStarted = true;
        GetComponent<CanvasGroup>().alpha = 0;
        GetComponent<Button>().enabled = false;
    }
}
