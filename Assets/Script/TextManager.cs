using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI.Extensions;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;


public class TextManager : MonoBehaviour
{
    public int currentStage;
    public int count = 0;
    public string text;

    [SerializeField]
    int tempInt = 0;

    public RectTransform Link;
    public RectTransform Controller;
    public RectTransform LinkCanvas;
    public RectTransform Typing1Canvas;
    public RectTransform Typing2Canvas;
    public RectTransform OptionCanvas;
    public RectTransform ImgLinkCanvas;
    public RectTransform ImgOptionCanvas;

    public Transform sphere;
    public Transform CH1_nomal;
    public Transform CH2_nomal;
    public Transform CH3;
   
    public Image BackGround;
    public Image PopUp;
    public Image Highlight;
    
    public Image floor;
    public Image icon360;
    public Image footImage;
    public Image dinosaurImage;
    public Image Iguanodon;
    public Image quizImage;

    public RawImage TextBox;
    public RawImage KingTextBox;

    public Text str;
    public Text PopUpText;
    public Text KingText;

    public Animator CHS;

    public Animator dino_big;
    public Animator dino_small;
    public Animator dino_run;
    public Animator bush;
    public Animator greenDino_eat;
    public Animator trex_eat;
    public Animator egu;
    public Animator groundHistroy;

    public Canvas canvas;

    public RectTransform CharacterScroll;
    public RectTransform PopUpScroll;
    public RectTransform NPCScroll;

    LinkQuizManager linkQuizManager;


