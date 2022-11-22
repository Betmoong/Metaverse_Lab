## Team: New Meta
![transparent](https://capsule-render.vercel.app/api?type=transparent&fontColor=703ee5&text=New%20Meta&height=150&fontSize=60&desc=Gloved%20Controller%20for%20Metaverse%20Interface%20&descAlignY=75&descAlign=60)

#  Metaverse_Lab
메타버스 인터페이스를 위한 장갑형 콘트롤러 개발<br/><br/>
<img width="457" alt="image" src="https://user-images.githubusercontent.com/100567791/203277363-fd14b27d-6b96-4904-9206-a08711418883.png">

## 🖥️ &nbsp; 프로젝트 소개
- 메타버스에서 햅틱의 필요성을 깨닫게 되어, 햅틱 중에서도 글러브를 통한 햅틱피드백을 구현하고자 한다.
- 햅틱 글러브를 통해 가상의 물체를 만지고 그 물체와 상호작용하면서 사용자에게 더 나은 몰입감을 제공하고자 한다. 
- 가상의 물체를 집었을 때 물체의 특성에 따라 달라지는 물체의 탄성력, 반발력을 사용자가 느끼게 할 것이다. 
- 이로써 보다 더욱 현실과 비슷한 감각을 메타버스 세계에서 느낄 수 있을 것이다.
- 또한, 이를 소근육 발달 컨텐츠와 결합하여 햅틱 글러브를 사용하여 디지털 컨텐츠를 즐기면서도 소근육 발달에 도움이 되도록 돕고자한다.
- 스마트 기기 사용이 늘어난 유아들이 게임을 하면서도 소근육 발달을 챙길 수 있을 것으로 기대한다.
- 또한, 재활 치료를 받는 사람들이 디지털 공간에서 다양한 컨텐츠를 즐기며 동시에 재활 치료가 가능하도록 하는 발판이 될 것으로 기대한다.

## 🕰️ &nbsp; 개발 기간
- 22.10.01 - 22.11.23

## 📚 &nbsp; Skills
- ### Languages <br/>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <img src="https://img.shields.io/badge/C-A8B9CC?style=flat-square&logo=C&logoColor=white"/> <img src="https://img.shields.io/badge/C%23-239120?style=flat-square&logo=C%20Sharp&logoColor=white"/>

- ### Skills <br/>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <img src="https://img.shields.io/badge/Arduino-00979D?style=flat-square&logo=Arduino&logoColor=white"/> <img src="https://img.shields.io/badge/Unity-%23000000.svg?style=flat-square&logo=unity&logoColor=white"/> <img src="https://img.shields.io/badge/GitHub-181717?style=flat-square&logo=GitHub&logoColor=white"/> <img src="https://img.shields.io/badge/git-F05032?style=flat-square&logo=git&logoColor=white"> <img src="https://img.shields.io/badge/Fusion360-0696D7?style=flat-square&logo=Autodesk&logoColor=white"/>

- ### etc <br/>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 모터, 근전도센서, 3D print


## 💁‍♂️ &nbsp; 팀원 구성
- 팀장: 김승채 - 유니티  Hand Tracking 제어
- 팀원1: 고준성 - 유니티 & Haptic Glove 간의 Bluetooth 통신
- 팀원2: 신찬웅 - 유니티 인터페이스 설계
- 팀원3: 임록희 - 아두이노 인터페이스 설계 및 모터 제어


## 🚩 &nbsp; 세션: 피지컬 컴퓨팅
#### &nbsp; 참가 영상 
https://user-images.githubusercontent.com/100567791/203295137-23f455f8-f56b-4aba-8dfe-5e8a66c8f506.mp4

<br/>

#### &nbsp; 가상 물체 잡기 구현 영상
https://user-images.githubusercontent.com/100567791/203296474-ae712b52-698c-4e3a-a80f-915860777479.mp4

<br/>

## 💻 &nbsp; 개발 내용
- 햅틱 장갑을 착용하여 가상 공간에 있는 가상 물체를 만져볼 수 있는 컨텐츠이다.
- 컨텐츠는 소근육 발달 컨텐츠 2개이다. 
- 유아들이 소근육 발달을 위해 사용하는 놀이기구는 블럭 끼워 맞추는 컨텐츠가 있다.
- 두 번째는 소근육 재활치료에 쓰이는 공 세게 쥐었다 펴는 컨텐츠이다.

<br/>

- 햅틱 장갑은 가상의 물체를 잡을 경우 모터가 손가락에 연결된 실을 잡아당기며 손가락에 힘을 주게 된다.
- 물체를 세게 쥘수록 물체의 탄성력 계산을 통해 실을 더욱 잡아당긴다. 이를 통해 물체의 탄성력, 반발력을 느끼게 해준다.

<br/>

- 유니티에서는 립모션을 통해 핸드트랙킹을 구현하였다. 
- 컨텐츠에서 가상의 손이 물체를 만지면 각 손가락과 물체에 주는 압력을 계산하게 된다.
- 이 계산된 값과 어떤 손가락인지를 아두이노로 블루투스를 통해 전달한다. 
- 이 정보들을 토대로 아두이노에서 해당 손가락에 특정 길이의 실을 당긴다.

<br/>

- 근전도 컨텐츠를 위해 근전도 센서를 착용하면 아두이노에서 근전도 데이터를 블루투스 통신으로 유니티에 전송한다.
- 유니티에서는 이 근전도 데이터를 토대로 그래프를 보여주며 현재 근전도 값, 평균값, 공을 몇 번 쥐었는지, 물건을 몇 번 옮겼는지, 각 Task당 평균과 최대값을 알려주는 UI가 있다.

<br/>

## 시스템 설계도
![그림1](https://user-images.githubusercontent.com/100567791/203299160-8a1f30f4-2928-4c80-96c1-8dc98018c2a1.png)

## Object Modeling – PC Application
![그림2](https://user-images.githubusercontent.com/100567791/203299509-f07af04f-d569-47f4-ac6b-60f1d1825ba6.png)

## Object Modeling – Haptic Glove

![그림3](https://user-images.githubusercontent.com/100567791/203299698-4d8b20e4-2784-477f-ab57-3eafb64e332c.png)

## Event Modeling – Unity&Arudino
![그림4](https://user-images.githubusercontent.com/100567791/203299820-65e19ece-4040-461f-9db8-2479849feebd.png)


## 각도에 따른 실의 길이 추적 방법(유니티)
<img width="636" alt="image" src="https://user-images.githubusercontent.com/100567791/203300820-d73d8f07-8704-48af-8ae4-355723b319c8.png">

## 가변저항에 따른 실의 길이 추적 방법(아두이노)
<img width="604" alt="image" src="https://user-images.githubusercontent.com/100567791/203300834-863f87b2-ef91-41ea-bb5f-ec97e0b759bc.png">


## Bluetooth 통신
- 목적: 아두이노 보드에 HC-06 블루투스 칩을 추가하고 외부 전원을 사용하여 사용자의 활동 범위를 넓히고자 한다.
- 원리: 아두이노와 컴퓨터를 블루투스를 통해 연결시킨 후 유니티에서 컴퓨터로 보낸 데이터를 그대로 아두이노 보드로 전달하고자 한다. 
- 데이터의 통신 방향: 유니티 -> 컴퓨터 -> 아두이노 보드
 
> 방법1) 3개의 데이터(변수)를 순차적으로 보내는 방법
> 1. Index – 3개의 손가락 중 어느 손가락에 해당하는 데이터인지
> 2.	IsTouched -  힘이 전달되었는지 유무(True or False)
> 3.	Fs – Force를 만들기 위해 필요한 실의 길이 변화량

> 방법2) 배열을 이용하여 한꺼번에 데이터를 보내는 방법
> [float1, float2, float3] 과 같이 배열을 만들어 각각 손가락에 전달되어야 하는 Fs(Force를 만들기 위해 필요한 실의 길이 변화량)를 한꺼번에 전달하는 방법(전달될 힘이 없다면 0값 입력) - Char의 형태로 데이터를 Unity에서 보낸 후 아두이노IDE에서 parsing을 통해 float1, float2, float3를 각각 서보 모터로 전송. 
> 방법 2를 통해 유니티에서 아두이노로 데이터를 보내기로 결정하여 유니티에서 특정 char을 보냈을 때 컴퓨터의 Bluetooth Serial Monitor에서 해당 char을 받을 수 있는지 테스트할 수 있는 UI를 유니티 내에서 만들었다. 
> 또한, 반대 방향으로도 통신이 가능하도록 Bluetooth Serial Monitor에서 보낸 char 데이터가 Unity 내 UI에 출력되도록 코드를 작성하였다.
  
보내고자 하는 데이터는 위와 같으며 방법2의 통신을 사용했다.

![bluetooth1](https://user-images.githubusercontent.com/100567791/203304083-ac5dc925-d6ff-411a-a3c7-74bea2bc04a5.png)


![bluetooth2](https://user-images.githubusercontent.com/100567791/203304146-a092fa6b-3387-4720-8772-629bfa0a60d3.png)
<Char 형태로 Unity와 Arduino 간 양방향 블루투스 통신이 성공한 모습>

- 아두이노의 시리얼 통신은 Asynchronous 시리얼 통신 이므로 블루투스 칩 HC-06의 synchronous 전송 속도는 최대 2.1Mbps이다.
- 본 프로젝트에서는 Baud rate을 9600으로 설정하므로 ASCII Code를 기준으로 1초에 9600개의 symbol을 보낼 수 있다.
- 통신에서 ASCII Code는 1 symbol이 8bit이므로 9600 Baud rate은 초당 9600*8=76800bit를 송, 수신하는 것이므로 2.1Mbps 속도를 가진 HC-06이 안정적으로 데이터를 전달할 수 있다.
- 또한, 이전 데이터와 다음에 송, 수신할 데이터가 관계가 없다는 점에서 데이터를 float 형태로 3번 보내는 것보다 char 형태로 한꺼번에 보내는 것이 더 효율적이라고 판단하였다.


![Bluetooth3](https://user-images.githubusercontent.com/100567791/203304910-9a4caca5-9b7d-49cd-8025-45ca13969d5b.png)


![Bluetooth4](https://user-images.githubusercontent.com/100567791/203304920-0e3f94bf-6f0a-4323-8315-2ceb081c74a2.png)

Parsing에 성공하여 string 형태로 받은 데이터를 int형 데이터로 아두이노에서 분리시켰다.

3개의 int형으로 분리한 데이터들을 각각 해당하는 모터로 값을 전송.

<img width="440" alt="bluetooth6" src="https://user-images.githubusercontent.com/100567791/203305178-73123746-d16f-4e1b-864a-d21d4692e236.png">


## Object Deform
![image](https://user-images.githubusercontent.com/100567791/203305338-fa74d847-464b-4d7c-bc02-c51918a5e25a.png)


- 컴퓨터 그래픽스에서 3차원 공간의 객체는 Polygon들로 구성된 Mesh로 정의된다.
- Polygon은 3개의 정점(Vertex)들이 모여 형성하는 하나의 삼각형을 가리킨다.
- 핸드트래킹된 손이 물체를 쥐면 물체의 형태를 변경시키기 위해서, 손가락이 주는 압력을 입력 받아 물체의 정점 정보들을 실시간으로 업데이트한다.
- 물체의 변형 과정은 손가락의 압력 -> 탄성력 -> 감쇠로 총 3단계로 이루어진다. 
- 정점들이 이동하는 방향벡터는 압력 지점에서 정점을 향한다. 
- 역제곱 법칙(inverse square law)에 의해서, 정점들이 손가락으로부터 받는 압력은 손가락이 힘을 가한 지점과의 거리의 제곱에 반비례한다.
- Mesh의 해상도와 크기에 따라서 정점 간의 거리가 1보다 작을 수 있기 때문에 정점이 받는 힘을 $1\over((1+a〖x)〗^2)$ (a=감쇠(attenuation) 계수, x=거리) 형태로 설정한다.
- 탄성력은 F = kx(k= 탄성계수, x=변한 길이)이므로 정점의 복원력은 정점의 현재 위치가 정점의 초기 위치와 떨어진 만큼 증가시킨다.
- 정점의 탄성력은 시간이 흐를수록 감쇠(damping)한다.


