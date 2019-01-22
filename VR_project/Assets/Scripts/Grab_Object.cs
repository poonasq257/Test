using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab_Object : MonoBehaviour {

    private SteamVR_TrackedObject trackedObj;
    private GameObject collidingObject;  // 1.trigger가 현재 충돌하고 있는 게임 오브젝트 저장
    private GameObject objectInHand;  // 2.플레이어가 현재 쥐고 있는 게임 오브젝트에 대한 참조 저장

    public bool isGetBasket = false;
    public GameObject myBasket;

    /*public Transform basketParentTransform;
    public bool IsBasket;
    public bool IsDoor;
    public bool IsGrandma;
    public bool IsRed;*/

    private SteamVR_Controller.Device Controller
    {
        get { return SteamVR_Controller.Input((int)trackedObj.index); }
    }

    void Awake()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();

    }

    //////////////////////

    private void SetCollidingObject(Collider col)
    {
        if (collidingObject || !col.GetComponent<Rigidbody>())  //이미 어떤 물체를 쥐고 있거나 || 충돌한 물체가 rigidbody가 없다면 충돌 무시
        {
            return;
        }

        collidingObject = col.gameObject;
    }

    public void OnTriggerEnter(Collider other)  // 1. trigger collider가 다른 collider에 진입했을 때 -> other를 움켜 쥘 수 있는 잠재적 타겟으로 설정
    {
        SetCollidingObject(other);
    }

    public void OnTriggerStay(Collider other)  // 2. 두개의 collider가 겹쳐진 채로 유지되었을때 SetCollidingObject를 호출 -> Enter만으로는 실패 확률이 존재하기 때문
    {
        SetCollidingObject(other);
    }

    public void OnTriggerExit(Collider other)  // 3. 떨어졌을 때 null로 설정
    {
        if (!collidingObject)
        {
            return;
        }

        collidingObject = null;
    }

    //////////////////////////

    private void GrabObject()  //오브젝트 쥐는 함수
    {
        objectInHand = collidingObject;  // 1. 플레이어의 손 안에 게임 오브젝트를 옮기고 colldingObject 초기화
        collidingObject = null;

        var joint = AddFixedJoint();  // 2. joint 를 만들어 AddFixedJoint() 함수로 현재 접촉한 오브젝트를 컨트롤러에 연결시킨다.
        joint.connectedBody = objectInHand.GetComponent<Rigidbody>();
    }

    private FixedJoint AddFixedJoint()  // 3. 새로운 fixed joint를 만드는 함수 -> 이를 컨트롤러의 컴포넌트에 등록(생성->연결) 시키고 떨어 지지않게 고정하고 그 값을 return
    {
        FixedJoint fx = gameObject.AddComponent<FixedJoint>();  //컴포넌트 추가
        fx.breakForce = 20000;
        fx.breakTorque = 20000;

        return fx;
    }

    //////////////////////////

    private void ReleaseObject()  //오브젝트 놓는 함수
    {
        if (GetComponent<FixedJoint>())  // 1. 컨트롤러에 fixed_joint 컴포넌트가 있는지 확인
        {
            GetComponent<FixedJoint>().connectedBody = null;  // 2. joint 연결 끊고, 컴포넌트 삭제하기
            Destroy(GetComponent<FixedJoint>()); //컴포넌트 삭제

            objectInHand.GetComponent<Rigidbody>().velocity = Controller.velocity;  // 3. 컨트롤러의 속도와 각속도를 버려질 물체에 부과
            objectInHand.GetComponent<Rigidbody>().angularVelocity = Controller.angularVelocity;
        }

        objectInHand = null;  // 4. 물체가 쥐어져있다는걸 표현한 objectInHand 해제
    }

    //////////////////////////

    void Update()
    {

        if (Controller.GetHairTriggerDown())  // 1. 플레이어가 hair 눌렀을 때, 
        {
            if (collidingObject)  // 접촉하고 있는 물체가 있다면?
            {
                if (collidingObject.tag == "Basket")
                {
                    collidingObject.SetActive(false);
                    isGetBasket = true;
                    myBasket.SetActive(true);
                    if(this.gameObject.tag=="Left")
                    {
                        isGetBasket = true;
                        GameManager.instance.setwhichHandGrap(1);
                    }
                    else if (this.gameObject.tag == "Right")
                    {
                        isGetBasket = true;
                        GameManager.instance.setwhichHandGrap(2);
                    }
                }

                /*else if (collidingObject.tag == "Grandma")
                {
                    IsGrandma = true;
                }

                else if (collidingObject.tag == "Red")
                {
                    IsRed = true;
                }*/

                if (collidingObject.tag == "Basket")
                {
                    isGetBasket = true;
                }

                else
                {
                    GrabObject();  // 잡는다!
                }
            }
        }

        if (Controller.GetHairTriggerUp())  // 2. 플레이어가 hair 뗐을 때,
        {
            if (objectInHand)  // 손에 물체가 있다면?
            {
                ReleaseObject();  // 물체는 떨어진다!
            }
        }
    }
}
