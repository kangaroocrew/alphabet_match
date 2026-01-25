using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GardenLogic : MonoBehaviour
{
    public GameLogic gameLogicObj;
	public GameObject[] GardenLetters;
	
	public int LetterCounter;
	public int AnimateCounter;
	public int AnimateStop;
	
	public bool AnimateFlag;
	public int StopCounter;
	public int randomLetterIndex;
	
	public GameObject[] chars;
	public GameObject[] playchars;
	
	float timer;
	[SerializeField] private float baseWaitTime = 0.1f; // now tunable in inspector
	float waitTime;
	int letterSelection;
	
	// Start is called before the first frame update
    void Start()
    {
	    ResetGarden();
    }
	
	public void SelectRandomLetters(){
		randomLetterIndex = UnityEngine.Random.Range(0,23);
		AnimateStop = 51 + randomLetterIndex;
	}
	
	public void ResetVars()
	{
		timer = 0f;

		//base cadance for letter spawning in the garden.
		//lower than 0.1f = faster, but still readable.
		float difficultyFactor = 1f;

		//Optional: scale speed a bit with difficulty/level
		if (gameLogicObj != null)
		{
			//Example: if levelNumber goes 0,1,2..., make higher levels a bit faster
			// Clamp01 keeps it in [0,1] so we dont go wild.
			float t = Mathf.Clamp01(gameLogicObj.levelNumber / 3f);
			difficultyFactor = Mathf.Lerp(1.0f, 0.7f, t); // up to 30% faster on harder levels.
		}

		waitTime = baseWaitTime * difficultyFactor;

		LetterCounter = 0;
		AnimateCounter = 0;
		SelectRandomLetters();
		StopCounter = 0;
		AnimateFlag = false;
		letterSelection = -1;
	}
	
	public void SelectChars(int _char){
		for (int i=0;i<chars.Length;i++){
			if (i==_char){
				chars[i].SetActive(true);
				playchars[i].SetActive(true);
			}else{
				chars[i].SetActive(false);
				playchars[i].SetActive(false);
			}
		}
	}
	
	public void ResetGarden(){
		ResetVars();
		for (int i=0;i<GardenLetters.Length;i++){
			GardenLetters[i].GetComponent<RectTransform>().localPosition = new Vector3(0f,0f,0f);
			GardenLetters[i].GetComponent<AnimateGardenLetter>().ResetAnimate();
		}
	}


    /* REMOVED SO 3 LETTERS ARE NO LONGER ANIMATED~
	public void AnimateLetterSelect(int _letterNum){
		if (!AnimateFlag){
			letterSelection[0] = _letterNum;
			letterSelection[1] = _letterNum + 1;
			letterSelection[2] = _letterNum + 2;
			//
			if (letterSelection[1] > 25){
				letterSelection[1] -= 26;
			}
			if (letterSelection[2] > 25){
				letterSelection[2] -= 26;
			}
			AnimateFlag = true;
		}
	}
	*/

    public void AnimateLetterSelect(int _letterNum)
    {
        if (!AnimateFlag)
        {
            letterSelection = _letterNum;
            AnimateFlag = true;
        }
    }

    /* REMOVED COMPLETELY SINCE IT DEALS IN THREE LETTERS.
    // Update is called once per frame
    void Update()
    {
        if (AnimateFlag){
			timer += Time.deltaTime;
			if (timer > waitTime){
				/*if (AnimateCounter>AnimateStop){
					GardenLetters[LetterCounter].GetComponent<AnimateGardenLetter>().AnimateFlag = 2;
					StopCounter++;
					if (StopCounter>2){
						AnimateFlag = false;
						gameLogicObj.SetLetterIndex(randomLetterIndex);
					}
				}else{*/ /*
					if (LetterCounter != letterSelection[0] && LetterCounter != letterSelection[1] && LetterCounter != letterSelection[2]){
						if (LetterCounter<26){
							GardenLetters[LetterCounter].GetComponent<AnimateGardenLetter>().AnimateFlag = 1;
						}
					}
				//}
				timer -= waitTime;
				LetterCounter++;
				AnimateCounter++;
				if (LetterCounter>=50){
					LetterCounter = 0;
					AnimateFlag = false;
					gameLogicObj.SetLetterIndex(letterSelection[0]);
					gameLogicObj.PlayGame();
				}
			}
		}
    } */

    void Update()
    {
        if (AnimateFlag)
        {
            timer += Time.deltaTime;
            if (timer > waitTime)
            {
                if (LetterCounter != letterSelection)
                {
                    if (LetterCounter < 26)
                    {
                        GardenLetters[LetterCounter]
                            .GetComponent<AnimateGardenLetter>()
                            .AnimateFlag = 1;
                    }
                }

                timer -= waitTime;
                LetterCounter++;
                AnimateCounter++;

                if (LetterCounter >= 30)
                {
                    LetterCounter = 0;
                    AnimateFlag = false;
                    gameLogicObj.SetLetterIndex(letterSelection);
                    gameLogicObj.PlayGame();
                }
            }
        }
    }


}
