using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraControl : MonoBehaviour
{
    // Bat dau voi tam nhin width(be rong)
    private int defaultWidth;

    //Be rong lan cuoi su dung
    private int lastUpdateWidth;

    //bat dau voi man hinh camera mau
    private float defaultCameraSize;

	//Bat dau tien trinh nay
	void Start()
	{
        defaultWidth = lastUpdateWidth = Camera.main.pixelWidth;
        defaultCameraSize = Camera.main.orthographicSize;
        ChangeCameraSize();
	}

	//Cap nhat tien trinh nay
	void Update()
	{
		if(lastUpdateWidth != Camera.main.pixelWidth)
		{
			lastUpdateWidth = Camera.main.pixelWidth;
			ChangeCameraSize();
		}
	}

	// Thay doi kich co camera phu hop voi tam nhin phan mem
	private void ChangeCameraSize()
	{
		Camera.main.orthographicSize = defaultCameraSize * ((float)defaultWidth / (float)lastUpdateWidth);
	}
}
