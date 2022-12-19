using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    /*기타설명
     태그W=하얀쪽
     태그B=검은쪽
     태그CT=클릭타일
     기물오브젝트이름은 백팀은 첫글자 W대문자 이후 띄어스기 없이 기물 영문명 첫글자 대문자로
                        흑팀은 첫글자 B대문자 이후 띄어스기 없이 기물 영문명 첫글자 대문자로
     clickedObj:클릭된 오브젝트 넣는 변수
     
     */
    public string turn;//누구턴인지 판별변수 W는흰팀 B는흑팀
    public float Sc;//기물크기변수

    public static bool destroyT;

    public GameObject cTile;//클릭해서 위치 선택하는 타일
    public GameObject tileA;//하얀타일
    public GameObject tileB;//검은타일
    public GameObject pawnW;//백폰
    public GameObject bishopW;//백비숍
    public GameObject knightW;//백나이트
    public GameObject rookW;//백룩
    public GameObject queenW;//백퀸
    public GameObject kingW;//백킹
    public GameObject pawnB;//흑폰
    public GameObject bishopB;//흑비숍
    public GameObject knightB;//흑나이트
    public GameObject rookB;//흑룩
    public GameObject queenB;//흑퀸
    public GameObject kingB;//흑킹
    public bool exClickTile = false;//클릭판정 타일 존재 유무
    public GameObject chosObj;//선택된 게임오브젝트
    void Start()
    {
        //Debug.Log(GameObject.Find("Ctile"));
        turn = "W";
        destroyT = false;
        Sc = 25f;
        CreatTile();//타일생성
        CreatW();//백기물 생성
        CreatB();//흑기물 생성
    }

    void Update()
    {
        Click();
    }
    public void Click() //기물 클릭시 함수
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);//클릭밑준비
        RaycastHit hit;//클릭밑준비
        if (Input.GetMouseButtonDown(0) == true) //마우스 클릭시
        {
            if (Physics.Raycast(ray, out hit)) //마우스 클릭시 오브젝트를 클릭하면
            {

                GameObject clickedObj = hit.transform.gameObject;//클릭된 오브젝트 넣는 변수


                if (exClickTile == false) //클릭타일 없을시(즉 기물 선택 안한 시점이라면)
                {
                    destroyT = false;
                    if (turn == "W")//백 턴일때 
                    {
                        if (hit.transform.gameObject.tag == "W")//클릭된 오브젝트가 백색일시
                        {
                            float x = float.Parse(clickedObj.transform.parent.name.Substring(0, 2));//선택된 오브젝트의 가상x좌표
                            float z = float.Parse(clickedObj.transform.parent.name.Substring(4));//선택된 오브젝트의 가상z좌표

                            if (clickedObj.name == "WPawnU")//클릭된 오브젝트가 위로가는 폰이라면 
                            {
                                UPawnMove(clickedObj, "W", x, z);
                            }//폰선택
                            if (clickedObj.name == "WPawnD")//클릭된 오브젝트가 위로가는 폰이라면 
                            {

                                DPawnMove(clickedObj, "W", x, z);
                            }//폰선택
                            if (clickedObj.name == "WRook")//
                            {
                                RookMove(clickedObj, "W", x, z);
                            }//룩선택
                            if (clickedObj.name == "WBishop")
                            {
                                BishopMove(clickedObj, "W", x, z);
                            }//비숍선택
                            if (clickedObj.name == "WKnight")
                            {
                                KnightMove(clickedObj, "W", x, z);
                            }//나이트선택
                            if (clickedObj.name == "WQueen")
                            {
                                QueenMove(clickedObj, "W", x, z);
                            }//퀸선택
                            if (clickedObj.name == "WKing")
                            {
                                KingMove(clickedObj, "W", x, z);
                            }//킹선택
                        }
                    }
                    if (turn == "B")//흑 턴일때 
                    {
                        if (hit.transform.gameObject.tag == "B")//클릭된 오브젝트가 흑색일시
                        {
                            float x = float.Parse(clickedObj.transform.parent.name.Substring(0, 2));//선택된 오브젝트의 가상x좌표
                            float z = float.Parse(clickedObj.transform.parent.name.Substring(4));//선택된 오브젝트의 가상z좌표

                            if (clickedObj.name == "BPawnU")//클릭된 오브젝트가 위로가는 폰이라면 
                            {
                                UPawnMove(clickedObj, "B", x, z);
                            }
                            //폰선택
                            if (clickedObj.name == "BPawnD")//클릭된 오브젝트가 위로가는 폰이라면 
                            {
                                DPawnMove(clickedObj, "B", x, z);
                            }//폰선택
                            if (clickedObj.name == "BRook")//
                            {
                                RookMove(clickedObj, "B", x, z);
                            }//룩선택
                            if (clickedObj.name == "BBishop")
                            {
                                BishopMove(clickedObj, "B", x, z);
                            }//비숍선택
                            if (clickedObj.name == "BKnight")
                            {
                                KnightMove(clickedObj, "B", x, z);
                            }//나이트선택
                            if (clickedObj.name == "BQueen")
                            {
                                QueenMove(clickedObj, "B", x, z);
                            }//퀸선택
                            if (clickedObj.name == "BKing")
                            {
                                KingMove(clickedObj, "B", x, z);
                            }//킹선택
                        }
                    }
                }
                else if (exClickTile == true)//클릭타일 있을시(기물 선택 시점) 
                {

                    if (clickedObj.tag == "CT")
                    {
                        float x = float.Parse(clickedObj.transform.parent.name.Substring(0, 2));//선택된 오브젝트의 가상x좌표
                        float z = float.Parse(clickedObj.transform.parent.name.Substring(4));//선택된 오브젝트의 가상z좌표
                        if (clickedObj.transform.parent.GetChild(0).tag == "W" || clickedObj.transform.parent.GetChild(0).tag == "B")
                        {
                            Destroy(clickedObj.transform.parent.GetChild(0).gameObject);
                        }
                        //이동할 타일에 기물이 있으면 삭제
                        SetP(chosObj, string.Format("{0} _ {1} ", x, z));
                        //chosObj.transform.position = new Vector3(clickedObj.transform.position.x, 0.3f, clickedObj.transform.position.z);
                        //선택된 기물을 선택된 타일 위치로 이동
                        //chosObj.transform.parent = clickedObj.transform.parent;
                        //선택된 기물 부모를 있는 타일로 변경
                        destroyT = true;


                        //모든 선택 타일 삭제

                        exClickTile = false;//타일존재 X
                        chosObj = null;//선택된 오브젝트 변수 비움
                        TurnChange();//턴교체
                    }
                    else
                    {
                        destroyT = true;


                        //모든 선택 타일 삭제
                        chosObj = null;//선택된 오브젝트 변수 비움
                        exClickTile = false;//타일존재 X
                    }
                }

            }//클릭
        }
    }
    public void CreatTile()
    {
        for (int z = 101; z < 121; z++)//세로줄 생성
        {
            if (z % 2 == 0)//짝수줄일때
            {
                for (int x = 1; x < 9; x++)//가로줄 생성
                {
                    if (x % 2 == 0)//짝수면 하얀타일 생성
                    {
                        GameObject tile = Instantiate(tileA);//생성
                        tile.transform.position = new Vector3(x, 0, z);//위치지정
                        tile.transform.parent = GameObject.Find("Tiles").transform;//부모지정
                        tile.name = (string.Format("{0} _ {1} ", x, z - 100));//좌표로 이름지정
                    }
                    else //홀수면 검은타일생성
                    {
                        GameObject tile = Instantiate(tileB);
                        tile.transform.position = new Vector3(x, 0, z);
                        tile.transform.parent = GameObject.Find("Tiles").transform;
                        tile.name = (string.Format("{0} _ {1} ", x, z - 100));
                    }


                }

            }
            else //홀수줄일때
            {
                for (int x = 1; x < 9; x++)//가로줄 생성
                {
                    if (x % 2 == 0)//짝수면 검은타일 생성
                    {
                        GameObject tile = Instantiate(tileB);
                        tile.transform.position = new Vector3(x, 0, z);
                        tile.transform.parent = GameObject.Find("Tiles").transform;
                        tile.name = (string.Format("{0} _ {1} ", x, z - 100));
                    }
                    else //홀수면 하얀타일생성
                    {
                        GameObject tile = Instantiate(tileA);
                        tile.transform.position = new Vector3(x, 0, z);
                        tile.transform.parent = GameObject.Find("Tiles").transform;
                        tile.name = (string.Format("{0} _ {1} ", x, z - 100));
                    }


                }
            }
        }//타일생성
    }//타일생성함수
    public void CreatW()//백기물생성함수
    {
        for (int x = 1; x < 9; x++) //백폰생성
        {

            GameObject pawnU = Instantiate(pawnW);//PawnU위로 가는폰
            pawnU.name = "WPawnU";//이름변경
            pawnU.transform.parent = GameObject.Find(string.Format("{0} _ {1} ", x, 4)).transform;//부모지정
            pawnU.transform.localScale = new Vector3(Sc, Sc, 200 * Sc);//크기 지정,z에 200곱한건 타일 자식으로 둘때 모양이 일그러지지 않게 하려고
            pawnU.transform.position = new Vector3(x, 0.3f, 104);//위치 설정
            pawnU.transform.localScale = new Vector3(Sc, Sc, 200 * Sc);//크기 지정,z에 200곱한건 타일 자식으로 둘때 모양이 일그러지지 않게 하려고
            pawnU.tag = "W";//태그 추가

            GameObject pawnD = Instantiate(pawnW);//PawnD아래로 가는폰
            pawnD.name = "WPawnD";//이름변경
            pawnD.transform.parent = GameObject.Find(string.Format("{0} _ {1} ", x, 2)).transform;//부모지정
            pawnD.transform.localScale = new Vector3(Sc, Sc, 200 * Sc);//크기 지정,z에 200곱한건 타일 자식으로 둘때 모양이 일그러지지 않게 하려고
            pawnD.transform.position = new Vector3(x, 0.3f, 102);//위치 설정
            pawnD.tag = "W";//태그 추가

        }//백폰생성

        //킹생성==================================================
        GameObject king = Instantiate(kingW);//king 킹 생성
        king.name = "WKing";//이름변경
        king.transform.parent = GameObject.Find(string.Format("{0} _ {1} ", 5, 3)).transform;//부모지정
        king.transform.localScale = new Vector3(Sc, Sc, 200 * Sc);//크기 지정,z에 200곱한건 타일 자식으로 둘때 모양이 일그러지지 않게 하려고
        king.transform.position = new Vector3(5, 0.3f, 103);//위치 설정
        king.tag = "W";//태그 추가
                       //====================================================

        //비숍생성============================================
        GameObject bishop = Instantiate(bishopW);//첫번째 비숍
        bishop.name = "WBishop";//이름변경
        bishop.transform.parent = GameObject.Find(string.Format("{0} _ {1} ", 3, 3)).transform;//부모지정
        bishop.transform.localScale = new Vector3(Sc, Sc, 200 * Sc);//크기 지정,z에 200곱한건 타일 자식으로 둘때 모양이 일그러지지 않게 하려고
        bishop.transform.position = new Vector3(3, 0.3f, 103);//위치 설정
        bishop.tag = "W";//태그 추가

        GameObject bishop2 = Instantiate(bishopW);//두번째 비숍
        bishop2.name = "WBishop";//이름변경
        bishop2.transform.parent = GameObject.Find(string.Format("{0} _ {1} ", 6, 3)).transform;//부모지정
        bishop2.transform.localScale = new Vector3(Sc, Sc, 200 * Sc);//크기 지정,z에 200곱한건 타일 자식으로 둘때 모양이 일그러지지 않게 하려고
        bishop2.transform.position = new Vector3(6, 0.3f, 103);//위치 설정
        bishop2.tag = "W";//태그 추가
        //====================================================

        //룩생성========================
        GameObject rook = Instantiate(rookW);//첫번째 룩
        rook.name = "WRook";//이름변경
        rook.transform.parent = GameObject.Find(string.Format("{0} _ {1} ", 1, 3)).transform;//부모지정
        rook.transform.localScale = new Vector3(Sc, Sc, 200 * Sc);//크기 지정,z에 200곱한건 타일 자식으로 둘때 모양이 일그러지지 않게 하려고
        rook.transform.position = new Vector3(1, 0.3f, 103);//위치 설정
        rook.tag = "W";//태그 추가

        GameObject rook2 = Instantiate(rookW);//두번째 룩
        rook2.name = "WRook";//이름변경
        rook2.transform.parent = GameObject.Find(string.Format("{0} _ {1} ", 8, 3)).transform;//부모지정
        rook2.transform.localScale = new Vector3(Sc, Sc, 200 * Sc);//크기 지정,z에 200곱한건 타일 자식으로 둘때 모양이 일그러지지 않게 하려고
        rook2.transform.position = new Vector3(8, 0.3f, 103);//위치 설정
        rook2.tag = "W";//태그 추가
        //============================

        //나이트생성========================
        GameObject knight = Instantiate(knightW);//첫번째 나이트
        knight.name = "WKnight";//이름변경
        knight.transform.parent = GameObject.Find(string.Format("{0} _ {1} ", 2, 3)).transform;//부모지정
        knight.transform.localScale = new Vector3(Sc, Sc, 200 * Sc);//크기 지정,z에 200곱한건 타일 자식으로 둘때 모양이 일그러지지 않게 하려고
        knight.transform.position = new Vector3(2, 0.3f, 103);//위치 설정
        knight.tag = "W";//태그 추가

        GameObject knight2 = Instantiate(knightW);//두번째 나이트
        knight2.name = "WKnight";//이름변경
        knight2.transform.parent = GameObject.Find(string.Format("{0} _ {1} ", 7, 3)).transform;//부모지정
        knight2.transform.localScale = new Vector3(Sc, Sc, 200 * Sc);//크기 지정,z에 200곱한건 타일 자식으로 둘때 모양이 일그러지지 않게 하려고
        knight2.transform.position = new Vector3(7, 0.3f, 103);//위치 설정
        knight2.tag = "W";//태그 추가
        //============================

        //퀸생성================================
        GameObject queen = Instantiate(queenW);//첫번째 퀸
        queen.name = "WQueen";//이름변경
        queen.transform.parent = GameObject.Find(string.Format("{0} _ {1} ", 4, 3)).transform;//부모지정
        queen.transform.localScale = new Vector3(Sc, Sc, 200 * Sc);//크기 지정,z에 200곱한건 타일 자식으로 둘때 모양이 일그러지지 않게 하려고
        queen.transform.position = new Vector3(4, 0.3f, 103);//위치 설정
        queen.tag = "W";//태그 추가
        //======================================


    }
    public void CreatB()//흑기물생성함수
    {
        for (int x = 1; x < 9; x++) //흑폰생성======================
        {

            GameObject pawnU = Instantiate(pawnB);//PawnU위로 가는폰
            pawnU.name = "BPawnU";//이름변경
            pawnU.transform.parent = GameObject.Find(string.Format("{0} _ {1} ", x, 14)).transform;//부모지정
            pawnU.transform.localScale = new Vector3(Sc, Sc, 200 * Sc);//크기 지정,z에 200곱한건 타일 자식으로 둘때 모양이 일그러지지 않게 하려고
            pawnU.transform.position = new Vector3(x, 0.3f, 114);//위치 설정
            pawnU.transform.localScale = new Vector3(Sc, Sc, 200 * Sc);//크기 지정,z에 200곱한건 타일 자식으로 둘때 모양이 일그러지지 않게 하려고
            pawnU.tag = "B";//태그 추가

            GameObject pawnD = Instantiate(pawnB);//PawnD아래로 가는폰
            pawnD.name = "BPawnD";//이름변경
            pawnD.transform.parent = GameObject.Find(string.Format("{0} _ {1} ", x, 12)).transform;//부모지정
            pawnD.transform.localScale = new Vector3(Sc, Sc, 200 * Sc);//크기 지정,z에 200곱한건 타일 자식으로 둘때 모양이 일그러지지 않게 하려고
            pawnD.transform.position = new Vector3(x, 0.3f, 112);//위치 설정
            pawnD.tag = "B";//태그 추가

        }//흑폰생성===========================

        //킹생성==================================================
        GameObject king = Instantiate(kingB);//king 킹 생성
        king.name = "BKing";//이름변경
        king.transform.parent = GameObject.Find(string.Format("{0} _ {1} ", 5, 13)).transform;//부모지정
        king.transform.localScale = new Vector3(Sc, Sc, 200 * Sc);//크기 지정,z에 200곱한건 타일 자식으로 둘때 모양이 일그러지지 않게 하려고
        king.transform.position = new Vector3(5, 0.3f, 113);//위치 설정
        king.tag = "B";//태그 추가
                       //====================================================

        //비숍생성============================================
        GameObject bishop = Instantiate(bishopB);//첫번째 비숍
        bishop.name = "BBishop";//이름변경
        bishop.transform.parent = GameObject.Find(string.Format("{0} _ {1} ", 3, 13)).transform;//부모지정
        bishop.transform.localScale = new Vector3(Sc, Sc, 200 * Sc);//크기 지정,z에 200곱한건 타일 자식으로 둘때 모양이 일그러지지 않게 하려고
        bishop.transform.position = new Vector3(3, 0.3f, 113);//위치 설정
        bishop.tag = "B";//태그 추가

        GameObject bishop2 = Instantiate(bishopB);//두번째 비숍
        bishop2.name = "BBishop";//이름변경
        bishop2.transform.parent = GameObject.Find(string.Format("{0} _ {1} ", 6, 13)).transform;//부모지정
        bishop2.transform.localScale = new Vector3(Sc, Sc, 200 * Sc);//크기 지정,z에 200곱한건 타일 자식으로 둘때 모양이 일그러지지 않게 하려고
        bishop2.transform.position = new Vector3(6, 0.3f, 113);//위치 설정
        bishop2.tag = "B";//태그 추가
        //====================================================

        //룩생성========================
        GameObject rook = Instantiate(rookB);//첫번째 룩
        rook.name = "BRook";//이름변경
        rook.transform.parent = GameObject.Find(string.Format("{0} _ {1} ", 1, 13)).transform;//부모지정
        rook.transform.localScale = new Vector3(Sc, Sc, 200 * Sc);//크기 지정,z에 200곱한건 타일 자식으로 둘때 모양이 일그러지지 않게 하려고
        rook.transform.position = new Vector3(1, 0.3f, 113);//위치 설정
        rook.tag = "B";//태그 추가

        GameObject rook2 = Instantiate(rookB);//두번째 룩
        rook2.name = "BRook";//이름변경
        rook2.transform.parent = GameObject.Find(string.Format("{0} _ {1} ", 8, 13)).transform;//부모지정
        rook2.transform.localScale = new Vector3(Sc, Sc, 200 * Sc);//크기 지정,z에 200곱한건 타일 자식으로 둘때 모양이 일그러지지 않게 하려고
        rook2.transform.position = new Vector3(8, 0.3f, 113);//위치 설정
        rook2.tag = "B";//태그 추가
        //============================

        //나이트생성========================
        GameObject knight = Instantiate(knightB);//첫번째 나이트
        knight.name = "BKnight";//이름변경
        knight.transform.parent = GameObject.Find(string.Format("{0} _ {1} ", 2, 13)).transform;//부모지정
        knight.transform.localScale = new Vector3(Sc, Sc, 200 * Sc);//크기 지정,z에 200곱한건 타일 자식으로 둘때 모양이 일그러지지 않게 하려고
        knight.transform.position = new Vector3(2, 0.3f, 113);//위치 설정
        knight.tag = "B";//태그 추가

        GameObject knight2 = Instantiate(knightB);//두번째 나이트
        knight2.name = "BKnight";//이름변경
        knight2.transform.parent = GameObject.Find(string.Format("{0} _ {1} ", 7, 13)).transform;//부모지정
        knight2.transform.localScale = new Vector3(Sc, Sc, 200 * Sc);//크기 지정,z에 200곱한건 타일 자식으로 둘때 모양이 일그러지지 않게 하려고
        knight2.transform.position = new Vector3(7, 0.3f, 113);//위치 설정
        knight2.tag = "B";//태그 추가
        //============================

        //퀸생성================================
        GameObject queen = Instantiate(queenB);//첫번째 퀸
        queen.name = "BQueen";//이름변경
        queen.transform.parent = GameObject.Find(string.Format("{0} _ {1} ", 4, 13)).transform;//부모지정
        queen.transform.localScale = new Vector3(Sc, Sc, 200 * Sc);//크기 지정,z에 200곱한건 타일 자식으로 둘때 모양이 일그러지지 않게 하려고
        queen.transform.position = new Vector3(4, 0.3f, 113);//위치 설정
        queen.tag = "B";//태그 추가
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
    }//턴바꾸는 함수

    public void SetP(GameObject c, string p)
    {
        Debug.Log(string.Format("{0}", p));
        c.transform.parent = GameObject.Find(string.Format("{0}", p)).transform;
        c.transform.position
        =
        new Vector3(c.transform.parent.transform.position.x, c.transform.parent.transform.position.y, c.transform.parent.transform.position.z);
        //부모 설정 및 이동
    }//부모 설정 및 이동
    public void CreatCT(float x, float z)
    {
        GameObject ct = Instantiate(cTile);//클릭하여 위치로 이동하는 타일 생성
        ct.tag = "CT";//태그지정
        ct.name = "Ctile";//이름지정
        SetP(ct, string.Format("{0} _ {1} ", x, z));
        exClickTile = true;
    }//이동타일생성


    /////////////////////////////////////////////////////////////////////////////////////////////////////// 

    public void UPawnMove(GameObject cO, string turn, float x, float z)
    {
        chosObj = cO;//선택된 오브젝트를 변수에 보관

        if (z == 4 || z == 14)//시작지점이라면
        {
            chosObj = cO;//선택된 오브젝트를 변수에 보관

            GameObject ct = Instantiate(cTile);//클릭하여 위치로 이동하는 타일 생성
            ct.tag = "CT";//태그지정
            ct.name = "Ctile";//이름지정


            SetP(ct, string.Format("{0} _ {1} ", x, z + 1));
            if (GameObject.Find(string.Format("{0} _ {1} ", x, z + 1)).transform.childCount == 2)//만약 생성된 곳에 기물이 있을경우 이동타일 삭제 
            {
                Destroy(ct);
            }
            else
            {
                exClickTile = true;
                GameObject ct2 = Instantiate(cTile);//클릭하여 위치로 이동하는 타일 생성
                ct2.tag = "CT";//태그지정
                ct2.name = "Ctile";//이름지정


                SetP(ct2, string.Format("{0} _ {1} ", x, z + 2));
                if (GameObject.Find(string.Format("{0} _ {1} ", x, z + 2)).transform.childCount == 2)//만약 생성된 곳에 기물이 있을경우 이동타일 삭제 
                {
                    Destroy(ct2);
                }
            }






        }//시작지점이면
        else
        {
            chosObj = cO;//선택된 오브젝트를 변수에 보관

            GameObject ct = Instantiate(cTile);//클릭하여 위치로 이동하는 타일 생성
            ct.tag = "CT";//태그지정
            ct.name = "Ctile";//이름지정
            if (z + 1f == 21)//필드 나갈시
            {
                SetP(ct, string.Format("{0} _ {1} ", x, 1));
                if (GameObject.Find(string.Format("{0} _ {1} ", x, 1)).transform.childCount == 2)//만약 생성된 곳에 기물이 있을경우 이동타일 삭제 
                {
                    Destroy(ct);
                }
                else
                {
                    exClickTile = true;
                }


            }
            else //일반상황
            {
                SetP(ct, string.Format("{0} _ {1} ", x, z + 1));
                if (GameObject.Find(string.Format("{0} _ {1} ", x, z + 1)).transform.childCount == 2)//만약 생성된 곳에 기물이 있을경우 이동타일 삭제 
                {
                    Destroy(ct);
                }
                else
                {
                    exClickTile = true;
                }

            }

        }//일반


        //
        if (turn == "W")//백턴일때
        {
            if (x + 1 < 9 && z + 1 < 21)//일반
            {
                if (GameObject.Find(string.Format("{0} _ {1} ", x + 1, z + 1)).transform.childCount > 0) //오른쪽 위 있을시(함수 하면 오류나서 수제입력)    
                {

                    if (GameObject.Find(string.Format("{0} _ {1} ", x + 1, z + 1)).transform.GetChild(0).CompareTag("B"))
                    {
                        //Debug.Log(GameObject.Find(string.Format("{0} _ {1} ", x + 1, z + 1)));

                        GameObject ct3 = Instantiate(cTile);//클릭하여 위치로 이동하는 타일 생성
                        ct3.tag = "CT";//태그지정
                        ct3.name = "Ctile";//이름지정
                        ct3.transform.parent = GameObject.Find(string.Format("{0} _ {1} ", x + 1, z + 1)).transform;
                        ct3.transform.position
                        =
                        new Vector3(ct3.transform.parent.transform.position.x, ct3.transform.parent.transform.position.y, ct3.transform.parent.transform.position.z);
                        //SetP(ct3, string.Format("{0} _ {1}",x+1,z+1 ));
                        Debug.Log(string.Format("{0} _ {1}", x + 1, z + 1));
                        exClickTile = true;

                    }//오른쪽 위 있을시(함수 하면 오류나서 수제입력)    
                }
            }//오른쪽
            else if (x + 1 < 9 && z + 1 > 20)//위로 초과시
            {
                if (GameObject.Find(string.Format("{0} _ {1} ", x + 1, 1)).transform.childCount > 0) //오른쪽 위 있을시(함수 하면 오류나서 수제입력)    
                {

                    if (GameObject.Find(string.Format("{0} _ {1} ", x + 1, 1)).transform.GetChild(0).CompareTag("B"))
                    {
                        //Debug.Log(GameObject.Find(string.Format("{0} _ {1} ", x + 1, z + 1)));

                        GameObject ct3 = Instantiate(cTile);//클릭하여 위치로 이동하는 타일 생성
                        ct3.tag = "CT";//태그지정
                        ct3.name = "Ctile";//이름지정
                        ct3.transform.parent = GameObject.Find(string.Format("{0} _ {1} ", x + 1, 1)).transform;
                        ct3.transform.position
                        =
                        new Vector3(ct3.transform.parent.transform.position.x, ct3.transform.parent.transform.position.y, ct3.transform.parent.transform.position.z);
                        //SetP(ct3, string.Format("{0} _ {1}",x+1,z+1 ));
                        Debug.Log(string.Format("{0} _ {1}", x + 1, 1));
                        exClickTile = true;

                    }//오른쪽 위 있을시(함수 하면 오류나서 수제입력)    
                }
            }
            if (x - 1 > 0 && z + 1 < 21)
            {
                if (GameObject.Find(string.Format("{0} _ {1} ", x - 1, z + 1)).transform.childCount > 0) //왼쪽 위 있을시(함수 하면 오류나서 수제입력)    
                {

                    if (GameObject.Find(string.Format("{0} _ {1} ", x - 1, z + 1)).transform.GetChild(0).CompareTag("B"))
                    {


                        GameObject ct3 = Instantiate(cTile);//클릭하여 위치로 이동하는 타일 생성
                        ct3.tag = "CT";//태그지정
                        ct3.name = "Ctile";//이름지정
                        ct3.transform.parent = GameObject.Find(string.Format("{0} _ {1} ", x - 1, z + 1)).transform;
                        ct3.transform.position
                        =
                        new Vector3(ct3.transform.parent.transform.position.x, ct3.transform.parent.transform.position.y, ct3.transform.parent.transform.position.z);

                        Debug.Log(string.Format("{0} _ {1}", x - 1, z + 1));
                        exClickTile = true;

                    }
                }
            }//왼쪽 위 있을시(함수 하면 오류나서 수제입력)    
            else if (x - 1 > 0 && z + 1 > 20)//위로 초과시
            {
                if (GameObject.Find(string.Format("{0} _ {1} ", x - 1, 1)).transform.childCount > 0) //왼쪽 위 있을시(함수 하면 오류나서 수제입력)    
                {

                    if (GameObject.Find(string.Format("{0} _ {1} ", x - 1, 1)).transform.GetChild(0).CompareTag("B"))
                    {


                        GameObject ct3 = Instantiate(cTile);//클릭하여 위치로 이동하는 타일 생성
                        ct3.tag = "CT";//태그지정
                        ct3.name = "Ctile";//이름지정
                        ct3.transform.parent = GameObject.Find(string.Format("{0} _ {1} ", x - 1, 1)).transform;
                        ct3.transform.position
                        =
                        new Vector3(ct3.transform.parent.transform.position.x, ct3.transform.parent.transform.position.y, ct3.transform.parent.transform.position.z);

                        Debug.Log(string.Format("{0} _ {1}", x - 1, 1));
                        exClickTile = true;

                    }//왼쪽 위 있을시(함수 하면 오류나서 수제입력)    
                }
            }
        }
        else //흑턴일때
        {
            if (x + 1 < 9 && z + 1 < 21)//일반
            {
                if (GameObject.Find(string.Format("{0} _ {1} ", x + 1, z + 1)).transform.childCount > 0) //오른쪽 위 있을시(함수 하면 오류나서 수제입력)    
                {

                    if (GameObject.Find(string.Format("{0} _ {1} ", x + 1, z + 1)).transform.GetChild(0).CompareTag("W"))
                    {
                        //Debug.Log(GameObject.Find(string.Format("{0} _ {1} ", x + 1, z + 1)));

                        GameObject ct3 = Instantiate(cTile);//클릭하여 위치로 이동하는 타일 생성
                        ct3.tag = "CT";//태그지정
                        ct3.name = "Ctile";//이름지정
                        ct3.transform.parent = GameObject.Find(string.Format("{0} _ {1} ", x + 1, z + 1)).transform;
                        ct3.transform.position
                        =
                        new Vector3(ct3.transform.parent.transform.position.x, ct3.transform.parent.transform.position.y, ct3.transform.parent.transform.position.z);
                        //SetP(ct3, string.Format("{0} _ {1}",x+1,z+1 ));
                        Debug.Log(string.Format("{0} _ {1}", x + 1, z + 1));
                        exClickTile = true;

                    }//오른쪽 위 있을시(함수 하면 오류나서 수제입력)    
                }
            }//오른쪽
            else if (x + 1 < 9 && z + 1 > 20)//위로 초과시
            {
                if (GameObject.Find(string.Format("{0} _ {1} ", x + 1, 1)).transform.childCount > 0) //오른쪽 위 있을시(함수 하면 오류나서 수제입력)    
                {

                    if (GameObject.Find(string.Format("{0} _ {1} ", x + 1, 1)).transform.GetChild(0).CompareTag("W"))
                    {
                        //Debug.Log(GameObject.Find(string.Format("{0} _ {1} ", x + 1, z + 1)));

                        GameObject ct3 = Instantiate(cTile);//클릭하여 위치로 이동하는 타일 생성
                        ct3.tag = "CT";//태그지정
                        ct3.name = "Ctile";//이름지정
                        ct3.transform.parent = GameObject.Find(string.Format("{0} _ {1} ", x + 1, 1)).transform;
                        ct3.transform.position
                        =
                        new Vector3(ct3.transform.parent.transform.position.x, ct3.transform.parent.transform.position.y, ct3.transform.parent.transform.position.z);
                        //SetP(ct3, string.Format("{0} _ {1}",x+1,z+1 ));
                        Debug.Log(string.Format("{0} _ {1}", x + 1, 1));
                        exClickTile = true;

                    }//오른쪽 위 있을시(함수 하면 오류나서 수제입력)    
                }
            }
            if (x - 1 > 0 && z + 1 < 21)
            {
                if (GameObject.Find(string.Format("{0} _ {1} ", x - 1, z + 1)).transform.childCount > 0) //왼쪽 위 있을시(함수 하면 오류나서 수제입력)    
                {

                    if (GameObject.Find(string.Format("{0} _ {1} ", x - 1, z + 1)).transform.GetChild(0).CompareTag("W"))
                    {


                        GameObject ct3 = Instantiate(cTile);//클릭하여 위치로 이동하는 타일 생성
                        ct3.tag = "CT";//태그지정
                        ct3.name = "Ctile";//이름지정
                        ct3.transform.parent = GameObject.Find(string.Format("{0} _ {1} ", x - 1, z + 1)).transform;
                        ct3.transform.position
                        =
                        new Vector3(ct3.transform.parent.transform.position.x, ct3.transform.parent.transform.position.y, ct3.transform.parent.transform.position.z);

                        Debug.Log(string.Format("{0} _ {1}", x - 1, z + 1));
                        exClickTile = true;

                    }
                }
            }//왼쪽 위 있을시(함수 하면 오류나서 수제입력)    
            else if (x - 1 > 0 && z + 1 > 20)//위로 초과시
            {
                if (GameObject.Find(string.Format("{0} _ {1} ", x - 1, 1)).transform.childCount > 0) //왼쪽 위 있을시(함수 하면 오류나서 수제입력)    
                {

                    if (GameObject.Find(string.Format("{0} _ {1} ", x - 1, 1)).transform.GetChild(0).CompareTag("W"))
                    {


                        GameObject ct3 = Instantiate(cTile);//클릭하여 위치로 이동하는 타일 생성
                        ct3.tag = "CT";//태그지정
                        ct3.name = "Ctile";//이름지정
                        ct3.transform.parent = GameObject.Find(string.Format("{0} _ {1} ", x - 1, 1)).transform;
                        ct3.transform.position
                        =
                        new Vector3(ct3.transform.parent.transform.position.x, ct3.transform.parent.transform.position.y, ct3.transform.parent.transform.position.z);

                        Debug.Log(string.Format("{0} _ {1}", x - 1, 1));
                        exClickTile = true;

                    }//왼쪽 위 있을시(함수 하면 오류나서 수제입력)    
                }
            }


        }
        //흑턴일때


        //공격타일
    }//위로가는 폰 (좌부터 선택된 게임오브젝트,누구턴인지,xz좌표계)
    public void DPawnMove(GameObject cO, string turn, float x, float z)
    {
        chosObj = cO;//선택된 오브젝트를 변수에 보관

        if (z == 2 || z == 12)//시작지점이라면
        {
            chosObj = cO;//선택된 오브젝트를 변수에 보관

            GameObject ct = Instantiate(cTile);//클릭하여 위치로 이동하는 타일 생성
            ct.tag = "CT";//태그지정
            ct.name = "Ctile";//이름지정


            SetP(ct, string.Format("{0} _ {1} ", x, z - 1));
            if (GameObject.Find(string.Format("{0} _ {1} ", x, z - 1)).transform.childCount == 2)//만약 생성된 곳에 기물이 있을경우 이동타일 삭제 
            {
                Destroy(ct);
            }
            else
            {
                exClickTile = true;
                GameObject ct2 = Instantiate(cTile);//클릭하여 위치로 이동하는 타일 생성
                ct2.tag = "CT";//태그지정
                ct2.name = "Ctile";//이름지정


                if (z == 2)
                {
                    SetP(ct2, string.Format("{0} _ {1} ", x, 20));
                    if (GameObject.Find(string.Format("{0} _ {1} ", x, 20)).transform.childCount == 2)//만약 생성된 곳에 기물이 있을경우 이동타일 삭제 
                    {
                        Destroy(ct2);
                    }
                }
                else
                {
                    SetP(ct2, string.Format("{0} _ {1} ", x, z - 2));
                    if (GameObject.Find(string.Format("{0} _ {1} ", x, z - 2)).transform.childCount == 2)//만약 생성된 곳에 기물이 있을경우 이동타일 삭제 
                    {
                        Destroy(ct2);
                    }
                }

            }






        }//시작지점이면
        else
        {
            chosObj = cO;//선택된 오브젝트를 변수에 보관

            GameObject ct = Instantiate(cTile);//클릭하여 위치로 이동하는 타일 생성
            ct.tag = "CT";//태그지정
            ct.name = "Ctile";//이름지정
            if (z - 1f == 0)//필드 나갈시
            {
                SetP(ct, string.Format("{0} _ {1} ", x, 20));
                if (GameObject.Find(string.Format("{0} _ {1} ", x, 1)).transform.childCount == 2)//만약 생성된 곳에 기물이 있을경우 이동타일 삭제 
                {
                    Destroy(ct);
                }
                else
                {
                    exClickTile = true;
                }


            }
            else //일반상황
            {
                SetP(ct, string.Format("{0} _ {1} ", x, z - 1));
                if (GameObject.Find(string.Format("{0} _ {1} ", x, z - 1)).transform.childCount == 2)//만약 생성된 곳에 기물이 있을경우 이동타일 삭제 
                {
                    Destroy(ct);
                }
                else
                {
                    exClickTile = true;
                }

            }

        }//일반


        //

        if (turn == "W")//백턴일때
        {
            if (x + 1 < 9 && z - 1 > 0)//일반
            {
                if (GameObject.Find(string.Format("{0} _ {1} ", x + 1, z - 1)).transform.childCount > 0) //오른쪽 아래 있을시(함수 하면 오류나서 수제입력)    
                {

                    if (GameObject.Find(string.Format("{0} _ {1} ", x + 1, z - 1)).transform.GetChild(0).CompareTag("B"))
                    {
                        //Debug.Log(GameObject.Find(string.Format("{0} _ {1} ", x + 1, z + 1)));

                        GameObject ct3 = Instantiate(cTile);//클릭하여 위치로 이동하는 타일 생성
                        ct3.tag = "CT";//태그지정
                        ct3.name = "Ctile";//이름지정
                        ct3.transform.parent = GameObject.Find(string.Format("{0} _ {1} ", x + 1, z - 1)).transform;
                        ct3.transform.position
                        =
                        new Vector3(ct3.transform.parent.transform.position.x, ct3.transform.parent.transform.position.y, ct3.transform.parent.transform.position.z);
                        //SetP(ct3, string.Format("{0} _ {1}",x+1,z+1 ));
                        Debug.Log(string.Format("{0} _ {1}", x + 1, z - 1));
                        exClickTile = true;

                    }//오른쪽 아래 있을시(함수 하면 오류나서 수제입력)    
                }
            }//오른쪽
            else if (x + 1 < 9 && z - 1 < 1)//아래로 초과시
            {
                if (GameObject.Find(string.Format("{0} _ {1} ", x + 1, 20)).transform.childCount > 0) //오른쪽 아래 있을시(함수 하면 오류나서 수제입력)    
                {

                    if (GameObject.Find(string.Format("{0} _ {1} ", x + 1, 20)).transform.GetChild(0).CompareTag("B"))
                    {

                        GameObject ct3 = Instantiate(cTile);//클릭하여 위치로 이동하는 타일 생성
                        ct3.tag = "CT";//태그지정
                        ct3.name = "Ctile";//이름지정
                        ct3.transform.parent = GameObject.Find(string.Format("{0} _ {1} ", x + 1, 20)).transform;
                        ct3.transform.position
                        =
                        new Vector3(ct3.transform.parent.transform.position.x, ct3.transform.parent.transform.position.y, ct3.transform.parent.transform.position.z);
                        //SetP(ct3, string.Format("{0} _ {1}",x+1,z+1 ));
                        Debug.Log(string.Format("{0} _ {1}", x + 1, 20));
                        exClickTile = true;

                    }//오른쪽 아래 있을시(함수 하면 오류나서 수제입력)    
                }
            }
            if (x - 1 > 0 && z - 1 > 0)
            {
                if (GameObject.Find(string.Format("{0} _ {1} ", x - 1, z - 1)).transform.childCount > 0) //왼쪽 아래 있을시(함수 하면 오류나서 수제입력)    
                {

                    if (GameObject.Find(string.Format("{0} _ {1} ", x - 1, z - 1)).transform.GetChild(0).CompareTag("B"))
                    {


                        GameObject ct3 = Instantiate(cTile);//클릭하여 위치로 이동하는 타일 생성
                        ct3.tag = "CT";//태그지정
                        ct3.name = "Ctile";//이름지정
                        ct3.transform.parent = GameObject.Find(string.Format("{0} _ {1} ", x - 1, z - 1)).transform;
                        ct3.transform.position
                        =
                        new Vector3(ct3.transform.parent.transform.position.x, ct3.transform.parent.transform.position.y, ct3.transform.parent.transform.position.z);

                        Debug.Log(string.Format("{0} _ {1}", x - 1, z - 1));
                        exClickTile = true;

                    }
                }
            }//왼쪽 아래 있을시(함수 하면 오류나서 수제입력)    
            else if (x - 1 > 0 && z - 1 < 1)//아래로 초과시
            {
                if (GameObject.Find(string.Format("{0} _ {1} ", x - 1, 20)).transform.childCount > 0) //왼쪽 아래 있을시(함수 하면 오류나서 수제입력)    
                {

                    if (GameObject.Find(string.Format("{0} _ {1} ", x - 1, 20)).transform.GetChild(0).CompareTag("B"))
                    {


                        GameObject ct3 = Instantiate(cTile);//클릭하여 위치로 이동하는 타일 생성
                        ct3.tag = "CT";//태그지정
                        ct3.name = "Ctile";//이름지정
                        ct3.transform.parent = GameObject.Find(string.Format("{0} _ {1} ", x - 1, 20)).transform;
                        ct3.transform.position
                        =
                        new Vector3(ct3.transform.parent.transform.position.x, ct3.transform.parent.transform.position.y, ct3.transform.parent.transform.position.z);

                        Debug.Log(string.Format("{0} _ {1}", x - 1, 20));
                        exClickTile = true;

                    }//왼쪽 아래 있을시(함수 하면 오류나서 수제입력)    
                }
            }
        }
        //백턴일때
        else //흑턴일때
        {
            if (x + 1 < 9 && z - 1 > 0)//일반
            {
                if (GameObject.Find(string.Format("{0} _ {1} ", x + 1, z - 1)).transform.childCount > 0) //오른쪽 아래 있을시(함수 하면 오류나서 수제입력)    
                {

                    if (GameObject.Find(string.Format("{0} _ {1} ", x + 1, z - 1)).transform.GetChild(0).CompareTag("W"))
                    {
                        //Debug.Log(GameObject.Find(string.Format("{0} _ {1} ", x + 1, z + 1)));

                        GameObject ct3 = Instantiate(cTile);//클릭하여 위치로 이동하는 타일 생성
                        ct3.tag = "CT";//태그지정
                        ct3.name = "Ctile";//이름지정
                        ct3.transform.parent = GameObject.Find(string.Format("{0} _ {1} ", x + 1, z - 1)).transform;
                        ct3.transform.position
                        =
                        new Vector3(ct3.transform.parent.transform.position.x, ct3.transform.parent.transform.position.y, ct3.transform.parent.transform.position.z);
                        //SetP(ct3, string.Format("{0} _ {1}",x+1,z+1 ));
                        Debug.Log(string.Format("{0} _ {1}", x + 1, z - 1));
                        exClickTile = true;

                    }//오른쪽 아래 있을시(함수 하면 오류나서 수제입력)    
                }
            }//오른쪽
            else if (x + 1 < 9 && z - 1 < 1)//아래로 초과시
            {
                if (GameObject.Find(string.Format("{0} _ {1} ", x + 1, 20)).transform.childCount > 0) //오른쪽 아래 있을시(함수 하면 오류나서 수제입력)    
                {

                    if (GameObject.Find(string.Format("{0} _ {1} ", x + 1, 20)).transform.GetChild(0).CompareTag("W"))
                    {

                        GameObject ct3 = Instantiate(cTile);//클릭하여 위치로 이동하는 타일 생성
                        ct3.tag = "CT";//태그지정
                        ct3.name = "Ctile";//이름지정
                        ct3.transform.parent = GameObject.Find(string.Format("{0} _ {1} ", x + 1, 20)).transform;
                        ct3.transform.position
                        =
                        new Vector3(ct3.transform.parent.transform.position.x, ct3.transform.parent.transform.position.y, ct3.transform.parent.transform.position.z);
                        //SetP(ct3, string.Format("{0} _ {1}",x+1,z+1 ));
                        Debug.Log(string.Format("{0} _ {1}", x + 1, 20));
                        exClickTile = true;

                    }//오른쪽 아래 있을시(함수 하면 오류나서 수제입력)    
                }
            }
            if (x - 1 > 0 && z - 1 > 0)
            {
                if (GameObject.Find(string.Format("{0} _ {1} ", x - 1, z - 1)).transform.childCount > 0) //왼쪽 아래 있을시(함수 하면 오류나서 수제입력)    
                {

                    if (GameObject.Find(string.Format("{0} _ {1} ", x - 1, z - 1)).transform.GetChild(0).CompareTag("W"))
                    {


                        GameObject ct3 = Instantiate(cTile);//클릭하여 위치로 이동하는 타일 생성
                        ct3.tag = "CT";//태그지정
                        ct3.name = "Ctile";//이름지정
                        ct3.transform.parent = GameObject.Find(string.Format("{0} _ {1} ", x - 1, z - 1)).transform;
                        ct3.transform.position
                        =
                        new Vector3(ct3.transform.parent.transform.position.x, ct3.transform.parent.transform.position.y, ct3.transform.parent.transform.position.z);

                        Debug.Log(string.Format("{0} _ {1}", x - 1, z - 1));
                        exClickTile = true;

                    }
                }
            }//왼쪽 아래 있을시(함수 하면 오류나서 수제입력)    
            else if (x - 1 > 0 && z - 1 < 1)//아래로 초과시
            {
                if (GameObject.Find(string.Format("{0} _ {1} ", x - 1, 20)).transform.childCount > 0) //왼쪽 아래 있을시(함수 하면 오류나서 수제입력)    
                {

                    if (GameObject.Find(string.Format("{0} _ {1} ", x - 1, 20)).transform.GetChild(0).CompareTag("W"))
                    {


                        GameObject ct3 = Instantiate(cTile);//클릭하여 위치로 이동하는 타일 생성
                        ct3.tag = "CT";//태그지정
                        ct3.name = "Ctile";//이름지정
                        ct3.transform.parent = GameObject.Find(string.Format("{0} _ {1} ", x - 1, 20)).transform;
                        ct3.transform.position
                        =
                        new Vector3(ct3.transform.parent.transform.position.x, ct3.transform.parent.transform.position.y, ct3.transform.parent.transform.position.z);

                        Debug.Log(string.Format("{0} _ {1}", x - 1, 20));
                        exClickTile = true;

                    }//왼쪽 아래 있을시(함수 하면 오류나서 수제입력)    
                }
            }

        }
        //흑턴일때


        //공격타일
    }//아래로 가는 폰

    public void RookMove(GameObject cO, string turn, float x, float z)//룩이동타일 생성
    {
        chosObj = cO;//선택된 오브젝트를 변수에 보관

        for (int i = 1; i < 20; i++) //위로생성
        {
            if (z + i < 21)//위로생성
            {
                if (GameObject.Find(string.Format("{0} _ {1} ", x, z + i)).transform.childCount == 1)
                {
                    if (turn == "W")//백턴
                    {
                        if (GameObject.Find(string.Format("{0} _ {1} ", x, z + i)).transform.GetChild(0).tag == "B")
                        {
                            GameObject ct = Instantiate(cTile);//클릭하여 위치로 이동하는 타일 생성
                            ct.tag = "CT";//태그지정
                            ct.name = "Ctile";//이름지정
                            SetP(ct, string.Format("{0} _ {1} ", x, z + i));
                            exClickTile = true;
                            break;
                        }
                        else
                        {
                            break;
                        }
                    }//백턴
                    else //흑턴
                    {
                        if (GameObject.Find(string.Format("{0} _ {1} ", x, z + i)).transform.GetChild(0).tag == "W")
                        {
                            GameObject ct = Instantiate(cTile);//클릭하여 위치로 이동하는 타일 생성
                            ct.tag = "CT";//태그지정
                            ct.name = "Ctile";//이름지정
                            SetP(ct, string.Format("{0} _ {1} ", x, z + i));
                            exClickTile = true;
                            break;
                        }
                        else
                        {
                            break;
                        }
                    }//흑턴
                }
                else
                {

                    GameObject ct = Instantiate(cTile);//클릭하여 위치로 이동하는 타일 생성
                    ct.tag = "CT";//태그지정
                    ct.name = "Ctile";//이름지정
                    SetP(ct, string.Format("{0} _ {1} ", x, z + i));
                    exClickTile = true;



                }
            }//위로생성
            else if (z + i > 20)
            {
                if (GameObject.Find(string.Format("{0} _ {1} ", x, z + i - 20)).transform.childCount == 1)
                {
                    if (turn == "W")//백턴
                    {
                        if (GameObject.Find(string.Format("{0} _ {1} ", x, z + i - 20)).transform.GetChild(0).tag == "B")
                        {
                            GameObject ct = Instantiate(cTile);//클릭하여 위치로 이동하는 타일 생성
                            ct.tag = "CT";//태그지정
                            ct.name = "Ctile";//이름지정
                            SetP(ct, string.Format("{0} _ {1} ", x, z + i - 20));
                            exClickTile = true;
                            break;
                        }
                        else
                        {
                            break;
                        }
                    }//백턴
                    else //흑턴
                    {
                        if (GameObject.Find(string.Format("{0} _ {1} ", x, z + i - 20)).transform.GetChild(0).tag == "W")
                        {
                            GameObject ct = Instantiate(cTile);//클릭하여 위치로 이동하는 타일 생성
                            ct.tag = "CT";//태그지정
                            ct.name = "Ctile";//이름지정
                            SetP(ct, string.Format("{0} _ {1} ", x, z + i - 20));
                            exClickTile = true;
                            break;
                        }
                        else
                        {
                            break;
                        }
                    }//흑턴
                }
                else
                {

                    GameObject ct = Instantiate(cTile);//클릭하여 위치로 이동하는 타일 생성
                    ct.tag = "CT";//태그지정
                    ct.name = "Ctile";//이름지정
                    SetP(ct, string.Format("{0} _ {1} ", x, z + i - 20));
                    exClickTile = true;



                }
            }//위로생성
        }//위로 생성
        for (int i = 1; i < 20; i++) //아래생성
        {
            if (z - i > 0)//아래로생성
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
                    if (turn == "W")//백턴
                    {
                        if (GameObject.Find(string.Format("{0} _ {1} ", x, z - i)).transform.GetChild(0).tag == "B")
                        {
                            GameObject ct = Instantiate(cTile);//클릭하여 위치로 이동하는 타일 생성
                            ct.tag = "CT";//태그지정
                            ct.name = "Ctile";//이름지정
                            SetP(ct, string.Format("{0} _ {1} ", x, z - i));
                            exClickTile = true;
                            break;
                        }
                        else
                        {
                            break;
                        }
                    }//백턴
                    else //흑턴
                    {
                        if (GameObject.Find(string.Format("{0} _ {1} ", x, z - i)).transform.GetChild(0).tag == "W")
                        {
                            GameObject ct = Instantiate(cTile);//클릭하여 위치로 이동하는 타일 생성
                            ct.tag = "CT";//태그지정
                            ct.name = "Ctile";//이름지정
                            SetP(ct, string.Format("{0} _ {1} ", x, z - i));
                            exClickTile = true;
                            break;
                        }
                        else
                        {
                            break;
                        }
                    }//흑턴
                }
                else
                {

                    GameObject ct = Instantiate(cTile);//클릭하여 위치로 이동하는 타일 생성
                    ct.tag = "CT";//태그지정
                    ct.name = "Ctile";//이름지정
                    SetP(ct, string.Format("{0} _ {1} ", x, z - i));
                    exClickTile = true;



                }
            }//아래생성
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
                    if (turn == "W")//백턴
                    {

                        if (GameObject.Find(string.Format("{0} _ {1} ", x, z - i + 20)).transform.GetChild(0).tag == "B")
                        {
                            GameObject ct = Instantiate(cTile);//클릭하여 위치로 이동하는 타일 생성
                            ct.tag = "CT";//태그지정
                            ct.name = "Ctile";//이름지정
                            SetP(ct, string.Format("{0} _ {1} ", x, z - i + 20));
                            exClickTile = true;
                            break;
                        }
                        else
                        {
                            break;
                        }
                    }//백턴
                    else //흑턴
                    {
                        if (GameObject.Find(string.Format("{0} _ {1} ", x, z - i + 20)).transform.GetChild(0).tag == "W")
                        {
                            GameObject ct = Instantiate(cTile);//클릭하여 위치로 이동하는 타일 생성
                            ct.tag = "CT";//태그지정
                            ct.name = "Ctile";//이름지정
                            SetP(ct, string.Format("{0} _ {1} ", x, z - i + 20));
                            exClickTile = true;
                            break;
                        }
                        else
                        {
                            break;
                        }
                    }//흑턴
                }
                else
                {

                    GameObject ct = Instantiate(cTile);//클릭하여 위치로 이동하는 타일 생성
                    ct.tag = "CT";//태그지정
                    ct.name = "Ctile";//이름지정
                    SetP(ct, string.Format("{0} _ {1} ", x, z - i + 20));
                    exClickTile = true;




                }
            }//아래로생성
        }//아래로 생성
        for (int i = 1; i < 8; i++)
        {
            if (x + i < 9)
            {
                if (GameObject.Find(string.Format("{0} _ {1} ", x + i, z)).transform.childCount == 0) //빈타일
                {
                    CreatCT(x + i, z);
                }//빈타일
                else if (GameObject.Find(string.Format("{0} _ {1} ", x + i, z)).transform.childCount == 1) //안빈타일
                {
                    if (turn == "W" && GameObject.Find(string.Format("{0} _ {1} ", x + i, z)).transform.GetChild(0).tag == "B")//벡턴에 흑이면 
                    {
                        CreatCT(x + i, z);
                        break;
                    }
                    else if (turn == "W" && GameObject.Find(string.Format("{0} _ {1} ", x + i, z)).transform.GetChild(0).tag == "W")//백턴에백이면 
                    {
                        break;
                    }
                    else if (turn == "B" && GameObject.Find(string.Format("{0} _ {1} ", x + i, z)).transform.GetChild(0).tag == "W")//흑턴에백이면
                    {
                        CreatCT(x + i, z);
                        break;
                    }
                    else if (turn == "B" && GameObject.Find(string.Format("{0} _ {1} ", x + i, z)).transform.GetChild(0).tag == "B")//흑턴에흑이면 
                    {
                        break;
                    }
                }//안빈타일

            }
            else
            {
                break;
            }


        }//오른쪽생성
        for (int i = 1; i < 8; i++)
        {
            if (x - i > 0)
            {
                if (GameObject.Find(string.Format("{0} _ {1} ", x - i, z)).transform.childCount == 0) //빈타일
                {
                    CreatCT(x - i, z);
                }//빈타일
                else if (GameObject.Find(string.Format("{0} _ {1} ", x - i, z)).transform.childCount == 1) //안빈타일
                {
                    if (turn == "W" && GameObject.Find(string.Format("{0} _ {1} ", x - i, z)).transform.GetChild(0).tag == "B")//벡턴에 흑이면 
                    {
                        CreatCT(x - i, z);
                        break;
                    }
                    else if (turn == "W" && GameObject.Find(string.Format("{0} _ {1} ", x - i, z)).transform.GetChild(0).tag == "W")//백턴에백이면 
                    {
                        break;
                    }
                    else if (turn == "B" && GameObject.Find(string.Format("{0} _ {1} ", x - i, z)).transform.GetChild(0).tag == "W")//흑턴에백이면
                    {
                        CreatCT(x - i, z);
                        break;
                    }
                    else if (turn == "B" && GameObject.Find(string.Format("{0} _ {1} ", x - i, z)).transform.GetChild(0).tag == "B")//흑턴에흑이면 
                    {
                        break;
                    }
                }//안빈타일

            }
            else
            {
                break;
            }


        }//왼쪽생성
    }//룩이동타일생성

    public void BishopMove(GameObject cO, string turn, float x, float z)
    {
        chosObj = cO;//선택된 오브젝트를 변수에 보관
        for (int i = 1; i < 8; i++)//오른쪽위 생성
        {
            if (z + i < 21)
            {
                if (x + i > 8)
                {
                    break;

                }
                else
                {
                    if (GameObject.Find(string.Format("{0} _ {1} ", x + i, z + i)).transform.childCount == 0) //빈타일
                    {
                        CreatCT(x + i, z + i);
                    }//빈타일
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
                    if (GameObject.Find(string.Format("{0} _ {1} ", x + i, z + i - 20)).transform.childCount == 0) //빈타일
                    {
                        CreatCT(x + i, z + i - 20);
                    }//빈타일
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
        }//오른쪽위 생성

        for (int i = 1; i < 8; i++)//왼쪽위 생성
        {
            if (z + i < 21)
            {
                if (x - i < 1)
                {
                    break;

                }
                else
                {
                    if (GameObject.Find(string.Format("{0} _ {1} ", x - i, z + i)).transform.childCount == 0) //빈타일
                    {
                        CreatCT(x - i, z + i);
                    }//빈타일
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
                    if (GameObject.Find(string.Format("{0} _ {1} ", x - i, z + i - 20)).transform.childCount == 0) //빈타일
                    {
                        CreatCT(x - i, z + i - 20);
                    }//빈타일
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
        }//왼쪽위 생성

        for (int i = 1; i < 8; i++)//오른쪽아래 생성
        {
            if (z - i > 0)
            {
                if (x + i > 8)
                {
                    break;

                }
                else
                {
                    if (GameObject.Find(string.Format("{0} _ {1} ", x + i, z - i)).transform.childCount == 0) //빈타일
                    {
                        CreatCT(x + i, z - i);
                    }//빈타일
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
                    if (GameObject.Find(string.Format("{0} _ {1} ", x + i, z - i + 20)).transform.childCount == 0) //빈타일
                    {
                        CreatCT(x + i, z - i + 20);
                    }//빈타일
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
        }//오른쪽아래 생성

        for (int i = 1; i < 8; i++)//왼쪽아래 생성
        {
            if (z - i > 0)
            {
                if (x - i < 1)
                {
                    break;

                }
                else
                {
                    if (GameObject.Find(string.Format("{0} _ {1} ", x - i, z - i)).transform.childCount == 0) //빈타일
                    {
                        CreatCT(x - i, z - i);
                    }//빈타일
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
                    if (GameObject.Find(string.Format("{0} _ {1} ", x - i, z - i + 20)).transform.childCount == 0) //빈타일
                    {
                        CreatCT(x - i, z - i + 20);
                    }//빈타일
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
        }//왼쪽아래 생성
    }//비숍이동타일 생성

    public void KnightMove(GameObject cO, string turn, float x, float z)//나이트이동 타일 생성 
    {
        chosObj = cO;
        ////////////////////////오른쪽에서 첫번째 2개
        ////////////////////////오른쪽에서 첫번째 2개
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
        ////////////////////////왼쪽에서 첫번째 2개
        ////////////////////////왼쪽에서 첫번째 2개
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
        ////////////////////////오른쪽에서 두번째 2개
        ////////////////////////오른쪽에서 두번째 2개
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
        ///////////////////////왼쪽에서 두번째2개
        ///////////////////////왼쪽에서 두번째2개
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

    public void QueenMove(GameObject cO, string turn, float x, float z)//퀸이동타일생성
    {
        chosObj = cO;//선택된 오브젝트를 변수에 보관
        for (int i = 1; i < 20; i++) //위로생성
        {
            if (z + i < 21)//위로생성
            {
                if (GameObject.Find(string.Format("{0} _ {1} ", x, z + i)).transform.childCount == 1)
                {
                    if (turn == "W")//백턴
                    {
                        if (GameObject.Find(string.Format("{0} _ {1} ", x, z + i)).transform.GetChild(0).tag == "B")
                        {
                            GameObject ct = Instantiate(cTile);//클릭하여 위치로 이동하는 타일 생성
                            ct.tag = "CT";//태그지정
                            ct.name = "Ctile";//이름지정
                            SetP(ct, string.Format("{0} _ {1} ", x, z + i));
                            exClickTile = true;
                            break;
                        }
                        else
                        {
                            break;
                        }
                    }//백턴
                    else //흑턴
                    {
                        if (GameObject.Find(string.Format("{0} _ {1} ", x, z + i)).transform.GetChild(0).tag == "W")
                        {
                            GameObject ct = Instantiate(cTile);//클릭하여 위치로 이동하는 타일 생성
                            ct.tag = "CT";//태그지정
                            ct.name = "Ctile";//이름지정
                            SetP(ct, string.Format("{0} _ {1} ", x, z + i));
                            exClickTile = true;
                            break;
                        }
                        else
                        {
                            break;
                        }
                    }//흑턴
                }
                else
                {

                    GameObject ct = Instantiate(cTile);//클릭하여 위치로 이동하는 타일 생성
                    ct.tag = "CT";//태그지정
                    ct.name = "Ctile";//이름지정
                    SetP(ct, string.Format("{0} _ {1} ", x, z + i));
                    exClickTile = true;



                }
            }//위로생성
            else if (z + i > 20)
            {
                if (GameObject.Find(string.Format("{0} _ {1} ", x, z + i - 20)).transform.childCount == 1)
                {
                    if (turn == "W")//백턴
                    {
                        if (GameObject.Find(string.Format("{0} _ {1} ", x, z + i - 20)).transform.GetChild(0).tag == "B")
                        {
                            GameObject ct = Instantiate(cTile);//클릭하여 위치로 이동하는 타일 생성
                            ct.tag = "CT";//태그지정
                            ct.name = "Ctile";//이름지정
                            SetP(ct, string.Format("{0} _ {1} ", x, z + i - 20));
                            exClickTile = true;
                            break;
                        }
                        else
                        {
                            break;
                        }
                    }//백턴
                    else //흑턴
                    {
                        if (GameObject.Find(string.Format("{0} _ {1} ", x, z + i - 20)).transform.GetChild(0).tag == "W")
                        {
                            GameObject ct = Instantiate(cTile);//클릭하여 위치로 이동하는 타일 생성
                            ct.tag = "CT";//태그지정
                            ct.name = "Ctile";//이름지정
                            SetP(ct, string.Format("{0} _ {1} ", x, z + i - 20));
                            exClickTile = true;
                            break;
                        }
                        else
                        {
                            break;
                        }
                    }//흑턴
                }
                else
                {

                    GameObject ct = Instantiate(cTile);//클릭하여 위치로 이동하는 타일 생성
                    ct.tag = "CT";//태그지정
                    ct.name = "Ctile";//이름지정
                    SetP(ct, string.Format("{0} _ {1} ", x, z + i - 20));
                    exClickTile = true;



                }
            }//위로생성
        }//위로 생성
        for (int i = 1; i < 20; i++) //아래생성
        {
            if (z - i > 0)//아래로생성
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
                    if (turn == "W")//백턴
                    {
                        if (GameObject.Find(string.Format("{0} _ {1} ", x, z - i)).transform.GetChild(0).tag == "B")
                        {
                            GameObject ct = Instantiate(cTile);//클릭하여 위치로 이동하는 타일 생성
                            ct.tag = "CT";//태그지정
                            ct.name = "Ctile";//이름지정
                            SetP(ct, string.Format("{0} _ {1} ", x, z - i));
                            exClickTile = true;
                            break;
                        }
                        else
                        {
                            break;
                        }
                    }//백턴
                    else //흑턴
                    {
                        if (GameObject.Find(string.Format("{0} _ {1} ", x, z - i)).transform.GetChild(0).tag == "W")
                        {
                            GameObject ct = Instantiate(cTile);//클릭하여 위치로 이동하는 타일 생성
                            ct.tag = "CT";//태그지정
                            ct.name = "Ctile";//이름지정
                            SetP(ct, string.Format("{0} _ {1} ", x, z - i));
                            exClickTile = true;
                            break;
                        }
                        else
                        {
                            break;
                        }
                    }//흑턴
                }
                else
                {

                    GameObject ct = Instantiate(cTile);//클릭하여 위치로 이동하는 타일 생성
                    ct.tag = "CT";//태그지정
                    ct.name = "Ctile";//이름지정
                    SetP(ct, string.Format("{0} _ {1} ", x, z - i));
                    exClickTile = true;



                }
            }//아래생성
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
                    if (turn == "W")//백턴
                    {

                        if (GameObject.Find(string.Format("{0} _ {1} ", x, z - i + 20)).transform.GetChild(0).tag == "B")
                        {
                            GameObject ct = Instantiate(cTile);//클릭하여 위치로 이동하는 타일 생성
                            ct.tag = "CT";//태그지정
                            ct.name = "Ctile";//이름지정
                            SetP(ct, string.Format("{0} _ {1} ", x, z - i + 20));
                            exClickTile = true;
                            break;
                        }
                        else
                        {
                            break;
                        }
                    }//백턴
                    else //흑턴
                    {
                        if (GameObject.Find(string.Format("{0} _ {1} ", x, z - i + 20)).transform.GetChild(0).tag == "W")
                        {
                            GameObject ct = Instantiate(cTile);//클릭하여 위치로 이동하는 타일 생성
                            ct.tag = "CT";//태그지정
                            ct.name = "Ctile";//이름지정
                            SetP(ct, string.Format("{0} _ {1} ", x, z - i + 20));
                            exClickTile = true;
                            break;
                        }
                        else
                        {
                            break;
                        }
                    }//흑턴
                }
                else
                {

                    GameObject ct = Instantiate(cTile);//클릭하여 위치로 이동하는 타일 생성
                    ct.tag = "CT";//태그지정
                    ct.name = "Ctile";//이름지정
                    SetP(ct, string.Format("{0} _ {1} ", x, z - i + 20));
                    exClickTile = true;




                }
            }//아래로생성
        }//아래로 생성
        for (int i = 1; i < 8; i++)
        {
            if (x + i < 9)
            {
                if (GameObject.Find(string.Format("{0} _ {1} ", x + i, z)).transform.childCount == 0) //빈타일
                {
                    CreatCT(x + i, z);
                }//빈타일
                else if (GameObject.Find(string.Format("{0} _ {1} ", x + i, z)).transform.childCount == 1) //안빈타일
                {
                    if (turn == "W" && GameObject.Find(string.Format("{0} _ {1} ", x + i, z)).transform.GetChild(0).tag == "B")//벡턴에 흑이면 
                    {
                        CreatCT(x + i, z);
                        break;
                    }
                    else if (turn == "W" && GameObject.Find(string.Format("{0} _ {1} ", x + i, z)).transform.GetChild(0).tag == "W")//백턴에백이면 
                    {
                        break;
                    }
                    else if (turn == "B" && GameObject.Find(string.Format("{0} _ {1} ", x + i, z)).transform.GetChild(0).tag == "W")//흑턴에백이면
                    {
                        CreatCT(x + i, z);
                        break;
                    }
                    else if (turn == "B" && GameObject.Find(string.Format("{0} _ {1} ", x + i, z)).transform.GetChild(0).tag == "B")//흑턴에흑이면 
                    {
                        break;
                    }
                }//안빈타일

            }
            else
            {
                break;
            }


        }//오른쪽생성
        for (int i = 1; i < 8; i++)
        {
            if (x - i > 0)
            {
                if (GameObject.Find(string.Format("{0} _ {1} ", x - i, z)).transform.childCount == 0) //빈타일
                {
                    CreatCT(x - i, z);
                }//빈타일
                else if (GameObject.Find(string.Format("{0} _ {1} ", x - i, z)).transform.childCount == 1) //안빈타일
                {
                    if (turn == "W" && GameObject.Find(string.Format("{0} _ {1} ", x - i, z)).transform.GetChild(0).tag == "B")//벡턴에 흑이면 
                    {
                        CreatCT(x - i, z);
                        break;
                    }
                    else if (turn == "W" && GameObject.Find(string.Format("{0} _ {1} ", x - i, z)).transform.GetChild(0).tag == "W")//백턴에백이면 
                    {
                        break;
                    }
                    else if (turn == "B" && GameObject.Find(string.Format("{0} _ {1} ", x - i, z)).transform.GetChild(0).tag == "W")//흑턴에백이면
                    {
                        CreatCT(x - i, z);
                        break;
                    }
                    else if (turn == "B" && GameObject.Find(string.Format("{0} _ {1} ", x - i, z)).transform.GetChild(0).tag == "B")//흑턴에흑이면 
                    {
                        break;
                    }
                }//안빈타일

            }
            else
            {
                break;
            }


        }//왼쪽생성
        for (int i = 1; i < 8; i++)//오른쪽위 생성
        {
            if (z + i < 21)
            {
                if (x + i > 8)
                {
                    break;

                }
                else
                {
                    if (GameObject.Find(string.Format("{0} _ {1} ", x + i, z + i)).transform.childCount == 0) //빈타일
                    {
                        CreatCT(x + i, z + i);
                    }//빈타일
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
                    if (GameObject.Find(string.Format("{0} _ {1} ", x + i, z + i - 20)).transform.childCount == 0) //빈타일
                    {
                        CreatCT(x + i, z + i - 20);
                    }//빈타일
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
        }//오른쪽위 생성

        for (int i = 1; i < 8; i++)//왼쪽위 생성
        {
            if (z + i < 21)
            {
                if (x - i < 1)
                {
                    break;

                }
                else
                {
                    if (GameObject.Find(string.Format("{0} _ {1} ", x - i, z + i)).transform.childCount == 0) //빈타일
                    {
                        CreatCT(x - i, z + i);
                    }//빈타일
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
                    if (GameObject.Find(string.Format("{0} _ {1} ", x - i, z + i - 20)).transform.childCount == 0) //빈타일
                    {
                        CreatCT(x - i, z + i - 20);
                    }//빈타일
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
        }//왼쪽위 생성

        for (int i = 1; i < 8; i++)//오른쪽아래 생성
        {
            if (z - i > 0)
            {
                if (x + i > 8)
                {
                    break;

                }
                else
                {
                    if (GameObject.Find(string.Format("{0} _ {1} ", x + i, z - i)).transform.childCount == 0) //빈타일
                    {
                        CreatCT(x + i, z - i);
                    }//빈타일
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
                    if (GameObject.Find(string.Format("{0} _ {1} ", x + i, z - i + 20)).transform.childCount == 0) //빈타일
                    {
                        CreatCT(x + i, z - i + 20);
                    }//빈타일
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
        }//오른쪽아래 생성

        for (int i = 1; i < 8; i++)//왼쪽아래 생성
        {
            if (z - i > 0)
            {
                if (x - i < 1)
                {
                    break;

                }
                else
                {
                    if (GameObject.Find(string.Format("{0} _ {1} ", x - i, z - i)).transform.childCount == 0) //빈타일
                    {
                        CreatCT(x - i, z - i);
                    }//빈타일
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
                    if (GameObject.Find(string.Format("{0} _ {1} ", x - i, z - i + 20)).transform.childCount == 0) //빈타일
                    {
                        CreatCT(x - i, z - i + 20);
                    }//빈타일
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
        }//왼쪽아래 생성
    }

    public void KingMove(GameObject cO, string turn, float x, float z)
    {
        chosObj = cO;//선택된 오브젝트를 변수에 보관
        ///////////
        if (z + 1 < 21)//위로생성
        {
            if (GameObject.Find(string.Format("{0} _ {1} ", x, z + 1)).transform.childCount == 1)
            {
                if (turn == "W")//백턴
                {
                    if (GameObject.Find(string.Format("{0} _ {1} ", x, z + 1)).transform.GetChild(0).tag == "B")
                    {
                        GameObject ct = Instantiate(cTile);//클릭하여 위치로 이동하는 타일 생성
                        ct.tag = "CT";//태그지정
                        ct.name = "Ctile";//이름지정
                        SetP(ct, string.Format("{0} _ {1} ", x, z + 1));
                        exClickTile = true;

                    }
                    else
                    {

                    }
                }//백턴
                else //흑턴
                {
                    if (GameObject.Find(string.Format("{0} _ {1} ", x, z + 1)).transform.GetChild(0).tag == "W")
                    {
                        GameObject ct = Instantiate(cTile);//클릭하여 위치로 이동하는 타일 생성
                        ct.tag = "CT";//태그지정
                        ct.name = "Ctile";//이름지정
                        SetP(ct, string.Format("{0} _ {1} ", x, z + 1));
                        exClickTile = true;

                    }
                    else
                    {

                    }
                }//흑턴
            }
            else
            {

                GameObject ct = Instantiate(cTile);//클릭하여 위치로 이동하는 타일 생성
                ct.tag = "CT";//태그지정
                ct.name = "Ctile";//이름지정
                SetP(ct, string.Format("{0} _ {1} ", x, z + 1));
                exClickTile = true;



            }
        }//위로생성
        else if (z + 1 > 20)
        {
            if (GameObject.Find(string.Format("{0} _ {1} ", x, z + 1 - 20)).transform.childCount == 1)
            {
                if (turn == "W")//백턴
                {
                    if (GameObject.Find(string.Format("{0} _ {1} ", x, z + 1 - 20)).transform.GetChild(0).tag == "B")
                    {
                        GameObject ct = Instantiate(cTile);//클릭하여 위치로 이동하는 타일 생성
                        ct.tag = "CT";//태그지정
                        ct.name = "Ctile";//이름지정
                        SetP(ct, string.Format("{0} _ {1} ", x, z + 1 - 20));
                        exClickTile = true;

                    }
                    else
                    {

                    }
                }//백턴
                else //흑턴
                {
                    if (GameObject.Find(string.Format("{0} _ {1} ", x, z + 1 - 20)).transform.GetChild(0).tag == "W")
                    {
                        GameObject ct = Instantiate(cTile);//클릭하여 위치로 이동하는 타일 생성
                        ct.tag = "CT";//태그지정
                        ct.name = "Ctile";//이름지정
                        SetP(ct, string.Format("{0} _ {1} ", x, z + 1 - 20));
                        exClickTile = true;

                    }
                    else
                    {

                    }
                }//흑턴
            }
            else
            {

                GameObject ct = Instantiate(cTile);//클릭하여 위치로 이동하는 타일 생성
                ct.tag = "CT";//태그지정
                ct.name = "Ctile";//이름지정
                SetP(ct, string.Format("{0} _ {1} ", x, z + 1 - 20));
                exClickTile = true;



            }
        }
        /////////////////
        if (z - 1 > 0)//아래로생성
        {
            if (GameObject.Find(string.Format("{0} _ {1} ", x, z - 1)).transform.childCount == 2)
            {

            }
            if (GameObject.Find(string.Format("{0} _ {1} ", x, z - 1)).transform.childCount == 1)
            {
                if (GameObject.Find(string.Format("{0} _ {1} ", x, z - 1)).transform.GetChild(0).tag == "CT")
                {

                }
                if (turn == "W")//백턴
                {
                    if (GameObject.Find(string.Format("{0} _ {1} ", x, z - 1)).transform.GetChild(0).tag == "B")
                    {
                        GameObject ct = Instantiate(cTile);//클릭하여 위치로 이동하는 타일 생성
                        ct.tag = "CT";//태그지정
                        ct.name = "Ctile";//이름지정
                        SetP(ct, string.Format("{0} _ {1} ", x, z - 1));
                        exClickTile = true;

                    }
                    else
                    {

                    }
                }//백턴
                else //흑턴
                {
                    if (GameObject.Find(string.Format("{0} _ {1} ", x, z - 1)).transform.GetChild(0).tag == "W")
                    {
                        GameObject ct = Instantiate(cTile);//클릭하여 위치로 이동하는 타일 생성
                        ct.tag = "CT";//태그지정
                        ct.name = "Ctile";//이름지정
                        SetP(ct, string.Format("{0} _ {1} ", x, z - 1));
                        exClickTile = true;

                    }
                    else
                    {

                    }
                }//흑턴
            }
            else
            {

                GameObject ct = Instantiate(cTile);//클릭하여 위치로 이동하는 타일 생성
                ct.tag = "CT";//태그지정
                ct.name = "Ctile";//이름지정
                SetP(ct, string.Format("{0} _ {1} ", x, z - 1));
                exClickTile = true;



            }
        }//아래생성
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
                if (turn == "W")//백턴
                {

                    if (GameObject.Find(string.Format("{0} _ {1} ", x, z - 1 + 20)).transform.GetChild(0).tag == "B")
                    {
                        GameObject ct = Instantiate(cTile);//클릭하여 위치로 이동하는 타일 생성
                        ct.tag = "CT";//태그지정
                        ct.name = "Ctile";//이름지정
                        SetP(ct, string.Format("{0} _ {1} ", x, z - 1 + 20));
                        exClickTile = true;

                    }
                    else
                    {

                    }
                }//백턴
                else //흑턴
                {
                    if (GameObject.Find(string.Format("{0} _ {1} ", x, z - 1 + 20)).transform.GetChild(0).tag == "W")
                    {
                        GameObject ct = Instantiate(cTile);//클릭하여 위치로 이동하는 타일 생성
                        ct.tag = "CT";//태그지정
                        ct.name = "Ctile";//이름지정
                        SetP(ct, string.Format("{0} _ {1} ", x, z - 1 + 20));
                        exClickTile = true;

                    }
                    else
                    {

                    }
                }//흑턴
            }
            else
            {

                GameObject ct = Instantiate(cTile);//클릭하여 위치로 이동하는 타일 생성
                ct.tag = "CT";//태그지정
                ct.name = "Ctile";//이름지정
                SetP(ct, string.Format("{0} _ {1} ", x, z - 1 + 20));
                exClickTile = true;




            }
        }//아래로생성
        ////////////////
        if (x + 1 < 9)
        {
            if (GameObject.Find(string.Format("{0} _ {1} ", x + 1, z)).transform.childCount == 0) //빈타일
            {
                CreatCT(x + 1, z);
            }//빈타일
            else if (GameObject.Find(string.Format("{0} _ {1} ", x + 1, z)).transform.childCount == 1) //안빈타일
            {
                if (turn == "W" && GameObject.Find(string.Format("{0} _ {1} ", x + 1, z)).transform.GetChild(0).tag == "B")//벡턴에 흑이면 
                {
                    CreatCT(x + 1, z);

                }
                else if (turn == "W" && GameObject.Find(string.Format("{0} _ {1} ", x + 1, z)).transform.GetChild(0).tag == "W")//백턴에백이면 
                {

                }
                else if (turn == "B" && GameObject.Find(string.Format("{0} _ {1} ", x + 1, z)).transform.GetChild(0).tag == "W")//흑턴에백이면
                {
                    CreatCT(x + 1, z);

                }
                else if (turn == "B" && GameObject.Find(string.Format("{0} _ {1} ", x + 1, z)).transform.GetChild(0).tag == "B")//흑턴에흑이면 
                {

                }
            }//안빈타일

        }//오른쪽생성
        ///////////////
        if (x - 1 > 0)
        {
            if (GameObject.Find(string.Format("{0} _ {1} ", x - 1, z)).transform.childCount == 0) //빈타일
            {
                CreatCT(x - 1, z);
            }//빈타일
            else if (GameObject.Find(string.Format("{0} _ {1} ", x - 1, z)).transform.childCount == 1) //안빈타일
            {
                if (turn == "W" && GameObject.Find(string.Format("{0} _ {1} ", x - 1, z)).transform.GetChild(0).tag == "B")//벡턴에 흑이면 
                {
                    CreatCT(x - 1, z);

                }
                else if (turn == "W" && GameObject.Find(string.Format("{0} _ {1} ", x - 1, z)).transform.GetChild(0).tag == "W")//백턴에백이면 
                {

                }
                else if (turn == "B" && GameObject.Find(string.Format("{0} _ {1} ", x - 1, z)).transform.GetChild(0).tag == "W")//흑턴에백이면
                {
                    CreatCT(x - 1, z);

                }
                else if (turn == "B" && GameObject.Find(string.Format("{0} _ {1} ", x - 1, z)).transform.GetChild(0).tag == "B")//흑턴에흑이면 
                {

                }
            }//안빈타일

        }/////왼쪽생성
        ////////////////
        if (z + 1 < 21)
        {
            if (x+1 > 8)
            {


            }
            else
            {
                if (GameObject.Find(string.Format("{0} _ {1} ", x+1, z + 1)).transform.childCount == 0) //빈타일
                {
                    CreatCT(x+1, z + 1);
                }//빈타일
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
        }//오른쪽위 생성
        else if (z + 1 > 20)
        {
            if (x+1 > 8)
            {


            }
            else
            {
                if (GameObject.Find(string.Format("{0} _ {1} ", x+1, z + 1 - 20)).transform.childCount == 0) //빈타일
                {
                    CreatCT(x+1, z + 1 - 20);
                }//빈타일
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
        }//오른쪽위 생성
        ////////////////
        if (z - 1 > 0)
        {
            if (x + 1 > 8)
            {


            }
            else
            {
                if (GameObject.Find(string.Format("{0} _ {1} ", x + 1, z-1)).transform.childCount == 0) //빈타일
                {
                    CreatCT(x + 1, z-1);
                }//빈타일
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
        }//오른쪽아래 생성
        else if (z-1 <1)
        {
            if (x + 1 > 8)
            {


            }
            else
            {
                if (GameObject.Find(string.Format("{0} _ {1} ", x + 1, z-1 +20)).transform.childCount == 0) //빈타일
                {
                    CreatCT(x + 1, z-1 +20);
                }//빈타일
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
        }//오른쪽아래 생성
        ////////////////
        if (z + 1 < 21)
        {
            if (x-1 < 1)
            {


            }
            else
            {
                if (GameObject.Find(string.Format("{0} _ {1} ", x-1, z + 1)).transform.childCount == 0) //빈타일
                {
                    CreatCT(x-1, z + 1);
                }//빈타일
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
        }//왼쪽위 생성
        else if (z + 1 > 20)
        {
            if (x-1 < 1)
            {


            }
            else
            {
                if (GameObject.Find(string.Format("{0} _ {1} ", x-1, z + 1 - 20)).transform.childCount == 0) //빈타일
                {
                    CreatCT(x-1, z + 1 - 20);
                }//빈타일
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
        }//왼쪽위 생성
        ////////////////
        if (z - 1 > 0)
        {
            if (x-1 < 1)
            {


            }
            else
            {
                if (GameObject.Find(string.Format("{0} _ {1} ", x-1, z - 1)).transform.childCount == 0) //빈타일
                {
                    CreatCT(x-1, z - 1);
                }//빈타일
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
        }//오른쪽아래 생성
        else if (z - 1 < 1)
        {
            if (x-1 < 1)
            {


            }
            else
            {
                if (GameObject.Find(string.Format("{0} _ {1} ", x-1, z - 1 + 20)).transform.childCount == 0) //빈타일
                {
                    CreatCT(x-1, z - 1 + 20);
                }//빈타일
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
        }//오른쪽아래 생성
         ////////////////

    }
}

