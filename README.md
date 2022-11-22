## Team: New Meta
![transparent](https://capsule-render.vercel.app/api?type=transparent&fontColor=703ee5&text=New%20Meta&height=150&fontSize=60&desc=Gloved%20Controller%20for%20Metaverse%20Interface%20&descAlignY=75&descAlign=60)

#  Metaverse_Lab
메타버스 인터페이스를 위한 장갑형 콘트롤러 개발<br/><br/>
<img width="457" alt="image" src="https://user-images.githubusercontent.com/100567791/203277363-fd14b27d-6b96-4904-9206-a08711418883.png">
<br/>

## 🖥️ &nbsp; 프로젝트 소개
- 메타버스에서 햅틱의 필요성을 깨닫게 되어, 햅틱 중에서도 글러브를 통한 햅틱피드백을 구현하고자 한다.
- 햅틱 글러브를 통해 가상의 물체를 만지고 그 물체와 상호작용하면서 사용자에게 더 나은 몰입감을 제공하고자 한다. 
- 가상의 물체를 집었을 때 물체의 특성에 따라 달라지는 물체의 탄성력, 반발력을 사용자가 느끼게 할 것이다. 
- 이로써 보다 더욱 현실과 비슷한 감각을 메타버스 세계에서 느낄 수 있을 것이다.
- 또한, 이를 소근육 발달 컨텐츠와 결합하여 햅틱 글러브를 사용하여 디지털 컨텐츠를 즐기면서도 소근육 발달에 도움이 되도록 돕고자한다.
- 스마트 기기 사용이 늘어난 유아들이 게임을 하면서도 소근육 발달을 챙길 수 있을 것으로 기대한다.
- 또한, 재활 치료를 받는 사람들이 디지털 공간에서 다양한 컨텐츠를 즐기며 동시에 재활 치료가 가능하도록 하는 발판이 될 것으로 기대한다.
<br/>

## 🕰️ &nbsp; 개발 기간
- 22.10.01 - 22.11.23
<br/>

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


<br/><br/><br/><br/>








> 세션 : 피지컬 컴퓨팅  
프로젝트 명 : 메타버스 인터페이스를 위한 장갑형 콘트롤러 개발  
팀 명 : New Meta  
개발 기간 : 10.1~11.23  
사용 언어 : C, C#   
사용 기술 : 아두이노, 유니티, 모터, 근전도 센서, 3Dprint  
영상 주소 : https://youtu.be/H0LzQGk7tHw  

[![IMAGE ALT TEXT HERE](https://img.youtube.com/vi/H0LzQGk7tHw/0.jpg)](https://www.youtube.com/watch?v=H0LzQGk7tHw)
 
가상 물체 집기 구현 영상
https://user-images.githubusercontent.com/63523334/202908902-5a766467-4ca2-4730-b6bf-6c686df80c04.mp4


# 개발 내용 
햅틱 장갑을 착용하여 가상 공간에 있는 가상 물체를 만져볼 수 있는 컨텐츠이다.
컨텐츠는 소근육 발달 컨텐츠 2개이다. 
유아들이 소근육 발달을 위해 사용하는 놀이기구는 블럭 끼워 맞추는 컨텐츠가 있다.
두 번째는 소근육 재활치료에 쓰이는 공 세게 쥐었다 펴는 컨텐츠이다.

햅틱 장갑은 가상의 물체를 잡을 경우 모터가 손가락에 연결된 실을 잡아당기며 손가락에 힘을 주게 된다.
물체를 세게 쥘수록 물체의 탄성력 계산을 통해 실을 더욱 잡아당긴다. 이를 통해 물체의 탄성력, 반발력을 느끼게 해준다.

유니티에서는 립모션을 통해 핸드트랙킹을 구현하였다. 
컨텐츠에서 가상의 손이 물체를 만지면 각 손가락과 물체에 주는 압력을 계산하게 된다.
이 계산된 값과 어떤 손가락인지를 아두이노로 블루투스를 통해 전달한다. 
이 정보들을 토대로 아두이노에서 해당 손가락에 특정 길이의 실을 당긴다.

근전도 컨텐츠를 위해 근전도 센서를 착용하면 아두이노에서 근전도 데이터를 블루투스 통신으로 유니티에 전송한다.
유니티에서는 이 근전도 데이터를 토대로 그래프를 보여주고, 
현재 근전도 값, 평균값, 공을 몇 번 쥐었는지, 물건을 몇 번 옮겼는지, 각 Task당 평균과 최대값을 알려주는 UI가 있다.



# 가상 물체 잡기 구현영상
> https://user-images.githubusercontent.com/100567791/203256496-d3a60ff7-e7bd-46d3-a9ac-2e93bc8988f9.mp4



