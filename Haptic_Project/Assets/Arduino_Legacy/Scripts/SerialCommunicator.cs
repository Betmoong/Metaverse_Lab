using System;
using System.Collections;
using System.IO.Ports;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

[Serializable] public class SerialCommunicator : MonoBehaviour
{
    int RxSize = 24; //Receive
    int TxSize = 3; // Transmit


    //Ŭ���� ���� Serializable ����ϰ�, ����������� SerializeField����ϳ� ��������?
    [Serializable] public struct RxDATA // ������κ��� �����͸� �޾ƿ��� ���� Receive Data ����ü�� float�� ���� 6�� 
    {
        [SerializeField] public float yaw; // ����
        [SerializeField] public float pitch; // ��Ī
        [SerializeField] public float roll; // �Ѹ�
        [SerializeField] public float flx0; // �÷�������0
        [SerializeField] public float flx1; // �÷�������1
        [SerializeField] public float flx2; // �÷�������2
    };

    [Serializable] public struct TxDATA // ������ ������ �����ϱ� ���� Transmit Data ����ü�� short�� ���� 3��
    {
        [SerializeField] public short servoAct0; // ��������0
        [SerializeField] public short servoAct1; // ��������1
        [SerializeField] public short servoAct2; // ��������2
    };

    SerialPort sp; // SerialPort ��ü ���� ���߿� �����ĺ���
    Queue<byte> ReadData = new Queue<byte>(); // C# �� Queue ����

    /*
     Queue�� FIFO�̴�.
     ����
     Queue<int> q = new Queue<int>();
     q.Enqueue(120);
     q.Enqueue(130);
     q.Enqueue(150);

     int next = q.Dequeue(); // 120
     next = q.Dequeue(); // 130 
     */

    //���ӿ�����Ʈ ����
    public GameObject wrist;
    public GameObject index1;
    public GameObject index2;
    public GameObject index3;
    public GameObject midfg1;
    public GameObject midfg2;
    public GameObject midfg3;
    public GameObject thumb1;
    public GameObject thumb2;
    public GameObject thumb3;

    [SerializeField] public RxDATA RxBuffer; // ��ü ����
    [SerializeField] public TxDATA TxBuffer; // ��ü ����

    [SerializeField] public float[] angle = new float[3] { 0, 0, 0 }; // float�� �迭 ����, ���� 3��

    // Start is called before the first frame update
    void Start()
    {
        string the_com = ""; // �ʱ�ȭ�� empty string�̴�.


        // SerialPort.GetPortNames()�� string���� ���ҷ� ���� �迭�ΰ�??
        // COM1�� ���ϴ°����� ���� �Ƶ��̳� ��Ʈ�̸��� �ǹ��ϴ°� ����.
        // ���߿� �����ĺ���
        foreach (string mysps in SerialPort.GetPortNames()) 
        {
            print(mysps);
            if (mysps != "COM1") { the_com = mysps; break; } 
        }
        the_com = "COM3"; // �̰� �Ƹ��� �� �Ƶ��̳��� ��Ʈ�� COM3�̶� �ۼ��� �ڵ��ϰͰ���.

        sp = new SerialPort("\\\\.\\" + the_com, 115200); // ������ public SerialPort(string portName, int baudRate); �̴�. �׷��� �� "\\\\.\\" �̰� �ִ°���?

        if (!sp.IsOpen) // ���� serialport�� �������� �ʴٸ� ���� , open�� ����Ʈ�ϴ� ���ǹ�
        {
            print("Opening " + the_com + ", baud 115200");
            sp.Open();
            sp.ReadTimeout = 100;
            sp.Handshake = Handshake.None; // enum ����ߴ�. 
            if (sp.IsOpen) { print("Open"); }
        }
    }

    // Update is called once per frame
    void Update()
    {
        // ������Ʈ�Ҷ����� �ø�����Ʈ�� ���������� �����Ѵ�.
        if (sp.IsOpen) {
        int size = sp.BytesToRead; // Gets the number of bytes of data in the receive buffer. (���Ź��ۿ� ����ִ� �������� ����Ʈ ��)

        byte[] BUFFER = new byte[size]; // �迭
        sp.Read(BUFFER, 0, size); // Reads from the SerialPort input buffer. (�ø�����Ʈ�� ��ǲ���۷κ��� �д´�.)
        /*
            Reads a number of bytes from the SerialPort input buffer and writes those bytes into a byte array at the specified offset.
            public int Read (byte[] buffer, int offset, int count);
            buffer : The byte array to write the input to.
            offset : The offset in buffer at which to write the bytes.
            count : The maximum number of bytes to read. Fewer bytes are read if count is greater than the number of bytes in the input buffer.
         */



        // ReadData�� Queue�̴�. �ø�����Ʈ�� ��ǲ���۷� ���� �о���� �����Ͱ� BUFFER�迭�� ����Ǿ� �ְ�, �̰��� Queue�� Enqueue�ϴ°��̴�.
        for (Int16 c = 0; c < size; c++) ReadData.Enqueue(BUFFER[c]); // Queue<byte> ReadData = new Queue<byte>(); ���� �����Ѱ� ����

        while (ReadData.Count > RxSize) // ReadData�� Queue�̴�. Count �޼ҵ�� The number of elements contained in the Queue. �׸��� RxSize�� ������ ���ǵ� ����̴�.
            {
            while (true) { if (ReadData.Dequeue() == 170) break; }
                // ReadData.Dequeue �żҵ��� ���ϰ��� �ø�����Ʈ�� ��ǲ���۷� ���� �о���� �����͸� ���ۿ� �����Ѱ��� Enqueue�� Queue�� �������̴�. �� 170�� ���ϴ°�? ���߿� �˾ƺ���.
                /*
                Returns a single-precision floating point number converted from four bytes at a specified position in a byte array.

                public static float ToSingle (byte[] value, int startIndex);
                value : An array of bytes.
                startIndex : The starting position within value.

                from four bytes ��°͋����� ����Ʈ 4���� ���ҷΰ��� �迭�� �Ű������� ���°��ΰ�? ��Ȯ������ �ʴ�.
                �׸��� RxSize�� 24�� ������ yaw pitch roll flx0 flx1 flx2 �̷��� �� 6���� ���� ���� 4bytes �� 6*4=24 �ΰͰ���. ��Ȯ������ �ʴ�.
                */
            RxBuffer.yaw = BitConverter.ToSingle(
                new byte[4]{ReadData.Dequeue(), ReadData.Dequeue(), ReadData.Dequeue(), ReadData.Dequeue()},0); //�Ű������� �迭�� 0 ���� �� 2���̴�.
            RxBuffer.pitch = BitConverter.ToSingle(
                new byte[4]{ReadData.Dequeue(), ReadData.Dequeue(), ReadData.Dequeue(), ReadData.Dequeue()},0);
            RxBuffer.roll = BitConverter.ToSingle(
                new byte[4]{ReadData.Dequeue(), ReadData.Dequeue(), ReadData.Dequeue(), ReadData.Dequeue()},0);
            
            RxBuffer.flx0 = BitConverter.ToSingle(
                new byte[4]{ReadData.Dequeue(), ReadData.Dequeue(), ReadData.Dequeue(), ReadData.Dequeue()},0);
            RxBuffer.flx1 = BitConverter.ToSingle(
                new byte[4]{ReadData.Dequeue(), ReadData.Dequeue(), ReadData.Dequeue(), ReadData.Dequeue()},0);
            RxBuffer.flx2 = BitConverter.ToSingle(
                new byte[4]{ReadData.Dequeue(), ReadData.Dequeue(), ReadData.Dequeue(), ReadData.Dequeue()},0);
        }

        angle[0] = RxBuffer.yaw * 180.0f / 3.141592f; // Radian Degree ��ȯ
        angle[1] = RxBuffer.pitch * 180.0f / 3.141592f;
        angle[2] = RxBuffer.roll * 180.0f / 3.141592f;
        }

        print(String.Format("{0}, {1}, {2}, {3}, {4}, {5}", angle[0], angle[1], angle[2], RxBuffer.flx0, RxBuffer.flx1, RxBuffer.flx2));

        wrist.transform.rotation = Quaternion.Euler(-angle[2], angle[0], -angle[1]);


        //�հ��� ���� ȸ��
        index1.transform.localRotation = Quaternion.Euler(- RxBuffer.flx1 / 3, 0, 0);
        index2.transform.localRotation = Quaternion.Euler(- RxBuffer.flx1 / 3, 0, 0);
        index3.transform.localRotation = Quaternion.Euler(- RxBuffer.flx1 / 3, 0, 0); 
        midfg1.transform.localRotation = Quaternion.Euler(- RxBuffer.flx2 / 3, 0, 0);
        midfg2.transform.localRotation = Quaternion.Euler(- RxBuffer.flx2 / 3, 0, 0);
        midfg3.transform.localRotation = Quaternion.Euler(- RxBuffer.flx2 / 3, 0, 0); 
        thumb2.transform.localRotation = Quaternion.Euler(- RxBuffer.flx0 / 2, 0, 0);
        thumb3.transform.localRotation = Quaternion.Euler(- RxBuffer.flx0 / 2, 0, 0); 

        //TxBuffer.servoAct0 = 0xFF;
        //TxBuffer.servoAct1 = 0xFF;
        //TxBuffer.servoAct2 = 0xFF;
        SerialTx(TxBuffer); // �������� ����
    }


    bool SerialTx(TxDATA tx)
    {
        if (!sp.IsOpen)
        {
            return false;
        }
        /*
         Writes data to the serial port output buffer.

        Writes a specified number of bytes to the serial port using data from a buffer.
        public void Write (byte[] buffer, int offset, int count);

        buffer : The byte array that contains the data to write to the port.
        offset : The zero-based byte offset in the buffer parameter at which to begin copying bytes to the port.
        count : The number of bytes to write.

        */
        sp.Write(new byte[1] {0xAA}, 0, 1); // ������ 0xAA�� �ϴ°Ͱ���.
        print(string.Format("tx : {0}, {1}, {2}", tx.servoAct0, tx.servoAct1, tx.servoAct2));
        sp.Write(System.BitConverter.GetBytes(tx.servoAct0), 0, 2); // ����° �Ķ���Ͱ� 2�� ������ TxDATA ����ü�� ���� servoAct0�� 2bytes type�� short�̱� �����̶�� �����Ѵ�. ��Ȯ������ �ʴ�.
        sp.Write(System.BitConverter.GetBytes(tx.servoAct1), 0, 2);
        sp.Write(System.BitConverter.GetBytes(tx.servoAct2), 0, 2);
        
        return true;
    }
}
