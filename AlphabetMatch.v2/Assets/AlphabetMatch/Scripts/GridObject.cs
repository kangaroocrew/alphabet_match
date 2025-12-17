using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GridObject : MonoBehaviour
{
    public string gridLetter;
    public string gridWord;

    public Image letterImage;
    public Image gridImage;
    public TextMeshProUGUI gridText;

    // NEW: TMP for the letter that sits in the green box
    public TextMeshProUGUI letterTMP;

    public bool followCharacterFlag;
    public Transform CharacterObj;

    public bool clickObjectFlag;

    void Start()
    {
        followCharacterFlag = false;
        clickObjectFlag = false;
    }

    void FixedUpdate()
    {
        if (followCharacterFlag)
        {
            transform.localPosition = new Vector3(
                CharacterObj.localPosition.x,
                CharacterObj.localPosition.y,
                CharacterObj.localPosition.z);
        }
    }

    // --------------------   Letter TMP helpers  --------------------------//

    // Show a letter via TextMeshPro
    public void DisplayLetterText(string letter)
    {
        if (letterTMP == null) return;

        letterTMP.text = letter;
        letterTMP.gameObject.SetActive(true);
    }

    // Hide the letter TMP
    public void ClearLetterText()
    {
        if (letterTMP == null) return;

        letterTMP.text = "";
        letterTMP.gameObject.SetActive(false);
    }

    // --------------------   Load/Display Images  --------------------------//

    public void DisplayWordImage(string _filename)
    {
        char letter = _filename[0];
        string imageFilename = "Objects/Images/letter" + letter + "/" + _filename;
        gridImage.sprite = Resources.Load<Sprite>(imageFilename);
    }

    public void ClearWordImage()
    {
        string imageFilename = "Objects/Images/empty";
        gridImage.sprite = Resources.Load<Sprite>(imageFilename);
    }

    // --------------------   Load/Display Text Field  ----------------------//

    public void DisplayLetterImage(string _word)
    {
        char letter = _word[0];
        string imageFilename = "Letters/" + letter + "_letter";
        letterImage.sprite = Resources.Load<Sprite>(imageFilename);
    }

    public void ClearLetterImage()
    {
        string imageFilename = "Objects/Images/empty";
        letterImage.sprite = Resources.Load<Sprite>(imageFilename);
    }

    public void DisplayWordText(string _word)
    {
        int textStringLength = _word.Length - 1;
        gridText.text = FormatDisplayText(_word);
        gridText.fontSize = 44;
        if (textStringLength > 1)
        {
            gridText.fontSize = 32;
        }
        if (textStringLength > 6)
        {
            gridText.fontSize = 26;
        }
        if (textStringLength > 10)
        {
            gridText.fontSize = 22;
        }
        if (textStringLength > 17)
        {
            gridText.fontSize = 18;
        }
    }

    public void ClearWordText()
    {
        gridText.text = "";
    }

    private string FormatDisplayText(string _word)
    {
        string wordText = _word.ToLower();
        int textStringLength = wordText.Length - 1;
        string textEnd = wordText.Substring(1, textStringLength);
        string displayText = "<color=#FF0000>";
        displayText += _word.Substring(0, 1).ToUpper();
        displayText += "</color>";
        displayText += textEnd;
        return displayText;
    }
}
