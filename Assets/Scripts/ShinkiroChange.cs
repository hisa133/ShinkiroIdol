using UnityEngine;
using System;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine.UI;
using System.Linq;
using System.IO;



public class ShinkiroChange : MonoBehaviour
{
    private string musicName; // 読み込む譜面の名前
    private string level; // 難易度
    private TextAsset csvFile; // CSVファイル
    public List<string[]> csvDatas = new List<string[]>(); // CSVの中身を入れるリスト
    private int height = 0; // CSVの行数
                            // Use this for initialization
    GameObject Naiyou;
    GameObject Omi;
    GameObject Hoshi;
    GameObject Kesu;

    public int iRandNum;
    public Sprite texture;

    private Text txt;

    GameObject ButtonExe; //ButtonExeそのものが入る変数

    SinkiroManager script; //SinkiroManager Scriptが入る変数
    SpriteRenderer MainSpriteRenderer;

    [SerializeField]
    Material mat;
    void Start()
    {
        ButtonExe = GameObject.Find("ButtonExe"); //ButtonExeをオブジェクトの名前から取得して変数に格納する
        Omi = GameObject.Find("Omikuji");
        Kesu = GameObject.Find("ImageBack");
        //最初は見えない
        mat.SetColor("_Color", new Color(1, 1, 1, 0));

        //csv読み込み
        musicName = "Shinkiro"; // 曲名
        //level = "0"; // 難易度
        csvFile = Resources.Load("CSV/" + musicName) as TextAsset; /* Resouces/CSV下のCSV読み込み */
        StringReader reader = new StringReader(csvFile.text);

        MainSpriteRenderer = Omi.GetComponent<SpriteRenderer>();
        //見えないように
        MainSpriteRenderer.color = new Color(255f, 255f, 255f, 0f);

     


        while (reader.Peek() > -1)
        {
            string line = reader.ReadLine();
            csvDatas.Add(line.Split(',')); // リストに入れる
            height++; // 行数加算
        }
        //整数の乱数を返す
        iRandNum = UnityEngine.Random.Range(1, 9);
        //Debug.Log("CSVの内容は" + csvDatas[iRandNum][0]);
        Debug.Log(iRandNum);
        Text myText;
        Naiyou = GameObject.Find("Canvas/Text");
        Naiyou.GetComponent<Text>().enabled = false;
        myText = Naiyou.GetComponentInChildren<Text>();
        Debug.Log(myText.text);
        myText.text = csvDatas[iRandNum][8];
        //iRandNum = 5;
        //Debug.Log(csvDatas[iRandNum][9]);
        texture = Resources.Load<Sprite>("Omikuji/" + csvDatas[iRandNum][9]);
        Debug.Log(texture.name);

        MainSpriteRenderer.sprite = texture;


        Texture2D Imtexture = Resources.Load("Shinkiro/" + csvDatas[iRandNum][4]) as Texture2D;
        Image img = GameObject.Find("Canvas/ImageBack/ImageShinkiro").GetComponent<Image>();
        img.sprite = Sprite.Create(Imtexture, new Rect(0, 0, Imtexture.width, Imtexture.height), Vector2.zero);

    }



    void Awake()
    {

        //SceneManager.sceneLoaded += OnSceneLoaded;//イベントにメソッドを登録

    }

    //private void OnSceneLoaded(Scene scene, LoadSceneMode sceneMode)
    //{
   //     Debug.Log(scene.buildIndex);//sceneの番号はscene.buildIndexで分かる
   //     Debug.Log(scene.name + " scene loaded");
   // }




    float Sin = 1f;
    float Alha = 0f;
    long a = 1;
    float b = 0f;
    float skl = 0f;
    Boolean pushflg = true;
    Boolean Effe = false;
    Boolean Effe1 = false;



    //script = ButtonExe.GetComponent<SinkiroManager>();
    //Boolean pushflg = script.bpushFlg;


    //if (a == 1) {
    //    pushflg = true;
    //    a = 2;
    //}




