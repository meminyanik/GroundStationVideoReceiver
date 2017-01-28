using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DroneVideoReceiver
{
    public partial class VideoReceiverForm : Form
    {
        Process videoReceiverProcess;                           //Process for receiving video
        IntPtr handleForVideoReceiverWindow;                    //Handle for the video receiver window
        bool condition;                                         //Holds the condition (True:Started - False:Stopped)

        //TODO: Start/Stop Button will be enabled according to the established socket connection with Raspberry Pi
        public VideoReceiverForm()
        {
            InitializeComponent();

            //initialize variables
            condition = false;
            videoReceiverProcess = null;
            handleForVideoReceiverWindow = IntPtr.Zero;

            //RichTextBox.CheckForIllegalCrossThreadCalls = false;       
        }

        //starts video receiving from the streamer
        private void buttonStartStop_Click(object sender, EventArgs e)
        {
            //Video receiver is not running, will be started
            if(!condition)
            {
                StartVideoReceiver();
            }
            //Video receiver is running, will be stopped
            else
            {
                StopVideoReceiver();
            }

            buttonStartStop.Text = condition ? "Stop Video Receiver" : "Start Video Receiver";
        }

        private void StartVideoReceiver()
        {
            //create new process for video streamer
            videoReceiverProcess = new Process();

            //set the executable file for the process
            videoReceiverProcess.StartInfo.FileName = "C:\\gstreamer\\1.0\\x86_64\\bin\\gst-launch-1.0.exe";

            //set arguments for the process
            //videoReceiverProcess.StartInfo.Arguments = "videotestsrc ! autovideosink";      //arguments for testing gstreamer

            //other examples for gstreamer (send and receive)
            //videoReceiverProcess.StartInfo.Arguments = "autovideosrc ! video/x-raw,width=640,height=480 ! timeoverlay ! tee name=\"local\" ! queue ! autovideosink local. ! queue ! jpegenc! rtpjpegpay ! udpsink host=127.0.0.1 port= 5000";
            videoReceiverProcess.StartInfo.Arguments = "udpsrc port=5000 ! application/x-rtp, payload=96 ! rtpjitterbuffer ! rtph264depay ! avdec_h264 ! fpsdisplaysink sync=false text-overlay=false";

            //set other options for the video receiver process
            videoReceiverProcess.StartInfo.RedirectStandardOutput = true;
            videoReceiverProcess.StartInfo.RedirectStandardError = true;
            videoReceiverProcess.EnableRaisingEvents = true;

            //options for NOT opening a console window to start the process 
            videoReceiverProcess.StartInfo.CreateNoWindow = true;
            videoReceiverProcess.StartInfo.UseShellExecute = false;

            //start the video streamer process
            videoReceiverProcess.Start();

            //wait for the process to get a MainWindowHandle
            int timeElapsed = 0;                                //Elapsed time in ms
            int waitTime = 10;                                  //Waiting time in ms for each step of the while loop    
            int maximumWaitTime = 3000;                         //Maximum waiting time in ms
            while (videoReceiverProcess.MainWindowHandle == IntPtr.Zero)
            {
                System.Threading.Thread.Sleep(waitTime);
                timeElapsed += waitTime;

                if (timeElapsed > maximumWaitTime)
                {
                    videoReceiverProcess.Kill();
                    videoReceiverProcess = null;
                    handleForVideoReceiverWindow = IntPtr.Zero;

                    MessageBox.Show("Could not connect to Raspberry Pi\nPlease check the configuration", "Connection Error", MessageBoxButtons.OK);

                    break;
                }
            }
            //System.Threading.Thread.Sleep(1000);

            //Process was started successfully
            if (videoReceiverProcess != null)
            {
                //get MainWindowHandle of the video receiver process
                handleForVideoReceiverWindow = videoReceiverProcess.MainWindowHandle;

                //Link the window of the video streamer process to the main window
                WindowOperations windowOperations = new WindowOperations();
                windowOperations.LinkToMainWindow(panelVideo, handleForVideoReceiverWindow);

                //Video receiver started
                condition = true;
            }
        }

        //stops video receiving from the streamer
        private void StopVideoReceiver()
        {
            videoReceiverProcess.CloseMainWindow();
            videoReceiverProcess = null;
            handleForVideoReceiverWindow = IntPtr.Zero;
            condition = false;
        }
    }
}
