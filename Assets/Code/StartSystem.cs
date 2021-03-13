using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
public class StartSystem : MonoBehaviour
{
    // UI 相关参数
    public RawImage rawImage;//简而言之就是将手机所摄取的图像显示再这个2D平面内
    // 摄像机图片参数
    private WebCamTexture webCamTexture;
    // Use this for initialization
    void Start(){
        // 打开相机
        StartCoroutine("OpenCamera");
    }
    /// <summary>
    /// 使用协程打开相机函数
    /// </summary>
    /// <returns></returns>
    IEnumerator OpenCamera()
    {
        // 申请相机权限
        yield return Application.RequestUserAuthorization(UserAuthorization.WebCam);
        // 判断是否有相机权限
        if (Application.HasUserAuthorization(UserAuthorization.WebCam)){
            // 获取相机设备
            WebCamDevice[] webCamDevices = WebCamTexture.devices;
            // 判断是否有相机设别
            if (webCamDevices != null && webCamDevices.Length > 0){
                // 把 0 号设备（移动端后置摄像头）名称赋值
                string webCamName = webCamDevices[0].name;
                // 设置相机渲染宽高，并运行相机
                webCamTexture = new WebCamTexture(webCamName, Screen.width, Screen.height);
                webCamTexture.Play();
                // 把获取的图像渲染到画布上
                rawImage.texture = webCamTexture;
            }
        }
    }
}