    void Update()
    {

        if (pushflg == true)
        {

            if (Sin > 0.1f)
            {
                mat.EnableKeyword("_SinWave");
                mat.SetFloat("_SinWave", Sin);
                Sin = Sin - 0.005f;


            }


            if (Alha < 1f)
            {
                mat.EnableKeyword("_Color");
                mat.SetColor("_Color", new Color(1, 1, 1, Alha));
                Alha = Alha + 0.005f;


            }

            if (pushflg == true && Sin < 0.1f && Alha > 1f && a >= 1)
            {

                Debug.Log("終わり");
                //script.bpushFlg = false;
                pushflg = false;

                Sin = 1f;
                //Alha = 0f;

                //テキストを表示する
                // Omikuji;

                //Hoshi.SetActive(true);
                switch (iRandNum)
                {
                    case 1:
                        GameObject.Find("Canvas").transform.Find("GameObject").gameObject.SetActive(true);
                        GameObject.Find("Canvas").transform.Find("Deadful").gameObject.SetActive(true);
                        Effe = true;
                        break;
                    case 2:
                        GameObject.Find("Canvas").transform.Find("GameObject").gameObject.SetActive(true);
                        GameObject.Find("Canvas").transform.Find("Deadful").gameObject.SetActive(true);
                        Effe = true;
                        break;
                    case 3:
                        GameObject.Find("Canvas").transform.Find("Smoke").gameObject.SetActive(true);
                        GameObject.Find("Canvas").transform.Find("bomb").gameObject.SetActive(true);
                        Effe = true;
                        break;
                    case 4:
                        GameObject.Find("Canvas").transform.Find("Smoke").gameObject.SetActive(true);
                        GameObject.Find("Canvas").transform.Find("bomb").gameObject.SetActive(true);
                        Effe = true;
                        break;
                    case 5:
                        GameObject.Find("Canvas").transform.Find("Shine").gameObject.SetActive(true);
                        GameObject.Find("Canvas").transform.Find("CFX_SpawnSystem").gameObject.SetActive(true);
                        GameObject.Find("Canvas").transform.Find("Star").gameObject.SetActive(true);
                        Effe = true;
                        break;
                    case 6:
                        GameObject.Find("Canvas").transform.Find("Smoke").gameObject.SetActive(true);
                        GameObject.Find("Canvas").transform.Find("bomb").gameObject.SetActive(true);
                        Effe = true;
                        break;
                    case 7:
                        GameObject.Find("Canvas").transform.Find("Shine").gameObject.SetActive(true);
                        GameObject.Find("Canvas").transform.Find("CFX_SpawnSystem").gameObject.SetActive(true);

                        Effe = true;
                        break;
                    case 8:
                        GameObject.Find("Canvas").transform.Find("Smoke").gameObject.SetActive(true);
                        GameObject.Find("Canvas").transform.Find("bomb").gameObject.SetActive(true);
                        Effe = true;
                        break;

                    default:
                        Effe = true;
                        break;
                }


                Naiyou.GetComponent<Text>().enabled = true;
                //Omikuji = Naiyou.GetComponent();
                //Omikuji.text ="大吉　今日はいいことありそう";
            }

    


        }
        else
        {
            if (b < 1f && Effe == true)
            {
                //Debug.Log(Hoshi.activeSelf);
                //Debug.Log(b);
                MainSpriteRenderer.color = new Color(255f, 255f, 255f, b);
 
                b = b + 0.07f;
                //if (b > 0.003f)
                //{
                //    b = b + 0.01f;
                //}

            }
            if (skl < 6.2f && Effe == true)
            {
                Debug.Log(skl);
                Omi.transform.localScale = new Vector3(
                            Omi.transform.localScale.x + skl,
                            Omi.transform.localScale.y + skl,
                            Omi.transform.localScale.z
                        );
                skl = skl + 0.375f;
                Effe1 = true;
                //if (b > 0.003f)
                //{
                //    b = b + 0.01f;
                //}

            }

            if (Effe1 == true && skl > 6.2f && iRandNum == 7 | iRandNum == 5 )
            {
                GameObject.Find("Canvas").transform.Find("Hanabi").gameObject.SetActive(true);
                GameObject.Find("Canvas").transform.Find("Firework").gameObject.SetActive(true);
                GameObject.Find("Canvas").transform.Find("Firework1").gameObject.SetActive(true);
            }

            if (Effe1 == true && skl > 6.2f && iRandNum == 1 | iRandNum == 2)
            {
                Kesu.GetComponent<Image>().color = new Color(7.0f / 255.0f, 40.0f / 255.0f, 120.0f / 255.0f, 210.0f / 255.0f);
                GameObject.Find("Canvas").transform.Find("BAT").gameObject.SetActive(true);
            }

            if (Effe1 == true && skl > 6.2f && iRandNum == 3 | iRandNum == 4 | iRandNum == 6 | iRandNum == 8)
            {
                
                GameObject.Find("Canvas").transform.Find("Particledaiya").gameObject.SetActive(true);
            }
        }

    }
}