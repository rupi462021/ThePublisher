﻿//using System;
//using System.IO;
//using System.Reflection;
//using System.Threading;
//using System.Threading.Tasks;
//using System.Web;
//using Google.Apis.Auth.OAuth2;
//using Google.Apis.Services;
//using Google.Apis.Upload;
//using Google.Apis.Util.Store;
//using Google.Apis.YouTube.v3;
//using Google.Apis.YouTube.v3.Data;

//namespace ThePublisherM.utils
//{
//    public class UploadVideoShimi
//    {
//        //[STAThread]
//        //static void Main(string[] args)
//        //{
//        //    Console.WriteLine("YouTube Data API: Upload Video");
//        //    Console.WriteLine("==============================");

//        //    try
//        //    {
//        //        new UploadVideo().Run().Wait();
//        //    }
//        //    catch (AggregateException ex)
//        //    {
//        //        foreach (var e in ex.InnerExceptions)
//        //        {
//        //            Console.WriteLine("Error: " + e.Message);
//        //        }
//        //    }

//        //    Console.WriteLine("Press any key to continue...");
//        //    Console.ReadKey();
//        //}
//        public delegate void Notify();
//        public event Notify onUploadFinished;
//        private string title;
//        private string description;
//        public UploadVideoShimi(string title, string description)
//        {
//            this.title = title;
//            this.description = description;

//        }
//        public async void UploadAsync()
//        {
//            await Task.Run(Run);
//        }
//        private async Task Run()
//        {
//            UserCredential credential;
//            using (var stream = new FileStream(@"client_secret.json", FileMode.Open, FileAccess.Read))
//            {
//                credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
//                    GoogleClientSecrets.Load(stream).Secrets,
//                    // This OAuth 2.0 access scope allows an application to upload files to the
//                    // authenticated user's YouTube channel, but doesn't allow other types of access.
//                    new[] { YouTubeService.Scope.YoutubeUpload },
//                    "user",
//                    CancellationToken.None
//                );
//            }

//            var youtubeService = new YouTubeService(new BaseClientService.Initializer()
//            {
//                HttpClientInitializer = credential,
//                ApplicationName = Assembly.GetExecutingAssembly().GetName().Name
//            });

//            var video = new Video();
//            video.Snippet = new VideoSnippet();
//            video.Snippet.Title = this.title;
//            video.Snippet.Description = this.description;
//            video.Snippet.Tags = new string[] { "tag1", "tag2" };
//            video.Snippet.CategoryId = "22"; // See https://developers.google.com/youtube/v3/docs/videoCategories/list
//            video.Status = new VideoStatus();
//            video.Status.PrivacyStatus = "unlisted"; // or "private" or "public"
//            var filePath = System.AppDomain.CurrentDomain.BaseDirectory + "\\utils\\testing.mp4"; // Replace with path to actual movie file.

//            using (var fileStream = new FileStream(filePath, FileMode.Open))
//            {
//                var videosInsertRequest = youtubeService.Videos.Insert(video, "snippet,status", fileStream, "video/*");
//                videosInsertRequest.ProgressChanged += videosInsertRequest_ProgressChanged;
//                videosInsertRequest.ResponseReceived += videosInsertRequest_ResponseReceived;

//                await videosInsertRequest.UploadAsync();
//            }
//        }

//        void videosInsertRequest_ProgressChanged(Google.Apis.Upload.IUploadProgress progress)
//        {
//            switch (progress.Status)
//            {
//                case UploadStatus.Uploading:
//                    Console.WriteLine("{0} bytes sent.", progress.BytesSent);
//                    break;

//                case UploadStatus.Failed:
//                    Console.WriteLine("An error prevented the upload from completing.\n{0}", progress.Exception);
//                    break;
//            }
//        }

//        void videosInsertRequest_ResponseReceived(Video video)
//        {
//            Console.WriteLine("Video id '{0}' was successfully uploaded.", video.Id);
//            onUploadFinished?.Invoke();
//        }

//    }
//}