using UnityEngine;

public class Collision_Thumb : MonoBehaviour
{
    //�� �浹 ���� ����
    public bool touchedwoodball;
    public bool touchedmetalball;
    public bool touchedplasticball;

    //���������
    public AudioClip woodsound;
    public AudioClip metalsound;
    public AudioClip plasticsound;
    public AudioClip fixedwoodsound;
    public AudioClip fixedmetalsound;
    public AudioClip fixedplasticsound;

    //������ҽ� ������Ʈ
    AudioSource aud;

    //���ӿ�����Ʈ
    public GameObject index3;
    public GameObject mid3;
    public GameObject thumb3;
    public GameObject CenterPalm;
    public GameObject DerivedRotation_x;
    public GameObject woodball;
    public GameObject metalball;
    public GameObject plasticball;

    public SerialCommunicator sr;
    
    //�� ���� ���� �Ǵ�
    bool IsBorder;

    //Grab�Ǵ� �ι�° ����(�հ��� ����)
    float ThresHold_Value_Thumb = -0.5f;

    //������� �޼ҵ�
    void PlayingSound(int num)
    {
        if(num==0)
        {
            this.aud.PlayOneShot(this.woodsound);
        }
        else if(num==1)
        {
            this.aud.PlayOneShot(this.metalsound);
        }
        else if (num == 2)
        {
            this.aud.PlayOneShot(this.plasticsound);

        }
        else if (num == 3)
        {
            this.aud.PlayOneShot(this.fixedwoodsound);

        }
        else if (num == 4)
        {
            this.aud.PlayOneShot(this.fixedmetalsound);

        }
        else if (num == 5)
        {
            this.aud.PlayOneShot(this.fixedplasticsound);

        }
    }


    // Start is called before the first frame update
    void Start()
    {
        this.aud = GetComponent<AudioSource>();
        sr = GameObject.Find("Hand (3)").GetComponent<SerialCommunicator>();
    }


    void LateUpdate()
    {
        if (isGrab())
        {
            sr.TxBuffer.servoAct1 = 30;
            print(string.Format("Thumb ON! {0}", DerivedRotation_x.transform.localRotation.x));
        }
        else
        {
            print(string.Format("Thumb OFF! {0}", DerivedRotation_x.transform.localRotation.x));
            sr.TxBuffer.servoAct1 = 180;
        }

        //Debug.Log("Thumb finger : " + DerivedRotation_x.transform.localRotation.x);
        if ((touchedwoodball && DerivedRotation_x.transform.localRotation.x < ThresHold_Value_Thumb))
            woodball.transform.position = new Vector3(CenterPalm.transform.position.x, CenterPalm.transform.position.y - 0.4f, CenterPalm.transform.position.z);

        else
            touchedwoodball = false;

        if (touchedmetalball && DerivedRotation_x.transform.localRotation.x < ThresHold_Value_Thumb)
            metalball.transform.position = new Vector3(CenterPalm.transform.position.x, CenterPalm.transform.position.y - 0.4f, CenterPalm.transform.position.z);
        else
            touchedmetalball = false;

        if (touchedplasticball && DerivedRotation_x.transform.localRotation.x < ThresHold_Value_Thumb)
            plasticball.transform.position = new Vector3(CenterPalm.transform.position.x, CenterPalm.transform.position.y - 0.4f, CenterPalm.transform.position.z);
        else
            touchedplasticball = false;
    }

    //�浹����
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Wood")
        {
            PlayingSound(0);
            touchedwoodball = true;

        }
        else if (other.gameObject.tag == "Metal")
        {
            PlayingSound(1);
            touchedmetalball = true;

        }
        else if (other.gameObject.tag == "Plastic")
        {
            PlayingSound(2);
            touchedplasticball = true;

        }
        else if (other.gameObject.tag == "FixedWood")
        {
            PlayingSound(3);
        }

        else if (other.gameObject.tag == "FixedMetal")
        {
            PlayingSound(4);
        }
        else if (other.gameObject.tag == "FixedPlastic")
        {
            PlayingSound(5);
        }
    }

    //�浹��
    void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag == "Wood")
        {
            PlayingSound(0);
            touchedwoodball = true;

        }
        else if (other.gameObject.tag == "Metal")
        {
            PlayingSound(1);
            touchedmetalball = true;

        }
        else if (other.gameObject.tag == "Plastic")
        {
            PlayingSound(2);
            touchedplasticball = true;

        }
        else if (other.gameObject.tag == "FixedWood")
        {
            PlayingSound(3);
        }

        else if (other.gameObject.tag == "FixedMetal")
        {
            PlayingSound(4);
        }
        else if (other.gameObject.tag == "FixedPlastic")
        {
            PlayingSound(5);
        }
    }
    
    //�浹����
    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Wood")
        {
            Debug.Log("Wood");
            this.aud.PlayOneShot(this.woodsound);
        }
        else if (other.gameObject.tag == "FixedWood")
        {
            Debug.Log("Wood");
            this.aud.PlayOneShot(this.woodsound);
        }
        else if (other.gameObject.tag == "Metal")
        {
            Debug.Log("Metal");
            this.aud.PlayOneShot(this.metalsound);
        }
        else if (other.gameObject.tag == "FixedMetal")
        {
            Debug.Log("Wood");
            this.aud.PlayOneShot(this.woodsound);
        }
        else if (other.gameObject.tag == "Plastic")
        {
            Debug.Log("Plastic");
            this.aud.PlayOneShot(this.plasticsound);
        }
        else if (other.gameObject.tag == "FixedPlastic")
        {
            Debug.Log("Plastic");
            this.aud.PlayOneShot(this.plasticsound);
        }
    }
  
    //Grab���� �Ǵ�
    bool isGrab()
    {
        if (touchedmetalball || touchedplasticball || touchedwoodball)
            return true;
        return false;
    }


}