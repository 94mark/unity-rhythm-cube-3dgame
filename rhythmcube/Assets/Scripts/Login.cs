using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BackEnd;
using UnityEngine.UI;

public class Login : MonoBehaviour
{
    [SerializeField] InputField id = null;
    [SerializeField] InputField pw = null;

    DatabaseManager theDatabase;

    // Start is called before the first frame update
    void Start()
    {
        theDatabase = FindObjectOfType<DatabaseManager>();
        Backend.Initialize(InitializeCallback);
    }

    void InitializeCallback()
    {
        if (Backend.IsInitialized)
        {
            Debug.Log(Backend.Utils.GetServerTime());
            Debug.Log(Backend.Utils.GetGoogleHash());
        }
        else
            Debug.Log("�ʱ�ȭ ���� (���ͳ� ���� ���");
    }

    public void BtnRegist()
    {
        string t_id = id.text;
        string t_pw = pw.text;

        BackendReturnObject bro = Backend.BMember.CustomSignUp(t_id, t_pw, "Test");

        if(bro.IsSuccess())
        {
            Debug.Log("ȸ������ �Ϸ�");
            this.gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("ȸ������ ����");
        }
    }

    public void BtnLogin()
    {
        string t_id = id.text;
        string t_pw = pw.text;

        BackendReturnObject bro = Backend.BMember.CustomLogin(t_id, t_pw);

        if (bro.IsSuccess())
        {
            Debug.Log("�α��� �Ϸ�");
            theDatabase.LoadScore();
            this.gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("�α��� ����");
        }
    }
}