    private void Awake()
    {
        
    }
    // Use this for initialization
    void Start()
    {
        linkQuizManager = FindObjectOfType<LinkQuizManager>();

        
        
        // 퀴즈 캔버스 비활성화(초기에)
        LinkCanvas.transform.gameObject.SetActive(false);
        Typing1Canvas.transform.gameObject.SetActive(false);
        Typing2Canvas.transform.gameObject.SetActive(false);
        OptionCanvas.transform.gameObject.SetActive(false);
        ImgLinkCanvas.transform.gameObject.SetActive(false);
        ImgOptionCanvas.transform.gameObject.SetActive(false);

        // 링크, 팝업, 팝업 텍스트, 북 비활성화(초기에)
        Link.transform.gameObject.SetActive(false);
        PopUp.transform.gameObject.SetActive(false);
        PopUpText.transform.gameObject.SetActive(false);
        PopUpScroll.transform.gameObject.SetActive(false);
        icon360.transform.gameObject.SetActive(false);


        // 남주, 여주, 선생 비활성화(초기에)
        CH1_nomal.transform.gameObject.SetActive(false);
        CH2_nomal.transform.gameObject.SetActive(false);
        CH3.transform.gameObject.SetActive(true);

        // public 으로 넣어준 것들은 매 scene마다 수동으로 넣어주기 때문에 넣지 않는 scene에서는 사용 자체를 하지 않기 때문에
        // 쓰지 않는 오브젝트는 false를 해줄 필요가 없다.


        if(currentStage==1)     // stage 1일 때
        { 
            KingText.transform.gameObject.SetActive(false);
            KingTextBox.transform.gameObject.SetActive(false);
            floor.transform.gameObject.SetActive(false);
            footImage.transform.gameObject.SetActive(false);
            dinosaurImage.transform.gameObject.SetActive(false);
            Controller.transform.gameObject.SetActive(false);
            dino_big.transform.gameObject.SetActive(false);
            dino_small.transform.gameObject.SetActive(false);
            dino_run.transform.gameObject.SetActive(false);
            dino_run.GetComponent<Movement>().running = false;
            groundHistroy.transform.gameObject.SetActive(false);
            quizImage.transform.gameObject.SetActive(false);
            NPCScroll.transform.gameObject.SetActive(false);

            // 선생트리거 활성화
            CHS.SetTrigger("teachAnim");

            // start로 인해 초기에 텍스트창이 뜸(맵에서 선택 후 텍스트에 뿌려짐)
            // XML를 찾아서 text에 넣어주는 과정
            text = Science_Text_Script1.Instance.scenario[currentStage].text[Science_Text_Script1.Instance.scenario[currentStage].Num[count]];

            if (text.Contains("###"))    //이름과 텍스트를 같이 뿌려줌
            {
                string temp = text.Replace("###", AppManage.Instance.Name);
                GameObject.Find("TypingManager").GetComponent<TypingManager>().TypingText(temp, str);
            }
            else
            {   // 텍스트만 뿌려줌
                GameObject.Find("TypingManager").GetComponent<TypingManager>().TypingText(text, str);
            }
        }
        else if(currentStage==2)    // stage 2 일 때    
        { 
            CH1_nomal.transform.gameObject.SetActive(false);
            CH2_nomal.transform.gameObject.SetActive(false);
            CH3.transform.gameObject.SetActive(false);
            KingText.transform.gameObject.SetActive(false);
            KingTextBox.transform.gameObject.SetActive(false);
            NPCScroll.transform.gameObject.SetActive(false);
            footImage.transform.gameObject.SetActive(false);
            dinosaurImage.transform.gameObject.SetActive(false);
            icon360.transform.gameObject.SetActive(true);

            dino_big.transform.gameObject.SetActive(false);
            dino_small.transform.gameObject.SetActive(true);
            egu.transform.gameObject.SetActive(false);
            greenDino_eat.transform.gameObject.SetActive(false);
            trex_eat.transform.gameObject.SetActive(false);
            Iguanodon.transform.gameObject.SetActive(false);
            bush.transform.gameObject.SetActive(false);
            quizImage.transform.gameObject.SetActive(false);


            text = Science_Text_Script1.Instance.scenario[currentStage].text[Science_Text_Script1.Instance.scenario[currentStage].Num[count]];
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
        else
        { 
            CH1_nomal.transform.gameObject.SetActive(false);
            CH2_nomal.transform.gameObject.SetActive(false);
            CH3.transform.gameObject.SetActive(true);
            icon360.transform.gameObject.SetActive(true);
            CHS.SetTrigger("teachAnim");

            // start로 인해 초기에 텍스트창이 뜸(맵에서 선택 후 텍스트에 뿌려짐)
            // XML를 찾아서 text에 넣어주는 과정
            text = Science_Text_Script1.Instance.scenario[currentStage].text[Science_Text_Script1.Instance.scenario[currentStage].Num[count]];

            if (text.Contains("###"))    //이름과 텍스트를 같이 뿌려줌
            {
                string temp = text.Replace("###", AppManage.Instance.Name);
                GameObject.Find("TypingManager").GetComponent<TypingManager>().TypingText(temp, str);
            }
            else
            {   // 텍스트만 뿌려줌
                GameObject.Find("TypingManager").GetComponent<TypingManager>().TypingText(text, str);
            }
        }

    }
    AnimatorStateInfo animInfo;
    // Update is called once per frame
    void Update()
    {
        switch (currentStage)       //각 스테이지별 업데이트 해줘야하는 상태
        {
            case 1:
                switch (count)
                {
                    default:
                        break;
                }
                break;
            case 2:
                switch(count)
                {
                    case 0:
                        BackGround.transform.gameObject.SetActive(false);
                        break;
                    default:
                        break;
                }
                break;
            case 3:
                switch(count)
                {
                    case 0:
                        BackGround.transform.gameObject.SetActive(false);    
                        break;
                }
                break;
            case 4:
                switch(count)
                {
                    case 0:
                        BackGround.transform.gameObject.SetActive(false);
                        break;
                }
                break;
            case 5:
                switch(count)
                {
                    case 0:
                        BackGround.transform.gameObject.SetActive(false);
                        break;
                }
                break;
        }
    }
    
    // 앞으로 가는 화살표를 누를 시
    public void forwardDown()
    {
        Text tempText;
        
        // 텍스트가 완전히 다 찍히면 if문 성립
        if (AppManage.Instance.isComplite)
        {
            switch (currentStage)       //텍스트박스, 컨트롤러 등 각종 기능들 끄고 키는 스위치문
            {
                case 1:
                    switch (count)
                    {
                        case 1:
                            dino_big.transform.gameObject.SetActive(true);
                            dino_big.SetTrigger("dinoOpennig");
                            str.text = string.Empty;
                            TextBox.transform.gameObject.SetActive(false);
                            CharacterScroll.transform.gameObject.SetActive(false);
                            KingText.transform.gameObject.SetActive(true);
                            KingTextBox.transform.gameObject.SetActive(true);
                            NPCScroll.transform.gameObject.SetActive(true);
                            count++;
                            break;
                        case 2:
                        //case 4:
                        case 5:
                        case 19:
                            KingText.text = string.Empty;
                            KingTextBox.transform.gameObject.SetActive(false);
                            NPCScroll.transform.gameObject.SetActive(false);
                            TextBox.transform.gameObject.SetActive(true);
                            CharacterScroll.transform.gameObject.SetActive(true);
                            count++;
                            break;
                        case 3:
                        case 13:
                        case 18:
                            KingTextBox.transform.gameObject.SetActive(true);
                            NPCScroll.transform.gameObject.SetActive(true);
                            str.text = string.Empty;
                            TextBox.transform.gameObject.SetActive(false);
                            CharacterScroll.transform.gameObject.SetActive(false);
                            count++;
                            break;
                        case 6:
                            Camera.main.transform.rotation = Quaternion.Euler(Vector3.zero);
                            sphere.transform.gameObject.SetActive(true);
                            icon360.transform.gameObject.SetActive(true);
                            BackGround.transform.gameObject.SetActive(false);
                            Controller.transform.gameObject.SetActive(true);
                            dino_big.transform.gameObject.SetActive(false);
                            count++;
                            break;
                        case 7:
                            BackGround.transform.gameObject.SetActive(true);
                            Camera.main.transform.rotation = Quaternion.Euler(Vector3.zero);
                            sphere.transform.gameObject.SetActive(false);
                            Controller.transform.gameObject.SetActive(false);
                            icon360.transform.gameObject.SetActive(false);
                            dino_big.transform.gameObject.SetActive(true);
                            str.text = string.Empty;
                            TextBox.transform.gameObject.SetActive(false);
                            CharacterScroll.transform.gameObject.SetActive(false);
                            KingTextBox.transform.gameObject.SetActive(true);
                            NPCScroll.transform.gameObject.SetActive(true);
                            count++;
                            break;
                        case 8:
                            switch (tempInt)
                            {
                                case 0:
                                    if(linkQuizManager.OptionClear == false)
                                    {
                                        dino_big.transform.gameObject.SetActive(false);
                                        KingText.text = string.Empty;
                                        KingText.transform.gameObject.SetActive(false);
                                        KingTextBox.transform.gameObject.SetActive(false);
                                        NPCScroll.transform.gameObject.SetActive(false);
                                        linkQuizManager.GenerateOptionQuiz(0, tempInt);
                                        OptionCanvas.transform.gameObject.SetActive(true);
                                        quizImage.transform.gameObject.SetActive(true);
                                    }
                                    else
                                    {
                                        tempInt++;
                                        linkQuizManager.OptionClear = false;
                                        OptionCanvas.transform.gameObject.SetActive(false);
                                        dino_big.transform.gameObject.SetActive(true);
                                        KingText.transform.gameObject.SetActive(true);
                                        KingTextBox.transform.gameObject.SetActive(true);
                                        NPCScroll.transform.gameObject.SetActive(true);
                                        count++;
                                    }
                                    break;
                            }
                            break;
                        case 9:
                            quizImage.transform.gameObject.SetActive(false);
                            PopUp.transform.gameObject.SetActive(true);
                            PopUpText.transform.gameObject.SetActive(true);
                            PopUpScroll.transform.gameObject.SetActive(true);
                            dino_big.transform.gameObject.SetActive(false);
                            KingText.text = string.Empty;
                            KingTextBox.transform.gameObject.SetActive(false);
                            NPCScroll.transform.gameObject.SetActive(false);
                            groundHistroy.transform.gameObject.SetActive(true);
                            count++;
                            break;
                        case 10:
                            groundHistroy.SetTrigger("Ground");
                            count++;
                            break;
                        case 11:
                            KingText.transform.gameObject.SetActive(true);
                            KingTextBox.transform.gameObject.SetActive(true);
                            NPCScroll.transform.gameObject.SetActive(true);
                            dino_big.transform.gameObject.SetActive(true);
                            groundHistroy.transform.gameObject.SetActive(false);
                            PopUp.transform.gameObject.SetActive(false);
                            PopUpScroll.transform.gameObject.SetActive(false);
                            PopUpText.text = string.Empty;
                            count++;
                            break;
                        case 12:
                            switch (tempInt)
                            {
                                case 1:
                                    if (linkQuizManager.OptionClear == false)
                                    {
                                        dino_big.transform.gameObject.SetActive(false);
                                        KingText.transform.gameObject.SetActive(false);
                                        KingTextBox.transform.gameObject.SetActive(false);
                                        NPCScroll.transform.gameObject.SetActive(false);
                                        linkQuizManager.GenerateOptionQuiz(0, tempInt);
                                        OptionCanvas.transform.gameObject.SetActive(true);
                                    }
                                    else
                                    {
                                        tempInt++;
                                        linkQuizManager.OptionClear = false;
                                        OptionCanvas.transform.gameObject.SetActive(false);
                                        KingText.text = string.Empty;
                                        KingText.transform.gameObject.SetActive(true);
                                        TextBox.transform.gameObject.SetActive(true);
                                        CharacterScroll.transform.gameObject.SetActive(true);
                                        dino_big.transform.gameObject.SetActive(true);
                                        count++;
                                    }
                                    break;
                            }
                            break;
                        case 14:
                            PopUp.transform.gameObject.SetActive(true);
                            PopUpText.transform.gameObject.SetActive(true);
                            PopUpScroll.transform.gameObject.SetActive(true);
                            floor.transform.gameObject.SetActive(true);
                            dino_big.transform.gameObject.SetActive(false);
                            KingText.text = string.Empty;
                            KingTextBox.transform.gameObject.SetActive(false);
                            NPCScroll.transform.gameObject.SetActive(false);
                            count++;
                            break;
                        case 15:
                            floor.sprite = Resources.Load<Sprite>("휘어진 지층");
                            count++;
                            break;
                        case 16:
                            floor.sprite = Resources.Load<Sprite>("끊어진 지층");
                            CH1_nomal.transform.gameObject.SetActive(false);
                            CH2_nomal.transform.gameObject.SetActive(false);
                            CH3.transform.gameObject.SetActive(false);
                            dino_small.transform.gameObject.SetActive(true);
                            count++;
                            break;      
                        case 17:
                            if (linkQuizManager.OptionClear == false)
                            {
                                floor.transform.gameObject.SetActive(false);
                                PopUp.transform.gameObject.SetActive(false);
                                PopUpText.transform.gameObject.SetActive(false);
                                PopUpScroll.transform.gameObject.SetActive(false);
                                linkQuizManager.GenerateOptionQuiz(0, tempInt);
                                OptionCanvas.transform.gameObject.SetActive(true);
                                if (AppManage.Instance.Gender == 0)
                                {
                                    CH1_nomal.transform.gameObject.SetActive(false);
                                    CH2_nomal.transform.gameObject.SetActive(true);
                                    CH3.transform.gameObject.SetActive(false);
                                    dino_small.transform.gameObject.SetActive(false);
                                    CHS.SetTrigger("CH2Anim");
                                }
                                else
                                {
                                    CH1_nomal.transform.gameObject.SetActive(true);
                                    CH2_nomal.transform.gameObject.SetActive(false);
                                    CH3.transform.gameObject.SetActive(false);
                                    dino_small.transform.gameObject.SetActive(false);
                                    CHS.SetTrigger("CH1Anim");
                                }
                            }
                            else
                            {
                                tempInt++;
                                linkQuizManager.OptionClear = false;
                                linkQuizManager.ImgOptionClear = false;
                                OptionCanvas.transform.gameObject.SetActive(false);
                                PopUpText.text = string.Empty;
                                PopUpText.transform.gameObject.SetActive(true);
                                TextBox.transform.gameObject.SetActive(true);
                                CharacterScroll.transform.gameObject.SetActive(true);
                                dino_big.transform.gameObject.SetActive(true);
                                count++;
                            }
                            break;
                        case 20:
                            dino_big.transform.gameObject.SetActive(false);
                            dino_run.transform.gameObject.SetActive(true);
                            dino_run.GetComponent<Movement>().ResetPosition();
                            dino_run.GetComponent<Movement>().running = true;
                            PopUp.transform.gameObject.SetActive(true);
                            str.text = string.Empty;
                            TextBox.transform.gameObject.SetActive(false);
                            CharacterScroll.transform.gameObject.SetActive(false);
                            count++;
                            break;
                        case 21:
                            dinosaurImage.transform.gameObject.SetActive(true);
                            dino_run.transform.gameObject.SetActive(false);
                            dino_run.GetComponent<Movement>().running = false;
                            PopUpScroll.transform.gameObject.SetActive(true);
                            count++;
                            break;
                        case 22:
                            dinosaurImage.sprite = Resources.Load<Sprite>("footprint_03");
                            count++;
                            break;
                        case 23:
                            dinosaurImage.sprite = Resources.Load<Sprite>("footprint_04");
                            count++;
                            break;
                        case 24:    //발자국 이미지
                            dinosaurImage.transform.gameObject.SetActive(false);
                            footImage.sprite = Resources.Load<Sprite>("용각류 발자국");
                            footImage.transform.gameObject.SetActive(true);
                            CH1_nomal.transform.gameObject.SetActive(false);
                            CH2_nomal.transform.gameObject.SetActive(false);
                            CH3.transform.gameObject.SetActive(true);
                            dino_small.transform.gameObject.SetActive(false);
                            count++;
                            break;
                        case 25:
                            PopUp.transform.gameObject.SetActive(false);
                            PopUpText.text = string.Empty;
                            PopUpScroll.transform.gameObject.SetActive(false);
                            TextBox.transform.gameObject.SetActive(true);
                            CharacterScroll.transform.gameObject.SetActive(true);
                            count++;
                            break;
                        case 26:
                            dino_big.transform.gameObject.SetActive(true);
                            footImage.transform.gameObject.SetActive(false);
                            count++;
                            break;
                        case 27:
                            KingTextBox.transform.gameObject.SetActive(true);
                            NPCScroll.transform.gameObject.SetActive(true);
                            str.text = string.Empty;
                            TextBox.transform.gameObject.SetActive(false);
                            CharacterScroll.transform.gameObject.SetActive(false);
                            dino_big.transform.gameObject.SetActive(true);
                            count++;
                            break;
                        case 28:
                            SceneManager.LoadScene("Stage1_End");
                            break;
                        default:
                            count++;
                            break;

                    }
                    break;
                case 2:
                    switch (count)
                    {
                        case 0:
                            sphere.transform.gameObject.SetActive(false);
                            Controller.transform.gameObject.SetActive(false);
                            icon360.transform.gameObject.SetActive(false);
                            BackGround.transform.gameObject.SetActive(true);
                            Camera.main.transform.rotation = Quaternion.Euler(Vector3.zero);
                            dino_big.transform.gameObject.SetActive(true);
                            count++;
                            break;
                        case 1:
                            KingText.transform.gameObject.SetActive(true);
                            KingTextBox.transform.gameObject.SetActive(true);
                            NPCScroll.transform.gameObject.SetActive(true);
                            str.text = string.Empty;
                            TextBox.transform.gameObject.SetActive(false);
                            CharacterScroll.transform.gameObject.SetActive(false);
                            dino_big.transform.gameObject.SetActive(true);
                            dino_big.SetTrigger("dinoJump");
                            count++;
                            break;
                        case 2:     //사진제시
                            footImage.transform.gameObject.SetActive(true);
                            dino_big.transform.gameObject.SetActive(false);
                            KingText.text = string.Empty;
                            KingTextBox.transform.gameObject.SetActive(false);
                            NPCScroll.transform.gameObject.SetActive(false);
                            str.transform.gameObject.SetActive(true);
                            TextBox.transform.gameObject.SetActive(true);
                            CharacterScroll.transform.gameObject.SetActive(true);
                            CH1_nomal.transform.gameObject.SetActive(false);
                            CH2_nomal.transform.gameObject.SetActive(false);
                            CH3.transform.gameObject.SetActive(true);
                            CHS.SetTrigger("teachAnim");
                            count++;
                            break;
                        case 3:
                            switch (tempInt)
                            {
                                case 0:
                                    if (linkQuizManager.OptionClear == false)
                                    {
                                        footImage.transform.gameObject.SetActive(false);
                                        str.transform.gameObject.SetActive(false);
                                        TextBox.transform.gameObject.SetActive(false);
                                        CharacterScroll.transform.gameObject.SetActive(false);
                                        linkQuizManager.GenerateOptionQuiz(1, tempInt);
                                        OptionCanvas.transform.gameObject.SetActive(true);
                                        quizImage.sprite = Resources.Load<Sprite>("용각류 발자국");
                                        quizImage.transform.gameObject.SetActive(true);
                                        if (AppManage.Instance.Gender == 0)
                                        {
                                            CH1_nomal.transform.gameObject.SetActive(false);
                                            CH2_nomal.transform.gameObject.SetActive(true);
                                            CH3.transform.gameObject.SetActive(false);
                                            dino_small.transform.gameObject.SetActive(false);
                                            CHS.SetTrigger("CH2Anim");
                                        }
                                        else
                                        {
                                            CH1_nomal.transform.gameObject.SetActive(true);
                                            CH2_nomal.transform.gameObject.SetActive(false);
                                            CH3.transform.gameObject.SetActive(false);
                                            dino_small.transform.gameObject.SetActive(false);
                                            CHS.SetTrigger("CH1Anim");
                                        }
                                    }
                                    else
                                    {
                                        tempInt++;
                                        linkQuizManager.OptionClear = false;
                                        OptionCanvas.transform.gameObject.SetActive(false);
                                        str.text = string.Empty;
                                        str.transform.gameObject.SetActive(true);
                                        dino_big.transform.gameObject.SetActive(true);
                                        KingTextBox.transform.gameObject.SetActive(true);
                                        NPCScroll.transform.gameObject.SetActive(true);
                                        count++;
                                    }
                                    break;
                            }
                            break;

                        case 4:     // 팝업 해설 이미지
                            BackGround.sprite = Resources.Load<Sprite>("Dino_BG");
                            dino_big.transform.gameObject.SetActive(false);
                            quizImage.transform.gameObject.SetActive(false);
                            KingTextBox.transform.gameObject.SetActive(false);
                            KingText.text = string.Empty;
                            NPCScroll.transform.gameObject.SetActive(false);
                            TextBox.transform.gameObject.SetActive(true);
                            CharacterScroll.transform.gameObject.SetActive(true);
                            greenDino_eat.transform.gameObject.SetActive(true);
                            count++;
                            break;
                        case 5:
                            str.text = string.Empty;
                            greenDino_eat.transform.gameObject.SetActive(false);
                            TextBox.transform.gameObject.SetActive(false);
                            CharacterScroll.transform.gameObject.SetActive(false);
                            PopUp.transform.gameObject.SetActive(true);
                            PopUpText.transform.gameObject.SetActive(true);
                            PopUpScroll.transform.gameObject.SetActive(true);
                            dinosaurImage.sprite = Resources.Load<Sprite>("아파토사이즈");
                            dinosaurImage.transform.gameObject.SetActive(true);
                            count++;
                            break;
                        case 6:
                            dinosaurImage.sprite = Resources.Load<Sprite>("브라키오사이즈");
                            count++;
                            break;
                        case 7:
                            PopUp.transform.gameObject.SetActive(false);
                            PopUpScroll.transform.gameObject.SetActive(false);
                            PopUpText.text = string.Empty;
                            dino_big.transform.gameObject.SetActive(true);
                            TextBox.transform.gameObject.SetActive(true);
                            CharacterScroll.transform.gameObject.SetActive(true);
                            dinosaurImage.transform.gameObject.SetActive(false);
                            BackGround.sprite = Resources.Load<Sprite>("제천마을");
                            count++;
                            break;
                        case 8:
                            str.text = string.Empty;
                            TextBox.transform.gameObject.SetActive(false);
                            CharacterScroll.transform.gameObject.SetActive(false);
                            KingTextBox.transform.gameObject.SetActive(true);
                            NPCScroll.transform.gameObject.SetActive(true);
                            count++;
                            break;
                        case 9:     //발자국 사진 변경
                            dino_big.transform.gameObject.SetActive(false);
                            KingText.text = string.Empty;
                            KingTextBox.transform.gameObject.SetActive(false);
                            NPCScroll.transform.gameObject.SetActive(false);
                            footImage.sprite = Resources.Load<Sprite>("조각류 발자국");
                            footImage.transform.gameObject.SetActive(true);
                            TextBox.transform.gameObject.SetActive(true);
                            CharacterScroll.transform.gameObject.SetActive(true);
                            count++;
                            break;
                        case 10:
                            footImage.transform.gameObject.SetActive(false);
                            egu.transform.gameObject.SetActive(true);
                            KingTextBox.transform.gameObject.SetActive(true);
                            NPCScroll.transform.gameObject.SetActive(true);
                            str.text = string.Empty;
                            TextBox.transform.gameObject.SetActive(false);
                            CharacterScroll.transform.gameObject.SetActive(false);
                            count++;
                            break;
                        case 11:        //팝업 해설 이미지
                            PopUp.transform.gameObject.SetActive(true);
                            PopUpScroll.transform.gameObject.SetActive(true);
                            egu.transform.gameObject.SetActive(false);
                            KingText.text = string.Empty;
                            KingTextBox.transform.gameObject.SetActive(false);
                            NPCScroll.transform.gameObject.SetActive(false);
                            Iguanodon.transform.gameObject.SetActive(true);
                            count++;
                            break;
                        case 12:
                            PopUp.transform.gameObject.SetActive(false);
                            PopUpText.text = string.Empty;
                            PopUpScroll.transform.gameObject.SetActive(false);
                            egu.transform.gameObject.SetActive(true);
                            KingTextBox.transform.gameObject.SetActive(true);
                            NPCScroll.transform.gameObject.SetActive(true);
                            Iguanodon.transform.gameObject.SetActive(false);
                            count++;
                            break;
                        case 13:
                            egu.transform.gameObject.SetActive(false);
                            dino_big.transform.gameObject.SetActive(true);
                            count++;
                            break;
                        case 14:
                            dino_big.transform.gameObject.SetActive(false);
                            KingText.text = string.Empty;
                            KingTextBox.transform.gameObject.SetActive(false);
                            NPCScroll.transform.gameObject.SetActive(false);
                            bush.transform.gameObject.SetActive(true);
                            TextBox.transform.gameObject.SetActive(true);
                            CharacterScroll.transform.gameObject.SetActive(true);
                            BackGround.sprite = Resources.Load<Sprite>("Dino_BG02");
                            count++;
                            break;
                        case 15:
                            bush.transform.gameObject.SetActive(false);
                            egu.transform.gameObject.SetActive(true);
                            KingTextBox.transform.gameObject.SetActive(true);
                            NPCScroll.transform.gameObject.SetActive(true);
                            BackGround.sprite = Resources.Load<Sprite>("제천마을");
                            count++;
                            break;
                        case 16:
                            KingText.text = string.Empty;
                            KingTextBox.transform.gameObject.SetActive(false);
                            NPCScroll.transform.gameObject.SetActive(false);
                            count++;
                            break;
                        case 17:
                            KingTextBox.transform.gameObject.SetActive(true);
                            NPCScroll.transform.gameObject.SetActive(true);
                            count++;
                            break;
                        case 18:
                            egu.transform.gameObject.SetActive(false);
                            KingTextBox.transform.gameObject.SetActive(false);
                            KingText.text = string.Empty;
                            NPCScroll.transform.gameObject.SetActive(false);
                            trex_eat.transform.gameObject.SetActive(true);
                            BackGround.sprite = Resources.Load<Sprite>("Dino_BG03");
                            count++;
                            break;
                        case 20:
                            BackGround.sprite = Resources.Load<Sprite>("제천마을");
                            TextBox.transform.gameObject.SetActive(true);
                            CharacterScroll.transform.gameObject.SetActive(true);
                            KingTextBox.transform.gameObject.SetActive(true);
                            NPCScroll.transform.gameObject.SetActive(true);
                            trex_eat.transform.gameObject.SetActive(false);
                            CH3.transform.gameObject.SetActive(false);
                            egu.transform.gameObject.SetActive(true);
                            dino_small.transform.gameObject.SetActive(true);
                            count++;
                            break;
                        case 21:
                            switch (tempInt)
                            {
                                case 1:
                                    if (linkQuizManager.ImgLinkClear == false)
                                    {
                                        if (AppManage.Instance.Gender == 0)
                                        {
                                            CH1_nomal.gameObject.SetActive(false);
                                            CH2_nomal.gameObject.SetActive(true);
                                            CH3.transform.gameObject.SetActive(false);
                                            dino_small.transform.gameObject.SetActive(false);
                                            egu.transform.gameObject.SetActive(false);
                                            CHS.SetTrigger("CH2Anim");
                                        }
                                        else
                                        {
                                            CH1_nomal.gameObject.SetActive(true);
                                            CH2_nomal.gameObject.SetActive(false);
                                            CH3.transform.gameObject.SetActive(false);
                                            dino_small.transform.gameObject.SetActive(false);
                                            egu.transform.gameObject.SetActive(false);
                                            CHS.SetTrigger("CH1Anim");
                                        }
                                        ImgLinkCanvas.transform.gameObject.SetActive(true);
                                        str.transform.gameObject.SetActive(false);
                                        TextBox.transform.gameObject.SetActive(false);
                                        CharacterScroll.transform.gameObject.SetActive(false);
                                        KingText.transform.gameObject.SetActive(false);
                                        KingTextBox.transform.gameObject.SetActive(false);
                                        NPCScroll.transform.gameObject.SetActive(false);
                                        linkQuizManager.GenerateImgLinkQuiz(1, tempInt);
                                    }
                                    else
                                    {
                                        linkQuizManager.OptionClear = false;
                                        linkQuizManager.ImgLinkClear = false;
                                        ImgLinkCanvas.transform.gameObject.SetActive(false);
                                        str.text = string.Empty;
                                        str.transform.gameObject.SetActive(true);
                                        TextBox.transform.gameObject.SetActive(true);
                                        CharacterScroll.transform.gameObject.SetActive(true);
                                        KingText.text = string.Empty;
                                        KingText.transform.gameObject.SetActive(true);
                                        NPCScroll.transform.gameObject.SetActive(true);
                                        count++;
                                    }
                                    break;
                            }
                            break;
                        case 22:
                            egu.transform.gameObject.SetActive(true);
                            KingTextBox.transform.gameObject.SetActive(true);
                            NPCScroll.transform.gameObject.SetActive(true);
                            count++;
                            break;
                        case 23:
                            canvas.renderMode = RenderMode.ScreenSpaceOverlay;
                            AppManage.Instance.isComplite = true;
                            GameObject.Find("UIManager").SendMessage("CaptureOn");
                            break;
                        default:
                            count++;
                            break;
                    }
                    break;
                case 3:
                    switch (count)
                    {
                        case 0:
                            icon360.transform.gameObject.SetActive(false);
                            sphere.transform.gameObject.SetActive(false);
                            Controller.transform.gameObject.SetActive(false);
                            BackGround.transform.gameObject.SetActive(true);
                            PopUp.transform.gameObject.SetActive(true);
                            PopUpText.transform.gameObject.SetActive(true);
                            PopUpScroll.transform.gameObject.SetActive(true);
                            GameObject.Find("WebManager").SendMessage("initURL", "https://museum.goseong.go.kr/index.goseong");
                            Link.transform.gameObject.SetActive(false);
                            //tempText = GameObject.Find("Text").GetComponent<Text>();
                            //tempText.text = "공룡박물관 홈페이지";
                            str.text = string.Empty;
                            TextBox.transform.gameObject.SetActive(false);
                            CharacterScroll.transform.gameObject.SetActive(false);
                            count++;
                            break;
                        case 1:     // satge 3의 퀴즈
                            switch (tempInt)
                            {
                                case 0:
                                    if (linkQuizManager.OptionClear == false)
                                    {
                                        PopUp.transform.gameObject.SetActive(false);
                                        PopUpText.transform.gameObject.SetActive(false);
                                        PopUpScroll.transform.gameObject.SetActive(false);
                                        Link.transform.gameObject.SetActive(false);
                                        linkQuizManager.GenerateOptionQuiz(2, tempInt);
                                        OptionCanvas.transform.gameObject.SetActive(true);
                                        if (AppManage.Instance.Gender == 0)
                                        {
                                            CH1_nomal.gameObject.SetActive(false);
                                            CH2_nomal.gameObject.SetActive(true);
                                            CH3.transform.gameObject.SetActive(false);
                                            CHS.SetTrigger("CH2Anim");
                                        }
                                        else
                                        {
                                            CH1_nomal.gameObject.SetActive(true);
                                            CH2_nomal.gameObject.SetActive(false);
                                            CH3.transform.gameObject.SetActive(false);
                                            CHS.SetTrigger("CH1Anim");
                                        }
                                    }
                                    else
                                    {
                                        tempInt++;
                                        linkQuizManager.ImgOptionClear = false;
                                        OptionCanvas.transform.gameObject.SetActive(false);
                                        ImgOptionCanvas.transform.gameObject.SetActive(true);
                                        linkQuizManager.GenerateImgOptionQuiz(2, tempInt);

                                    }
                                    break;
                                case 1:
                                    if (linkQuizManager.ImgOptionClear == false)
                                    {
                                        OptionCanvas.transform.gameObject.SetActive(false);
                                        ImgOptionCanvas.transform.gameObject.SetActive(true);

                                    }
                                    else
                                    {
                                        ImgOptionCanvas.transform.gameObject.SetActive(false);
                                        TextBox.transform.gameObject.SetActive(true);
                                        str.transform.gameObject.SetActive(true);
                                        CharacterScroll.transform.gameObject.SetActive(true);
                                        count++;
                                    }
                                    break;
                            }
                            break;

                        case 2:     // 퀴즈 후 해설
                            //퀴즈 캔버스 끄기
                            AppManage.Instance.EndStage(currentStage);
                            break;

                        //case 3:                            
                        //    break;
                    }
                    break;
                case 4:
                    switch(count)
                    {
                        case 0:
                            icon360.transform.gameObject.SetActive(false);
                            sphere.transform.gameObject.SetActive(false);
                            Controller.transform.gameObject.SetActive(false);
                            BackGround.transform.gameObject.SetActive(true);
                            PopUp.transform.gameObject.SetActive(true);
                            PopUpText.transform.gameObject.SetActive(true);
                            PopUpScroll.transform.gameObject.SetActive(true);
                            str.text = string.Empty;
                            TextBox.transform.gameObject.SetActive(false);
                            CharacterScroll.transform.gameObject.SetActive(false);
                            GameObject.Find("WebManager").SendMessage("initURL", "https://dhp.goseong.go.kr/index.goseong");
                            Link.transform.gameObject.SetActive(false);
                            //tempText = GameObject.Find("Text").GetComponent<Text>();
                            //tempText.text = "당항포 공식 홈페이지";
                            count++;
                            break;

                        case 1:         //퀴즈
                            switch (tempInt)
                            {
                                case 0:
                                    if (linkQuizManager.OptionClear == false)
                                    {
                                        PopUpText.transform.gameObject.SetActive(false);
                                        PopUp.transform.gameObject.SetActive(false);
                                        PopUpScroll.transform.gameObject.SetActive(false);
                                        Link.transform.gameObject.SetActive(false);
                                        Link.transform.gameObject.SetActive(false);
                                        linkQuizManager.GenerateOptionQuiz(3, tempInt);
                                        OptionCanvas.transform.gameObject.SetActive(true);
                                        if (AppManage.Instance.Gender == 0)
                                        {
                                            CH1_nomal.gameObject.SetActive(false);
                                            CH2_nomal.gameObject.SetActive(true);
                                            CH3.transform.gameObject.SetActive(false);
                                            CHS.SetTrigger("CH2Anim");
                                        }
                                        else
                                        {
                                            CH1_nomal.gameObject.SetActive(true);
                                            CH2_nomal.gameObject.SetActive(false);
                                            CH3.transform.gameObject.SetActive(false);
                                            CHS.SetTrigger("CH1Anim");
                                        }
                                    }
                                    else
                                    {
                                        tempInt++;
                                        OptionCanvas.transform.gameObject.SetActive(false);
                                        str.transform.gameObject.SetActive(true);
                                        TextBox.transform.gameObject.SetActive(true);
                                        CharacterScroll.transform.gameObject.SetActive(true);
                                        linkQuizManager.LinkClear = false;
                                        count++;
                                    }
                                    break;                    
                            }
                            break;
                        case 2:
                            switch (tempInt)
                            {
                                case 1:
                                    if (linkQuizManager.LinkClear == false)
                                    {
                                        str.transform.gameObject.SetActive(false);
                                        TextBox.transform.gameObject.SetActive(false);
                                        CharacterScroll.transform.gameObject.SetActive(false);
                                        LinkCanvas.transform.gameObject.SetActive(true);
                                        linkQuizManager.GenerateLinkQuiz(3, tempInt);
                                        tempInt++;
                                    }
                                    break;
                                case 2:
                                    if(linkQuizManager.LinkClear == true)
                                    {
                                        AppManage.Instance.EndStage(currentStage);
                                    }
                                    break;
                            }
                            break;
                    }
                    break;
                case 5:
                    switch (count)
                    {
                        case 0:
                            tempInt = 0;
                            icon360.transform.gameObject.SetActive(false);
                            sphere.transform.gameObject.SetActive(false);
                            Controller.transform.gameObject.SetActive(false);
                            BackGround.transform.gameObject.SetActive(true);
                            PopUp.transform.gameObject.SetActive(true);
                            PopUpText.transform.gameObject.SetActive(true);
                            PopUpScroll.transform.gameObject.SetActive(true);
                            GameObject.Find("WebManager").SendMessage("initURL", "http://www.dinopark.net/index.goseong?menuCd=DOM_000001104002004000");
                            Link.transform.gameObject.SetActive(true);
                            tempText = GameObject.Find("Text").GetComponent<Text>();
                            tempText.text = "사이버 공룡 테마파크 홈페이지";
                            str.text = string.Empty;
                            TextBox.transform.gameObject.SetActive(false);
                            CharacterScroll.transform.gameObject.SetActive(false);
                            count++;
                            break;

                        case 1:         //퀴즈
                            switch (tempInt)
                            {
                                case 0:
                                    if (linkQuizManager.OptionClear == false)
                                    {
                                        PopUpText.text = string.Empty;
                                        PopUp.transform.gameObject.SetActive(false);
                                        PopUpText.transform.gameObject.SetActive(false);
                                        PopUpScroll.transform.gameObject.SetActive(false);
                                        Link.transform.gameObject.SetActive(false);
                                        linkQuizManager.GenerateOptionQuiz(4, tempInt);
                                        OptionCanvas.transform.gameObject.SetActive(true);
                                        if (AppManage.Instance.Gender == 0)
                                        {
                                            CH1_nomal.gameObject.SetActive(false);
                                            CH2_nomal.gameObject.SetActive(true);
                                            CH3.transform.gameObject.SetActive(false);
                                            CHS.SetTrigger("CH2Anim");
                                        }
                                        else
                                        {
                                            CH1_nomal.gameObject.SetActive(true);
                                            CH2_nomal.gameObject.SetActive(false);
                                            CH3.transform.gameObject.SetActive(false);
                                            CHS.SetTrigger("CH1Anim");
                                        }
                                    }
                                    else
                                    {
                                        tempInt++;
                                        OptionCanvas.transform.gameObject.SetActive(false);
                                        linkQuizManager.LinkClear = false;
                                        LinkCanvas.transform.gameObject.SetActive(true);
                                        linkQuizManager.GenerateLinkQuiz(4, tempInt);
                                        //count++;
                                    }
                                    break;

                                case 1:
                                    if (linkQuizManager.LinkClear == true)
                                    {
                                        AppManage.Instance.EndStage(currentStage);
                                    }
                                    break;
                            }
                            break;

                    }
                   break;

        }

            switch(currentStage)        //텍스트를 뿌려주기 위한 스위치문
            {
                case 1:
                    switch(count)
                    {
                        case 0:
                        case 1:
                        case 3:
                        case 6:
                        case 7:
                        case 13:
                        case 18:
                        case 20:
                        case 26:
                        case 27:
                            text = Science_Text_Script1.Instance.scenario[currentStage].text[Science_Text_Script1.Instance.scenario[currentStage].Num[count]];
                            if (text.Contains("###"))
                            {
                                string temp = text.Replace("###", AppManage.Instance.Name);
                                GameObject.Find("TypingManager").GetComponent<TypingManager>().TypingText(temp, str);
                            }
                            else
                            {
                                GameObject.Find("TypingManager").GetComponent<TypingManager>().TypingText(text, str);
                            }
                            break;
                        case 10:
                        case 11:
                        case 15:
                        case 16:
                        case 17:
                        case 22:
                        case 23:
                        case 24:
                        case 25:
                            text = Science_Text_Script1.Instance.scenario[currentStage].text[Science_Text_Script1.Instance.scenario[currentStage].Num[count]];
                            if (text.Contains("###"))
                            {
                                string temp = text.Replace("###", AppManage.Instance.Name);
                                GameObject.Find("TypingManager").GetComponent<TypingManager>().TypingText(temp, PopUpText);
                            }
                            else
                            {
                                GameObject.Find("TypingManager").GetComponent<TypingManager>().TypingText(text, PopUpText);
                            }
                            break;
                        case 21:
                            break;
                        default:
                            text = Science_Text_Script1.Instance.scenario[currentStage].text[Science_Text_Script1.Instance.scenario[currentStage].Num[count]];
                            if (text.Contains("###"))
                            {
                                string temp = text.Replace("###", AppManage.Instance.Name);
                                GameObject.Find("TypingManager").GetComponent<TypingManager>().TypingText(temp, KingText);
                            }
                            else
                            {
                                GameObject.Find("TypingManager").GetComponent<TypingManager>().TypingText(text, KingText);
                            }
                            break;
                    }
                    break;
                case 2:
                    switch(count)
                    {
                        case 1:
                        case 3:
                        case 5:
                        case 8:                 
                        case 10:
                        case 15:
                        case 17:
                        case 19:
                        case 20:
                        case 22:
                            text = Science_Text_Script1.Instance.scenario[currentStage].text[Science_Text_Script1.Instance.scenario[currentStage].Num[count]];
                            if (text.Contains("###"))
                            {
                                string temp = text.Replace("###", AppManage.Instance.Name);
                                GameObject.Find("TypingManager").GetComponent<TypingManager>().TypingText(temp, str);
                            }
                            else
                            {
                                GameObject.Find("TypingManager").GetComponent<TypingManager>().TypingText(text , str);
                            }
                            break;
                        case 6:
                        case 7:
                        case 12:
                            text = Science_Text_Script1.Instance.scenario[currentStage].text[Science_Text_Script1.Instance.scenario[currentStage].Num[count]];
                            if (text.Contains("###"))
                            {
                                string temp = text.Replace("###", AppManage.Instance.Name);
                                GameObject.Find("TypingManager").GetComponent<TypingManager>().TypingText(temp, PopUpText);
                            }
                            else
                            {
                                GameObject.Find("TypingManager").GetComponent<TypingManager>().TypingText(text, PopUpText);
                            }
                            break;
                        case 16:
                        case 18:
                        case 21:
                        case 23:
                            text = Science_Text_Script1.Instance.scenario[currentStage].text[Science_Text_Script1.Instance.scenario[currentStage].Num[count]];
                            if (text.Contains("###"))
                            {
                                string temp = text.Replace("###", AppManage.Instance.Name);
                                GameObject.Find("TypingManager").GetComponent<TypingManager>().TypingText(temp, KingText);
                                GameObject.Find("TypingManager").GetComponent<TypingManager>().TypingText2(temp, str);
                            }
                            else
                            {
                                GameObject.Find("TypingManager").GetComponent<TypingManager>().TypingText(text, KingText);
                                GameObject.Find("TypingManager").GetComponent<TypingManager>().TypingText2(text, str);
                            }
                            break;
                        default:
                            text = Science_Text_Script1.Instance.scenario[currentStage].text[Science_Text_Script1.Instance.scenario[currentStage].Num[count]];
                            if (text.Contains("###"))
                            {
                                string temp = text.Replace("###", AppManage.Instance.Name);
                                GameObject.Find("TypingManager").GetComponent<TypingManager>().TypingText(temp, KingText);
                            }
                            else
                            {
                                GameObject.Find("TypingManager").GetComponent<TypingManager>().TypingText(text, KingText);
                            }
                            break;
                    }
                    break;
                case 3:
                    switch(count)
                    {
                        case 1:
                            text = Science_Text_Script1.Instance.scenario[currentStage].text[Science_Text_Script1.Instance.scenario[currentStage].Num[count]];
                            if (text.Contains("###"))
                            {
                                string temp = text.Replace("###", AppManage.Instance.Name);
                                GameObject.Find("TypingManager").GetComponent<TypingManager>().TypingText(temp, PopUpText);
                            }
                            else
                            {
                                GameObject.Find("TypingManager").GetComponent<TypingManager>().TypingText(text, PopUpText);
                            }
                            break;
                        default:
                            text = Science_Text_Script1.Instance.scenario[currentStage].text[Science_Text_Script1.Instance.scenario[currentStage].Num[count]];
                            if (text.Contains("###"))
                            {
                                string temp = text.Replace("###", AppManage.Instance.Name);
                                GameObject.Find("TypingManager").GetComponent<TypingManager>().TypingText(temp, str);
                            }
                            else
                            {
                                GameObject.Find("TypingManager").GetComponent<TypingManager>().TypingText(text, str);
                            }
                            break;

                    }
                    break;
                case 4:
                    switch (count)
                    {
                        case 1:
                            text = Science_Text_Script1.Instance.scenario[currentStage].text[Science_Text_Script1.Instance.scenario[currentStage].Num[count]];
                            if (text.Contains("###"))
                            {
                                string temp = text.Replace("###", AppManage.Instance.Name);
                                GameObject.Find("TypingManager").GetComponent<TypingManager>().TypingText(temp, PopUpText);
                            }
                            else
                            {
                                GameObject.Find("TypingManager").GetComponent<TypingManager>().TypingText(text, PopUpText);
                            }
                            break;
                        case 2:
                            text = Science_Text_Script1.Instance.scenario[currentStage].text[Science_Text_Script1.Instance.scenario[currentStage].Num[count]];
                            if (text.Contains("###"))
                            {
                                string temp = text.Replace("###", AppManage.Instance.Name);
                                GameObject.Find("TypingManager").GetComponent<TypingManager>().TypingText(temp, str);
                            }
                            else
                            {
                                GameObject.Find("TypingManager").GetComponent<TypingManager>().TypingText(text, str);
                            }
                            break;
                        default:
                            text = Science_Text_Script1.Instance.scenario[currentStage].text[Science_Text_Script1.Instance.scenario[currentStage].Num[count]];
                            if (text.Contains("###"))
                            {
                                string temp = text.Replace("###", AppManage.Instance.Name);
                                GameObject.Find("TypingManager").GetComponent<TypingManager>().TypingText(temp, str);
                            }
                            else
                            {
                                GameObject.Find("TypingManager").GetComponent<TypingManager>().TypingText(text, str);
                            }
                            break;
                    }
                    break;
                case 5:
                    switch (count)
                    {
                        case 1:
                            text = Science_Text_Script1.Instance.scenario[currentStage].text[Science_Text_Script1.Instance.scenario[currentStage].Num[count]];
                            if (text.Contains("###"))
                            {
                                string temp = text.Replace("###", AppManage.Instance.Name);
                                GameObject.Find("TypingManager").GetComponent<TypingManager>().TypingText(temp, PopUpText);
                            }
                            else
                            {
                                GameObject.Find("TypingManager").GetComponent<TypingManager>().TypingText(text, PopUpText);
                            }
                            break;
                        default:
                            text = Science_Text_Script1.Instance.scenario[currentStage].text[Science_Text_Script1.Instance.scenario[currentStage].Num[count]];
                            if (text.Contains("###"))
                            {
                                string temp = text.Replace("###", AppManage.Instance.Name);
                                GameObject.Find("TypingManager").GetComponent<TypingManager>().TypingText(temp, str);
                            }
                            else
                            {
                                GameObject.Find("TypingManager").GetComponent<TypingManager>().TypingText(text, str);
                            }
                            break;
                    }
                    break;
            }

            // 에니메이션이 출력되는 오브젝트들 활성화
            switch (currentStage)
            {
                case 1:
                    switch (count)
                    {
                        case 1:
                        case 2:
                        case 3:
                        case 4:
                        case 5:
                        case 6:
                        case 8:
                        case 9:
                        case 12:
                        case 14:
                        case 18:
                        case 19:
                        case 20:
                        case 27:
                        case 28:
                        case 29:
                            if (AppManage.Instance.Gender == 0)
                            {
                                CH1_nomal.gameObject.SetActive(false);
                                CH2_nomal.gameObject.SetActive(true);
                                CH3.gameObject.SetActive(false);
                                dino_small.transform.gameObject.SetActive(false);
                            }
                            else
                            {
                                CH1_nomal.gameObject.SetActive(true);
                                CH2_nomal.gameObject.SetActive(false);
                                CH3.gameObject.SetActive(false);
                                dino_small.transform.gameObject.SetActive(false);
                            }
                            break;
                        case 7:
                        case 15:
                        case 16:
                        case 26:
                            CH1_nomal.gameObject.SetActive(false);
                            CH2_nomal.gameObject.SetActive(false);
                            CH3.transform.gameObject.SetActive(false);
                            dino_small.transform.gameObject.SetActive(true);
                            break;
                        case 17:
                        case 25:
                            break;
                        default:
                            CH1_nomal.gameObject.SetActive(false);
                            CH2_nomal.gameObject.SetActive(false);
                            CH3.transform.gameObject.SetActive(true);
                            dino_small.transform.gameObject.SetActive(false);
                            break;
                    }
                    break;
                case 2:
                    switch (count)
                    {
                        case 1:
                        case 2:
                        case 4:
                        case 8:
                        case 9:
                        case 10:
                        case 11:
                        case 13:
                        case 14:
                        case 17:
                        case 22:
                            if (AppManage.Instance.Gender == 0)
                            {
                                CH1_nomal.gameObject.SetActive(false);
                                CH2_nomal.gameObject.SetActive(true);
                                CH3.gameObject.SetActive(false);
                                dino_small.transform.gameObject.SetActive(false);
                            }
                            else
                            {
                                CH1_nomal.gameObject.SetActive(true);
                                CH2_nomal.gameObject.SetActive(false);
                                CH3.gameObject.SetActive(false);
                                dino_small.transform.gameObject.SetActive(false);
                            }
                            break;
                        case 16:
                        case 18:
                        case 23:
                            CH1_nomal.transform.gameObject.SetActive(false);
                            CH2_nomal.transform.gameObject.SetActive(false);
                            CH3.transform.gameObject.SetActive(false);
                            dino_small.transform.gameObject.SetActive(true);
                            break;
                        case 3:
                        case 21:
                            break;
                        default:            
                            CH1_nomal.transform.gameObject.SetActive(false);
                            CH2_nomal.transform.gameObject.SetActive(false);
                            CH3.transform.gameObject.SetActive(true);
                            dino_small.transform.gameObject.SetActive(false);
                            break;
                    }
                    break;
                case 3:
                    switch (count)          // 순천만습지입구 에니메이션이 출력되는 오브젝트 활성화
                    {
                        case 1:
                            break;
                        default:
                            CH1_nomal.gameObject.SetActive(false);
                            CH2_nomal.gameObject.SetActive(false);
                            CH3.gameObject.SetActive(true);
                            break;
                    }
                    break;
                case 4:
                    switch (count)
                    {
                        case 1:
                            break;
                        default:
                            CH1_nomal.gameObject.SetActive(false);
                            CH2_nomal.gameObject.SetActive(false);
                            CH3.gameObject.SetActive(true);
                            break;
                    }
                    break;
                case 5:
                    switch (count)
                    {
                        case 1:
                            break;
                        default:
                            CH1_nomal.gameObject.SetActive(false);
                            CH2_nomal.gameObject.SetActive(false);
                            CH3.gameObject.SetActive(true);
                            break;
                    }
                    break;

                default:
                    break;
            }
            // 플레이어 에니메이션을 키기 위한 if문(anim 배열에 *인 위치가 플레이어 에니메이션 부분이므로)
            if (Science_Text_Script1.Instance.scenario[currentStage].anim[Science_Text_Script1.Instance.scenario[currentStage].Num[count]] == "*")
            {
                if (AppManage.Instance.Gender == 0)
                {
                    CHS.SetTrigger("CH2Anim");
                }
                else
                {
                    CHS.SetTrigger("CH1Anim");
                }
            }
            else        //npc 에니메이션을 키기 위한 else문
            {
                if (currentStage == 1)
                {
                    if(count!=17&&count!=25)
                    {
                        CHS.SetTrigger(Science_Text_Script1.Instance.scenario[currentStage].anim[Science_Text_Script1.Instance.scenario[currentStage].Num[count]]);
                    }
                }
                else if(currentStage == 2)
                {
                    if(count!=3&&count!=21)
                    {
                        CHS.SetTrigger(Science_Text_Script1.Instance.scenario[currentStage].anim[Science_Text_Script1.Instance.scenario[currentStage].Num[count]]);
                    }
                }
                else if(currentStage==3)
                {
                    if(count!=1)
                    {
                        CHS.SetTrigger(Science_Text_Script1.Instance.scenario[currentStage].anim[Science_Text_Script1.Instance.scenario[currentStage].Num[count]]);
                    }
                }

                else if (currentStage == 4)
                {
                    if (count != 1)
                    {
                        CHS.SetTrigger(Science_Text_Script1.Instance.scenario[currentStage].anim[Science_Text_Script1.Instance.scenario[currentStage].Num[count]]);
                    }
                }

                else if (currentStage == 5)
                {
                    if (count != 1)
                    {
                        CHS.SetTrigger(Science_Text_Script1.Instance.scenario[currentStage].anim[Science_Text_Script1.Instance.scenario[currentStage].Num[count]]);
                    }
                }
            } 
   
            AppManage.Instance.isComplite = false;
            if(currentStage==1)
            {
                if(count==21)
                {
                    AppManage.Instance.isComplite = true;
                }
            }
            else if(currentStage==2)
            {
                if(count==23)
                {
                    AppManage.Instance.isComplite = true;
                }
            }
        }
        else
        {
            AppManage.Instance.isClicked = true;
            AppManage.Instance.isClicked2 = true;

        }
    }
    // 뒤로 가기 화살표를 누를 시
    public void BeforeDown()
    {
        Text tempText;
        if (AppManage.Instance.isComplite)
        {
            if (count > 0)
            {
                count--;
            }
            else
            {
                SceneManager.LoadScene("SelectMap");
            }
            switch (currentStage)       // 키는 건 앞으로(forward case보다 +1) 끄는건 뒤로(forward case보다 -1)
            {
                case 1:
                    switch (count)
                    {
                        case 1:
                            dino_big.transform.gameObject.SetActive(false);
                            KingText.text = string.Empty;
                            KingTextBox.transform.gameObject.SetActive(false);
                            NPCScroll.transform.gameObject.SetActive(false);
                            TextBox.transform.gameObject.SetActive(true);
                            CharacterScroll.transform.gameObject.SetActive(true);
                            break;
                        case 2:
                            dino_big.transform.gameObject.SetActive(true);
                            dino_big.SetTrigger("dinoOpennig");
                            str.text = string.Empty;
                            TextBox.transform.gameObject.SetActive(false);
                            CharacterScroll.transform.gameObject.SetActive(false);
                            KingTextBox.transform.gameObject.SetActive(true);
                            NPCScroll.transform.gameObject.SetActive(true);
                            break;
                        case 3:
                        case 13:
                        case 18:
                        case 27:
                            KingText.text = string.Empty;
                            KingTextBox.transform.gameObject.SetActive(false);
                            NPCScroll.transform.gameObject.SetActive(false);
                            TextBox.transform.gameObject.SetActive(true);
                            CharacterScroll.transform.gameObject.SetActive(true);
                            break;
                        case 5:
                            str.text = string.Empty;
                            TextBox.transform.gameObject.SetActive(false);
                            CharacterScroll.transform.gameObject.SetActive(false);
                            KingTextBox.transform.gameObject.SetActive(true);
                            NPCScroll.transform.gameObject.SetActive(true);
                            break;
                        case 6:
                            BackGround.transform.gameObject.SetActive(true);
                            sphere.transform.gameObject.SetActive(false);
                            Controller.transform.gameObject.SetActive(false);
                            icon360.transform.gameObject.SetActive(false);
                            dino_big.transform.gameObject.SetActive(true);
                            break;
                        case 7:
                            BackGround.transform.gameObject.SetActive(false);
                            sphere.transform.gameObject.SetActive(true);
                            Controller.transform.gameObject.SetActive(true);
                            icon360.transform.gameObject.SetActive(true);
                            dino_small.transform.gameObject.SetActive(true);
                            dino_big.transform.gameObject.SetActive(false);
                            KingText.text = string.Empty;
                            KingText.transform.gameObject.SetActive(true);
                            KingTextBox.transform.gameObject.SetActive(false);
                            NPCScroll.transform.gameObject.SetActive(false);
                            TextBox.transform.gameObject.SetActive(true);
                            CharacterScroll.transform.gameObject.SetActive(true);
                            tempInt = 0;
                            linkQuizManager.OptionClear = false;
                            OptionCanvas.transform.gameObject.SetActive(false);
                            break;
                        case 8:
                            tempInt = 0;
                            linkQuizManager.OptionClear = false;
                            OptionCanvas.transform.gameObject.SetActive(false);
                            break;
                        case 9:
                            groundHistroy.transform.gameObject.SetActive(false);
                            dino_big.transform.gameObject.SetActive(true);
                            KingTextBox.transform.gameObject.SetActive(true);
                            NPCScroll.transform.gameObject.SetActive(true);
                            PopUp.transform.gameObject.SetActive(false);
                            PopUpText.text = string.Empty;
                            PopUpScroll.transform.gameObject.SetActive(false);
                            break;
                        case 10:
                            groundHistroy.SetTrigger("Rewind");
                            break;
                        case 11:
                            dino_big.transform.gameObject.SetActive(false);
                            KingText.text=string.Empty;
                            KingTextBox.transform.gameObject.SetActive(false);
                            NPCScroll.transform.gameObject.SetActive(false);
                            PopUp.transform.gameObject.SetActive(true);
                            PopUpScroll.transform.gameObject.SetActive(true);
                            groundHistroy.transform.gameObject.SetActive(true);
                            OptionCanvas.transform.gameObject.SetActive(false);
                            linkQuizManager.OptionClear = false;
                            tempInt = 1;
                            groundHistroy.SetTrigger("Ground");
                            break;
                        case 12:
                            tempInt = 1;
                            OptionCanvas.transform.gameObject.SetActive(false);
                            linkQuizManager.OptionClear = false;
                            KingTextBox.transform.gameObject.SetActive(true);
                            NPCScroll.transform.gameObject.SetActive(true);
                            str.text = string.Empty;
                            TextBox.transform.gameObject.SetActive(false);
                            CharacterScroll.transform.gameObject.SetActive(false);
                            break;
                        case 14:
                            PopUp.transform.gameObject.SetActive(false);
                            PopUpText.text = string.Empty;
                            PopUpScroll.transform.gameObject.SetActive(false);
                            floor.transform.gameObject.SetActive(false);
                            dino_big.transform.gameObject.SetActive(true);
                            KingTextBox.transform.gameObject.SetActive(true);
                            NPCScroll.transform.gameObject.SetActive(true);
                            break;
                        case 15:
                            floor.transform.gameObject.SetActive(true);
                            floor.sprite = Resources.Load<Sprite>("수평지층");
                            linkQuizManager.OptionClear = false;
                            break;
                        case 16:
                            floor.transform.gameObject.SetActive(true);
                            floor.sprite = Resources.Load<Sprite>("휘어진 지층");
                            PopUp.transform.gameObject.SetActive(true);
                            PopUpText.transform.gameObject.SetActive(true);
                            PopUpScroll.transform.gameObject.SetActive(true);
                            //floor.sprite = Resources.Load<Sprite>("끊어진 지층");     
                            OptionCanvas.transform.gameObject.SetActive(false);
                            linkQuizManager.OptionClear = false;
                            tempInt = 2;           
                            break;
                        case 17:
                            tempInt = 2;
                            linkQuizManager.OptionClear = false;
                            linkQuizManager.ImgOptionClear = false;
                            OptionCanvas.transform.gameObject.SetActive(false);
                            floor.sprite = Resources.Load<Sprite>("수평지층");
                            floor.transform.gameObject.SetActive(true);
                            dino_big.transform.gameObject.SetActive(false);
                            PopUp.transform.gameObject.SetActive(true);
                            PopUpScroll.transform.gameObject.SetActive(true);
                            str.text = string.Empty;
                            TextBox.transform.gameObject.SetActive(false);
                            CharacterScroll.transform.gameObject.SetActive(false);
                            CH1_nomal.transform.gameObject.SetActive(false);
                            CH2_nomal.transform.gameObject.SetActive(false);
                            CH3.transform.gameObject.SetActive(false);
                            dino_small.transform.gameObject.SetActive(true);
                            break;
                        case 19:
                            str.text = string.Empty;
                            TextBox.transform.gameObject.SetActive(false);
                            CharacterScroll.transform.gameObject.SetActive(false);
                            KingTextBox.transform.gameObject.SetActive(true);
                            NPCScroll.transform.gameObject.SetActive(true);
                            break;
                        case 20:
                            PopUp.transform.gameObject.SetActive(false);
                            PopUpScroll.transform.gameObject.SetActive(false);
                            dino_big.transform.gameObject.SetActive(true);
                            dino_run.transform.gameObject.SetActive(false);
                            TextBox.transform.gameObject.SetActive(true);
                            CharacterScroll.transform.gameObject.SetActive(true);
                            break;
                        case 21:
                            dinosaurImage.transform.gameObject.SetActive(false);
                            dino_run.transform.gameObject.SetActive(true);
                            dino_run.GetComponent<Movement>().ResetPosition();
                            dino_run.GetComponent<Movement>().running = true;
                            PopUpText.text = string.Empty;
                            break;
                        case 22:
                            dinosaurImage.transform.gameObject.SetActive(true);
                            dinosaurImage.sprite = Resources.Load<Sprite>("footprint_01");
                            break;
                        case 23:
                            dinosaurImage.sprite = Resources.Load<Sprite>("footprint_03");
                            break;
                        case 24:
                            PopUp.transform.gameObject.SetActive(true);
                            PopUpText.transform.gameObject.SetActive(true);
                            PopUpScroll.transform.gameObject.SetActive(true);
                            dinosaurImage.sprite = Resources.Load<Sprite>("footprint_04");
                            dinosaurImage.transform.gameObject.SetActive(true);
                            footImage.transform.gameObject.SetActive(false);
                            ImgOptionCanvas.transform.gameObject.SetActive(false);
                            linkQuizManager.ImgOptionClear = false;
                            break;
                        case 25:    //발자국 이미지
                            dinosaurImage.transform.gameObject.SetActive(false);
                            footImage.sprite = Resources.Load<Sprite>("용각류 발자국");
                            footImage.transform.gameObject.SetActive(true);
                            str.text = string.Empty;
                            TextBox.transform.gameObject.SetActive(false);
                            CharacterScroll.transform.gameObject.SetActive(false);
                            CH1_nomal.transform.gameObject.SetActive(false);
                            CH2_nomal.transform.gameObject.SetActive(false);
                            CH3.transform.gameObject.SetActive(true);
                            dino_big.transform.gameObject.SetActive(false);
                            CHS.SetTrigger("teachAnim");
                            PopUp.transform.gameObject.SetActive(true);
                            PopUpScroll.transform.gameObject.SetActive(true);
                            ImgOptionCanvas.transform.gameObject.SetActive(false);
                            linkQuizManager.ImgOptionClear = false;
                            break;
                        case 26:
                            footImage.transform.gameObject.SetActive(true);
                            dino_big.transform.gameObject.SetActive(false);
                            KingText.text = string.Empty;
                            KingTextBox.transform.gameObject.SetActive(false);
                            NPCScroll.transform.gameObject.SetActive(false);
                            TextBox.transform.gameObject.SetActive(true);
                            CharacterScroll.transform.gameObject.SetActive(true);
                            break;
                        default:                           
                            break;
                    }
                    break;
                case 2:
                    switch (count)
                    {
                        case 0:
                            sphere.transform.gameObject.SetActive(true);
                            Controller.transform.gameObject.SetActive(true);
                            icon360.transform.gameObject.SetActive(true);
                            BackGround.transform.gameObject.SetActive(false);
                            Camera.main.transform.rotation = Quaternion.Euler(Vector3.zero);
                            dino_big.transform.gameObject.SetActive(false);
                            break;
                        case 1:
                            KingText.text = string.Empty;
                            KingTextBox.transform.gameObject.SetActive(false);
                            NPCScroll.transform.gameObject.SetActive(false);
                            TextBox.transform.gameObject.SetActive(true);
                            CharacterScroll.transform.gameObject.SetActive(true);
                            dino_big.SetTrigger("dinoIdle");
                            break;
                        case 2:     //사진제시
                            footImage.transform.gameObject.SetActive(false);
                            str.text=string.Empty;
                            str.transform.gameObject.SetActive(true);
                            dino_big.transform.gameObject.SetActive(true);
                            TextBox.transform.gameObject.SetActive(false);
                            CharacterScroll.transform.gameObject.SetActive(false);
                            KingTextBox.transform.gameObject.SetActive(true);
                            NPCScroll.transform.gameObject.SetActive(true);
                            tempInt = 0;
                            OptionCanvas.transform.gameObject.SetActive(false);
                            linkQuizManager.OptionClear = false;
                            break;
                        case 3:
                            tempInt = 0;
                            dino_big.transform.gameObject.SetActive(false);
                            KingText.text = string.Empty;
                            KingTextBox.transform.gameObject.SetActive(false);
                            NPCScroll.transform.gameObject.SetActive(false);
                            str.transform.gameObject.SetActive(true);
                            TextBox.transform.gameObject.SetActive(true);
                            CharacterScroll.transform.gameObject.SetActive(true);
                            footImage.transform.gameObject.SetActive(true);
                            CH1_nomal.transform.gameObject.SetActive(false);
                            CH2_nomal.transform.gameObject.SetActive(false);
                            dino_small.transform.gameObject.SetActive(false);
                            CH3.transform.gameObject.SetActive(true);
                            CHS.SetTrigger("teachAnim");
                            break;
                        case 4:
                            BackGround.sprite = Resources.Load<Sprite>("제천마을");
                            greenDino_eat.transform.gameObject.SetActive(false);
                            dino_big.transform.gameObject.SetActive(true);
                            KingTextBox.transform.gameObject.SetActive(true);
                            NPCScroll.transform.gameObject.SetActive(true);
                            str.text = string.Empty;
                            TextBox.transform.gameObject.SetActive(false);
                            CharacterScroll.transform.gameObject.SetActive(false);
                            break;
                        case 5:
                            greenDino_eat.transform.gameObject.SetActive(true);
                            TextBox.transform.gameObject.SetActive(true);
                            CharacterScroll.transform.gameObject.SetActive(true);
                            dinosaurImage.transform.gameObject.SetActive(false);
                            PopUp.transform.gameObject.SetActive(false);
                            PopUpText.text = string.Empty;
                            PopUpScroll.transform.gameObject.SetActive(false);
                            break;
                        case 6:
                            dinosaurImage.sprite = Resources.Load<Sprite>("아파토사이즈");
                            break;
                        case 7:
                            dinosaurImage.sprite = Resources.Load<Sprite>("브라키오사이즈");
                            dinosaurImage.transform.gameObject.SetActive(true);
                            BackGround.sprite = Resources.Load<Sprite>("Dino_BG");
                            dino_big.transform.gameObject.SetActive(false);
                            str.text = string.Empty;
                            TextBox.transform.gameObject.SetActive(false);
                            CharacterScroll.transform.gameObject.SetActive(false);
                            PopUp.transform.gameObject.SetActive(true);
                            PopUpScroll.transform.gameObject.SetActive(true);
                            break;
                        case 8:
                            KingText.text = string.Empty;
                            KingTextBox.transform.gameObject.SetActive(false);
                            NPCScroll.transform.gameObject.SetActive(false);
                            TextBox.transform.gameObject.SetActive(true);
                            CharacterScroll.transform.gameObject.SetActive(true);
                            break;
                        case 9:
                            footImage.transform.gameObject.SetActive(false);
                            dino_big.transform.gameObject.SetActive(true);
                            str.text = string.Empty;
                            TextBox.transform.gameObject.SetActive(false);
                            CharacterScroll.transform.gameObject.SetActive(false);
                            KingTextBox.transform.gameObject.SetActive(true);
                            NPCScroll.transform.gameObject.SetActive(true);
                            break;
                        case 10:
                            footImage.transform.gameObject.SetActive(true);
                            egu.transform.gameObject.SetActive(false);
                            KingText.text = string.Empty;
                            KingTextBox.transform.gameObject.SetActive(false);
                            NPCScroll.transform.gameObject.SetActive(false);
                            TextBox.transform.gameObject.SetActive(true);
                            CharacterScroll.transform.gameObject.SetActive(true);
                            break;
                        case 11:
                            Iguanodon.transform.gameObject.SetActive(false);
                            PopUp.transform.gameObject.SetActive(false);
                            PopUpText.text = string.Empty;
                            PopUpScroll.transform.gameObject.SetActive(false);
                            egu.transform.gameObject.SetActive(true);
                            KingTextBox.transform.gameObject.SetActive(true);
                            NPCScroll.transform.gameObject.SetActive(true);
                            break;
                        case 12:        //팝업 해설 이미지
                            Iguanodon.transform.gameObject.SetActive(true);
                            PopUp.transform.gameObject.SetActive(true);
                            PopUpScroll.transform.gameObject.SetActive(true);
                            egu.transform.gameObject.SetActive(false);
                            KingTextBox.transform.gameObject.SetActive(false);
                            KingText.text = string.Empty;
                            NPCScroll.transform.gameObject.SetActive(false);
                            break;
                        case 13:
                            dino_big.transform.gameObject.SetActive(false);
                            egu.transform.gameObject.SetActive(true);
                            break;
                        case 14:
                            BackGround.sprite = Resources.Load<Sprite>("제천마을");
                            bush.transform.gameObject.SetActive(false);
                            str.text = string.Empty;
                            TextBox.transform.gameObject.SetActive(false);
                            CharacterScroll.transform.gameObject.SetActive(false);
                            KingTextBox.transform.gameObject.SetActive(true);
                            NPCScroll.transform.gameObject.SetActive(true);
                            dino_big.transform.gameObject.SetActive(true);
                            break;
                        case 15:
                            BackGround.sprite = Resources.Load<Sprite>("Dino_BG02");
                            bush.transform.gameObject.SetActive(true);
                            KingText.text = string.Empty;
                            KingTextBox.transform.gameObject.SetActive(false);
                            NPCScroll.transform.gameObject.SetActive(false);
                            egu.transform.gameObject.SetActive(false);
                            break;
                        case 16:
                            KingTextBox.transform.gameObject.SetActive(true);
                            NPCScroll.transform.gameObject.SetActive(true);
                            break;
                        case 17:
                            KingText.text = string.Empty;
                            KingTextBox.transform.gameObject.SetActive(false);
                            NPCScroll.transform.gameObject.SetActive(false);
                            break;
                        case 18:        //팝업 해설 이미지
                            BackGround.sprite = Resources.Load<Sprite>("제천마을");
                            trex_eat.transform.gameObject.SetActive(false);
                            egu.transform.gameObject.SetActive(true);
                            KingTextBox.transform.gameObject.SetActive(true);
                            NPCScroll.transform.gameObject.SetActive(true);
                            break;
                        case 20:
                            BackGround.sprite = Resources.Load<Sprite>("Dino_BG03");
                            egu.transform.gameObject.SetActive(false);
                            trex_eat.transform.gameObject.SetActive(true);
                            tempInt = 1;
                            ImgLinkCanvas.transform.gameObject.SetActive(false);
                            linkQuizManager.ImgLinkClear = false;
                            str.text = string.Empty;
                            str.transform.gameObject.SetActive(true);
                            KingText.text = string.Empty;
                            KingText.transform.gameObject.SetActive(true);
                            KingTextBox.transform.gameObject.SetActive(false);
                            NPCScroll.transform.gameObject.SetActive(false);
                            TextBox.transform.gameObject.SetActive(true);
                            CharacterScroll.transform.gameObject.SetActive(true);
                            break;
                        case 21:
                            BackGround.sprite = Resources.Load<Sprite>("제천마을");
                            str.transform.gameObject.SetActive(true);
                            TextBox.transform.gameObject.SetActive(true);
                            CharacterScroll.transform.gameObject.SetActive(true);
                            KingText.transform.gameObject.SetActive(true);
                            KingTextBox.transform.gameObject.SetActive(true);
                            NPCScroll.transform.gameObject.SetActive(true);
                            ImgLinkCanvas.transform.gameObject.SetActive(false);
                            linkQuizManager.ImgLinkClear = false;
                            tempInt = 1;
                            egu.transform.gameObject.SetActive(true);
                            dino_small.transform.gameObject.SetActive(true);
                            CH1_nomal.transform.gameObject.SetActive(false);
                            CH2_nomal.transform.gameObject.SetActive(false);
                            CH3.transform.gameObject.SetActive(false);
                            break;
                        case 22:
                            egu.transform.gameObject.SetActive(false);
                            KingText.text = string.Empty;
                            KingTextBox.transform.gameObject.SetActive(false);
                            NPCScroll.transform.gameObject.SetActive(false);
                            break;
                        default:

                            break;
                    }
                    break;
                case 3:
                    switch (count)
                    {
                        case 0:
                            icon360.transform.gameObject.SetActive(true);
                            sphere.transform.gameObject.SetActive(true);
                            Controller.transform.gameObject.SetActive(true);
                            BackGround.transform.gameObject.SetActive(false);
                            PopUp.transform.gameObject.SetActive(false);
                            PopUpText.transform.gameObject.SetActive(false);
                            PopUpScroll.transform.gameObject.SetActive(false);
                            Link.transform.gameObject.SetActive(false);
                            OptionCanvas.transform.gameObject.SetActive(false);
                            ImgOptionCanvas.transform.gameObject.SetActive(false);
                            linkQuizManager.OptionClear = false;
                            linkQuizManager.ImgOptionClear = false;
                            tempInt = 0;
                            TextBox.transform.gameObject.SetActive(true);
                            CharacterScroll.transform.gameObject.SetActive(true);
                            CHS.SetTrigger("teachAnim");
                            break;
                        case 1:
                            tempInt = 0;
                            PopUp.transform.gameObject.SetActive(true);
                            PopUpText.transform.gameObject.SetActive(true);
                            PopUp.overrideSprite = Resources.Load<Sprite>("Popup_Png");
                            PopUpScroll.transform.gameObject.SetActive(true);
                            GameObject.Find("WebManager").SendMessage("initURL", "https://museum.goseong.go.kr/index.goseong");
                            Link.transform.gameObject.SetActive(false);
                            //tempText = GameObject.Find("Text").GetComponent<Text>();
                            //tempText.text = "공룡박물관 홈페이지";
                            OptionCanvas.transform.gameObject.SetActive(false);
                            ImgOptionCanvas.transform.gameObject.SetActive(false);
                            linkQuizManager.OptionClear = false;
                            linkQuizManager.ImgOptionClear = false;
                            str.text = string.Empty;
                            TextBox.transform.gameObject.SetActive(false);
                            CharacterScroll.transform.gameObject.SetActive(false);
                            CHS.SetTrigger("teachAnim");
                            break;
                        case 2:
                            ImgOptionCanvas.transform.gameObject.SetActive(false);
                            linkQuizManager.ImgOptionClear = false;
                            break;

      

                            //case 3:                            
                            //    break;
                    }
                    break;
                case 4:
                    switch (count)
                    {
                        case 0:
                            icon360.transform.gameObject.SetActive(true);
                            sphere.transform.gameObject.SetActive(true);
                            Controller.transform.gameObject.SetActive(true);
                            BackGround.transform.gameObject.SetActive(false);
                            PopUp.transform.gameObject.SetActive(false);
                            PopUpText.transform.gameObject.SetActive(false);
                            PopUpScroll.transform.gameObject.SetActive(false);
                            Link.transform.gameObject.SetActive(false);
                            TextBox.transform.gameObject.SetActive(true);
                            CharacterScroll.transform.gameObject.SetActive(true);
                            OptionCanvas.transform.gameObject.SetActive(false);
                            LinkCanvas.transform.gameObject.SetActive(false);
                            linkQuizManager.OptionClear = false;
                            linkQuizManager.LinkClear = false;
                            tempInt = 0;
                            CHS.SetTrigger("teachAnim");
                            break;

                        case 1:
                            tempInt = 0;
                            PopUp.transform.gameObject.SetActive(true);
                            PopUpText.transform.gameObject.SetActive(true);
                            PopUpScroll.transform.gameObject.SetActive(true);
                            PopUp.overrideSprite = Resources.Load<Sprite>("Popup_Png");
                            GameObject.Find("WebManager").SendMessage("initURL", "https://dhp.goseong.go.kr/index.goseong");
                            Link.transform.gameObject.SetActive(false);
                            //tempText = GameObject.Find("Text").GetComponent<Text>();
                            //tempText.text = "당항포 공식 홈페이지";
                            OptionCanvas.transform.gameObject.SetActive(false);
                            LinkCanvas.transform.gameObject.SetActive(false);
                            linkQuizManager.LinkClear = false;
                            linkQuizManager.OptionClear = false;
                            CHS.SetTrigger("teachAnim");
                            TextBox.transform.gameObject.SetActive(false);
                            CharacterScroll.transform.gameObject.SetActive(false);
                            break;
                        case 2:
                            OptionCanvas.transform.gameObject.SetActive(false);
                            str.transform.gameObject.SetActive(true);
                            TextBox.transform.gameObject.SetActive(true);
                            CharacterScroll.transform.gameObject.SetActive(true);
                            linkQuizManager.LinkClear = false;
                            linkQuizManager.OptionClear = false;
                            break;
                    }
                    break;
                case 5:
                    switch (count)
                    {
                        case 0:
                            icon360.transform.gameObject.SetActive(true);
                            sphere.transform.gameObject.SetActive(true);
                            Controller.transform.gameObject.SetActive(true);
                            BackGround.transform.gameObject.SetActive(false);
                            PopUp.transform.gameObject.SetActive(false);
                            PopUpText.transform.gameObject.SetActive(false);
                            PopUpScroll.transform.gameObject.SetActive(false);
                            Link.transform.gameObject.SetActive(false);
                            CHS.SetTrigger("teachAnim");
                            OptionCanvas.transform.gameObject.SetActive(false);
                            LinkCanvas.transform.gameObject.SetActive(false);
                            linkQuizManager.OptionClear = false;
                            linkQuizManager.LinkClear = false;
                            tempInt = 0;
                            TextBox.transform.gameObject.SetActive(true);
                            CharacterScroll.transform.gameObject.SetActive(true);
                            break;


                        case 1:
                            tempInt = 0;
                            PopUp.transform.gameObject.SetActive(true);
                            PopUp.overrideSprite = Resources.Load<Sprite>("Popup_Png");
                            PopUpScroll.transform.gameObject.SetActive(true);
                            GameObject.Find("WebManager").SendMessage("initURL", "http://www.dinopark.net/index.goseong?menuCd=DOM_000001104002004000");
                            Link.transform.gameObject.SetActive(true);
                            tempText = GameObject.Find("Text").GetComponent<Text>();
                            tempText.text = "사이버 공룡 테마파크 홈페이지";
                            OptionCanvas.transform.gameObject.SetActive(false);
                            LinkCanvas.transform.gameObject.SetActive(false);
                            linkQuizManager.OptionClear = false;
                            linkQuizManager.LinkClear = false;
                            CHS.SetTrigger("teachAnim");
                            break;

                    }
                    break;

                default:
                    break;
            }
            switch (currentStage)
            {
                case 1:
                    switch (count)
                    {
                        case 0:
                        case 1:
                        case 3:
                        case 6:
                        case 7:
                        case 13:
                        case 18:
                        case 20:
                        case 26:
                        case 27:
                            text = Science_Text_Script1.Instance.scenario[currentStage].text[Science_Text_Script1.Instance.scenario[currentStage].Num[count]];
                            if (text.Contains("###"))
                            {
                                string temp = text.Replace("###", AppManage.Instance.Name);
                                GameObject.Find("TypingManager").GetComponent<TypingManager>().TypingText(temp, str);
                            }
                            else
                            {
                                GameObject.Find("TypingManager").GetComponent<TypingManager>().TypingText(text, str);
                            }
                            break;
                        case 10:
                        case 11:
                        case 15:
                        case 16:
                        case 17:
                        case 22:
                        case 23:
                        case 24:
                        case 25:
                            text = Science_Text_Script1.Instance.scenario[currentStage].text[Science_Text_Script1.Instance.scenario[currentStage].Num[count]];
                            if (text.Contains("###"))
                            {
                                string temp = text.Replace("###", AppManage.Instance.Name);
                                GameObject.Find("TypingManager").GetComponent<TypingManager>().TypingText(temp, PopUpText);
                            }
                            else
                            {
                                GameObject.Find("TypingManager").GetComponent<TypingManager>().TypingText(text, PopUpText);
                            }
                            break;
                        case 21:
                            break;
                        default:
                            text = Science_Text_Script1.Instance.scenario[currentStage].text[Science_Text_Script1.Instance.scenario[currentStage].Num[count]];
                            if (text.Contains("###"))
                            {
                                string temp = text.Replace("###", AppManage.Instance.Name);
                                GameObject.Find("TypingManager").GetComponent<TypingManager>().TypingText(temp, KingText);
                            }
                            else
                            {
                                GameObject.Find("TypingManager").GetComponent<TypingManager>().TypingText(text, KingText);
                            }
                            break;
                    }
                    break;
                case 2:
                    switch (count)
                    {
                        case 0:
                        case 1:
                        case 3:
                        case 5:
                        case 8:
                        case 10:
                        case 15:
                        case 17:
                        case 19:
                        case 20:
                        case 22:
                            text = Science_Text_Script1.Instance.scenario[currentStage].text[Science_Text_Script1.Instance.scenario[currentStage].Num[count]];
                            if (text.Contains("###"))
                            {
                                string temp = text.Replace("###", AppManage.Instance.Name);
                                GameObject.Find("TypingManager").GetComponent<TypingManager>().TypingText(temp, str);
                            }
                            else
                            {
                                GameObject.Find("TypingManager").GetComponent<TypingManager>().TypingText(text, str);
                            }
                            break;
                        case 6:
                        case 7:
                        case 12:
                            text = Science_Text_Script1.Instance.scenario[currentStage].text[Science_Text_Script1.Instance.scenario[currentStage].Num[count]];
                            if (text.Contains("###"))
                            {
                                string temp = text.Replace("###", AppManage.Instance.Name);
                                GameObject.Find("TypingManager").GetComponent<TypingManager>().TypingText(temp, PopUpText);
                            }
                            else
                            {
                                GameObject.Find("TypingManager").GetComponent<TypingManager>().TypingText(text, PopUpText);
                            }
                            break;
                        case 16:
                        case 18:
                        case 21:
                        case 23:
                            text = Science_Text_Script1.Instance.scenario[currentStage].text[Science_Text_Script1.Instance.scenario[currentStage].Num[count]];
                            if (text.Contains("###"))
                            {
                                string temp = text.Replace("###", AppManage.Instance.Name);
                                GameObject.Find("TypingManager").GetComponent<TypingManager>().TypingText(temp, KingText);
                                GameObject.Find("TypingManager").GetComponent<TypingManager>().TypingText2(temp, str);
                            }
                            else
                            {
                                GameObject.Find("TypingManager").GetComponent<TypingManager>().TypingText(text, KingText);
                                GameObject.Find("TypingManager").GetComponent<TypingManager>().TypingText2(text, str);
                            }
                            break;
                        default:
                            text = Science_Text_Script1.Instance.scenario[currentStage].text[Science_Text_Script1.Instance.scenario[currentStage].Num[count]];
                            if (text.Contains("###"))
                            {
                                string temp = text.Replace("###", AppManage.Instance.Name);
                                GameObject.Find("TypingManager").GetComponent<TypingManager>().TypingText(temp, KingText);
                            }
                            else
                            {
                                GameObject.Find("TypingManager").GetComponent<TypingManager>().TypingText(text, KingText);
                            }
                            break;
                    }
                    break;
                case 3:
                    switch (count)
                    {
                        case 1:
                            text = Science_Text_Script1.Instance.scenario[currentStage].text[Science_Text_Script1.Instance.scenario[currentStage].Num[count]];
                            if (text.Contains("###"))
                            {
                                string temp = text.Replace("###", AppManage.Instance.Name);
                                GameObject.Find("TypingManager").GetComponent<TypingManager>().TypingText(temp, PopUpText);
                            }
                            else
                            {
                                GameObject.Find("TypingManager").GetComponent<TypingManager>().TypingText(text, PopUpText);
                            }

                            break;
                        default:
                            text = Science_Text_Script1.Instance.scenario[currentStage].text[Science_Text_Script1.Instance.scenario[currentStage].Num[count]];
                            if (text.Contains("###"))
                            {
                                string temp = text.Replace("###", AppManage.Instance.Name);
                                GameObject.Find("TypingManager").GetComponent<TypingManager>().TypingText(temp, str);
                            }
                            else
                            {
                                GameObject.Find("TypingManager").GetComponent<TypingManager>().TypingText(text, str);
                            }

                            break;
                    }
                    break;
                case 4:
                    switch (count)
                    {
                        case 1:
                            text = Science_Text_Script1.Instance.scenario[currentStage].text[Science_Text_Script1.Instance.scenario[currentStage].Num[count]];
                            if (text.Contains("###"))
                            {
                                string temp = text.Replace("###", AppManage.Instance.Name);
                                GameObject.Find("TypingManager").GetComponent<TypingManager>().TypingText(temp, PopUpText);
                            }
                            else
                            {
                                GameObject.Find("TypingManager").GetComponent<TypingManager>().TypingText(text, PopUpText);
                            }
                            break;
                        default:
                            text = Science_Text_Script1.Instance.scenario[currentStage].text[Science_Text_Script1.Instance.scenario[currentStage].Num[count]];
                            if (text.Contains("###"))
                            {
                                string temp = text.Replace("###", AppManage.Instance.Name);
                                GameObject.Find("TypingManager").GetComponent<TypingManager>().TypingText(temp, str);
                            }
                            else
                            {
                                GameObject.Find("TypingManager").GetComponent<TypingManager>().TypingText(text, str);
                            }
                            break;
                    }
                    break;
                case 5:
                    switch (count)
                    {
                        case 1:
                            text = Science_Text_Script1.Instance.scenario[currentStage].text[Science_Text_Script1.Instance.scenario[currentStage].Num[count]];
                            if (text.Contains("###"))
                            {
                                string temp = text.Replace("###", AppManage.Instance.Name);
                                GameObject.Find("TypingManager").GetComponent<TypingManager>().TypingText(temp, PopUpText);
                            }
                            else
                            {
                                GameObject.Find("TypingManager").GetComponent<TypingManager>().TypingText(text, PopUpText);
                            }
                            break;
                        default:
                            text = Science_Text_Script1.Instance.scenario[currentStage].text[Science_Text_Script1.Instance.scenario[currentStage].Num[count]];
                            if (text.Contains("###"))
                            {
                                string temp = text.Replace("###", AppManage.Instance.Name);
                                GameObject.Find("TypingManager").GetComponent<TypingManager>().TypingText(temp, str);
                            }
                            else
                            {
                                GameObject.Find("TypingManager").GetComponent<TypingManager>().TypingText(text, str);
                            }
                            break;
                    }
                    break;
                default:
                    break;
            }
            switch (currentStage)
            {
                case 1:
                    switch (count)
                    {
                        case 1:
                        case 2:
                        case 3:
                        case 4:
                        case 5:
                        case 6:
                        case 8:
                        case 9:
                        case 12:
                        case 14:
                        case 18:
                        case 19:
                        case 20:
                        case 27:
                        case 28:
                        case 29:
                            if (AppManage.Instance.Gender == 0)
                            {
                                CH1_nomal.gameObject.SetActive(false);
                                CH2_nomal.gameObject.SetActive(true);
                                CH3.gameObject.SetActive(false);
                                dino_small.transform.gameObject.SetActive(false);
                            }
                            else
                            {
                                CH1_nomal.gameObject.SetActive(true);
                                CH2_nomal.gameObject.SetActive(false);
                                CH3.gameObject.SetActive(false);
                                dino_small.transform.gameObject.SetActive(false);
                            }
                            break;
                        case 7:
                        case 15:
                        case 16:
                        case 26:
                            CH1_nomal.gameObject.SetActive(false);
                            CH2_nomal.gameObject.SetActive(false);
                            CH3.transform.gameObject.SetActive(false);
                            dino_small.transform.gameObject.SetActive(true);
                            break;
                        case 17:
                            break;
                        default:
                            CH1_nomal.gameObject.SetActive(false);
                            CH2_nomal.gameObject.SetActive(false);
                            CH3.transform.gameObject.SetActive(true);
                            dino_small.transform.gameObject.SetActive(false);
                            break;
                    }
                    break;
                case 2:
                    switch (count)
                    {
                        case 1:
                        case 2:
                        case 4:
                        case 8:
                        case 9:
                        case 10:
                        case 11:
                        case 13:
                        case 14:
                        case 17:
                        case 22:
                            if (AppManage.Instance.Gender == 0)
                            {
                                CH1_nomal.gameObject.SetActive(false);
                                CH2_nomal.gameObject.SetActive(true);
                                CH3.gameObject.SetActive(false);
                                dino_small.transform.gameObject.SetActive(false);
                            }
                            else
                            {
                                CH1_nomal.gameObject.SetActive(true);
                                CH2_nomal.gameObject.SetActive(false);
                                CH3.gameObject.SetActive(false);
                                dino_small.transform.gameObject.SetActive(false);
                            }
                            break;
                        case 0:
                        case 16:
                        case 18:
                        case 23:
                            CH1_nomal.transform.gameObject.SetActive(false);
                            CH2_nomal.transform.gameObject.SetActive(false);
                            CH3.transform.gameObject.SetActive(false);
                            dino_small.transform.gameObject.SetActive(true);
                            break;
                        case 3:
                        case 21:
                            break;
                        default:
                            CH1_nomal.transform.gameObject.SetActive(false);
                            CH2_nomal.transform.gameObject.SetActive(false);
                            CH3.transform.gameObject.SetActive(true);
                            dino_small.transform.gameObject.SetActive(false);
                            break;
                    }
                    break;
                case 3:
                    switch (count)          // 순천만습지입구 에니메이션이 출력되는 오브젝트 활성화
                    {
                        case 0:
                        case 1:
                        case 3:
                            CH1_nomal.gameObject.SetActive(false);
                            CH2_nomal.gameObject.SetActive(false);
                            CH3.gameObject.SetActive(true);
                            break;
                        default:
                            CH1_nomal.gameObject.SetActive(false);
                            CH2_nomal.gameObject.SetActive(false);
                            CH3.gameObject.SetActive(false);
                            break;
                    }
                    break;
                case 4:
                    switch (count)
                    {
                        case 0:
                        case 1:
                        case 3:
                        case 4:
                            CH1_nomal.gameObject.SetActive(false);
                            CH2_nomal.gameObject.SetActive(false);
                            CH3.gameObject.SetActive(true);
                            break;
                        default:
                            CH1_nomal.gameObject.SetActive(false);
                            CH2_nomal.gameObject.SetActive(false);
                            CH3.gameObject.SetActive(false);
                            break;
                    }
                    break;
                case 5:
                    switch (count)
                    {
                        case 0:
                        case 1:
                        case 3:
                            CH1_nomal.gameObject.SetActive(false);
                            CH2_nomal.gameObject.SetActive(false);
                            CH3.gameObject.SetActive(true);
                            break;
                        default:
                            CH1_nomal.gameObject.SetActive(false);
                            CH2_nomal.gameObject.SetActive(false);
                            CH3.gameObject.SetActive(false);
                            break;
                    }
                    break;

                default:
                    break;
            }
            if (Science_Text_Script1.Instance.scenario[currentStage].anim[Science_Text_Script1.Instance.scenario[currentStage].Num[count]] == "*")
            {
                if (AppManage.Instance.Gender == 0)
                {
                    CHS.SetTrigger("CH2Anim");
                }
                else
                {
                    CHS.SetTrigger("CH1Anim");
                }
            }
            else        //npc 에니메이션을 키기 위한 else문
            {
                if (currentStage == 1)
                {
                    if (count != 17 && count != 25)
                    {
                        CHS.SetTrigger(Science_Text_Script1.Instance.scenario[currentStage].anim[Science_Text_Script1.Instance.scenario[currentStage].Num[count]]);
                    }
                }
                else if (currentStage == 2)
                {
                    if (count != 3 && count != 21)
                    {
                        CHS.SetTrigger(Science_Text_Script1.Instance.scenario[currentStage].anim[Science_Text_Script1.Instance.scenario[currentStage].Num[count]]);
                    }
                }
                else if (currentStage == 3)
                {
                    if (count != 1)
                    {
                        CHS.SetTrigger(Science_Text_Script1.Instance.scenario[currentStage].anim[Science_Text_Script1.Instance.scenario[currentStage].Num[count]]);
                    }
                }

                else if (currentStage == 4)
                {
                    if (count != 1)
                    {
                        CHS.SetTrigger(Science_Text_Script1.Instance.scenario[currentStage].anim[Science_Text_Script1.Instance.scenario[currentStage].Num[count]]);
                    }
                }

                else if (currentStage == 5)
                {
                    if (count != 1)
                    {
                        CHS.SetTrigger(Science_Text_Script1.Instance.scenario[currentStage].anim[Science_Text_Script1.Instance.scenario[currentStage].Num[count]]);
                    }
                }
            }

            AppManage.Instance.isComplite = false;
            if (currentStage == 1)
            {
                if (count == 21)
                {
                    AppManage.Instance.isComplite = true;
                }
            }
        }
        else
        {
            AppManage.Instance.isClicked = true;
            AppManage.Instance.isClicked2 = true;

        }
    }
    // 사진 찍기 기능에서 나가기 버튼
    public void ExitCapture()
    {
        if (AppManage.Instance.isComplite)
        {
            if (currentStage == 1)
            {
                GameObject.Find("UIManager").SendMessage("CaptureOff");
                AppManage.Instance.isComplite = false;
                canvas.renderMode = RenderMode.ScreenSpaceCamera;
                count++;
                if (AppManage.Instance.Gender == 0)
                {
                    CH1_nomal.gameObject.SetActive(false);
                    CH2_nomal.gameObject.SetActive(true);
                    CH3.gameObject.SetActive(false);
                }
                else
                {
                    CH1_nomal.gameObject.SetActive(true);
                    CH2_nomal.gameObject.SetActive(false);
                    CH3.gameObject.SetActive(false);
                }
                text = Science_Text_Script1.Instance.scenario[currentStage].text[Science_Text_Script1.Instance.scenario[currentStage].Num[count]];
                if (text.Contains("###"))
                {
                    string temp = text.Replace("###", AppManage.Instance.Name);
                    GameObject.Find("TypingManager").GetComponent<TypingManager>().TypingText(temp, str);
                }
                else
                {
                    GameObject.Find("TypingManager").GetComponent<TypingManager>().TypingText(text, str);
                }

                if (Science_Text_Script1.Instance.scenario[currentStage].anim[Science_Text_Script1.Instance.scenario[currentStage].Num[count]] == "*")
                {
                    if (AppManage.Instance.Gender == 0)
                    {
                        CHS.SetTrigger("CH2Anim");
                    }
                    else
                    {
                        CHS.SetTrigger("CH1Anim");
                    }
                }
                else
                {
                    CHS.SetTrigger(Science_Text_Script1.Instance.scenario[currentStage].anim[Science_Text_Script1.Instance.scenario[currentStage].Num[count]]);
                }
            }
            else if (currentStage == 2)
            {
                SceneManager.LoadScene("Stage2_End");
            }
        }
    }
}
