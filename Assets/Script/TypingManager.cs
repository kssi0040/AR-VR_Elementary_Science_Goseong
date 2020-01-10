using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class TypingManager : MonoBehaviour 
{
    [SerializeField]
    Text dialogue;

    private string text = "Q 2. 대한민국의 주권은 국민에게 있습니다. 주권의 의미를 알아볼까요?&#xA; &#xA;주인된 권리로 우리나라의 국민이라면 누구나 가진다.";

    StringBuilder sb1 = new StringBuilder();
    StringBuilder sb2 = new StringBuilder();
    StringBuilder sb3 = new StringBuilder();
    StringBuilder sb4 = new StringBuilder();

    WaitForSeconds SpellingDelay = new WaitForSeconds(0.03f);
    
	// Use this for initialization
	void Start () 
    {
        //TypingText(text, dialogue);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void TypingText(string contents, Text uiText)
    {
        sb1.Append(contents);

        TypeSentence(uiText);
    }

    public void TypingText2(string contents, Text uiText)
    {
        sb3.Append(contents);

        TypeSentence2(uiText);
    }

    private void TypeSentence(Text uiText)
    {
        StartCoroutine(ITypeSentence(uiText));
    }

    private void TypeSentence2(Text uiText)
    {
        StartCoroutine(ITypeSentence2(uiText));
    }
    private IEnumerator ITypeSentence(Text uiText)
    {
        foreach (char letter in sb1.ToString().ToCharArray())
        {
            //_dialogueText.text += letter;
            sb2.Append(letter);
            uiText.text = sb2.ToString();

            yield return SpellingDelay;

            Debug.Log("ITypeSentence: " + AppManage.Instance.isClicked);

            if(AppManage.Instance.isClicked)
            {
                Debug.Log("ItypeSentence1");

                uiText.text = string.Empty;
                uiText.text = sb1.ToString();
                break;
            }
        }
        AppManage.Instance.isComplite = true;
        AppManage.Instance.isClicked = false;
        sb1.Length = 0;
        sb2.Length = 0;
        Debug.Log("Completed!");
    }

    private IEnumerator ITypeSentence2(Text uiText)
    {
        AppManage.Instance.isClicked2 = false;      //앞으로가는 버튼을 누를 경우 TypingText에서 isCompilte가 다 찍힌 것으로 나오게 되므로 
                                                    // if (AppManage.Instance.isComplite)가 성립한 것으로 치고 TypingTex2가 거치지 않고 가게된다.
        foreach (char letter in sb3.ToString().ToCharArray())
        {
            //_dialogueText.text += letter;
            sb4.Append(letter);
            uiText.text = sb4.ToString();

            yield return SpellingDelay;

            Debug.Log("ITypeSentence2: " + AppManage.Instance.isClicked2);

            if (AppManage.Instance.isClicked2)
            {
                Debug.Log("ItypeSentence2");

                uiText.text = string.Empty;
                uiText.text = sb3.ToString();
                break;
            }
        }
        AppManage.Instance.isComplite = true;
        AppManage.Instance.isClicked2 = false;
        sb3.Length = 0;
        sb4.Length = 0;
        Debug.Log("Completed!");
    }
}
