using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndManager : MonoBehaviour
{
    public string text;
    public RawImage TextBox;
    public Text str;
    public Transform CH1_nomal;     //여주인공 노말
    public Transform CH2_nomal;     //남주인공 노말
    public Transform CH3;           //선생(해설)
    public Animator NPC;
    public Animator Character;
    public int Stage;
    public int count;
    // Use this for initialization
    void Start()
    {
        count = 0;
        CH1_nomal.transform.gameObject.SetActive(false);
        CH2_nomal.transform.gameObject.SetActive(false);
        CH3.transform.gameObject.SetActive(false);
        NPC.transform.gameObject.SetActive(false);

        switch (Stage)
        {
            case 0:
            case 2:
            case 6:
                CH3.transform.gameObject.SetActive(true);   //시작 프롤로그 id  0번째 부분 시작은 해설이므로 선생오브젝트 활성화
                break;      //break로 case문을 빠져나가서 텍스트를 뿌려주는 switch문으로
            case 1:
                NPC.transform.gameObject.SetActive(true);
                break;
        }
        switch (Stage)
        {
            case 0:
            case 6:
                text = Science_Text_Script1.Instance.scenario[Stage].text[count];
                if (text.Contains("###"))
                {
                    string temp = text.Replace("###", AppManage.Instance.Name);
                    GameObject.Find("TypingManager").GetComponent<TypingManager>().TypingText(temp, str);   //TypingManager로 인해 Text가 자연스럽게 뿌려짐
                }
                else
                {
                    GameObject.Find("TypingManager").GetComponent<TypingManager>().TypingText(text, str);
                }
                break;
            default:
                ChangeStr(Stage);
                break;
        }
        AppManage.Instance.isComplite = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void ChangeStr(int _stage)
    {
        //Debug.Log(Science_Text_Script1.Instance.scenario[_stage].text[Science_Text_Script1.Instance.scenario[_stage].text.Count - 1]);
        
        // scenario[_stage].text.Count - 1 가 현재 스테이지의 text의 개수만큼 세 주어서 마지막 부분을 text변수에 넣어준다.
        // ex) 1스테이지의 text개수가 26개이면 0부터 세어준 경우이므로 -1을 해주어서 마지막 부분인 25 text변수에 넣어주는 것
        text = Science_Text_Script1.Instance.scenario[_stage].text[Science_Text_Script1.Instance.scenario[_stage].text.Count - 1];

        if (text.Contains("###"))
        {
            string temp = text.Replace("###", AppManage.Instance.Name);
            GameObject.Find("TypingManager").GetComponent<TypingManager>().TypingText(temp, str);
        }
        else
        {
            GameObject.Find("TypingManager").GetComponent<TypingManager>().TypingText(text, str);
        }
    }

    public void NextScript()    //버튼을 눌렀을 때 (화살표를 눌렀을때 호출)
    {
        if (AppManage.Instance.isComplite)
        {
            switch (Stage)
            {
                case 0:
                    switch (count)
                    {
                        case 1:
                            if (AppManage.Instance.Gender == 0)
                            {
                                CH2_nomal.transform.gameObject.SetActive(true);
                                CH3.transform.gameObject.SetActive(false);
                                Character.SetTrigger("CH2Anim");
                            }
                            else
                            {
                                CH1_nomal.transform.gameObject.SetActive(true);
                                CH3.transform.gameObject.SetActive(false);
                                Character.SetTrigger("CH1Anim");
                            }
                            count++;
                            break;
                        case 2:
                            AppManage.Instance.isComplite = false;
                            SceneManager.LoadScene("SelectMap");
                            break;
                        default:
                            CH1_nomal.transform.gameObject.SetActive(false);
                            
                            CH2_nomal.transform.gameObject.SetActive(false);
                            CH3.transform.gameObject.SetActive(true);
                            Character.SetTrigger("teachAnim");
                            count++;
                            break;
                    }
                    break;
                case 6:
                    switch(count)
                    {
                        case 1:
                            AppManage.Instance.isComplite = false;
                            TextBox.transform.gameObject.SetActive(false);
                            str.text = string.Empty;
                            AppManage.Instance.isExit = true;
                            count++;
                            break;
                        default:
                            CH1_nomal.transform.gameObject.SetActive(false);
                            CH2_nomal.transform.gameObject.SetActive(false);
                            CH3.transform.gameObject.SetActive(true);
                            Character.SetTrigger("teachAnim");
                            count++;
                            break;
                    }
                    break;
                default:
                    break;
            }
            if (Stage == 6)
            {
                if (count != 2)
                {
                    text = Science_Text_Script1.Instance.scenario[Stage].text[Science_Text_Script1.Instance.scenario[Stage].Num[count]];
                    if (text.Contains("###"))
                    {
                        string temp = text.Replace("###", AppManage.Instance.Name);
                        GameObject.Find("TypingManager").GetComponent<TypingManager>().TypingText(temp, str);
                    }
                    else
                    {
                        GameObject.Find("TypingManager").GetComponent<TypingManager>().TypingText(text, str);
                    }
                    AppManage.Instance.isComplite = false;
                }
            }
            else
            {
                text = Science_Text_Script1.Instance.scenario[Stage].text[Science_Text_Script1.Instance.scenario[Stage].Num[count]];
                if (text.Contains("###"))
                {
                    string temp = text.Replace("###", AppManage.Instance.Name);
                    GameObject.Find("TypingManager").GetComponent<TypingManager>().TypingText(temp, str);
                }
                else
                {
                    GameObject.Find("TypingManager").GetComponent<TypingManager>().TypingText(text, str);
                }
                AppManage.Instance.isComplite = false;
            }
        }
        else
        {
            AppManage.Instance.isClicked = true;
            //AppManage.Instance.isClicked2 = true;
        }
    }
}
