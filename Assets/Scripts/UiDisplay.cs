using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UiDisplay : MonoBehaviour
{
    private int lives = 3;
    private int score = 0;
    public Text livesText;
    private void Update()
    {
        score=FindObjectOfType<GameManager>().score;
        lives = FindObjectOfType<GameManager>().lives;

        livesText.text = "Lives x" + lives + "\n" + score;
    }

}
