using System;
using System.Collections.Generic;
using VideoApplication.Core.Entity;

namespace VideoApplication
{
    class Program
    {
        static List<Video> videos = new List<Video>();
        static List<Genre> genres = new List<Genre>();
        static int videoId = 1;

        static string[] menuItems = {
                "Show all video titles",
                "Add new video",
                "Edit video",
                "Delete video",
                "Exit"
        };

        static void Main(string[] args)
        {
            AddMockVideos();
            var selection = ShowMenu();
            HandleSelection(selection);

        }

        private static void AddMockVideos()
        {
            videos.Add(new Video
            {
                Id = videoId++,
                Name = "Something"
            });

            videos.Add(new Video
            {
                Id = videoId++,
                Name = "SomethingElse"
            });
        }

        static public int ShowMenu()
        {


            Console.WriteLine("Select an action from the menu by selecting the menuitems number:");

            for (int i = 0; i < menuItems.Length; i++)
            {
                Console.WriteLine($"{(i + 1)}. {menuItems[i]}");
            }

            int number;
            string value = Console.ReadLine();

            while (!int.TryParse(value, out number)
                || number < 1
                || number > menuItems.Length)
            {
                Console.WriteLine("Has to be a number");
                value = Console.ReadLine();
            }

            return number;
        }


        static private void HandleSelection(int selection)
        {
            while (selection != menuItems.Length)
            {
                Console.Clear();
                switch (selection)
                {
                    case 1:
                        ShowAllVideos();
                        break;

                    case 2:
                        Console.WriteLine("Enter video title");
                        AddVideo(Console.ReadLine());
                        break;

                    case 3:
                        var edited = EditVideo(GetIdFromUser());
                        if (!edited)
                        {
                            Console.WriteLine("Video could not be edited");
                        }
                        break;

                    case 4:
                        var deleted = DeleteVideo(GetIdFromUser());
                        if (!deleted)
                        {
                            Console.WriteLine("Video could not be deleted");
                        }
                        break;

                }

                selection = ShowMenu();

            }
        }

        static private int GetIdFromUser()
        {
            Console.WriteLine("Enter video id");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("write a number");
            }
            return id;
        }



        static public bool EditVideo(int id)
        {
            var video = FindVideoById(id);
            if (video != null)
            {
                Console.WriteLine("Edit the video title of selected video");
                var title = Console.ReadLine();
                video.Name = title;
                return true;
            }
            else
            {
                return false;
            }
        }

        static public Video FindVideoById(int id)
        {
            if (videos.Exists(video => video.Id == id))
            {
                return videos.Find(video => video.Id == id);
            }
            else
            {
                return null;
            }
        }

        static public bool DeleteVideo(int id)
        {
            var vid = FindVideoById(id);
            if (vid != null)
            {
                videos.Remove(vid);
                return true;
            }
            else
            {
                return false;
            }
        }

        static public void AddVideo(string videoTitle)
        {
            videos.Add(new Video
            {
                Id = videoId++,
                Name = videoTitle
            });
        }

        static public void ShowAllVideos()
        {
            foreach (var video in videos)
            {
                Console.WriteLine($"{video.Id}. {video.Name}");
            }
        }
    }

}

