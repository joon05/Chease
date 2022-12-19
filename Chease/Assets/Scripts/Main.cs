using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    /*��Ÿ����
     �±�W=�Ͼ���
     �±�B=������
     �±�CT=Ŭ��Ÿ��
     �⹰������Ʈ�̸��� ������ ù���� W�빮�� ���� ���� ���� �⹰ ������ ù���� �빮�ڷ�
                        ������ ù���� B�빮�� ���� ���� ���� �⹰ ������ ù���� �빮�ڷ�
     clickedObj:Ŭ���� ������Ʈ �ִ� ����
     
     */
    public string turn;//���������� �Ǻ����� W������ B������
    public float Sc;//�⹰ũ�⺯��

    public static bool destroyT;

    public GameObject cTile;//Ŭ���ؼ� ��ġ �����ϴ� Ÿ��
    public GameObject tileA;//�Ͼ�Ÿ��
    public GameObject tileB;//����Ÿ��
    public GameObject pawnW;//����
    public GameObject bishopW;//����
    public GameObject knightW;//�鳪��Ʈ
    public GameObject rookW;//���
    public GameObject queenW;//����
    public GameObject kingW;//��ŷ
    public GameObject pawnB;//����
    public GameObject bishopB;//����
    public GameObject knightB;//�泪��Ʈ
    public GameObject rookB;//���
    public GameObject queenB;//����
    public GameObject kingB;//��ŷ
    public bool exClickTile = false;//Ŭ������ Ÿ�� ���� ����
    public GameObject chosObj;//���õ� ���ӿ�����Ʈ
    void Start()
    {
        //Debug.Log(GameObject.Find("Ctile"));
        turn = "W";
        destroyT = false;
        Sc = 25f;
        CreatTile();//Ÿ�ϻ���
        CreatW();//��⹰ ����
        CreatB();//��⹰ ����
    }

    void Update()
    {
        Click();
    }
    public void Click() //�⹰ Ŭ���� �Լ�
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);//Ŭ�����غ�
        RaycastHit hit;//Ŭ�����غ�
        if (Input.GetMouseButtonDown(0) == true) //���콺 Ŭ����
        {
            if (Physics.Raycast(ray, out hit)) //���콺 Ŭ���� ������Ʈ�� Ŭ���ϸ�
            {

                GameObject clickedObj = hit.transform.gameObject;//Ŭ���� ������Ʈ �ִ� ����


                if (exClickTile == false) //Ŭ��Ÿ�� ������(�� �⹰ ���� ���� �����̶��)
                {
                    destroyT = false;
                    if (turn == "W")//�� ���϶� 
                    {
                        if (hit.transform.gameObject.tag == "W")//Ŭ���� ������Ʈ�� ����Ͻ�
                        {
                            float x = float.Parse(clickedObj.transform.parent.name.Substring(0, 2));//���õ� ������Ʈ�� ����x��ǥ
                            float z = float.Parse(clickedObj.transform.parent.name.Substring(4));//���õ� ������Ʈ�� ����z��ǥ

                            if (clickedObj.name == "WPawnU")//Ŭ���� ������Ʈ�� ���ΰ��� ���̶�� 
                            {
                                UPawnMove(clickedObj, "W", x, z);
                            }//������
                            if (clickedObj.name == "WPawnD")//Ŭ���� ������Ʈ�� ���ΰ��� ���̶�� 
                            {

                                DPawnMove(clickedObj, "W", x, z);
                            }//������
                            if (clickedObj.name == "WRook")//
                            {
                                RookMove(clickedObj, "W", x, z);
                            }//�輱��
                            if (clickedObj.name == "WBishop")
                            {
                                BishopMove(clickedObj, "W", x, z);
                            }//�����
                            if (clickedObj.name == "WKnight")
                            {
                                KnightMove(clickedObj, "W", x, z);
                            }//����Ʈ����
                            if (clickedObj.name == "WQueen")
                            {
                                QueenMove(clickedObj, "W", x, z);
                            }//������
                            if (clickedObj.name == "WKing")
                            {
                                KingMove(clickedObj, "W", x, z);
                            }//ŷ����
                        }
                    }
                    if (turn == "B")//�� ���϶� 
                    {
                        if (hit.transform.gameObject.tag == "B")//Ŭ���� ������Ʈ�� ����Ͻ�
                        {
                            float x = float.Parse(clickedObj.transform.parent.name.Substring(0, 2));//���õ� ������Ʈ�� ����x��ǥ
                            float z = float.Parse(clickedObj.transform.parent.name.Substring(4));//���õ� ������Ʈ�� ����z��ǥ

                            if (clickedObj.name == "BPawnU")//Ŭ���� ������Ʈ�� ���ΰ��� ���̶�� 
                            {
                                UPawnMove(clickedObj, "B", x, z);
                            }
                            //������
                            if (clickedObj.name == "BPawnD")//Ŭ���� ������Ʈ�� ���ΰ��� ���̶�� 
                            {
                                DPawnMove(clickedObj, "B", x, z);
                            }//������
                            if (clickedObj.name == "BRook")//
                            {
                                RookMove(clickedObj, "B", x, z);
                            }//�輱��
                            if (clickedObj.name == "BBishop")
                            {
                                BishopMove(clickedObj, "B", x, z);
                            }//�����
                            if (clickedObj.name == "BKnight")
                            {
                                KnightMove(clickedObj, "B", x, z);
                            }//����Ʈ����
                            if (clickedObj.name == "BQueen")
                            {
                                QueenMove(clickedObj, "B", x, z);
                            }//������
                            if (clickedObj.name == "BKing")
                            {
                                KingMove(clickedObj, "B", x, z);
                            }//ŷ����
                        }
                    }
                }
                else if (exClickTile == true)//Ŭ��Ÿ�� ������(�⹰ ���� ����) 
                {

                    if (clickedObj.tag == "CT")
                    {
                        float x = float.Parse(clickedObj.transform.parent.name.Substring(0, 2));//���õ� ������Ʈ�� ����x��ǥ
                        float z = float.Parse(clickedObj.transform.parent.name.Substring(4));//���õ� ������Ʈ�� ����z��ǥ
                        if (clickedObj.transform.parent.GetChild(0).tag == "W" || clickedObj.transform.parent.GetChild(0).tag == "B")
                        {
                            Destroy(clickedObj.transform.parent.GetChild(0).gameObject);
                        }
                        //�̵��� Ÿ�Ͽ� �⹰�� ������ ����
                        SetP(chosObj, string.Format("{0} _ {1} ", x, z));
                        //chosObj.transform.position = new Vector3(clickedObj.transform.position.x, 0.3f, clickedObj.transform.position.z);
                        //���õ� �⹰�� ���õ� Ÿ�� ��ġ�� �̵�
                        //chosObj.transform.parent = clickedObj.transform.parent;
                        //���õ� �⹰ �θ� �ִ� Ÿ�Ϸ� ����
                        destroyT = true;


                        //��� ���� Ÿ�� ����

                        exClickTile = false;//Ÿ������ X
                        chosObj = null;//���õ� ������Ʈ ���� ���
                        TurnChange();//�ϱ�ü
                    }
                    else
                    {
                        destroyT = true;


                        //��� ���� Ÿ�� ����
                        chosObj = null;//���õ� ������Ʈ ���� ���
                        exClickTile = false;//Ÿ������ X
                    }
                }

            }//Ŭ��
        }
    }
    public void CreatTile()
    {
        for (int z = 101; z < 121; z++)//������ ����
        {
            if (z % 2 == 0)//¦�����϶�
            {
                for (int x = 1; x < 9; x++)//������ ����
                {
                    if (x % 2 == 0)//¦���� �Ͼ�Ÿ�� ����
                    {
                        GameObject tile = Instantiate(tileA);//����
                        tile.transform.position = new Vector3(x, 0, z);//��ġ����
                        tile.transform.parent = GameObject.Find("Tiles").transform;//�θ�����
                        tile.name = (string.Format("{0} _ {1} ", x, z - 100));//��ǥ�� �̸�����
                    }
                    else //Ȧ���� ����Ÿ�ϻ���
                    {
                        GameObject tile = Instantiate(tileB);
                        tile.transform.position = new Vector3(x, 0, z);
                        tile.transform.parent = GameObject.Find("Tiles").transform;
                        tile.name = (string.Format("{0} _ {1} ", x, z - 100));
                    }


                }

            }
            else //Ȧ�����϶�
            {
                for (int x = 1; x < 9; x++)//������ ����
                {
                    if (x % 2 == 0)//¦���� ����Ÿ�� ����
                    {
                        GameObject tile = Instantiate(tileB);
                        tile.transform.position = new Vector3(x, 0, z);
                        tile.transform.parent = GameObject.Find("Tiles").transform;
                        tile.name = (string.Format("{0} _ {1} ", x, z - 100));
                    }
                    else //Ȧ���� �Ͼ�Ÿ�ϻ���
                    {
                        GameObject tile = Instantiate(tileA);
                        tile.transform.position = new Vector3(x, 0, z);
                        tile.transform.parent = GameObject.Find("Tiles").transform;
                        tile.name = (string.Format("{0} _ {1} ", x, z - 100));
                    }


                }
            }
        }//Ÿ�ϻ���
    }//Ÿ�ϻ����Լ�
    public void CreatW()//��⹰�����Լ�
    {
        for (int x = 1; x < 9; x++) //��������
        {

            GameObject pawnU = Instantiate(pawnW);//PawnU���� ������
            pawnU.name = "WPawnU";//�̸�����
            pawnU.transform.parent = GameObject.Find(string.Format("{0} _ {1} ", x, 4)).transform;//�θ�����
            pawnU.transform.localScale = new Vector3(Sc, Sc, 200 * Sc);//ũ�� ����,z�� 200���Ѱ� Ÿ�� �ڽ����� �Ѷ� ����� �ϱ׷����� �ʰ� �Ϸ���
            pawnU.transform.position = new Vector3(x, 0.3f, 104);//��ġ ����
            pawnU.transform.localScale = new Vector3(Sc, Sc, 200 * Sc);//ũ�� ����,z�� 200���Ѱ� Ÿ�� �ڽ����� �Ѷ� ����� �ϱ׷����� �ʰ� �Ϸ���
            pawnU.tag = "W";//�±� �߰�

            GameObject pawnD = Instantiate(pawnW);//PawnD�Ʒ��� ������
            pawnD.name = "WPawnD";//�̸�����
            pawnD.transform.parent = GameObject.Find(string.Format("{0} _ {1} ", x, 2)).transform;//�θ�����
            pawnD.transform.localScale = new Vector3(Sc, Sc, 200 * Sc);//ũ�� ����,z�� 200���Ѱ� Ÿ�� �ڽ����� �Ѷ� ����� �ϱ׷����� �ʰ� �Ϸ���
            pawnD.transform.position = new Vector3(x, 0.3f, 102);//��ġ ����
            pawnD.tag = "W";//�±� �߰�

        }//��������

        //ŷ����==================================================
        GameObject king = Instantiate(kingW);//king ŷ ����
        king.name = "WKing";//�̸�����
        king.transform.parent = GameObject.Find(string.Format("{0} _ {1} ", 5, 3)).transform;//�θ�����
        king.transform.localScale = new Vector3(Sc, Sc, 200 * Sc);//ũ�� ����,z�� 200���Ѱ� Ÿ�� �ڽ����� �Ѷ� ����� �ϱ׷����� �ʰ� �Ϸ���
        king.transform.position = new Vector3(5, 0.3f, 103);//��ġ ����
        king.tag = "W";//�±� �߰�
                       //====================================================

        //������============================================
        GameObject bishop = Instantiate(bishopW);//ù��° ���
        bishop.name = "WBishop";//�̸�����
        bishop.transform.parent = GameObject.Find(string.Format("{0} _ {1} ", 3, 3)).transform;//�θ�����
        bishop.transform.localScale = new Vector3(Sc, Sc, 200 * Sc);//ũ�� ����,z�� 200���Ѱ� Ÿ�� �ڽ����� �Ѷ� ����� �ϱ׷����� �ʰ� �Ϸ���
        bishop.transform.position = new Vector3(3, 0.3f, 103);//��ġ ����
        bishop.tag = "W";//�±� �߰�

        GameObject bishop2 = Instantiate(bishopW);//�ι�° ���
        bishop2.name = "WBishop";//�̸�����
        bishop2.transform.parent = GameObject.Find(string.Format("{0} _ {1} ", 6, 3)).transform;//�θ�����
        bishop2.transform.localScale = new Vector3(Sc, Sc, 200 * Sc);//ũ�� ����,z�� 200���Ѱ� Ÿ�� �ڽ����� �Ѷ� ����� �ϱ׷����� �ʰ� �Ϸ���
        bishop2.transform.position = new Vector3(6, 0.3f, 103);//��ġ ����
        bishop2.tag = "W";//�±� �߰�
        //====================================================

        //�����========================
        GameObject rook = Instantiate(rookW);//ù��° ��
        rook.name = "WRook";//�̸�����
        rook.transform.parent = GameObject.Find(string.Format("{0} _ {1} ", 1, 3)).transform;//�θ�����
        rook.transform.localScale = new Vector3(Sc, Sc, 200 * Sc);//ũ�� ����,z�� 200���Ѱ� Ÿ�� �ڽ����� �Ѷ� ����� �ϱ׷����� �ʰ� �Ϸ���
        rook.transform.position = new Vector3(1, 0.3f, 103);//��ġ ����
        rook.tag = "W";//�±� �߰�

        GameObject rook2 = Instantiate(rookW);//�ι�° ��
        rook2.name = "WRook";//�̸�����
        rook2.transform.parent = GameObject.Find(string.Format("{0} _ {1} ", 8, 3)).transform;//�θ�����
        rook2.transform.localScale = new Vector3(Sc, Sc, 200 * Sc);//ũ�� ����,z�� 200���Ѱ� Ÿ�� �ڽ����� �Ѷ� ����� �ϱ׷����� �ʰ� �Ϸ���
        rook2.transform.position = new Vector3(8, 0.3f, 103);//��ġ ����
        rook2.tag = "W";//�±� �߰�
        //============================

        //����Ʈ����========================
        GameObject knight = Instantiate(knightW);//ù��° ����Ʈ
        knight.name = "WKnight";//�̸�����
        knight.transform.parent = GameObject.Find(string.Format("{0} _ {1} ", 2, 3)).transform;//�θ�����
        knight.transform.localScale = new Vector3(Sc, Sc, 200 * Sc);//ũ�� ����,z�� 200���Ѱ� Ÿ�� �ڽ����� �Ѷ� ����� �ϱ׷����� �ʰ� �Ϸ���
        knight.transform.position = new Vector3(2, 0.3f, 103);//��ġ ����
        knight.tag = "W";//�±� �߰�

        GameObject knight2 = Instantiate(knightW);//�ι�° ����Ʈ
        knight2.name = "WKnight";//�̸�����
        knight2.transform.parent = GameObject.Find(string.Format("{0} _ {1} ", 7, 3)).transform;//�θ�����
        knight2.transform.localScale = new Vector3(Sc, Sc, 200 * Sc);//ũ�� ����,z�� 200���Ѱ� Ÿ�� �ڽ����� �Ѷ� ����� �ϱ׷����� �ʰ� �Ϸ���
        knight2.transform.position = new Vector3(7, 0.3f, 103);//��ġ ����
        knight2.tag = "W";//�±� �߰�
        //============================

        //������================================
        GameObject queen = Instantiate(queenW);//ù��° ��
        queen.name = "WQueen";//�̸�����
        queen.transform.parent = GameObject.Find(string.Format("{0} _ {1} ", 4, 3)).transform;//�θ�����
        queen.transform.localScale = new Vector3(Sc, Sc, 200 * Sc);//ũ�� ����,z�� 200���Ѱ� Ÿ�� �ڽ����� �Ѷ� ����� �ϱ׷����� �ʰ� �Ϸ���
        queen.transform.position = new Vector3(4, 0.3f, 103);//��ġ ����
        queen.tag = "W";//�±� �߰�
        //======================================


    }
    public void CreatB()//��⹰�����Լ�
    {
        for (int x = 1; x < 9; x++) //��������======================
        {

            GameObject pawnU = Instantiate(pawnB);//PawnU���� ������
            pawnU.name = "BPawnU";//�̸�����
            pawnU.transform.parent = GameObject.Find(string.Format("{0} _ {1} ", x, 14)).transform;//�θ�����
            pawnU.transform.localScale = new Vector3(Sc, Sc, 200 * Sc);//ũ�� ����,z�� 200���Ѱ� Ÿ�� �ڽ����� �Ѷ� ����� �ϱ׷����� �ʰ� �Ϸ���
            pawnU.transform.position = new Vector3(x, 0.3f, 114);//��ġ ����
            pawnU.transform.localScale = new Vector3(Sc, Sc, 200 * Sc);//ũ�� ����,z�� 200���Ѱ� Ÿ�� �ڽ����� �Ѷ� ����� �ϱ׷����� �ʰ� �Ϸ���
            pawnU.tag = "B";//�±� �߰�

            GameObject pawnD = Instantiate(pawnB);//PawnD�Ʒ��� ������
            pawnD.name = "BPawnD";//�̸�����
            pawnD.transform.parent = GameObject.Find(string.Format("{0} _ {1} ", x, 12)).transform;//�θ�����
            pawnD.transform.localScale = new Vector3(Sc, Sc, 200 * Sc);//ũ�� ����,z�� 200���Ѱ� Ÿ�� �ڽ����� �Ѷ� ����� �ϱ׷����� �ʰ� �Ϸ���
            pawnD.transform.position = new Vector3(x, 0.3f, 112);//��ġ ����
            pawnD.tag = "B";//�±� �߰�

        }//��������===========================

        //ŷ����==================================================
        GameObject king = Instantiate(kingB);//king ŷ ����
        king.name = "BKing";//�̸�����
        king.transform.parent = GameObject.Find(string.Format("{0} _ {1} ", 5, 13)).transform;//�θ�����
        king.transform.localScale = new Vector3(Sc, Sc, 200 * Sc);//ũ�� ����,z�� 200���Ѱ� Ÿ�� �ڽ����� �Ѷ� ����� �ϱ׷����� �ʰ� �Ϸ���
        king.transform.position = new Vector3(5, 0.3f, 113);//��ġ ����
        king.tag = "B";//�±� �߰�
                       //====================================================

        //������============================================
        GameObject bishop = Instantiate(bishopB);//ù��° ���
        bishop.name = "BBishop";//�̸�����
        bishop.transform.parent = GameObject.Find(string.Format("{0} _ {1} ", 3, 13)).transform;//�θ�����
        bishop.transform.localScale = new Vector3(Sc, Sc, 200 * Sc);//ũ�� ����,z�� 200���Ѱ� Ÿ�� �ڽ����� �Ѷ� ����� �ϱ׷����� �ʰ� �Ϸ���
        bishop.transform.position = new Vector3(3, 0.3f, 113);//��ġ ����
        bishop.tag = "B";//�±� �߰�

        GameObject bishop2 = Instantiate(bishopB);//�ι�° ���
        bishop2.name = "BBishop";//�̸�����
        bishop2.transform.parent = GameObject.Find(string.Format("{0} _ {1} ", 6, 13)).transform;//�θ�����
        bishop2.transform.localScale = new Vector3(Sc, Sc, 200 * Sc);//ũ�� ����,z�� 200���Ѱ� Ÿ�� �ڽ����� �Ѷ� ����� �ϱ׷����� �ʰ� �Ϸ���
        bishop2.transform.position = new Vector3(6, 0.3f, 113);//��ġ ����
        bishop2.tag = "B";//�±� �߰�
        //====================================================

        //�����========================
        GameObject rook = Instantiate(rookB);//ù��° ��
        rook.name = "BRook";//�̸�����
        rook.transform.parent = GameObject.Find(string.Format("{0} _ {1} ", 1, 13)).transform;//�θ�����
        rook.transform.localScale = new Vector3(Sc, Sc, 200 * Sc);//ũ�� ����,z�� 200���Ѱ� Ÿ�� �ڽ����� �Ѷ� ����� �ϱ׷����� �ʰ� �Ϸ���
        rook.transform.position = new Vector3(1, 0.3f, 113);//��ġ ����
        rook.tag = "B";//�±� �߰�

        GameObject rook2 = Instantiate(rookB);//�ι�° ��
        rook2.name = "BRook";//�̸�����
        rook2.transform.parent = GameObject.Find(string.Format("{0} _ {1} ", 8, 13)).transform;//�θ�����
        rook2.transform.localScale = new Vector3(Sc, Sc, 200 * Sc);//ũ�� ����,z�� 200���Ѱ� Ÿ�� �ڽ����� �Ѷ� ����� �ϱ׷����� �ʰ� �Ϸ���
        rook2.transform.position = new Vector3(8, 0.3f, 113);//��ġ ����
        rook2.tag = "B";//�±� �߰�
        //============================

        //����Ʈ����========================
        GameObject knight = Instantiate(knightB);//ù��° ����Ʈ
        knight.name = "BKnight";//�̸�����
        knight.transform.parent = GameObject.Find(string.Format("{0} _ {1} ", 2, 13)).transform;//�θ�����
        knight.transform.localScale = new Vector3(Sc, Sc, 200 * Sc);//ũ�� ����,z�� 200���Ѱ� Ÿ�� �ڽ����� �Ѷ� ����� �ϱ׷����� �ʰ� �Ϸ���
        knight.transform.position = new Vector3(2, 0.3f, 113);//��ġ ����
        knight.tag = "B";//�±� �߰�

        GameObject knight2 = Instantiate(knightB);//�ι�° ����Ʈ
        knight2.name = "BKnight";//�̸�����
        knight2.transform.parent = GameObject.Find(string.Format("{0} _ {1} ", 7, 13)).transform;//�θ�����
        knight2.transform.localScale = new Vector3(Sc, Sc, 200 * Sc);//ũ�� ����,z�� 200���Ѱ� Ÿ�� �ڽ����� �Ѷ� ����� �ϱ׷����� �ʰ� �Ϸ���
        knight2.transform.position = new Vector3(7, 0.3f, 113);//��ġ ����
        knight2.tag = "B";//�±� �߰�
        //============================

        //������================================
        GameObject queen = Instantiate(queenB);//ù��° ��
        queen.name = "BQueen";//�̸�����
        queen.transform.parent = GameObject.Find(string.Format("{0} _ {1} ", 4, 13)).transform;//�θ�����
        queen.transform.localScale = new Vector3(Sc, Sc, 200 * Sc);//ũ�� ����,z�� 200���Ѱ� Ÿ�� �ڽ����� �Ѷ� ����� �ϱ׷����� �ʰ� �Ϸ���
        queen.transform.position = new Vector3(4, 0.3f, 113);//��ġ ����
        queen.tag = "B";//�±� �߰�
        //======================================


    }
    public void TurnChange()
    {
        if (turn == "B")
        {
            turn = "W";
        }
        else if (turn == "W")
        {
            turn = "B";
        }
    }//�Ϲٲٴ� �Լ�

    public void SetP(GameObject c, string p)
    {
        Debug.Log(string.Format("{0}", p));
        c.transform.parent = GameObject.Find(string.Format("{0}", p)).transform;
        c.transform.position
        =
        new Vector3(c.transform.parent.transform.position.x, c.transform.parent.transform.position.y, c.transform.parent.transform.position.z);
        //�θ� ���� �� �̵�
    }//�θ� ���� �� �̵�
    public void CreatCT(float x, float z)
    {
        GameObject ct = Instantiate(cTile);//Ŭ���Ͽ� ��ġ�� �̵��ϴ� Ÿ�� ����
        ct.tag = "CT";//�±�����
        ct.name = "Ctile";//�̸�����
        SetP(ct, string.Format("{0} _ {1} ", x, z));
        exClickTile = true;
    }//�̵�Ÿ�ϻ���


    /////////////////////////////////////////////////////////////////////////////////////////////////////// 

    public void UPawnMove(GameObject cO, string turn, float x, float z)
    {
        chosObj = cO;//���õ� ������Ʈ�� ������ ����

        if (z == 4 || z == 14)//���������̶��
        {
            chosObj = cO;//���õ� ������Ʈ�� ������ ����

            GameObject ct = Instantiate(cTile);//Ŭ���Ͽ� ��ġ�� �̵��ϴ� Ÿ�� ����
            ct.tag = "CT";//�±�����
            ct.name = "Ctile";//�̸�����


            SetP(ct, string.Format("{0} _ {1} ", x, z + 1));
            if (GameObject.Find(string.Format("{0} _ {1} ", x, z + 1)).transform.childCount == 2)//���� ������ ���� �⹰�� ������� �̵�Ÿ�� ���� 
            {
                Destroy(ct);
            }
            else
            {
                exClickTile = true;
                GameObject ct2 = Instantiate(cTile);//Ŭ���Ͽ� ��ġ�� �̵��ϴ� Ÿ�� ����
                ct2.tag = "CT";//�±�����
                ct2.name = "Ctile";//�̸�����


                SetP(ct2, string.Format("{0} _ {1} ", x, z + 2));
                if (GameObject.Find(string.Format("{0} _ {1} ", x, z + 2)).transform.childCount == 2)//���� ������ ���� �⹰�� ������� �̵�Ÿ�� ���� 
                {
                    Destroy(ct2);
                }
            }






        }//���������̸�
        else
        {
            chosObj = cO;//���õ� ������Ʈ�� ������ ����

            GameObject ct = Instantiate(cTile);//Ŭ���Ͽ� ��ġ�� �̵��ϴ� Ÿ�� ����
            ct.tag = "CT";//�±�����
            ct.name = "Ctile";//�̸�����
            if (z + 1f == 21)//�ʵ� ������
            {
                SetP(ct, string.Format("{0} _ {1} ", x, 1));
                if (GameObject.Find(string.Format("{0} _ {1} ", x, 1)).transform.childCount == 2)//���� ������ ���� �⹰�� ������� �̵�Ÿ�� ���� 
                {
                    Destroy(ct);
                }
                else
                {
                    exClickTile = true;
                }


            }
            else //�Ϲݻ�Ȳ
            {
                SetP(ct, string.Format("{0} _ {1} ", x, z + 1));
                if (GameObject.Find(string.Format("{0} _ {1} ", x, z + 1)).transform.childCount == 2)//���� ������ ���� �⹰�� ������� �̵�Ÿ�� ���� 
                {
                    Destroy(ct);
                }
                else
                {
                    exClickTile = true;
                }

            }

        }//�Ϲ�


        //
        if (turn == "W")//�����϶�
        {
            if (x + 1 < 9 && z + 1 < 21)//�Ϲ�
            {
                if (GameObject.Find(string.Format("{0} _ {1} ", x + 1, z + 1)).transform.childCount > 0) //������ �� ������(�Լ� �ϸ� �������� �����Է�)    
                {

                    if (GameObject.Find(string.Format("{0} _ {1} ", x + 1, z + 1)).transform.GetChild(0).CompareTag("B"))
                    {
                        //Debug.Log(GameObject.Find(string.Format("{0} _ {1} ", x + 1, z + 1)));

                        GameObject ct3 = Instantiate(cTile);//Ŭ���Ͽ� ��ġ�� �̵��ϴ� Ÿ�� ����
                        ct3.tag = "CT";//�±�����
                        ct3.name = "Ctile";//�̸�����
                        ct3.transform.parent = GameObject.Find(string.Format("{0} _ {1} ", x + 1, z + 1)).transform;
                        ct3.transform.position
                        =
                        new Vector3(ct3.transform.parent.transform.position.x, ct3.transform.parent.transform.position.y, ct3.transform.parent.transform.position.z);
                        //SetP(ct3, string.Format("{0} _ {1}",x+1,z+1 ));
                        Debug.Log(string.Format("{0} _ {1}", x + 1, z + 1));
                        exClickTile = true;

                    }//������ �� ������(�Լ� �ϸ� �������� �����Է�)    
                }
            }//������
            else if (x + 1 < 9 && z + 1 > 20)//���� �ʰ���
            {
                if (GameObject.Find(string.Format("{0} _ {1} ", x + 1, 1)).transform.childCount > 0) //������ �� ������(�Լ� �ϸ� �������� �����Է�)    
                {

                    if (GameObject.Find(string.Format("{0} _ {1} ", x + 1, 1)).transform.GetChild(0).CompareTag("B"))
                    {
                        //Debug.Log(GameObject.Find(string.Format("{0} _ {1} ", x + 1, z + 1)));

                        GameObject ct3 = Instantiate(cTile);//Ŭ���Ͽ� ��ġ�� �̵��ϴ� Ÿ�� ����
                        ct3.tag = "CT";//�±�����
                        ct3.name = "Ctile";//�̸�����
                        ct3.transform.parent = GameObject.Find(string.Format("{0} _ {1} ", x + 1, 1)).transform;
                        ct3.transform.position
                        =
                        new Vector3(ct3.transform.parent.transform.position.x, ct3.transform.parent.transform.position.y, ct3.transform.parent.transform.position.z);
                        //SetP(ct3, string.Format("{0} _ {1}",x+1,z+1 ));
                        Debug.Log(string.Format("{0} _ {1}", x + 1, 1));
                        exClickTile = true;

                    }//������ �� ������(�Լ� �ϸ� �������� �����Է�)    
                }
            }
            if (x - 1 > 0 && z + 1 < 21)
            {
                if (GameObject.Find(string.Format("{0} _ {1} ", x - 1, z + 1)).transform.childCount > 0) //���� �� ������(�Լ� �ϸ� �������� �����Է�)    
                {

                    if (GameObject.Find(string.Format("{0} _ {1} ", x - 1, z + 1)).transform.GetChild(0).CompareTag("B"))
                    {


                        GameObject ct3 = Instantiate(cTile);//Ŭ���Ͽ� ��ġ�� �̵��ϴ� Ÿ�� ����
                        ct3.tag = "CT";//�±�����
                        ct3.name = "Ctile";//�̸�����
                        ct3.transform.parent = GameObject.Find(string.Format("{0} _ {1} ", x - 1, z + 1)).transform;
                        ct3.transform.position
                        =
                        new Vector3(ct3.transform.parent.transform.position.x, ct3.transform.parent.transform.position.y, ct3.transform.parent.transform.position.z);

                        Debug.Log(string.Format("{0} _ {1}", x - 1, z + 1));
                        exClickTile = true;

                    }
                }
            }//���� �� ������(�Լ� �ϸ� �������� �����Է�)    
            else if (x - 1 > 0 && z + 1 > 20)//���� �ʰ���
            {
                if (GameObject.Find(string.Format("{0} _ {1} ", x - 1, 1)).transform.childCount > 0) //���� �� ������(�Լ� �ϸ� �������� �����Է�)    
                {

                    if (GameObject.Find(string.Format("{0} _ {1} ", x - 1, 1)).transform.GetChild(0).CompareTag("B"))
                    {


                        GameObject ct3 = Instantiate(cTile);//Ŭ���Ͽ� ��ġ�� �̵��ϴ� Ÿ�� ����
                        ct3.tag = "CT";//�±�����
                        ct3.name = "Ctile";//�̸�����
                        ct3.transform.parent = GameObject.Find(string.Format("{0} _ {1} ", x - 1, 1)).transform;
                        ct3.transform.position
                        =
                        new Vector3(ct3.transform.parent.transform.position.x, ct3.transform.parent.transform.position.y, ct3.transform.parent.transform.position.z);

                        Debug.Log(string.Format("{0} _ {1}", x - 1, 1));
                        exClickTile = true;

                    }//���� �� ������(�Լ� �ϸ� �������� �����Է�)    
                }
            }
        }
        else //�����϶�
        {
            if (x + 1 < 9 && z + 1 < 21)//�Ϲ�
            {
                if (GameObject.Find(string.Format("{0} _ {1} ", x + 1, z + 1)).transform.childCount > 0) //������ �� ������(�Լ� �ϸ� �������� �����Է�)    
                {

                    if (GameObject.Find(string.Format("{0} _ {1} ", x + 1, z + 1)).transform.GetChild(0).CompareTag("W"))
                    {
                        //Debug.Log(GameObject.Find(string.Format("{0} _ {1} ", x + 1, z + 1)));

                        GameObject ct3 = Instantiate(cTile);//Ŭ���Ͽ� ��ġ�� �̵��ϴ� Ÿ�� ����
                        ct3.tag = "CT";//�±�����
                        ct3.name = "Ctile";//�̸�����
                        ct3.transform.parent = GameObject.Find(string.Format("{0} _ {1} ", x + 1, z + 1)).transform;
                        ct3.transform.position
                        =
                        new Vector3(ct3.transform.parent.transform.position.x, ct3.transform.parent.transform.position.y, ct3.transform.parent.transform.position.z);
                        //SetP(ct3, string.Format("{0} _ {1}",x+1,z+1 ));
                        Debug.Log(string.Format("{0} _ {1}", x + 1, z + 1));
                        exClickTile = true;

                    }//������ �� ������(�Լ� �ϸ� �������� �����Է�)    
                }
            }//������
            else if (x + 1 < 9 && z + 1 > 20)//���� �ʰ���
            {
                if (GameObject.Find(string.Format("{0} _ {1} ", x + 1, 1)).transform.childCount > 0) //������ �� ������(�Լ� �ϸ� �������� �����Է�)    
                {

                    if (GameObject.Find(string.Format("{0} _ {1} ", x + 1, 1)).transform.GetChild(0).CompareTag("W"))
                    {
                        //Debug.Log(GameObject.Find(string.Format("{0} _ {1} ", x + 1, z + 1)));

                        GameObject ct3 = Instantiate(cTile);//Ŭ���Ͽ� ��ġ�� �̵��ϴ� Ÿ�� ����
                        ct3.tag = "CT";//�±�����
                        ct3.name = "Ctile";//�̸�����
                        ct3.transform.parent = GameObject.Find(string.Format("{0} _ {1} ", x + 1, 1)).transform;
                        ct3.transform.position
                        =
                        new Vector3(ct3.transform.parent.transform.position.x, ct3.transform.parent.transform.position.y, ct3.transform.parent.transform.position.z);
                        //SetP(ct3, string.Format("{0} _ {1}",x+1,z+1 ));
                        Debug.Log(string.Format("{0} _ {1}", x + 1, 1));
                        exClickTile = true;

                    }//������ �� ������(�Լ� �ϸ� �������� �����Է�)    
                }
            }
            if (x - 1 > 0 && z + 1 < 21)
            {
                if (GameObject.Find(string.Format("{0} _ {1} ", x - 1, z + 1)).transform.childCount > 0) //���� �� ������(�Լ� �ϸ� �������� �����Է�)    
                {

                    if (GameObject.Find(string.Format("{0} _ {1} ", x - 1, z + 1)).transform.GetChild(0).CompareTag("W"))
                    {


                        GameObject ct3 = Instantiate(cTile);//Ŭ���Ͽ� ��ġ�� �̵��ϴ� Ÿ�� ����
                        ct3.tag = "CT";//�±�����
                        ct3.name = "Ctile";//�̸�����
                        ct3.transform.parent = GameObject.Find(string.Format("{0} _ {1} ", x - 1, z + 1)).transform;
                        ct3.transform.position
                        =
                        new Vector3(ct3.transform.parent.transform.position.x, ct3.transform.parent.transform.position.y, ct3.transform.parent.transform.position.z);

                        Debug.Log(string.Format("{0} _ {1}", x - 1, z + 1));
                        exClickTile = true;

                    }
                }
            }//���� �� ������(�Լ� �ϸ� �������� �����Է�)    
            else if (x - 1 > 0 && z + 1 > 20)//���� �ʰ���
            {
                if (GameObject.Find(string.Format("{0} _ {1} ", x - 1, 1)).transform.childCount > 0) //���� �� ������(�Լ� �ϸ� �������� �����Է�)    
                {

                    if (GameObject.Find(string.Format("{0} _ {1} ", x - 1, 1)).transform.GetChild(0).CompareTag("W"))
                    {


                        GameObject ct3 = Instantiate(cTile);//Ŭ���Ͽ� ��ġ�� �̵��ϴ� Ÿ�� ����
                        ct3.tag = "CT";//�±�����
                        ct3.name = "Ctile";//�̸�����
                        ct3.transform.parent = GameObject.Find(string.Format("{0} _ {1} ", x - 1, 1)).transform;
                        ct3.transform.position
                        =
                        new Vector3(ct3.transform.parent.transform.position.x, ct3.transform.parent.transform.position.y, ct3.transform.parent.transform.position.z);

                        Debug.Log(string.Format("{0} _ {1}", x - 1, 1));
                        exClickTile = true;

                    }//���� �� ������(�Լ� �ϸ� �������� �����Է�)    
                }
            }


        }
        //�����϶�


        //����Ÿ��
    }//���ΰ��� �� (�º��� ���õ� ���ӿ�����Ʈ,����������,xz��ǥ��)
    public void DPawnMove(GameObject cO, string turn, float x, float z)
    {
        chosObj = cO;//���õ� ������Ʈ�� ������ ����

        if (z == 2 || z == 12)//���������̶��
        {
            chosObj = cO;//���õ� ������Ʈ�� ������ ����

            GameObject ct = Instantiate(cTile);//Ŭ���Ͽ� ��ġ�� �̵��ϴ� Ÿ�� ����
            ct.tag = "CT";//�±�����
            ct.name = "Ctile";//�̸�����


            SetP(ct, string.Format("{0} _ {1} ", x, z - 1));
            if (GameObject.Find(string.Format("{0} _ {1} ", x, z - 1)).transform.childCount == 2)//���� ������ ���� �⹰�� ������� �̵�Ÿ�� ���� 
            {
                Destroy(ct);
            }
            else
            {
                exClickTile = true;
                GameObject ct2 = Instantiate(cTile);//Ŭ���Ͽ� ��ġ�� �̵��ϴ� Ÿ�� ����
                ct2.tag = "CT";//�±�����
                ct2.name = "Ctile";//�̸�����


                if (z == 2)
                {
                    SetP(ct2, string.Format("{0} _ {1} ", x, 20));
                    if (GameObject.Find(string.Format("{0} _ {1} ", x, 20)).transform.childCount == 2)//���� ������ ���� �⹰�� ������� �̵�Ÿ�� ���� 
                    {
                        Destroy(ct2);
                    }
                }
                else
                {
                    SetP(ct2, string.Format("{0} _ {1} ", x, z - 2));
                    if (GameObject.Find(string.Format("{0} _ {1} ", x, z - 2)).transform.childCount == 2)//���� ������ ���� �⹰�� ������� �̵�Ÿ�� ���� 
                    {
                        Destroy(ct2);
                    }
                }

            }






        }//���������̸�
        else
        {
            chosObj = cO;//���õ� ������Ʈ�� ������ ����

            GameObject ct = Instantiate(cTile);//Ŭ���Ͽ� ��ġ�� �̵��ϴ� Ÿ�� ����
            ct.tag = "CT";//�±�����
            ct.name = "Ctile";//�̸�����
            if (z - 1f == 0)//�ʵ� ������
            {
                SetP(ct, string.Format("{0} _ {1} ", x, 20));
                if (GameObject.Find(string.Format("{0} _ {1} ", x, 1)).transform.childCount == 2)//���� ������ ���� �⹰�� ������� �̵�Ÿ�� ���� 
                {
                    Destroy(ct);
                }
                else
                {
                    exClickTile = true;
                }


            }
            else //�Ϲݻ�Ȳ
            {
                SetP(ct, string.Format("{0} _ {1} ", x, z - 1));
                if (GameObject.Find(string.Format("{0} _ {1} ", x, z - 1)).transform.childCount == 2)//���� ������ ���� �⹰�� ������� �̵�Ÿ�� ���� 
                {
                    Destroy(ct);
                }
                else
                {
                    exClickTile = true;
                }

            }

        }//�Ϲ�


        //

        if (turn == "W")//�����϶�
        {
            if (x + 1 < 9 && z - 1 > 0)//�Ϲ�
            {
                if (GameObject.Find(string.Format("{0} _ {1} ", x + 1, z - 1)).transform.childCount > 0) //������ �Ʒ� ������(�Լ� �ϸ� �������� �����Է�)    
                {

                    if (GameObject.Find(string.Format("{0} _ {1} ", x + 1, z - 1)).transform.GetChild(0).CompareTag("B"))
                    {
                        //Debug.Log(GameObject.Find(string.Format("{0} _ {1} ", x + 1, z + 1)));

                        GameObject ct3 = Instantiate(cTile);//Ŭ���Ͽ� ��ġ�� �̵��ϴ� Ÿ�� ����
                        ct3.tag = "CT";//�±�����
                        ct3.name = "Ctile";//�̸�����
                        ct3.transform.parent = GameObject.Find(string.Format("{0} _ {1} ", x + 1, z - 1)).transform;
                        ct3.transform.position
                        =
                        new Vector3(ct3.transform.parent.transform.position.x, ct3.transform.parent.transform.position.y, ct3.transform.parent.transform.position.z);
                        //SetP(ct3, string.Format("{0} _ {1}",x+1,z+1 ));
                        Debug.Log(string.Format("{0} _ {1}", x + 1, z - 1));
                        exClickTile = true;

                    }//������ �Ʒ� ������(�Լ� �ϸ� �������� �����Է�)    
                }
            }//������
            else if (x + 1 < 9 && z - 1 < 1)//�Ʒ��� �ʰ���
            {
                if (GameObject.Find(string.Format("{0} _ {1} ", x + 1, 20)).transform.childCount > 0) //������ �Ʒ� ������(�Լ� �ϸ� �������� �����Է�)    
                {

                    if (GameObject.Find(string.Format("{0} _ {1} ", x + 1, 20)).transform.GetChild(0).CompareTag("B"))
                    {

                        GameObject ct3 = Instantiate(cTile);//Ŭ���Ͽ� ��ġ�� �̵��ϴ� Ÿ�� ����
                        ct3.tag = "CT";//�±�����
                        ct3.name = "Ctile";//�̸�����
                        ct3.transform.parent = GameObject.Find(string.Format("{0} _ {1} ", x + 1, 20)).transform;
                        ct3.transform.position
                        =
                        new Vector3(ct3.transform.parent.transform.position.x, ct3.transform.parent.transform.position.y, ct3.transform.parent.transform.position.z);
                        //SetP(ct3, string.Format("{0} _ {1}",x+1,z+1 ));
                        Debug.Log(string.Format("{0} _ {1}", x + 1, 20));
                        exClickTile = true;

                    }//������ �Ʒ� ������(�Լ� �ϸ� �������� �����Է�)    
                }
            }
            if (x - 1 > 0 && z - 1 > 0)
            {
                if (GameObject.Find(string.Format("{0} _ {1} ", x - 1, z - 1)).transform.childCount > 0) //���� �Ʒ� ������(�Լ� �ϸ� �������� �����Է�)    
                {

                    if (GameObject.Find(string.Format("{0} _ {1} ", x - 1, z - 1)).transform.GetChild(0).CompareTag("B"))
                    {


                        GameObject ct3 = Instantiate(cTile);//Ŭ���Ͽ� ��ġ�� �̵��ϴ� Ÿ�� ����
                        ct3.tag = "CT";//�±�����
                        ct3.name = "Ctile";//�̸�����
                        ct3.transform.parent = GameObject.Find(string.Format("{0} _ {1} ", x - 1, z - 1)).transform;
                        ct3.transform.position
                        =
                        new Vector3(ct3.transform.parent.transform.position.x, ct3.transform.parent.transform.position.y, ct3.transform.parent.transform.position.z);

                        Debug.Log(string.Format("{0} _ {1}", x - 1, z - 1));
                        exClickTile = true;

                    }
                }
            }//���� �Ʒ� ������(�Լ� �ϸ� �������� �����Է�)    
            else if (x - 1 > 0 && z - 1 < 1)//�Ʒ��� �ʰ���
            {
                if (GameObject.Find(string.Format("{0} _ {1} ", x - 1, 20)).transform.childCount > 0) //���� �Ʒ� ������(�Լ� �ϸ� �������� �����Է�)    
                {

                    if (GameObject.Find(string.Format("{0} _ {1} ", x - 1, 20)).transform.GetChild(0).CompareTag("B"))
                    {


                        GameObject ct3 = Instantiate(cTile);//Ŭ���Ͽ� ��ġ�� �̵��ϴ� Ÿ�� ����
                        ct3.tag = "CT";//�±�����
                        ct3.name = "Ctile";//�̸�����
                        ct3.transform.parent = GameObject.Find(string.Format("{0} _ {1} ", x - 1, 20)).transform;
                        ct3.transform.position
                        =
                        new Vector3(ct3.transform.parent.transform.position.x, ct3.transform.parent.transform.position.y, ct3.transform.parent.transform.position.z);

                        Debug.Log(string.Format("{0} _ {1}", x - 1, 20));
                        exClickTile = true;

                    }//���� �Ʒ� ������(�Լ� �ϸ� �������� �����Է�)    
                }
            }
        }
        //�����϶�
        else //�����϶�
        {
            if (x + 1 < 9 && z - 1 > 0)//�Ϲ�
            {
                if (GameObject.Find(string.Format("{0} _ {1} ", x + 1, z - 1)).transform.childCount > 0) //������ �Ʒ� ������(�Լ� �ϸ� �������� �����Է�)    
                {

                    if (GameObject.Find(string.Format("{0} _ {1} ", x + 1, z - 1)).transform.GetChild(0).CompareTag("W"))
                    {
                        //Debug.Log(GameObject.Find(string.Format("{0} _ {1} ", x + 1, z + 1)));

                        GameObject ct3 = Instantiate(cTile);//Ŭ���Ͽ� ��ġ�� �̵��ϴ� Ÿ�� ����
                        ct3.tag = "CT";//�±�����
                        ct3.name = "Ctile";//�̸�����
                        ct3.transform.parent = GameObject.Find(string.Format("{0} _ {1} ", x + 1, z - 1)).transform;
                        ct3.transform.position
                        =
                        new Vector3(ct3.transform.parent.transform.position.x, ct3.transform.parent.transform.position.y, ct3.transform.parent.transform.position.z);
                        //SetP(ct3, string.Format("{0} _ {1}",x+1,z+1 ));
                        Debug.Log(string.Format("{0} _ {1}", x + 1, z - 1));
                        exClickTile = true;

                    }//������ �Ʒ� ������(�Լ� �ϸ� �������� �����Է�)    
                }
            }//������
            else if (x + 1 < 9 && z - 1 < 1)//�Ʒ��� �ʰ���
            {
                if (GameObject.Find(string.Format("{0} _ {1} ", x + 1, 20)).transform.childCount > 0) //������ �Ʒ� ������(�Լ� �ϸ� �������� �����Է�)    
                {

                    if (GameObject.Find(string.Format("{0} _ {1} ", x + 1, 20)).transform.GetChild(0).CompareTag("W"))
                    {

                        GameObject ct3 = Instantiate(cTile);//Ŭ���Ͽ� ��ġ�� �̵��ϴ� Ÿ�� ����
                        ct3.tag = "CT";//�±�����
                        ct3.name = "Ctile";//�̸�����
                        ct3.transform.parent = GameObject.Find(string.Format("{0} _ {1} ", x + 1, 20)).transform;
                        ct3.transform.position
                        =
                        new Vector3(ct3.transform.parent.transform.position.x, ct3.transform.parent.transform.position.y, ct3.transform.parent.transform.position.z);
                        //SetP(ct3, string.Format("{0} _ {1}",x+1,z+1 ));
                        Debug.Log(string.Format("{0} _ {1}", x + 1, 20));
                        exClickTile = true;

                    }//������ �Ʒ� ������(�Լ� �ϸ� �������� �����Է�)    
                }
            }
            if (x - 1 > 0 && z - 1 > 0)
            {
                if (GameObject.Find(string.Format("{0} _ {1} ", x - 1, z - 1)).transform.childCount > 0) //���� �Ʒ� ������(�Լ� �ϸ� �������� �����Է�)    
                {

                    if (GameObject.Find(string.Format("{0} _ {1} ", x - 1, z - 1)).transform.GetChild(0).CompareTag("W"))
                    {


                        GameObject ct3 = Instantiate(cTile);//Ŭ���Ͽ� ��ġ�� �̵��ϴ� Ÿ�� ����
                        ct3.tag = "CT";//�±�����
                        ct3.name = "Ctile";//�̸�����
                        ct3.transform.parent = GameObject.Find(string.Format("{0} _ {1} ", x - 1, z - 1)).transform;
                        ct3.transform.position
                        =
                        new Vector3(ct3.transform.parent.transform.position.x, ct3.transform.parent.transform.position.y, ct3.transform.parent.transform.position.z);

                        Debug.Log(string.Format("{0} _ {1}", x - 1, z - 1));
                        exClickTile = true;

                    }
                }
            }//���� �Ʒ� ������(�Լ� �ϸ� �������� �����Է�)    
            else if (x - 1 > 0 && z - 1 < 1)//�Ʒ��� �ʰ���
            {
                if (GameObject.Find(string.Format("{0} _ {1} ", x - 1, 20)).transform.childCount > 0) //���� �Ʒ� ������(�Լ� �ϸ� �������� �����Է�)    
                {

                    if (GameObject.Find(string.Format("{0} _ {1} ", x - 1, 20)).transform.GetChild(0).CompareTag("W"))
                    {


                        GameObject ct3 = Instantiate(cTile);//Ŭ���Ͽ� ��ġ�� �̵��ϴ� Ÿ�� ����
                        ct3.tag = "CT";//�±�����
                        ct3.name = "Ctile";//�̸�����
                        ct3.transform.parent = GameObject.Find(string.Format("{0} _ {1} ", x - 1, 20)).transform;
                        ct3.transform.position
                        =
                        new Vector3(ct3.transform.parent.transform.position.x, ct3.transform.parent.transform.position.y, ct3.transform.parent.transform.position.z);

                        Debug.Log(string.Format("{0} _ {1}", x - 1, 20));
                        exClickTile = true;

                    }//���� �Ʒ� ������(�Լ� �ϸ� �������� �����Է�)    
                }
            }

        }
        //�����϶�


        //����Ÿ��
    }//�Ʒ��� ���� ��

    public void RookMove(GameObject cO, string turn, float x, float z)//���̵�Ÿ�� ����
    {
        chosObj = cO;//���õ� ������Ʈ�� ������ ����

        for (int i = 1; i < 20; i++) //���λ���
        {
            if (z + i < 21)//���λ���
            {
                if (GameObject.Find(string.Format("{0} _ {1} ", x, z + i)).transform.childCount == 1)
                {
                    if (turn == "W")//����
                    {
                        if (GameObject.Find(string.Format("{0} _ {1} ", x, z + i)).transform.GetChild(0).tag == "B")
                        {
                            GameObject ct = Instantiate(cTile);//Ŭ���Ͽ� ��ġ�� �̵��ϴ� Ÿ�� ����
                            ct.tag = "CT";//�±�����
                            ct.name = "Ctile";//�̸�����
                            SetP(ct, string.Format("{0} _ {1} ", x, z + i));
                            exClickTile = true;
                            break;
                        }
                        else
                        {
                            break;
                        }
                    }//����
                    else //����
                    {
                        if (GameObject.Find(string.Format("{0} _ {1} ", x, z + i)).transform.GetChild(0).tag == "W")
                        {
                            GameObject ct = Instantiate(cTile);//Ŭ���Ͽ� ��ġ�� �̵��ϴ� Ÿ�� ����
                            ct.tag = "CT";//�±�����
                            ct.name = "Ctile";//�̸�����
                            SetP(ct, string.Format("{0} _ {1} ", x, z + i));
                            exClickTile = true;
                            break;
                        }
                        else
                        {
                            break;
                        }
                    }//����
                }
                else
                {

                    GameObject ct = Instantiate(cTile);//Ŭ���Ͽ� ��ġ�� �̵��ϴ� Ÿ�� ����
                    ct.tag = "CT";//�±�����
                    ct.name = "Ctile";//�̸�����
                    SetP(ct, string.Format("{0} _ {1} ", x, z + i));
                    exClickTile = true;



                }
            }//���λ���
            else if (z + i > 20)
            {
                if (GameObject.Find(string.Format("{0} _ {1} ", x, z + i - 20)).transform.childCount == 1)
                {
                    if (turn == "W")//����
                    {
                        if (GameObject.Find(string.Format("{0} _ {1} ", x, z + i - 20)).transform.GetChild(0).tag == "B")
                        {
                            GameObject ct = Instantiate(cTile);//Ŭ���Ͽ� ��ġ�� �̵��ϴ� Ÿ�� ����
                            ct.tag = "CT";//�±�����
                            ct.name = "Ctile";//�̸�����
                            SetP(ct, string.Format("{0} _ {1} ", x, z + i - 20));
                            exClickTile = true;
                            break;
                        }
                        else
                        {
                            break;
                        }
                    }//����
                    else //����
                    {
                        if (GameObject.Find(string.Format("{0} _ {1} ", x, z + i - 20)).transform.GetChild(0).tag == "W")
                        {
                            GameObject ct = Instantiate(cTile);//Ŭ���Ͽ� ��ġ�� �̵��ϴ� Ÿ�� ����
                            ct.tag = "CT";//�±�����
                            ct.name = "Ctile";//�̸�����
                            SetP(ct, string.Format("{0} _ {1} ", x, z + i - 20));
                            exClickTile = true;
                            break;
                        }
                        else
                        {
                            break;
                        }
                    }//����
                }
                else
                {

                    GameObject ct = Instantiate(cTile);//Ŭ���Ͽ� ��ġ�� �̵��ϴ� Ÿ�� ����
                    ct.tag = "CT";//�±�����
                    ct.name = "Ctile";//�̸�����
                    SetP(ct, string.Format("{0} _ {1} ", x, z + i - 20));
                    exClickTile = true;



                }
            }//���λ���
        }//���� ����
        for (int i = 1; i < 20; i++) //�Ʒ�����
        {
            if (z - i > 0)//�Ʒ��λ���
            {
                if (GameObject.Find(string.Format("{0} _ {1} ", x, z - i)).transform.childCount == 2)
                {
                    break;
                }
                if (GameObject.Find(string.Format("{0} _ {1} ", x, z - i)).transform.childCount == 1)
                {
                    if (GameObject.Find(string.Format("{0} _ {1} ", x, z - i)).transform.GetChild(0).tag == "CT")
                    {
                        break;
                    }
                    if (turn == "W")//����
                    {
                        if (GameObject.Find(string.Format("{0} _ {1} ", x, z - i)).transform.GetChild(0).tag == "B")
                        {
                            GameObject ct = Instantiate(cTile);//Ŭ���Ͽ� ��ġ�� �̵��ϴ� Ÿ�� ����
                            ct.tag = "CT";//�±�����
                            ct.name = "Ctile";//�̸�����
                            SetP(ct, string.Format("{0} _ {1} ", x, z - i));
                            exClickTile = true;
                            break;
                        }
                        else
                        {
                            break;
                        }
                    }//����
                    else //����
                    {
                        if (GameObject.Find(string.Format("{0} _ {1} ", x, z - i)).transform.GetChild(0).tag == "W")
                        {
                            GameObject ct = Instantiate(cTile);//Ŭ���Ͽ� ��ġ�� �̵��ϴ� Ÿ�� ����
                            ct.tag = "CT";//�±�����
                            ct.name = "Ctile";//�̸�����
                            SetP(ct, string.Format("{0} _ {1} ", x, z - i));
                            exClickTile = true;
                            break;
                        }
                        else
                        {
                            break;
                        }
                    }//����
                }
                else
                {

                    GameObject ct = Instantiate(cTile);//Ŭ���Ͽ� ��ġ�� �̵��ϴ� Ÿ�� ����
                    ct.tag = "CT";//�±�����
                    ct.name = "Ctile";//�̸�����
                    SetP(ct, string.Format("{0} _ {1} ", x, z - i));
                    exClickTile = true;



                }
            }//�Ʒ�����
            else if (z - i < 1)
            {

                if (GameObject.Find(string.Format("{0} _ {1} ", x, z - i + 20)).transform.childCount == 2)
                {
                    break;
                }
                if (GameObject.Find(string.Format("{0} _ {1} ", x, z - i + 20)).transform.childCount == 1)
                {
                    if (GameObject.Find(string.Format("{0} _ {1} ", x, z - i + 20)).transform.GetChild(0).tag == "CT")
                    {
                        break;
                    }
                    if (turn == "W")//����
                    {

                        if (GameObject.Find(string.Format("{0} _ {1} ", x, z - i + 20)).transform.GetChild(0).tag == "B")
                        {
                            GameObject ct = Instantiate(cTile);//Ŭ���Ͽ� ��ġ�� �̵��ϴ� Ÿ�� ����
                            ct.tag = "CT";//�±�����
                            ct.name = "Ctile";//�̸�����
                            SetP(ct, string.Format("{0} _ {1} ", x, z - i + 20));
                            exClickTile = true;
                            break;
                        }
                        else
                        {
                            break;
                        }
                    }//����
                    else //����
                    {
                        if (GameObject.Find(string.Format("{0} _ {1} ", x, z - i + 20)).transform.GetChild(0).tag == "W")
                        {
                            GameObject ct = Instantiate(cTile);//Ŭ���Ͽ� ��ġ�� �̵��ϴ� Ÿ�� ����
                            ct.tag = "CT";//�±�����
                            ct.name = "Ctile";//�̸�����
                            SetP(ct, string.Format("{0} _ {1} ", x, z - i + 20));
                            exClickTile = true;
                            break;
                        }
                        else
                        {
                            break;
                        }
                    }//����
                }
                else
                {

                    GameObject ct = Instantiate(cTile);//Ŭ���Ͽ� ��ġ�� �̵��ϴ� Ÿ�� ����
                    ct.tag = "CT";//�±�����
                    ct.name = "Ctile";//�̸�����
                    SetP(ct, string.Format("{0} _ {1} ", x, z - i + 20));
                    exClickTile = true;




                }
            }//�Ʒ��λ���
        }//�Ʒ��� ����
        for (int i = 1; i < 8; i++)
        {
            if (x + i < 9)
            {
                if (GameObject.Find(string.Format("{0} _ {1} ", x + i, z)).transform.childCount == 0) //��Ÿ��
                {
                    CreatCT(x + i, z);
                }//��Ÿ��
                else if (GameObject.Find(string.Format("{0} _ {1} ", x + i, z)).transform.childCount == 1) //�Ⱥ�Ÿ��
                {
                    if (turn == "W" && GameObject.Find(string.Format("{0} _ {1} ", x + i, z)).transform.GetChild(0).tag == "B")//���Ͽ� ���̸� 
                    {
                        CreatCT(x + i, z);
                        break;
                    }
                    else if (turn == "W" && GameObject.Find(string.Format("{0} _ {1} ", x + i, z)).transform.GetChild(0).tag == "W")//���Ͽ����̸� 
                    {
                        break;
                    }
                    else if (turn == "B" && GameObject.Find(string.Format("{0} _ {1} ", x + i, z)).transform.GetChild(0).tag == "W")//���Ͽ����̸�
                    {
                        CreatCT(x + i, z);
                        break;
                    }
                    else if (turn == "B" && GameObject.Find(string.Format("{0} _ {1} ", x + i, z)).transform.GetChild(0).tag == "B")//���Ͽ����̸� 
                    {
                        break;
                    }
                }//�Ⱥ�Ÿ��

            }
            else
            {
                break;
            }


        }//�����ʻ���
        for (int i = 1; i < 8; i++)
        {
            if (x - i > 0)
            {
                if (GameObject.Find(string.Format("{0} _ {1} ", x - i, z)).transform.childCount == 0) //��Ÿ��
                {
                    CreatCT(x - i, z);
                }//��Ÿ��
                else if (GameObject.Find(string.Format("{0} _ {1} ", x - i, z)).transform.childCount == 1) //�Ⱥ�Ÿ��
                {
                    if (turn == "W" && GameObject.Find(string.Format("{0} _ {1} ", x - i, z)).transform.GetChild(0).tag == "B")//���Ͽ� ���̸� 
                    {
                        CreatCT(x - i, z);
                        break;
                    }
                    else if (turn == "W" && GameObject.Find(string.Format("{0} _ {1} ", x - i, z)).transform.GetChild(0).tag == "W")//���Ͽ����̸� 
                    {
                        break;
                    }
                    else if (turn == "B" && GameObject.Find(string.Format("{0} _ {1} ", x - i, z)).transform.GetChild(0).tag == "W")//���Ͽ����̸�
                    {
                        CreatCT(x - i, z);
                        break;
                    }
                    else if (turn == "B" && GameObject.Find(string.Format("{0} _ {1} ", x - i, z)).transform.GetChild(0).tag == "B")//���Ͽ����̸� 
                    {
                        break;
                    }
                }//�Ⱥ�Ÿ��

            }
            else
            {
                break;
            }


        }//���ʻ���
    }//���̵�Ÿ�ϻ���

    public void BishopMove(GameObject cO, string turn, float x, float z)
    {
        chosObj = cO;//���õ� ������Ʈ�� ������ ����
        for (int i = 1; i < 8; i++)//�������� ����
        {
            if (z + i < 21)
            {
                if (x + i > 8)
                {
                    break;

                }
                else
                {
                    if (GameObject.Find(string.Format("{0} _ {1} ", x + i, z + i)).transform.childCount == 0) //��Ÿ��
                    {
                        CreatCT(x + i, z + i);
                    }//��Ÿ��
                    else if (GameObject.Find(string.Format("{0} _ {1} ", x + i, z + i)).transform.childCount == 1)
                    {
                        if (turn == "W")
                        {
                            if (GameObject.Find(string.Format("{0} _ {1} ", x + i, z + i)).transform.GetChild(0).tag == "B")
                            {
                                CreatCT(x + i, z + i);
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                        if (turn == "B")
                        {
                            if (GameObject.Find(string.Format("{0} _ {1} ", x + i, z + i)).transform.GetChild(0).tag == "W")
                            {
                                CreatCT(x + i, z + i);
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }

                }
            }
            else if (z + i > 20)
            {
                if (x + i > 8)
                {
                    break;

                }
                else
                {
                    if (GameObject.Find(string.Format("{0} _ {1} ", x + i, z + i - 20)).transform.childCount == 0) //��Ÿ��
                    {
                        CreatCT(x + i, z + i - 20);
                    }//��Ÿ��
                    else if (GameObject.Find(string.Format("{0} _ {1} ", x + i, z + i - 20)).transform.childCount == 1)
                    {
                        if (turn == "W")
                        {
                            if (GameObject.Find(string.Format("{0} _ {1} ", x + i, z + i - 20)).transform.GetChild(0).tag == "B")
                            {
                                CreatCT(x + i, z + i - 20);
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                        if (turn == "B")
                        {
                            if (GameObject.Find(string.Format("{0} _ {1} ", x + i, z + i - 20)).transform.GetChild(0).tag == "W")
                            {
                                CreatCT(x + i, z + i - 20);
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                }
            }
        }//�������� ����

        for (int i = 1; i < 8; i++)//������ ����
        {
            if (z + i < 21)
            {
                if (x - i < 1)
                {
                    break;

                }
                else
                {
                    if (GameObject.Find(string.Format("{0} _ {1} ", x - i, z + i)).transform.childCount == 0) //��Ÿ��
                    {
                        CreatCT(x - i, z + i);
                    }//��Ÿ��
                    else if (GameObject.Find(string.Format("{0} _ {1} ", x - i, z + i)).transform.childCount == 1)
                    {
                        if (turn == "W")
                        {
                            if (GameObject.Find(string.Format("{0} _ {1} ", x - i, z + i)).transform.GetChild(0).tag == "B")
                            {
                                CreatCT(x - i, z + i);
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                        if (turn == "B")
                        {
                            if (GameObject.Find(string.Format("{0} _ {1} ", x - i, z + i)).transform.GetChild(0).tag == "W")
                            {
                                CreatCT(x - i, z + i);
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                }
            }
            else if (z + i > 20)
            {
                if (x - i < 1)
                {
                    break;

                }
                else
                {
                    if (GameObject.Find(string.Format("{0} _ {1} ", x - i, z + i - 20)).transform.childCount == 0) //��Ÿ��
                    {
                        CreatCT(x - i, z + i - 20);
                    }//��Ÿ��
                    else if (GameObject.Find(string.Format("{0} _ {1} ", x - i, z + i - 20)).transform.childCount == 1)
                    {
                        if (turn == "W")
                        {
                            if (GameObject.Find(string.Format("{0} _ {1} ", x - i, z + i - 20)).transform.GetChild(0).tag == "B")
                            {
                                CreatCT(x - i, z + i - 20);
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                        if (turn == "B")
                        {
                            if (GameObject.Find(string.Format("{0} _ {1} ", x - i, z + i - 20)).transform.GetChild(0).tag == "W")
                            {
                                CreatCT(x - i, z + i - 20);
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                }
            }
        }//������ ����

        for (int i = 1; i < 8; i++)//�����ʾƷ� ����
        {
            if (z - i > 0)
            {
                if (x + i > 8)
                {
                    break;

                }
                else
                {
                    if (GameObject.Find(string.Format("{0} _ {1} ", x + i, z - i)).transform.childCount == 0) //��Ÿ��
                    {
                        CreatCT(x + i, z - i);
                    }//��Ÿ��
                    else if (GameObject.Find(string.Format("{0} _ {1} ", x + i, z - i)).transform.childCount == 1)
                    {
                        if (turn == "W")
                        {
                            if (GameObject.Find(string.Format("{0} _ {1} ", x + i, z - i)).transform.GetChild(0).tag == "B")
                            {
                                CreatCT(x + i, z - i);
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                        if (turn == "B")
                        {
                            if (GameObject.Find(string.Format("{0} _ {1} ", x + i, z - i)).transform.GetChild(0).tag == "W")
                            {
                                CreatCT(x + i, z - i);
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }

                }
            }
            else if (z - i < 1)
            {
                if (x + i > 8)
                {
                    break;

                }
                else
                {
                    if (GameObject.Find(string.Format("{0} _ {1} ", x + i, z - i + 20)).transform.childCount == 0) //��Ÿ��
                    {
                        CreatCT(x + i, z - i + 20);
                    }//��Ÿ��
                    else if (GameObject.Find(string.Format("{0} _ {1} ", x + i, z - i + 20)).transform.childCount == 1)
                    {
                        if (turn == "W")
                        {
                            if (GameObject.Find(string.Format("{0} _ {1} ", x + i, z - i + 20)).transform.GetChild(0).tag == "B")
                            {
                                CreatCT(x + i, z - i + 20);
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                        if (turn == "B")
                        {
                            if (GameObject.Find(string.Format("{0} _ {1} ", x + i, z - i + 20)).transform.GetChild(0).tag == "W")
                            {
                                CreatCT(x + i, z - i + 20);
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                }
            }
        }//�����ʾƷ� ����

        for (int i = 1; i < 8; i++)//���ʾƷ� ����
        {
            if (z - i > 0)
            {
                if (x - i < 1)
                {
                    break;

                }
                else
                {
                    if (GameObject.Find(string.Format("{0} _ {1} ", x - i, z - i)).transform.childCount == 0) //��Ÿ��
                    {
                        CreatCT(x - i, z - i);
                    }//��Ÿ��
                    else if (GameObject.Find(string.Format("{0} _ {1} ", x - i, z - i)).transform.childCount == 1)
                    {
                        if (turn == "W")
                        {
                            if (GameObject.Find(string.Format("{0} _ {1} ", x - i, z - i)).transform.GetChild(0).tag == "B")
                            {
                                CreatCT(x - i, z - i);
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                        if (turn == "B")
                        {
                            if (GameObject.Find(string.Format("{0} _ {1} ", x - i, z - i)).transform.GetChild(0).tag == "W")
                            {
                                CreatCT(x - i, z - i);
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                }
            }
            else if (z - i < 1)
            {
                if (x - i < 1)
                {
                    break;

                }
                else
                {
                    if (GameObject.Find(string.Format("{0} _ {1} ", x - i, z - i + 20)).transform.childCount == 0) //��Ÿ��
                    {
                        CreatCT(x - i, z - i + 20);
                    }//��Ÿ��
                    else if (GameObject.Find(string.Format("{0} _ {1} ", x - i, z - i + 20)).transform.childCount == 1)
                    {
                        if (turn == "W")
                        {
                            if (GameObject.Find(string.Format("{0} _ {1} ", x - i, z - i + 20)).transform.GetChild(0).tag == "B")
                            {
                                CreatCT(x - i, z - i + 20);
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                        if (turn == "B")
                        {
                            if (GameObject.Find(string.Format("{0} _ {1} ", x - i, z - i + 20)).transform.GetChild(0).tag == "W")
                            {
                                CreatCT(x - i, z - i + 20);
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                }
            }
        }//���ʾƷ� ����
    }//����̵�Ÿ�� ����

    public void KnightMove(GameObject cO, string turn, float x, float z)//����Ʈ�̵� Ÿ�� ���� 
    {
        chosObj = cO;
        ////////////////////////�����ʿ��� ù��° 2��
        ////////////////////////�����ʿ��� ù��° 2��
        if (x + 2 > 8)
        {
        }
        else if (x + 2 < 9)
        {
            if (z + 1 < 21)
            {
                if (GameObject.Find(string.Format("{0} _ {1} ", x + 2, z + 1)).transform.childCount == 0)
                {
                    CreatCT(x + 2, z + 1);
                }
                else if (GameObject.Find(string.Format("{0} _ {1} ", x + 2, z + 1)).transform.childCount == 1)
                {
                    if (turn == "W")
                    {
                        if (GameObject.Find(string.Format("{0} _ {1} ", x + 2, z + 1)).transform.GetChild(0).tag == "B")
                        {
                            CreatCT(x + 2, z + 1);

                        }

                    }
                    if (turn == "B")
                    {
                        if (GameObject.Find(string.Format("{0} _ {1} ", x + 2, z + 1)).transform.GetChild(0).tag == "W")
                        {
                            CreatCT(x + 2, z + 1);

                        }

                    }
                }

            }
            else if (z + 1 > 20)
            {
                if (GameObject.Find(string.Format("{0} _ {1} ", x + 2, 1)).transform.childCount == 0)
                {
                    CreatCT(x + 2, 1);
                }
                else if (GameObject.Find(string.Format("{0} _ {1} ", x + 2, 1)).transform.childCount == 1)
                {
                    if (turn == "W")
                    {
                        if (GameObject.Find(string.Format("{0} _ {1} ", x + 2, 1)).transform.GetChild(0).tag == "B")
                        {
                            CreatCT(x + 2, 1);

                        }

                    }
                    if (turn == "B")
                    {
                        if (GameObject.Find(string.Format("{0} _ {1} ", x + 2, 1)).transform.GetChild(0).tag == "W")
                        {
                            CreatCT(x + 2, 1);

                        }

                    }
                }
            }
            if (z - 1 > 0)
            {
                if (GameObject.Find(string.Format("{0} _ {1} ", x + 2, z - 1)).transform.childCount == 0)
                {
                    CreatCT(x + 2, z - 1);
                }
                else if (GameObject.Find(string.Format("{0} _ {1} ", x + 2, z - 1)).transform.childCount == 1)
                {
                    if (turn == "W")
                    {
                        if (GameObject.Find(string.Format("{0} _ {1} ", x + 2, z - 1)).transform.GetChild(0).tag == "B")
                        {
                            CreatCT(x + 2, z - 1);

                        }

                    }
                    if (turn == "B")
                    {
                        if (GameObject.Find(string.Format("{0} _ {1} ", x + 2, z - 1)).transform.GetChild(0).tag == "W")
                        {
                            CreatCT(x + 2, z - 1);

                        }

                    }
                }
            }
            else if (z - 1 < 1)
            {
                if (GameObject.Find(string.Format("{0} _ {1} ", x + 2, 20)).transform.childCount == 0)
                {
                    CreatCT(x + 2, 20);
                }
                else if (GameObject.Find(string.Format("{0} _ {1} ", x + 2, 20)).transform.childCount == 1)
                {
                    if (turn == "W")
                    {
                        if (GameObject.Find(string.Format("{0} _ {1} ", x + 2, 20)).transform.GetChild(0).tag == "B")
                        {
                            CreatCT(x + 2, 20);

                        }

                    }
                    if (turn == "B")
                    {
                        if (GameObject.Find(string.Format("{0} _ {1} ", x + 2, 20)).transform.GetChild(0).tag == "W")
                        {
                            CreatCT(x + 2, 20);

                        }

                    }
                }
            }
        }
        ////////////////////////���ʿ��� ù��° 2��
        ////////////////////////���ʿ��� ù��° 2��
        if (x - 2 < 1)
        {
        }
        else if (x - 2 > 0)
        {
            if (z + 1 < 21)
            {
                if (GameObject.Find(string.Format("{0} _ {1} ", x - 2, z + 1)).transform.childCount == 0)
                {
                    CreatCT(x - 2, z + 1);
                }
                else if (GameObject.Find(string.Format("{0} _ {1} ", x - 2, z + 1)).transform.childCount == 1)
                {
                    if (turn == "W")
                    {
                        if (GameObject.Find(string.Format("{0} _ {1} ", x - 2, z + 1)).transform.GetChild(0).tag == "B")
                        {
                            CreatCT(x - 2, z + 1);

                        }

                    }
                    if (turn == "B")
                    {
                        if (GameObject.Find(string.Format("{0} _ {1} ", x - 2, z + 1)).transform.GetChild(0).tag == "W")
                        {
                            CreatCT(x - 2, z + 1);

                        }

                    }
                }

            }
            else if (z + 1 > 20)
            {
                if (GameObject.Find(string.Format("{0} _ {1} ", x - 2, 1)).transform.childCount == 0)
                {
                    CreatCT(x - 2, 1);
                }
                else if (GameObject.Find(string.Format("{0} _ {1} ", x - 2, 1)).transform.childCount == 1)
                {
                    if (turn == "W")
                    {
                        if (GameObject.Find(string.Format("{0} _ {1} ", x - 2, 1)).transform.GetChild(0).tag == "B")
                        {
                            CreatCT(x - 2, 1);

                        }

                    }
                    if (turn == "B")
                    {
                        if (GameObject.Find(string.Format("{0} _ {1} ", x - 2, 1)).transform.GetChild(0).tag == "W")
                        {
                            CreatCT(x - 2, 1);

                        }

                    }
                }
            }
            if (z - 1 > 0)
            {
                if (GameObject.Find(string.Format("{0} _ {1} ", x - 2, z - 1)).transform.childCount == 0)
                {
                    CreatCT(x - 2, z - 1);
                }
                else if (GameObject.Find(string.Format("{0} _ {1} ", x - 2, z - 1)).transform.childCount == 1)
                {
                    if (turn == "W")
                    {
                        if (GameObject.Find(string.Format("{0} _ {1} ", x - 2, z - 1)).transform.GetChild(0).tag == "B")
                        {
                            CreatCT(x - 2, z - 1);

                        }

                    }
                    if (turn == "B")
                    {
                        if (GameObject.Find(string.Format("{0} _ {1} ", x - 2, z - 1)).transform.GetChild(0).tag == "W")
                        {
                            CreatCT(x - 2, z - 1);

                        }

                    }
                }
            }
            else if (z - 1 < 1)
            {
                if (GameObject.Find(string.Format("{0} _ {1} ", x - 2, 20)).transform.childCount == 0)
                {
                    CreatCT(x + 2, 20);
                }
                else if (GameObject.Find(string.Format("{0} _ {1} ", x - 2, 20)).transform.childCount == 1)
                {
                    if (turn == "W")
                    {
                        if (GameObject.Find(string.Format("{0} _ {1} ", x - 2, 20)).transform.GetChild(0).tag == "B")
                        {
                            CreatCT(x - 2, 20);

                        }

                    }
                    if (turn == "B")
                    {
                        if (GameObject.Find(string.Format("{0} _ {1} ", x - 2, 20)).transform.GetChild(0).tag == "W")
                        {
                            CreatCT(x - 2, 20);

                        }

                    }
                }
            }
        }
        ////////////////////////�����ʿ��� �ι�° 2��
        ////////////////////////�����ʿ��� �ι�° 2��
        if (x + 1 > 8)
        {
        }
        else if (x + 1 < 9)
        {
            if (z + 2 < 21)
            {
                if (GameObject.Find(string.Format("{0} _ {1} ", x + 1, z + 2)).transform.childCount == 0)
                {
                    CreatCT(x + 1, z + 2);
                }
                else if (GameObject.Find(string.Format("{0} _ {1} ", x + 1, z + 2)).transform.childCount == 1)
                {
                    if (turn == "W")
                    {
                        if (GameObject.Find(string.Format("{0} _ {1} ", x + 1, z + 2)).transform.GetChild(0).tag == "B")
                        {
                            CreatCT(x + 1, z + 2);

                        }

                    }
                    if (turn == "B")
                    {
                        if (GameObject.Find(string.Format("{0} _ {1} ", x + 1, z + 2)).transform.GetChild(0).tag == "W")
                        {
                            CreatCT(x + 1, z + 2);

                        }

                    }
                }

            }
            else if (z + 2 > 20)
            {
                if (GameObject.Find(string.Format("{0} _ {1} ", x + 1, z - 19)).transform.childCount == 0)
                {
                    CreatCT(x + 1, z - 19);
                }
                else if (GameObject.Find(string.Format("{0} _ {1} ", x + 1, z - 19)).transform.childCount == 1)
                {
                    if (turn == "W")
                    {
                        if (GameObject.Find(string.Format("{0} _ {1} ", x + 1, z - 19)).transform.GetChild(0).tag == "B")
                        {
                            CreatCT(x + 1, z - 19);

                        }

                    }
                    if (turn == "B")
                    {
                        if (GameObject.Find(string.Format("{0} _ {1} ", x + 1, z - 19)).transform.GetChild(0).tag == "W")
                        {
                            CreatCT(x + 1, z - 19);

                        }

                    }
                }
            }
            if (z - 2 > 0)
            {
                if (GameObject.Find(string.Format("{0} _ {1} ", x + 1, z - 2)).transform.childCount == 0)
                {
                    CreatCT(x + 1, z - 2);
                }
                else if (GameObject.Find(string.Format("{0} _ {1} ", x + 1, z - 2)).transform.childCount == 1)
                {
                    if (turn == "W")
                    {
                        if (GameObject.Find(string.Format("{0} _ {1} ", x + 1, z - 2)).transform.GetChild(0).tag == "B")
                        {
                            CreatCT(x + 1, z - 2);

                        }

                    }
                    if (turn == "B")
                    {
                        if (GameObject.Find(string.Format("{0} _ {1} ", x + 1, z - 2)).transform.GetChild(0).tag == "W")
                        {
                            CreatCT(x + 1, z - 2);

                        }

                    }
                }
            }
            else if (z - 2 < 1)
            {
                if (GameObject.Find(string.Format("{0} _ {1} ", x + 1, z + 18)).transform.childCount == 0)
                {
                    CreatCT(x + 1, z + 18);
                }
                else if (GameObject.Find(string.Format("{0} _ {1} ", x + 1, z + 18)).transform.childCount == 1)
                {
                    if (turn == "W")
                    {
                        if (GameObject.Find(string.Format("{0} _ {1} ", x + 1, z + 18)).transform.GetChild(0).tag == "B")
                        {
                            CreatCT(x + 1, z + 18);

                        }

                    }
                    if (turn == "B")
                    {
                        if (GameObject.Find(string.Format("{0} _ {1} ", x + 1, z + 18)).transform.GetChild(0).tag == "W")
                        {
                            CreatCT(x + 1, z + 18);

                        }

                    }
                }
            }
        }
        ///////////////////////���ʿ��� �ι�°2��
        ///////////////////////���ʿ��� �ι�°2��
        if (x - 1 < 1)
        {
        }
        else if (x - 1 > 0)
        {
            if (z + 2 < 21)
            {
                if (GameObject.Find(string.Format("{0} _ {1} ", x - 1, z + 2)).transform.childCount == 0)
                {
                    CreatCT(x - 1, z + 2);
                }
                else if (GameObject.Find(string.Format("{0} _ {1} ", x - 1, z + 2)).transform.childCount == 1)
                {
                    if (turn == "W")
                    {
                        if (GameObject.Find(string.Format("{0} _ {1} ", x - 1, z + 2)).transform.GetChild(0).tag == "B")
                        {
                            CreatCT(x - 1, z + 2);

                        }

                    }
                    if (turn == "B")
                    {
                        if (GameObject.Find(string.Format("{0} _ {1} ", x - 1, z + 2)).transform.GetChild(0).tag == "W")
                        {
                            CreatCT(x - 1, z + 2);

                        }

                    }
                }

            }
            else if (z + 2 > 20)
            {
                if (GameObject.Find(string.Format("{0} _ {1} ", x - 1, z - 19)).transform.childCount == 0)
                {
                    CreatCT(x - 1, z - 19);
                }
                else if (GameObject.Find(string.Format("{0} _ {1} ", x - 1, z - 19)).transform.childCount == 1)
                {
                    if (turn == "W")
                    {
                        if (GameObject.Find(string.Format("{0} _ {1} ", x - 1, z - 19)).transform.GetChild(0).tag == "B")
                        {
                            CreatCT(x - 1, z - 19);

                        }

                    }
                    if (turn == "B")
                    {
                        if (GameObject.Find(string.Format("{0} _ {1} ", x - 1, z - 19)).transform.GetChild(0).tag == "W")
                        {
                            CreatCT(x - 1, z - 19);

                        }

                    }
                }
            }
            if (z - 2 > 0)
            {
                if (GameObject.Find(string.Format("{0} _ {1} ", x - 1, z - 2)).transform.childCount == 0)
                {
                    CreatCT(x - 1, z - 2);
                }
                else if (GameObject.Find(string.Format("{0} _ {1} ", x - 1, z - 2)).transform.childCount == 1)
                {
                    if (turn == "W")
                    {
                        if (GameObject.Find(string.Format("{0} _ {1} ", x - 1, z - 2)).transform.GetChild(0).tag == "B")
                        {
                            CreatCT(x - 1, z - 2);

                        }

                    }
                    if (turn == "B")
                    {
                        if (GameObject.Find(string.Format("{0} _ {1} ", x - 1, z - 2)).transform.GetChild(0).tag == "W")
                        {
                            CreatCT(x - 1, z - 2);

                        }

                    }
                }
            }
            else if (z - 2 < 1)
            {
                if (GameObject.Find(string.Format("{0} _ {1} ", x - 1, z + 18)).transform.childCount == 0)
                {
                    CreatCT(x - 1, z + 18);
                }
                else if (GameObject.Find(string.Format("{0} _ {1} ", x - 1, z + 18)).transform.childCount == 1)
                {
                    if (turn == "W")
                    {
                        if (GameObject.Find(string.Format("{0} _ {1} ", x - 1, z + 18)).transform.GetChild(0).tag == "B")
                        {
                            CreatCT(x - 1, z + 18);

                        }

                    }
                    if (turn == "B")
                    {
                        if (GameObject.Find(string.Format("{0} _ {1} ", x - 1, z + 18)).transform.GetChild(0).tag == "W")
                        {
                            CreatCT(x - 1, z + 18);

                        }

                    }
                }
            }
        }
        //////////////////////////////////////////
    }

    public void QueenMove(GameObject cO, string turn, float x, float z)//���̵�Ÿ�ϻ���
    {
        chosObj = cO;//���õ� ������Ʈ�� ������ ����
        for (int i = 1; i < 20; i++) //���λ���
        {
            if (z + i < 21)//���λ���
            {
                if (GameObject.Find(string.Format("{0} _ {1} ", x, z + i)).transform.childCount == 1)
                {
                    if (turn == "W")//����
                    {
                        if (GameObject.Find(string.Format("{0} _ {1} ", x, z + i)).transform.GetChild(0).tag == "B")
                        {
                            GameObject ct = Instantiate(cTile);//Ŭ���Ͽ� ��ġ�� �̵��ϴ� Ÿ�� ����
                            ct.tag = "CT";//�±�����
                            ct.name = "Ctile";//�̸�����
                            SetP(ct, string.Format("{0} _ {1} ", x, z + i));
                            exClickTile = true;
                            break;
                        }
                        else
                        {
                            break;
                        }
                    }//����
                    else //����
                    {
                        if (GameObject.Find(string.Format("{0} _ {1} ", x, z + i)).transform.GetChild(0).tag == "W")
                        {
                            GameObject ct = Instantiate(cTile);//Ŭ���Ͽ� ��ġ�� �̵��ϴ� Ÿ�� ����
                            ct.tag = "CT";//�±�����
                            ct.name = "Ctile";//�̸�����
                            SetP(ct, string.Format("{0} _ {1} ", x, z + i));
                            exClickTile = true;
                            break;
                        }
                        else
                        {
                            break;
                        }
                    }//����
                }
                else
                {

                    GameObject ct = Instantiate(cTile);//Ŭ���Ͽ� ��ġ�� �̵��ϴ� Ÿ�� ����
                    ct.tag = "CT";//�±�����
                    ct.name = "Ctile";//�̸�����
                    SetP(ct, string.Format("{0} _ {1} ", x, z + i));
                    exClickTile = true;



                }
            }//���λ���
            else if (z + i > 20)
            {
                if (GameObject.Find(string.Format("{0} _ {1} ", x, z + i - 20)).transform.childCount == 1)
                {
                    if (turn == "W")//����
                    {
                        if (GameObject.Find(string.Format("{0} _ {1} ", x, z + i - 20)).transform.GetChild(0).tag == "B")
                        {
                            GameObject ct = Instantiate(cTile);//Ŭ���Ͽ� ��ġ�� �̵��ϴ� Ÿ�� ����
                            ct.tag = "CT";//�±�����
                            ct.name = "Ctile";//�̸�����
                            SetP(ct, string.Format("{0} _ {1} ", x, z + i - 20));
                            exClickTile = true;
                            break;
                        }
                        else
                        {
                            break;
                        }
                    }//����
                    else //����
                    {
                        if (GameObject.Find(string.Format("{0} _ {1} ", x, z + i - 20)).transform.GetChild(0).tag == "W")
                        {
                            GameObject ct = Instantiate(cTile);//Ŭ���Ͽ� ��ġ�� �̵��ϴ� Ÿ�� ����
                            ct.tag = "CT";//�±�����
                            ct.name = "Ctile";//�̸�����
                            SetP(ct, string.Format("{0} _ {1} ", x, z + i - 20));
                            exClickTile = true;
                            break;
                        }
                        else
                        {
                            break;
                        }
                    }//����
                }
                else
                {

                    GameObject ct = Instantiate(cTile);//Ŭ���Ͽ� ��ġ�� �̵��ϴ� Ÿ�� ����
                    ct.tag = "CT";//�±�����
                    ct.name = "Ctile";//�̸�����
                    SetP(ct, string.Format("{0} _ {1} ", x, z + i - 20));
                    exClickTile = true;



                }
            }//���λ���
        }//���� ����
        for (int i = 1; i < 20; i++) //�Ʒ�����
        {
            if (z - i > 0)//�Ʒ��λ���
            {
                if (GameObject.Find(string.Format("{0} _ {1} ", x, z - i)).transform.childCount == 2)
                {
                    break;
                }
                if (GameObject.Find(string.Format("{0} _ {1} ", x, z - i)).transform.childCount == 1)
                {
                    if (GameObject.Find(string.Format("{0} _ {1} ", x, z - i)).transform.GetChild(0).tag == "CT")
                    {
                        break;
                    }
                    if (turn == "W")//����
                    {
                        if (GameObject.Find(string.Format("{0} _ {1} ", x, z - i)).transform.GetChild(0).tag == "B")
                        {
                            GameObject ct = Instantiate(cTile);//Ŭ���Ͽ� ��ġ�� �̵��ϴ� Ÿ�� ����
                            ct.tag = "CT";//�±�����
                            ct.name = "Ctile";//�̸�����
                            SetP(ct, string.Format("{0} _ {1} ", x, z - i));
                            exClickTile = true;
                            break;
                        }
                        else
                        {
                            break;
                        }
                    }//����
                    else //����
                    {
                        if (GameObject.Find(string.Format("{0} _ {1} ", x, z - i)).transform.GetChild(0).tag == "W")
                        {
                            GameObject ct = Instantiate(cTile);//Ŭ���Ͽ� ��ġ�� �̵��ϴ� Ÿ�� ����
                            ct.tag = "CT";//�±�����
                            ct.name = "Ctile";//�̸�����
                            SetP(ct, string.Format("{0} _ {1} ", x, z - i));
                            exClickTile = true;
                            break;
                        }
                        else
                        {
                            break;
                        }
                    }//����
                }
                else
                {

                    GameObject ct = Instantiate(cTile);//Ŭ���Ͽ� ��ġ�� �̵��ϴ� Ÿ�� ����
                    ct.tag = "CT";//�±�����
                    ct.name = "Ctile";//�̸�����
                    SetP(ct, string.Format("{0} _ {1} ", x, z - i));
                    exClickTile = true;



                }
            }//�Ʒ�����
            else if (z - i < 1)
            {

                if (GameObject.Find(string.Format("{0} _ {1} ", x, z - i + 20)).transform.childCount == 2)
                {
                    break;
                }
                if (GameObject.Find(string.Format("{0} _ {1} ", x, z - i + 20)).transform.childCount == 1)
                {
                    if (GameObject.Find(string.Format("{0} _ {1} ", x, z - i + 20)).transform.GetChild(0).tag == "CT")
                    {
                        break;
                    }
                    if (turn == "W")//����
                    {

                        if (GameObject.Find(string.Format("{0} _ {1} ", x, z - i + 20)).transform.GetChild(0).tag == "B")
                        {
                            GameObject ct = Instantiate(cTile);//Ŭ���Ͽ� ��ġ�� �̵��ϴ� Ÿ�� ����
                            ct.tag = "CT";//�±�����
                            ct.name = "Ctile";//�̸�����
                            SetP(ct, string.Format("{0} _ {1} ", x, z - i + 20));
                            exClickTile = true;
                            break;
                        }
                        else
                        {
                            break;
                        }
                    }//����
                    else //����
                    {
                        if (GameObject.Find(string.Format("{0} _ {1} ", x, z - i + 20)).transform.GetChild(0).tag == "W")
                        {
                            GameObject ct = Instantiate(cTile);//Ŭ���Ͽ� ��ġ�� �̵��ϴ� Ÿ�� ����
                            ct.tag = "CT";//�±�����
                            ct.name = "Ctile";//�̸�����
                            SetP(ct, string.Format("{0} _ {1} ", x, z - i + 20));
                            exClickTile = true;
                            break;
                        }
                        else
                        {
                            break;
                        }
                    }//����
                }
                else
                {

                    GameObject ct = Instantiate(cTile);//Ŭ���Ͽ� ��ġ�� �̵��ϴ� Ÿ�� ����
                    ct.tag = "CT";//�±�����
                    ct.name = "Ctile";//�̸�����
                    SetP(ct, string.Format("{0} _ {1} ", x, z - i + 20));
                    exClickTile = true;




                }
            }//�Ʒ��λ���
        }//�Ʒ��� ����
        for (int i = 1; i < 8; i++)
        {
            if (x + i < 9)
            {
                if (GameObject.Find(string.Format("{0} _ {1} ", x + i, z)).transform.childCount == 0) //��Ÿ��
                {
                    CreatCT(x + i, z);
                }//��Ÿ��
                else if (GameObject.Find(string.Format("{0} _ {1} ", x + i, z)).transform.childCount == 1) //�Ⱥ�Ÿ��
                {
                    if (turn == "W" && GameObject.Find(string.Format("{0} _ {1} ", x + i, z)).transform.GetChild(0).tag == "B")//���Ͽ� ���̸� 
                    {
                        CreatCT(x + i, z);
                        break;
                    }
                    else if (turn == "W" && GameObject.Find(string.Format("{0} _ {1} ", x + i, z)).transform.GetChild(0).tag == "W")//���Ͽ����̸� 
                    {
                        break;
                    }
                    else if (turn == "B" && GameObject.Find(string.Format("{0} _ {1} ", x + i, z)).transform.GetChild(0).tag == "W")//���Ͽ����̸�
                    {
                        CreatCT(x + i, z);
                        break;
                    }
                    else if (turn == "B" && GameObject.Find(string.Format("{0} _ {1} ", x + i, z)).transform.GetChild(0).tag == "B")//���Ͽ����̸� 
                    {
                        break;
                    }
                }//�Ⱥ�Ÿ��

            }
            else
            {
                break;
            }


        }//�����ʻ���
        for (int i = 1; i < 8; i++)
        {
            if (x - i > 0)
            {
                if (GameObject.Find(string.Format("{0} _ {1} ", x - i, z)).transform.childCount == 0) //��Ÿ��
                {
                    CreatCT(x - i, z);
                }//��Ÿ��
                else if (GameObject.Find(string.Format("{0} _ {1} ", x - i, z)).transform.childCount == 1) //�Ⱥ�Ÿ��
                {
                    if (turn == "W" && GameObject.Find(string.Format("{0} _ {1} ", x - i, z)).transform.GetChild(0).tag == "B")//���Ͽ� ���̸� 
                    {
                        CreatCT(x - i, z);
                        break;
                    }
                    else if (turn == "W" && GameObject.Find(string.Format("{0} _ {1} ", x - i, z)).transform.GetChild(0).tag == "W")//���Ͽ����̸� 
                    {
                        break;
                    }
                    else if (turn == "B" && GameObject.Find(string.Format("{0} _ {1} ", x - i, z)).transform.GetChild(0).tag == "W")//���Ͽ����̸�
                    {
                        CreatCT(x - i, z);
                        break;
                    }
                    else if (turn == "B" && GameObject.Find(string.Format("{0} _ {1} ", x - i, z)).transform.GetChild(0).tag == "B")//���Ͽ����̸� 
                    {
                        break;
                    }
                }//�Ⱥ�Ÿ��

            }
            else
            {
                break;
            }


        }//���ʻ���
        for (int i = 1; i < 8; i++)//�������� ����
        {
            if (z + i < 21)
            {
                if (x + i > 8)
                {
                    break;

                }
                else
                {
                    if (GameObject.Find(string.Format("{0} _ {1} ", x + i, z + i)).transform.childCount == 0) //��Ÿ��
                    {
                        CreatCT(x + i, z + i);
                    }//��Ÿ��
                    else if (GameObject.Find(string.Format("{0} _ {1} ", x + i, z + i)).transform.childCount == 1)
                    {
                        if (turn == "W")
                        {
                            if (GameObject.Find(string.Format("{0} _ {1} ", x + i, z + i)).transform.GetChild(0).tag == "B")
                            {
                                CreatCT(x + i, z + i);
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                        if (turn == "B")
                        {
                            if (GameObject.Find(string.Format("{0} _ {1} ", x + i, z + i)).transform.GetChild(0).tag == "W")
                            {
                                CreatCT(x + i, z + i);
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }

                }
            }
            else if (z + i > 20)
            {
                if (x + i > 8)
                {
                    break;

                }
                else
                {
                    if (GameObject.Find(string.Format("{0} _ {1} ", x + i, z + i - 20)).transform.childCount == 0) //��Ÿ��
                    {
                        CreatCT(x + i, z + i - 20);
                    }//��Ÿ��
                    else if (GameObject.Find(string.Format("{0} _ {1} ", x + i, z + i - 20)).transform.childCount == 1)
                    {
                        if (turn == "W")
                        {
                            if (GameObject.Find(string.Format("{0} _ {1} ", x + i, z + i - 20)).transform.GetChild(0).tag == "B")
                            {
                                CreatCT(x + i, z + i - 20);
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                        if (turn == "B")
                        {
                            if (GameObject.Find(string.Format("{0} _ {1} ", x + i, z + i - 20)).transform.GetChild(0).tag == "W")
                            {
                                CreatCT(x + i, z + i - 20);
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                }
            }
        }//�������� ����

        for (int i = 1; i < 8; i++)//������ ����
        {
            if (z + i < 21)
            {
                if (x - i < 1)
                {
                    break;

                }
                else
                {
                    if (GameObject.Find(string.Format("{0} _ {1} ", x - i, z + i)).transform.childCount == 0) //��Ÿ��
                    {
                        CreatCT(x - i, z + i);
                    }//��Ÿ��
                    else if (GameObject.Find(string.Format("{0} _ {1} ", x - i, z + i)).transform.childCount == 1)
                    {
                        if (turn == "W")
                        {
                            if (GameObject.Find(string.Format("{0} _ {1} ", x - i, z + i)).transform.GetChild(0).tag == "B")
                            {
                                CreatCT(x - i, z + i);
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                        if (turn == "B")
                        {
                            if (GameObject.Find(string.Format("{0} _ {1} ", x - i, z + i)).transform.GetChild(0).tag == "W")
                            {
                                CreatCT(x - i, z + i);
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                }
            }
            else if (z + i > 20)
            {
                if (x - i < 1)
                {
                    break;

                }
                else
                {
                    if (GameObject.Find(string.Format("{0} _ {1} ", x - i, z + i - 20)).transform.childCount == 0) //��Ÿ��
                    {
                        CreatCT(x - i, z + i - 20);
                    }//��Ÿ��
                    else if (GameObject.Find(string.Format("{0} _ {1} ", x - i, z + i - 20)).transform.childCount == 1)
                    {
                        if (turn == "W")
                        {
                            if (GameObject.Find(string.Format("{0} _ {1} ", x - i, z + i - 20)).transform.GetChild(0).tag == "B")
                            {
                                CreatCT(x - i, z + i - 20);
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                        if (turn == "B")
                        {
                            if (GameObject.Find(string.Format("{0} _ {1} ", x - i, z + i - 20)).transform.GetChild(0).tag == "W")
                            {
                                CreatCT(x - i, z + i - 20);
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                }
            }
        }//������ ����

        for (int i = 1; i < 8; i++)//�����ʾƷ� ����
        {
            if (z - i > 0)
            {
                if (x + i > 8)
                {
                    break;

                }
                else
                {
                    if (GameObject.Find(string.Format("{0} _ {1} ", x + i, z - i)).transform.childCount == 0) //��Ÿ��
                    {
                        CreatCT(x + i, z - i);
                    }//��Ÿ��
                    else if (GameObject.Find(string.Format("{0} _ {1} ", x + i, z - i)).transform.childCount == 1)
                    {
                        if (turn == "W")
                        {
                            if (GameObject.Find(string.Format("{0} _ {1} ", x + i, z - i)).transform.GetChild(0).tag == "B")
                            {
                                CreatCT(x + i, z - i);
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                        if (turn == "B")
                        {
                            if (GameObject.Find(string.Format("{0} _ {1} ", x + i, z - i)).transform.GetChild(0).tag == "W")
                            {
                                CreatCT(x + i, z - i);
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }

                }
            }
            else if (z - i < 1)
            {
                if (x + i > 8)
                {
                    break;

                }
                else
                {
                    if (GameObject.Find(string.Format("{0} _ {1} ", x + i, z - i + 20)).transform.childCount == 0) //��Ÿ��
                    {
                        CreatCT(x + i, z - i + 20);
                    }//��Ÿ��
                    else if (GameObject.Find(string.Format("{0} _ {1} ", x + i, z - i + 20)).transform.childCount == 1)
                    {
                        if (turn == "W")
                        {
                            if (GameObject.Find(string.Format("{0} _ {1} ", x + i, z - i + 20)).transform.GetChild(0).tag == "B")
                            {
                                CreatCT(x + i, z - i + 20);
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                        if (turn == "B")
                        {
                            if (GameObject.Find(string.Format("{0} _ {1} ", x + i, z - i + 20)).transform.GetChild(0).tag == "W")
                            {
                                CreatCT(x + i, z - i + 20);
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                }
            }
        }//�����ʾƷ� ����

        for (int i = 1; i < 8; i++)//���ʾƷ� ����
        {
            if (z - i > 0)
            {
                if (x - i < 1)
                {
                    break;

                }
                else
                {
                    if (GameObject.Find(string.Format("{0} _ {1} ", x - i, z - i)).transform.childCount == 0) //��Ÿ��
                    {
                        CreatCT(x - i, z - i);
                    }//��Ÿ��
                    else if (GameObject.Find(string.Format("{0} _ {1} ", x - i, z - i)).transform.childCount == 1)
                    {
                        if (turn == "W")
                        {
                            if (GameObject.Find(string.Format("{0} _ {1} ", x - i, z - i)).transform.GetChild(0).tag == "B")
                            {
                                CreatCT(x - i, z - i);
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                        if (turn == "B")
                        {
                            if (GameObject.Find(string.Format("{0} _ {1} ", x - i, z - i)).transform.GetChild(0).tag == "W")
                            {
                                CreatCT(x - i, z - i);
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                }
            }
            else if (z - i < 1)
            {
                if (x - i < 1)
                {
                    break;

                }
                else
                {
                    if (GameObject.Find(string.Format("{0} _ {1} ", x - i, z - i + 20)).transform.childCount == 0) //��Ÿ��
                    {
                        CreatCT(x - i, z - i + 20);
                    }//��Ÿ��
                    else if (GameObject.Find(string.Format("{0} _ {1} ", x - i, z - i + 20)).transform.childCount == 1)
                    {
                        if (turn == "W")
                        {
                            if (GameObject.Find(string.Format("{0} _ {1} ", x - i, z - i + 20)).transform.GetChild(0).tag == "B")
                            {
                                CreatCT(x - i, z - i + 20);
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                        if (turn == "B")
                        {
                            if (GameObject.Find(string.Format("{0} _ {1} ", x - i, z - i + 20)).transform.GetChild(0).tag == "W")
                            {
                                CreatCT(x - i, z - i + 20);
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                }
            }
        }//���ʾƷ� ����
    }

    public void KingMove(GameObject cO, string turn, float x, float z)
    {
        chosObj = cO;//���õ� ������Ʈ�� ������ ����
        ///////////
        if (z + 1 < 21)//���λ���
        {
            if (GameObject.Find(string.Format("{0} _ {1} ", x, z + 1)).transform.childCount == 1)
            {
                if (turn == "W")//����
                {
                    if (GameObject.Find(string.Format("{0} _ {1} ", x, z + 1)).transform.GetChild(0).tag == "B")
                    {
                        GameObject ct = Instantiate(cTile);//Ŭ���Ͽ� ��ġ�� �̵��ϴ� Ÿ�� ����
                        ct.tag = "CT";//�±�����
                        ct.name = "Ctile";//�̸�����
                        SetP(ct, string.Format("{0} _ {1} ", x, z + 1));
                        exClickTile = true;

                    }
                    else
                    {

                    }
                }//����
                else //����
                {
                    if (GameObject.Find(string.Format("{0} _ {1} ", x, z + 1)).transform.GetChild(0).tag == "W")
                    {
                        GameObject ct = Instantiate(cTile);//Ŭ���Ͽ� ��ġ�� �̵��ϴ� Ÿ�� ����
                        ct.tag = "CT";//�±�����
                        ct.name = "Ctile";//�̸�����
                        SetP(ct, string.Format("{0} _ {1} ", x, z + 1));
                        exClickTile = true;

                    }
                    else
                    {

                    }
                }//����
            }
            else
            {

                GameObject ct = Instantiate(cTile);//Ŭ���Ͽ� ��ġ�� �̵��ϴ� Ÿ�� ����
                ct.tag = "CT";//�±�����
                ct.name = "Ctile";//�̸�����
                SetP(ct, string.Format("{0} _ {1} ", x, z + 1));
                exClickTile = true;



            }
        }//���λ���
        else if (z + 1 > 20)
        {
            if (GameObject.Find(string.Format("{0} _ {1} ", x, z + 1 - 20)).transform.childCount == 1)
            {
                if (turn == "W")//����
                {
                    if (GameObject.Find(string.Format("{0} _ {1} ", x, z + 1 - 20)).transform.GetChild(0).tag == "B")
                    {
                        GameObject ct = Instantiate(cTile);//Ŭ���Ͽ� ��ġ�� �̵��ϴ� Ÿ�� ����
                        ct.tag = "CT";//�±�����
                        ct.name = "Ctile";//�̸�����
                        SetP(ct, string.Format("{0} _ {1} ", x, z + 1 - 20));
                        exClickTile = true;

                    }
                    else
                    {

                    }
                }//����
                else //����
                {
                    if (GameObject.Find(string.Format("{0} _ {1} ", x, z + 1 - 20)).transform.GetChild(0).tag == "W")
                    {
                        GameObject ct = Instantiate(cTile);//Ŭ���Ͽ� ��ġ�� �̵��ϴ� Ÿ�� ����
                        ct.tag = "CT";//�±�����
                        ct.name = "Ctile";//�̸�����
                        SetP(ct, string.Format("{0} _ {1} ", x, z + 1 - 20));
                        exClickTile = true;

                    }
                    else
                    {

                    }
                }//����
            }
            else
            {

                GameObject ct = Instantiate(cTile);//Ŭ���Ͽ� ��ġ�� �̵��ϴ� Ÿ�� ����
                ct.tag = "CT";//�±�����
                ct.name = "Ctile";//�̸�����
                SetP(ct, string.Format("{0} _ {1} ", x, z + 1 - 20));
                exClickTile = true;



            }
        }
        /////////////////
        if (z - 1 > 0)//�Ʒ��λ���
        {
            if (GameObject.Find(string.Format("{0} _ {1} ", x, z - 1)).transform.childCount == 2)
            {

            }
            if (GameObject.Find(string.Format("{0} _ {1} ", x, z - 1)).transform.childCount == 1)
            {
                if (GameObject.Find(string.Format("{0} _ {1} ", x, z - 1)).transform.GetChild(0).tag == "CT")
                {

                }
                if (turn == "W")//����
                {
                    if (GameObject.Find(string.Format("{0} _ {1} ", x, z - 1)).transform.GetChild(0).tag == "B")
                    {
                        GameObject ct = Instantiate(cTile);//Ŭ���Ͽ� ��ġ�� �̵��ϴ� Ÿ�� ����
                        ct.tag = "CT";//�±�����
                        ct.name = "Ctile";//�̸�����
                        SetP(ct, string.Format("{0} _ {1} ", x, z - 1));
                        exClickTile = true;

                    }
                    else
                    {

                    }
                }//����
                else //����
                {
                    if (GameObject.Find(string.Format("{0} _ {1} ", x, z - 1)).transform.GetChild(0).tag == "W")
                    {
                        GameObject ct = Instantiate(cTile);//Ŭ���Ͽ� ��ġ�� �̵��ϴ� Ÿ�� ����
                        ct.tag = "CT";//�±�����
                        ct.name = "Ctile";//�̸�����
                        SetP(ct, string.Format("{0} _ {1} ", x, z - 1));
                        exClickTile = true;

                    }
                    else
                    {

                    }
                }//����
            }
            else
            {

                GameObject ct = Instantiate(cTile);//Ŭ���Ͽ� ��ġ�� �̵��ϴ� Ÿ�� ����
                ct.tag = "CT";//�±�����
                ct.name = "Ctile";//�̸�����
                SetP(ct, string.Format("{0} _ {1} ", x, z - 1));
                exClickTile = true;



            }
        }//�Ʒ�����
        else if (z - 1 < 1)
        {

            if (GameObject.Find(string.Format("{0} _ {1} ", x, z - 1 + 20)).transform.childCount == 2)
            {

            }
            if (GameObject.Find(string.Format("{0} _ {1} ", x, z - 1 + 20)).transform.childCount == 1)
            {
                if (GameObject.Find(string.Format("{0} _ {1} ", x, z - 1 + 20)).transform.GetChild(0).tag == "CT")
                {

                }
                if (turn == "W")//����
                {

                    if (GameObject.Find(string.Format("{0} _ {1} ", x, z - 1 + 20)).transform.GetChild(0).tag == "B")
                    {
                        GameObject ct = Instantiate(cTile);//Ŭ���Ͽ� ��ġ�� �̵��ϴ� Ÿ�� ����
                        ct.tag = "CT";//�±�����
                        ct.name = "Ctile";//�̸�����
                        SetP(ct, string.Format("{0} _ {1} ", x, z - 1 + 20));
                        exClickTile = true;

                    }
                    else
                    {

                    }
                }//����
                else //����
                {
                    if (GameObject.Find(string.Format("{0} _ {1} ", x, z - 1 + 20)).transform.GetChild(0).tag == "W")
                    {
                        GameObject ct = Instantiate(cTile);//Ŭ���Ͽ� ��ġ�� �̵��ϴ� Ÿ�� ����
                        ct.tag = "CT";//�±�����
                        ct.name = "Ctile";//�̸�����
                        SetP(ct, string.Format("{0} _ {1} ", x, z - 1 + 20));
                        exClickTile = true;

                    }
                    else
                    {

                    }
                }//����
            }
            else
            {

                GameObject ct = Instantiate(cTile);//Ŭ���Ͽ� ��ġ�� �̵��ϴ� Ÿ�� ����
                ct.tag = "CT";//�±�����
                ct.name = "Ctile";//�̸�����
                SetP(ct, string.Format("{0} _ {1} ", x, z - 1 + 20));
                exClickTile = true;




            }
        }//�Ʒ��λ���
        ////////////////
        if (x + 1 < 9)
        {
            if (GameObject.Find(string.Format("{0} _ {1} ", x + 1, z)).transform.childCount == 0) //��Ÿ��
            {
                CreatCT(x + 1, z);
            }//��Ÿ��
            else if (GameObject.Find(string.Format("{0} _ {1} ", x + 1, z)).transform.childCount == 1) //�Ⱥ�Ÿ��
            {
                if (turn == "W" && GameObject.Find(string.Format("{0} _ {1} ", x + 1, z)).transform.GetChild(0).tag == "B")//���Ͽ� ���̸� 
                {
                    CreatCT(x + 1, z);

                }
                else if (turn == "W" && GameObject.Find(string.Format("{0} _ {1} ", x + 1, z)).transform.GetChild(0).tag == "W")//���Ͽ����̸� 
                {

                }
                else if (turn == "B" && GameObject.Find(string.Format("{0} _ {1} ", x + 1, z)).transform.GetChild(0).tag == "W")//���Ͽ����̸�
                {
                    CreatCT(x + 1, z);

                }
                else if (turn == "B" && GameObject.Find(string.Format("{0} _ {1} ", x + 1, z)).transform.GetChild(0).tag == "B")//���Ͽ����̸� 
                {

                }
            }//�Ⱥ�Ÿ��

        }//�����ʻ���
        ///////////////
        if (x - 1 > 0)
        {
            if (GameObject.Find(string.Format("{0} _ {1} ", x - 1, z)).transform.childCount == 0) //��Ÿ��
            {
                CreatCT(x - 1, z);
            }//��Ÿ��
            else if (GameObject.Find(string.Format("{0} _ {1} ", x - 1, z)).transform.childCount == 1) //�Ⱥ�Ÿ��
            {
                if (turn == "W" && GameObject.Find(string.Format("{0} _ {1} ", x - 1, z)).transform.GetChild(0).tag == "B")//���Ͽ� ���̸� 
                {
                    CreatCT(x - 1, z);

                }
                else if (turn == "W" && GameObject.Find(string.Format("{0} _ {1} ", x - 1, z)).transform.GetChild(0).tag == "W")//���Ͽ����̸� 
                {

                }
                else if (turn == "B" && GameObject.Find(string.Format("{0} _ {1} ", x - 1, z)).transform.GetChild(0).tag == "W")//���Ͽ����̸�
                {
                    CreatCT(x - 1, z);

                }
                else if (turn == "B" && GameObject.Find(string.Format("{0} _ {1} ", x - 1, z)).transform.GetChild(0).tag == "B")//���Ͽ����̸� 
                {

                }
            }//�Ⱥ�Ÿ��

        }/////���ʻ���
        ////////////////
        if (z + 1 < 21)
        {
            if (x+1 > 8)
            {


            }
            else
            {
                if (GameObject.Find(string.Format("{0} _ {1} ", x+1, z + 1)).transform.childCount == 0) //��Ÿ��
                {
                    CreatCT(x+1, z + 1);
                }//��Ÿ��
                else if (GameObject.Find(string.Format("{0} _ {1} ", x+1, z + 1)).transform.childCount == 1)
                {
                    if (turn == "W")
                    {
                        if (GameObject.Find(string.Format("{0} _ {1} ", x+1, z + 1)).transform.GetChild(0).tag == "B")
                        {
                            CreatCT(x+1, z + 1);

                        }
                        else
                        {

                        }
                    }
                    if (turn == "B")
                    {
                        if (GameObject.Find(string.Format("{0} _ {1} ", x+1, z + 1)).transform.GetChild(0).tag == "W")
                        {
                            CreatCT(x+1, z + 1);

                        }
                        else
                        {

                        }
                    }
                }

            }
        }//�������� ����
        else if (z + 1 > 20)
        {
            if (x+1 > 8)
            {


            }
            else
            {
                if (GameObject.Find(string.Format("{0} _ {1} ", x+1, z + 1 - 20)).transform.childCount == 0) //��Ÿ��
                {
                    CreatCT(x+1, z + 1 - 20);
                }//��Ÿ��
                else if (GameObject.Find(string.Format("{0} _ {1} ", x+1, z + 1 - 20)).transform.childCount == 1)
                {
                    if (turn == "W")
                    {
                        if (GameObject.Find(string.Format("{0} _ {1} ", x+1, z + 1 - 20)).transform.GetChild(0).tag == "B")
                        {
                            CreatCT(x+1, z + 1 - 20);

                        }
                        else
                        {

                        }
                    }
                    if (turn == "B")
                    {
                        if (GameObject.Find(string.Format("{0} _ {1} ", x+1, z + 1 - 20)).transform.GetChild(0).tag == "W")
                        {
                            CreatCT(x+1, z + 1 - 20);

                        }
                        else
                        {

                        }
                    }
                }
            }
        }//�������� ����
        ////////////////
        if (z - 1 > 0)
        {
            if (x + 1 > 8)
            {


            }
            else
            {
                if (GameObject.Find(string.Format("{0} _ {1} ", x + 1, z-1)).transform.childCount == 0) //��Ÿ��
                {
                    CreatCT(x + 1, z-1);
                }//��Ÿ��
                else if (GameObject.Find(string.Format("{0} _ {1} ", x + 1, z-1)).transform.childCount == 1)
                {
                    if (turn == "W")
                    {
                        if (GameObject.Find(string.Format("{0} _ {1} ", x + 1, z-1)).transform.GetChild(0).tag == "B")
                        {
                            CreatCT(x + 1, z-1);

                        }
                        else
                        {

                        }
                    }
                    if (turn == "B")
                    {
                        if (GameObject.Find(string.Format("{0} _ {1} ", x + 1, z-1)).transform.GetChild(0).tag == "W")
                        {
                            CreatCT(x + 1, z-1);

                        }
                        else
                        {

                        }
                    }
                }

            }
        }//�����ʾƷ� ����
        else if (z-1 <1)
        {
            if (x + 1 > 8)
            {


            }
            else
            {
                if (GameObject.Find(string.Format("{0} _ {1} ", x + 1, z-1 +20)).transform.childCount == 0) //��Ÿ��
                {
                    CreatCT(x + 1, z-1 +20);
                }//��Ÿ��
                else if (GameObject.Find(string.Format("{0} _ {1} ", x + 1, z-1 +20)).transform.childCount == 1)
                {
                    if (turn == "W")
                    {
                        if (GameObject.Find(string.Format("{0} _ {1} ", x + 1, z-1 +20)).transform.GetChild(0).tag == "B")
                        {
                            CreatCT(x + 1, z-1 +20);

                        }
                        else
                        {

                        }
                    }
                    if (turn == "B")
                    {
                        if (GameObject.Find(string.Format("{0} _ {1} ", x + 1, z-1 +20)).transform.GetChild(0).tag == "W")
                        {
                            CreatCT(x + 1, z-1 +20);

                        }
                        else
                        {

                        }
                    }
                }
            }
        }//�����ʾƷ� ����
        ////////////////
        if (z + 1 < 21)
        {
            if (x-1 < 1)
            {


            }
            else
            {
                if (GameObject.Find(string.Format("{0} _ {1} ", x-1, z + 1)).transform.childCount == 0) //��Ÿ��
                {
                    CreatCT(x-1, z + 1);
                }//��Ÿ��
                else if (GameObject.Find(string.Format("{0} _ {1} ", x-1, z + 1)).transform.childCount == 1)
                {
                    if (turn == "W")
                    {
                        if (GameObject.Find(string.Format("{0} _ {1} ", x-1, z + 1)).transform.GetChild(0).tag == "B")
                        {
                            CreatCT(x-1, z + 1);

                        }
                        else
                        {

                        }
                    }
                    if (turn == "B")
                    {
                        if (GameObject.Find(string.Format("{0} _ {1} ", x-1, z + 1)).transform.GetChild(0).tag == "W")
                        {
                            CreatCT(x-1, z + 1);

                        }
                        else
                        {

                        }
                    }
                }

            }
        }//������ ����
        else if (z + 1 > 20)
        {
            if (x-1 < 1)
            {


            }
            else
            {
                if (GameObject.Find(string.Format("{0} _ {1} ", x-1, z + 1 - 20)).transform.childCount == 0) //��Ÿ��
                {
                    CreatCT(x-1, z + 1 - 20);
                }//��Ÿ��
                else if (GameObject.Find(string.Format("{0} _ {1} ", x-1, z + 1 - 20)).transform.childCount == 1)
                {
                    if (turn == "W")
                    {
                        if (GameObject.Find(string.Format("{0} _ {1} ", x-1, z + 1 - 20)).transform.GetChild(0).tag == "B")
                        {
                            CreatCT(x-1, z + 1 - 20);

                        }
                        else
                        {

                        }
                    }
                    if (turn == "B")
                    {
                        if (GameObject.Find(string.Format("{0} _ {1} ", x-1, z + 1 - 20)).transform.GetChild(0).tag == "W")
                        {
                            CreatCT(x-1, z + 1 - 20);

                        }
                        else
                        {

                        }
                    }
                }
            }
        }//������ ����
        ////////////////
        if (z - 1 > 0)
        {
            if (x-1 < 1)
            {


            }
            else
            {
                if (GameObject.Find(string.Format("{0} _ {1} ", x-1, z - 1)).transform.childCount == 0) //��Ÿ��
                {
                    CreatCT(x-1, z - 1);
                }//��Ÿ��
                else if (GameObject.Find(string.Format("{0} _ {1} ", x-1, z - 1)).transform.childCount == 1)
                {
                    if (turn == "W")
                    {
                        if (GameObject.Find(string.Format("{0} _ {1} ", x-1, z - 1)).transform.GetChild(0).tag == "B")
                        {
                            CreatCT(x-1, z - 1);

                        }
                        else
                        {

                        }
                    }
                    if (turn == "B")
                    {
                        if (GameObject.Find(string.Format("{0} _ {1} ", x-1, z - 1)).transform.GetChild(0).tag == "W")
                        {
                            CreatCT(x-1, z - 1);

                        }
                        else
                        {

                        }
                    }
                }

            }
        }//�����ʾƷ� ����
        else if (z - 1 < 1)
        {
            if (x-1 < 1)
            {


            }
            else
            {
                if (GameObject.Find(string.Format("{0} _ {1} ", x-1, z - 1 + 20)).transform.childCount == 0) //��Ÿ��
                {
                    CreatCT(x-1, z - 1 + 20);
                }//��Ÿ��
                else if (GameObject.Find(string.Format("{0} _ {1} ", x-1, z - 1 + 20)).transform.childCount == 1)
                {
                    if (turn == "W")
                    {
                        if (GameObject.Find(string.Format("{0} _ {1} ", x-1, z - 1 + 20)).transform.GetChild(0).tag == "B")
                        {
                            CreatCT(x-1, z - 1 + 20);

                        }
                        else
                        {

                        }
                    }
                    if (turn == "B")
                    {
                        if (GameObject.Find(string.Format("{0} _ {1} ", x-1, z - 1 + 20)).transform.GetChild(0).tag == "W")
                        {
                            CreatCT(x-1, z - 1 + 20);

                        }
                        else
                        {

                        }
                    }
                }
            }
        }//�����ʾƷ� ����
         ////////////////

    }
}

