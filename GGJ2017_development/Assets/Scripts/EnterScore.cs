using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnterScore : MonoBehaviour {

    public Text char1Text;
    public Text char2Text;
    public Text char3Text;
    public Text scoreText;

    string[] chars = new string[3];
    string[] possibleChars = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };

    public int selectedBox;

    int selectedPossibleChar;

    bool canMoveCursor;

    void Start()
    {
        chars[0] = "A";
        chars[1] = "A";
        chars[2] = "A";
    }

    void Update()
    {
        scoreText.text = IScoreCounter.instance.score.ToString();

        if (Input.GetAxis("LeftStick") > 0.5f && canMoveCursor)
        {
            selectedBox++;
            selectedPossibleChar = 0;
            canMoveCursor = false;
        }
        if (Input.GetAxis("LeftStick") < -0.5f && canMoveCursor)
        {
            selectedBox--;
            selectedPossibleChar = 0;
            canMoveCursor = false;
        }

        if (selectedBox < 0)
        {
            selectedBox = 2;
        }
        if (selectedBox > 2)
        {
            selectedBox = 0;
        }

        if (Input.GetAxis("LeftStickY") > 0.5f && canMoveCursor)
        {
            selectedPossibleChar--;
            if (selectedPossibleChar < 0)
            {
                selectedPossibleChar = possibleChars.Length - 1;
            }
            chars[selectedBox] = possibleChars[selectedPossibleChar];
            canMoveCursor = false;
        }
        if (Input.GetAxis("LeftStickY") < -0.5f && canMoveCursor)
        {
            selectedPossibleChar++;
            if (selectedPossibleChar > possibleChars.Length - 1)
            {
                selectedPossibleChar = 0;
            }
            chars[selectedBox] = possibleChars[selectedPossibleChar];
            canMoveCursor = false;
        }

        char1Text.text = chars[0];
        char2Text.text = chars[1];
        char3Text.text = chars[2];

        if (Input.GetAxis("LeftStick") < 0.2f && Input.GetAxis("LeftStick") > -0.2f && Input.GetAxis("LeftStickY") < 0.2f && Input.GetAxis("LeftStickY") > -0.2f)
        {
            canMoveCursor = true;
        }

        if (Input.GetAxis("Cross") > 0.1f)
        {
            string name = chars[0] + chars[1] + chars[2];
            IHighScoreController.instance.RegisterScore(name, IScoreCounter.instance.score);
            gameObject.SetActive(false);
            Application.LoadLevel(Application.loadedLevel);
        }
    }

    IEnumerator WaitForCursorMovement()
    {
        canMoveCursor = false;
        yield return new WaitForSeconds(0.2f);
        canMoveCursor = true;
    }
}