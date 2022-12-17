using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraManager : MonoBehaviour
{
    public static CameraManager Instance { get; private set; }

    // 現在のカメラ位置
    public string CurrentPositionName { get; private set; }

	public GameObject ButtonLeft;
	public GameObject ButtonRight;
	public GameObject ButtonBack;

    // カメラの位置クラス
    private class CameraPositionInfo
    {
        // カメラの位置
        public Vector3 Position { get; set; }
        // カメラの角度
        public Vector3 Rotate { get; set; }
        // ボタンの移動先
        public MoveNames MoveNames { get; set; }
	}

    // ボタンの移動先クラス
    private class MoveNames
    {
        // 左ボタンを押した時の位置名
        public string Left { get; set; }
        // 右ボタンを押した時の位置名
        public string Right { get; set; }
        // 下ボタンを押した時の位置名
        public string Back { get; set; }
	}

	// 全カメラの位置情報
	private Dictionary<string, CameraPositionInfo> _CameraPositionInfoes = new Dictionary<string, CameraPositionInfo>
	{
        {
            // 位置
            "Exit",
            new CameraPositionInfo
            {
                Position = new Vector3(1.4f, 2.0f, -2.0f),
                Rotate = new Vector3(0, 0, 0),
                MoveNames = new MoveNames
                {
                    Left = "TVSideWall",
                    Right = "Sofa",
                }
            }
        },
        {
            // 位置
            "TVSideWall",
            new CameraPositionInfo
            {
                Position = new Vector3(4.0f, 3f, 0),
                Rotate = new Vector3(10, -90, 0),
                MoveNames = new MoveNames
                {
                    Left = "Box",
                    Right = "Exit",
                }
            }
        },
        {
            // 位置
            "Box",
            new CameraPositionInfo
            {
                Position = new Vector3(2.5f, 2.8f, -4.6f),
                Rotate = new Vector3(10, -90, 0),
                MoveNames = new MoveNames
                {
                    Left = "Bed",
                    Right = "TVSideWall",
                }
            }
        },
        {
            // 位置
            "Bed",
            new CameraPositionInfo
            {
                Position = new Vector3(-1.3f, 2.5f, 0.7f),
                Rotate = new Vector3(0, 152, 0),
                MoveNames = new MoveNames
                {
                    Left = "Sofa",
                    Right = "Box",
                }
            }
        },
        {
            // 位置
            "Sofa",
            new CameraPositionInfo
            {
                Position = new Vector3(-2.6f, 2.2f, -6.2f),
                Rotate = new Vector3(5, 42, 0),
                MoveNames = new MoveNames
                {
                    Left = "Exit",
                    Right = "Bed",
                }
            }
        },
        {
            // 位置
            "LowBox",
            new CameraPositionInfo
            {
                Position = new Vector3(-0.33f, 1.2f, 2.2f),
                Rotate = new Vector3(0, 90, 0),
                MoveNames = new MoveNames
                {
                    Back = "Sofa"
                }
            }
        },
        {
            // 位置
            "LowBox00",
            new CameraPositionInfo
            {
                Position = new Vector3(1.6f, 1.2f, 2.68f),
                Rotate = new Vector3(0, 90, 0),
                MoveNames = new MoveNames
                {
                    Back = "LowBox",
                }
            }
        },
        {
            // 位置
            "LowBox01",
            new CameraPositionInfo
            {
                Position = new Vector3(1.6f, 1.2f, 1.7f),
                Rotate = new Vector3(0, 90, 0),
                MoveNames = new MoveNames
                {
                    Back = "LowBox",
                }
            }
        },
        {
            // 位置
            "LowBox10",
            new CameraPositionInfo
            {
                Position = new Vector3(2.1f, 0.83f, 2.9f),
                Rotate = new Vector3(0, 90, 0),
                MoveNames = new MoveNames
                {
                    Back = "LowBox",
                }
            }
        },
        {
            // 位置
            "LowBox11",
            new CameraPositionInfo
            {
                Position = new Vector3(2.3f, 0.8f, 1.95f),
                Rotate = new Vector3(0, 90, 0),
                MoveNames = new MoveNames
                {
                    Back = "LowBox",
                }
            }
        },
        {
            // 位置
            "LowBox20",
            new CameraPositionInfo
            {
                Position = new Vector3(1.6f, 0.5f, 2.65f),
                Rotate = new Vector3(0, 90, 0),
                MoveNames = new MoveNames
                {
                    Back = "LowBox",
                }
            }
        },
        {
            // 位置
            "LowBox21",
            new CameraPositionInfo
            {
                Position = new Vector3(2.4f, 0.5f, 1.45f),
                Rotate = new Vector3(0, 90, 0),
                MoveNames = new MoveNames
                {
                    Back = "LowBox",
                }
            }
        },
        {
            // 位置
            "Door",
            new CameraPositionInfo
            {
                Position = new Vector3(2.5f, 1.5f, 2.7f),
                Rotate = new Vector3(0, 0, 0),
                MoveNames = new MoveNames
                {
                    Back = "Exit",
                }
            }
        },
        {
            // 位置
            "Vase",
            new CameraPositionInfo
            {
                Position = new Vector3(-3.2f, 3.2f, -3.2f),
                Rotate = new Vector3(90, -90, 0),
                MoveNames = new MoveNames
                {
                    Back = "Box",
                }
            }
        },
        {
            // 位置
            "Pillow",
            new CameraPositionInfo
            {
                Position = new Vector3(1.4f, 2.7f, -3.7f),
                Rotate = new Vector3(30, 132, 0),
                MoveNames = new MoveNames
                {
                    Back = "Bed",
                }
            }
        },
        {
            // 位置
            "MovePillow",
            new CameraPositionInfo
            {
                Position = new Vector3(1.4f, 2.7f, -3.7f),
                Rotate = new Vector3(30, 132, 0),
                MoveNames = new MoveNames
                {
                    Back = "Bed",
                }
            }
        },
        {
            // 位置
            "BoxPaint",
            new CameraPositionInfo
            {
                Position = new Vector3(-2.3f, 2.0f, -4.7f),
                Rotate = new Vector3(10, 270, 0),
                MoveNames = new MoveNames
                {
                    Back = "Box",
                }
            }
        },
        {
            // 位置
            "BoxSign",
            new CameraPositionInfo
            {
                Position = new Vector3(-2.2f, 1.8f, -5.6f),
                Rotate = new Vector3(0, 270, 0),
                MoveNames = new MoveNames
                {
                    Back = "Box",
                }
            }
        },
        {
            // 位置
            "BoxPaper",
            new CameraPositionInfo
            {
                Position = new Vector3(-3.24f, 2.7f, -5.65f),
                Rotate = new Vector3(90, 270, 0),
                MoveNames = new MoveNames
                {
                    Back = "Box",
                }
            }
        },
        {
            // 位置
            "SlideLowBox00",
            new CameraPositionInfo
            {
                Position = new Vector3(1.8f, 2.6f, 2.7f),
                Rotate = new Vector3(50, 90, 0),
                MoveNames = new MoveNames
                {
                    Back = "LowBox",
                }
            }
        },
        {
            // 位置
            "SlideLowBox10",
            new CameraPositionInfo
            {
                Position = new Vector3(1.8f, 2.2f, 2.7f),
                Rotate = new Vector3(50, 90, 0),
                MoveNames = new MoveNames
                {
                    Back = "LowBox",
                }
            }
        },
        {
            // 位置
            "SlideLowBox20",
            new CameraPositionInfo
            {
                Position = new Vector3(1.8f, 1.8f, 2.7f),
                Rotate = new Vector3(50, 90, 0),
                MoveNames = new MoveNames
                {
                    Back = "LowBox",
                }
            }
        },
        {
            // 位置
            "SlideLowBox01",
            new CameraPositionInfo
            {
                Position = new Vector3(1.8f, 2.6f, 1.7f),
                Rotate = new Vector3(50, 90, 0),
                MoveNames = new MoveNames
                {
                    Back = "LowBox",
                }
            }
        },
        {
            // 位置
            "SlideLowBox11",
            new CameraPositionInfo
            {
                Position = new Vector3(1.8f, 2.2f, 1.7f),
                Rotate = new Vector3(50, 90, 0),
                MoveNames = new MoveNames
                {
                    Back = "LowBox",
                }
            }
        },
        {
            // 位置
            "SlideLowBox21",
            new CameraPositionInfo
            {
                Position = new Vector3(1.8f, 1.8f, 1.7f),
                Rotate = new Vector3(50, 90, 0),
                MoveNames = new MoveNames
                {
                    Back = "LowBox",
                }
            }
        },
        {
            // 位置
            "Candle",
            new CameraPositionInfo
            {
                Position = new Vector3(2.8f, 2.2f, -1.3f),
                Rotate = new Vector3(20, 270, 0),
                MoveNames = new MoveNames
                {
                    Back = "Sofa",
                }
            }
        },
        {
            // 位置
            "Paints",
            new CameraPositionInfo
            {
                Position = new Vector3(1.0f, 2.7f, 3.2f),
                Rotate = new Vector3(10, 270, 0),
                MoveNames = new MoveNames
                {
                    Back = "TVSideWall",
                }
            }
        },
        {
            // 位置
            "Signs",
            new CameraPositionInfo
            {
                Position = new Vector3(-0.8f, 2.6f, -1.7f),
                Rotate = new Vector3(0, 0, 0),
                MoveNames = new MoveNames
                {
                    Back = "Exit",
                }
            }
        },
        {
            // 位置
            "SampleTableSet",
            new CameraPositionInfo
            {
                Position = new Vector3(-1.5f, 2.3f, 3.95f),
                Rotate = new Vector3(70, 90, 0),
                MoveNames = new MoveNames
                {
                    Back = "Signs",
                }
            }
        },
        {
            // 位置
            "SettingTable",
            new CameraPositionInfo
            {
                Position = new Vector3(1.0f, 2.3f, 4.05f),
                Rotate = new Vector3(40, -90, 0),
                MoveNames = new MoveNames
                {
                    Back = "Signs",
                }
            }
        },
	};

	// Start is called before the first frame update
	void Start()
    {
		Instance = this;

		ChangeCameraPosition("Exit");
		ButtonBack.GetComponent<Button>().onClick.AddListener(() =>
		{
			ChangeCameraPosition(_CameraPositionInfoes[CurrentPositionName].MoveNames.Back);
		});
        ButtonLeft.GetComponent<Button>().onClick.AddListener(() =>
		{
			ChangeCameraPosition(_CameraPositionInfoes[CurrentPositionName].MoveNames.Left);
		});
        ButtonRight.GetComponent<Button>().onClick.AddListener(() =>
		{
			ChangeCameraPosition(_CameraPositionInfoes[CurrentPositionName].MoveNames.Right);
		});
	}

    // カメラ移動
    public void ChangeCameraPosition(string positionName)
    {
        if (positionName == null)
			return;

		CurrentPositionName = positionName;

		GetComponent<Camera>().transform.position = _CameraPositionInfoes[CurrentPositionName].Position;
		GetComponent<Camera>().transform.rotation = Quaternion.Euler(_CameraPositionInfoes[CurrentPositionName].Rotate);

		UpdateButtonActive();
	}
    
    private void UpdateButtonActive()
    {
        if (_CameraPositionInfoes[CurrentPositionName].MoveNames.Back == null)
			ButtonBack.SetActive(false);
        else
			ButtonBack.SetActive(true);
        if (_CameraPositionInfoes[CurrentPositionName].MoveNames.Left == null)
			ButtonLeft.SetActive(false);
        else
			ButtonLeft.SetActive(true);
	    if (_CameraPositionInfoes[CurrentPositionName].MoveNames.Right == null)
			ButtonRight.SetActive(false);
        else
			ButtonRight.SetActive(true);
    }
}
