using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System.Text;

public class TitleManager : MonoBehaviour
{
    ShinkiroChange script;
    GameObject ImageShinkiro;
    Timecount script2;
    GameObject timec;
    

    // Use this for initialization
    void Start()
    {
        ImageShinkiro = GameObject.Find("Canvas/ImageBack/ImageShinkiro/GameObject");
        timec= GameObject.Find("Text (1)");

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PushstartButton()
    {
        SceneManager.LoadScene("SinkiroScene");
        StreamWriter sw;
        FileInfo fi;
        fi = new FileInfo(Application.dataPath + "/FileName.csv");
        sw = fi.AppendText();
        sw.WriteLine("1", true);
        sw.Flush();
        sw.Close();
    }

    public void PushEndtButton()
    {
        Application.Quit();

    }

    public void PushBack()
    {
        string shubetu;
        string jikan;

        script = ImageShinkiro.GetComponent<ShinkiroChange>();
        shubetu=script.texture.name;

        script2 = timec.GetComponent<Timecount>();
        jikan=(script2.time).ToString();
        StreamWriter sw;
        FileInfo fi;
        fi = new FileInfo(Application.dataPath + "/FileName.csv");
        sw = fi.AppendText();
        //", false, System.Text.Encoding.UTF8
        sw.WriteLine(shubetu + "," + jikan, true);
        sw.Flush();
        sw.Close();
        //jsonString = srA.ReadToEnd();
        //srA.Close();

        SceneManager.LoadScene("TitleScene");


    }

   
}