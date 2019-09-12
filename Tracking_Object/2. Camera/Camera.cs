using OpenCvSharp;
using System;
using System.Diagnostics;
using System.Threading;

namespace Tracking_Object
{
    class Camera : IDisposable
    {
        VideoCapture capture;
        private Thread camera;
        bool isCameraRunning = false;

        public void CaptureCamera()
        {
            camera = new Thread(new ThreadStart(CaptureCameraCallback));
            camera.Start();
        }

        private void CaptureCameraCallback()
        {
            using var capture = new VideoCapture(CaptureDevice.Any, index: 0);

            using Mat frame = new Mat();
            while (isCameraRunning == true)
            {
                var interval = (int)(1000 / capture.Fps);
                capture.Read(frame);
                Cv2.ImShow("Cam", frame);
                Debug.WriteLine(interval);
            }
        }
        private void Camera_Start()
        {
            CaptureCamera();
            isCameraRunning = true;

            capture.Release();
            isCameraRunning = false;
        }
        private void Camera_Stop()
        {
            capture.Release();
            isCameraRunning = false;
        }

        #region IDisposable Support
        private bool disposedValue = false; // 중복 호출을 검색하려면

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    capture.Dispose();
                    // TODO: 관리되는 상태(관리되는 개체)를 삭제합니다.
                }

                // TODO: 관리되지 않는 리소스(관리되지 않는 개체)를 해제하고 아래의 종료자를 재정의합니다.
                // TODO: 큰 필드를 null로 설정합니다.

                disposedValue = true;
            }
        }

        // TODO: 위의 Dispose(bool disposing)에 관리되지 않는 리소스를 해제하는 코드가 포함되어 있는 경우에만 종료자를 재정의합니다.
        // ~Camera()
        // {
        //   // 이 코드를 변경하지 마세요. 위의 Dispose(bool disposing)에 정리 코드를 입력하세요.
        //   Dispose(false);
        // }

        // 삭제 가능한 패턴을 올바르게 구현하기 위해 추가된 코드입니다.
        public void Dispose()
        {
            // 이 코드를 변경하지 마세요. 위의 Dispose(bool disposing)에 정리 코드를 입력하세요.
            Dispose(true);
            // TODO: 위의 종료자가 재정의된 경우 다음 코드 줄의 주석 처리를 제거합니다.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
