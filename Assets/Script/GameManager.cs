//https://qiita.com/Eureka/items/716f4f52b4106419dbec
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public string[] textMessage; //�e�L�X�g�̉��H�O�̈�s������ϐ�
    static public string[,] Poke_Data; //�e�L�X�g�̕����������2�����͔z�� 

    private int rowLength; //�e�L�X�g���̍s�����擾����ϐ�
    private int columnLength; //�e�L�X�g���̗񐔂��擾����ϐ�
    // Start is called before the first frame update
    void Start()
    {
        Initialized();
        //Debug.Log("�r�[�h���̂ڂ�����" + Poke_Data[1, 2]);
    }

    void Initialized()
    {
        TextAsset textasset = new TextAsset(); //�e�L�X�g�t�@�C���̃f�[�^���擾����C���X�^���X���쐬
        textasset = Resources.Load("isPoke_Data", typeof(TextAsset)) as TextAsset; //Resources�t�H���_����Ώۃe�L�X�g���擾
        string TextLines = textasset.text;
        textMessage = TextLines.Split('\n'); //

        //�s���Ɨ񐔂��擾
        columnLength = textMessage[0].Split('\t').Length;
        rowLength = textMessage.Length;

        //2���z����`
        Poke_Data = new string[rowLength, columnLength];

        for (int i = 0; i < rowLength; i++)
        {

            string[] tempWords = textMessage[i].Split('\t'); //textMessage���J���}���Ƃɕ��������̂��ꎞ�I��tempWords�ɑ��

            for (int n = 0; n < columnLength; n++)
            {
                Poke_Data[i, n] = tempWords[n]; //2���z��textWords�ɃJ���}���Ƃɕ�����tempWords�������Ă���
                //Debug.Log(Poke_Data[i, n]);
            }
        }

    }

    // Update is called once per frame
    void Update()
    {


    }
}
