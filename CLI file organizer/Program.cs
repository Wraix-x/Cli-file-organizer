using System.ComponentModel.Design;
using System.Xml;

namespace CLI_file_organizer
{
    internal class Program
    {
        static void Main(string[] args)

        {
            bool Selection = true;
            string Folder;
            string File_type;
            int Picker;
            string ImageDestinationFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            string AudioDestinationFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);
            string VideosDestinationFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyVideos);
            string DocumentDestinationFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string downloads = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");
            string[] Downloads = Directory.GetFiles(downloads);
            string[] Desktop = Directory.GetFiles(desktop);
            while (Selection)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("""

                ███████╗██╗██╗     ███████╗    ███╗   ███╗ █████╗ ███╗   ██╗ █████╗  ██████╗ ███████╗██████╗ 
                ██╔════╝██║██║     ██╔════╝    ████╗ ████║██╔══██╗████╗  ██║██╔══██╗██╔════╝ ██╔════╝██╔══██╗
                █████╗  ██║██║     █████╗      ██╔████╔██║███████║██╔██╗ ██║███████║██║  ███╗█████╗  ██████╔╝
                ██╔══╝  ██║██║     ██╔══╝      ██║╚██╔╝██║██╔══██║██║╚██╗██║██╔══██║██║   ██║██╔══╝  ██╔══██╗
                ██║     ██║███████╗███████╗    ██║ ╚═╝ ██║██║  ██║██║ ╚████║██║  ██║╚██████╔╝███████╗██║  ██║
                ╚═╝     ╚═╝╚══════╝╚══════╝    ╚═╝     ╚═╝╚═╝  ╚═╝╚═╝  ╚═══╝╚═╝  ╚═╝ ╚═════╝ ╚══════╝╚═╝  ╚═╝
                                                                                                             
                """);
                Console.ResetColor();
                Console.WriteLine("""
                    Options:
                    1. Continue
                    2. Exit
                    """);
                Console.Write("""

                    ║
                    ╚═> 
                    """);
                Picker = Convert.ToInt32(Console.ReadLine());
                if(Picker == 1)
                {
                    Console.WriteLine("Which folder do you want to organize (Downloads, Desktop, All)");
                    Console.WriteLine("DISCLAIMER! if you sellect all you will organize every file in both dirs");
                    Console.Write("> ");
                    Folder = Console.ReadLine();
                    if(Folder.ToUpper() == "DOWNLOADS")
                    {
                        Console.WriteLine("Which file type do you want to organize (Images, Audio, Videos, Documents, All");
                        Console.Write("> ");
                        File_type = Console.ReadLine();
                        if(File_type.ToUpper() == "IMAGES")
                        {
                            foreach(string download_files in Downloads)
                            {
                                string ImageDestination = Path.Combine(ImageDestinationFolder, Path.GetFileName(download_files));   
                                string extension = Path.GetExtension(download_files).ToLower();
                                if(extension == ".jpg" || extension == ".png" || extension == ".webp" || extension == ".gif" || extension == ".jpeg")
                                {
                                    if (File.Exists(ImageDestination))
                                    {
                                        error(); ;
                                    }
                                    else
                                    {
                                        File.Move(download_files, ImageDestination);
                                        Console.WriteLine(Path.GetFileName(download_files) + " has been moved");
                                    }
                                }
                            }
                        }
                        else if(File_type.ToUpper() == "AUDIO")
                        {
                            foreach(string download_files in Downloads)
                            {
                                string AudioDestination = Path.Combine(AudioDestinationFolder, Path.GetFileName(download_files));
                                string extension = Path.GetExtension(download_files).ToLower();
                                if (extension == ".mp3" || extension == ".wav" || extension == ".aiff" || extension == ".aac")
                                {
                                    if (File.Exists(AudioDestination))
                                    {
                                        error();
                                    }
                                    else
                                    {
                                        File.Move(download_files, AudioDestination);
                                        Console.WriteLine(Path.GetFileName(download_files) + " has been moved");
                                    }
                                }
                            }
                        }
                        else if(File_type.ToUpper() == "VIDEOS")
                        {
                            foreach (string download_files in Downloads)
                            {
                                string VideoDestination = Path.Combine(VideosDestinationFolder, Path.GetFileName(download_files));
                                string extension = Path.GetExtension(download_files).ToLower();
                                if(extension == ".mp4" || extension == ".mov" || extension == ".avi" || extension == ".mkv")
                                {
                                    if (File.Exists(VideoDestination))
                                    {
                                        error();
                                    }
                                    else
                                    {
                                        File.Move(download_files, VideoDestination);
                                        Console.WriteLine(Path.GetFileName(download_files) + " has been moved");
                                    }
                                }
                            }
                        }
                        else if (File_type.ToUpper() == "DOCUMENTS")
                        {
                            foreach (string download_files in Downloads)
                            {
                                string DocumentDestination = Path.Combine(DocumentDestinationFolder, Path.GetFileName(download_files));
                                string extension = Path.GetExtension(download_files).ToLower();
                                if (extension == ".docx" || extension == ".pdf" || extension == ".xlsx" || extension == ".pptx" || extension == ".txt" || extension == ".html" || extension == ".md" || extension == ".csv" || extension == ".pages")
                                {
                                    if (File.Exists(DocumentDestination))
                                    {
                                        error();
                                    }
                                    else
                                    {
                                        File.Move(download_files, DocumentDestination);
                                        Console.WriteLine(Path.GetFileName(download_files) + " has been moved");
                                    }
                                }
                            }
                        }
                        else if(File_type.ToUpper() == "ALL")
                        {
                            foreach (string download_files in Downloads)
                            {
                                string DocumentDestination = Path.Combine(DocumentDestinationFolder, Path.GetFileName(download_files));
                                string VideoDestination = Path.Combine(VideosDestinationFolder, Path.GetFileName(download_files));
                                string AudioDestination = Path.Combine(AudioDestinationFolder, Path.GetFileName(download_files));
                                string ImageDestination = Path.Combine(ImageDestinationFolder, Path.GetFileName(download_files));
                                string extension = Path.GetExtension(download_files).ToLower();
                                if (extension == ".jpg" || extension == ".png" || extension == ".webp" || extension == ".gif" || extension == ".jpeg")
                                {
                                    if (File.Exists(ImageDestination))
                                    {
                                        error();
                                    }
                                    else
                                    {
                                        File.Move(download_files, ImageDestination);
                                        Console.WriteLine(Path.GetFileName(download_files) + " has been moved to " + ImageDestinationFolder);
                                    }
                                }
                                else if (extension == ".docx" || extension == ".pdf" || extension == ".xlsx" || extension == ".pptx" || extension == ".txt" || extension == ".html" || extension == ".md" || extension == ".csv" || extension == ".pages")
                                {
                                    if (File.Exists(DocumentDestination))
                                    {
                                        error();
                                    }
                                    else
                                    {
                                        File.Move(download_files, DocumentDestination);
                                        Console.WriteLine(Path.GetFileName(download_files) + " has been moved to " +  DocumentDestinationFolder);
                                    }
                                }
                                else if (extension == ".mp4" || extension == ".mov" || extension == ".avi" || extension == ".mkv")
                                {
                                    if (File.Exists(VideoDestination))
                                    {
                                        error();
                                    }
                                    else
                                    {
                                        File.Move(download_files, VideoDestination);
                                        Console.WriteLine(Path.GetFileName(download_files) + " has been moved to " + VideosDestinationFolder);
                                    }
                                }
                                else if (extension == ".mp3" || extension == ".wav" || extension == ".aiff" || extension == ".aac")
                                {
                                    if (File.Exists(AudioDestination))
                                    {
                                        error();
                                    }
                                    else
                                    {
                                        File.Move(download_files, AudioDestination);
                                        Console.WriteLine(Path.GetFileName(download_files) + " has been moved to " + AudioDestinationFolder);
                                    }
                                }
                            }
                        }
                    }
                    else if (Folder.ToUpper() == "DESKTOP")
                    {
                        Console.WriteLine("Which file type do you want to organize (Images, Audio, Videos, Documents, All");
                        Console.Write("> ");
                        File_type = Console.ReadLine();
                        if (File_type.ToUpper() == "IMAGES")
                        {
                            foreach(string desktop_files in Desktop)
                            {
                                string ImageDestination = Path.Combine(ImageDestinationFolder, Path.GetFileName(desktop_files));
                                string extension = Path.GetExtension(desktop_files).ToLower();
                                if (extension == ".jpg" || extension == ".png" || extension == ".webp" || extension == ".gif" || extension == ".jpeg")
                                {
                                    if (File.Exists(ImageDestination))
                                    {
                                        error(); ;
                                    }
                                    else
                                    {
                                        File.Move(desktop_files, ImageDestination);
                                        Console.WriteLine(Path.GetFileName(desktop_files) + " has been moved");
                                    }
                                }
                            }
                        }
                        else if (File_type.ToUpper() == "AUDIO")
                        {
                            foreach (string desktop_files in Desktop)
                            {
                                string AudioDestination = Path.Combine(AudioDestinationFolder, Path.GetFileName(desktop_files));
                                string extension = Path.GetExtension(desktop_files).ToLower();
                                if (extension == ".mp3" || extension == ".wav" || extension == ".aiff" || extension == ".aac")
                                {
                                    if (File.Exists(AudioDestination))
                                    {
                                        error();
                                    }
                                    else
                                    {
                                        File.Move(desktop_files, AudioDestination);
                                        Console.WriteLine(Path.GetFileName(desktop_files) + " has been moved");
                                    }
                                }
                            }
                        }
                        else if (File_type.ToUpper() == "VIDEOS")
                        {
                            foreach (string desktop_files in Desktop)
                            {
                                string VideoDestination = Path.Combine(VideosDestinationFolder, Path.GetFileName(desktop_files));
                                string extension = Path.GetExtension(desktop_files).ToLower();
                                if (extension == ".mp4" || extension == ".mov" || extension == ".avi" || extension == ".mkv")
                                {
                                    if (File.Exists(VideoDestination))
                                    {
                                        error();
                                    }
                                    else
                                    {
                                        File.Move(desktop_files, VideoDestination);
                                        Console.WriteLine(Path.GetFileName(desktop_files) + " has been moved");
                                    }
                                }
                            }
                        }
                        else if (File_type.ToUpper() == "DOCUMENTS")
                        {
                            foreach (string desktop_files in Desktop)
                            {
                                string DocumentDestination = Path.Combine(DocumentDestinationFolder, Path.GetFileName(desktop_files));
                                string extension = Path.GetExtension(desktop_files).ToLower();
                                if (extension == ".docx" || extension == ".pdf" || extension == ".xlsx" || extension == ".pptx" || extension == ".txt" || extension == ".html" || extension == ".md" || extension == ".csv" || extension == ".pages")
                                {
                                    if (File.Exists(DocumentDestination))
                                    {
                                        error();
                                    }
                                    else
                                    {
                                        File.Move(desktop_files, DocumentDestination);
                                        Console.WriteLine(Path.GetFileName(desktop_files) + " has been moved");
                                    }
                                }
                            }
                        }
                        else if (File_type.ToUpper() == "ALL")
                        {
                            foreach (string desktop_files in Desktop)
                            {
                                string DocumentDestination = Path.Combine(DocumentDestinationFolder, Path.GetFileName(desktop_files));
                                string VideoDestination = Path.Combine(VideosDestinationFolder, Path.GetFileName(desktop_files));
                                string AudioDestination = Path.Combine(AudioDestinationFolder, Path.GetFileName(desktop_files));
                                string ImageDestination = Path.Combine(ImageDestinationFolder, Path.GetFileName(desktop_files));
                                string extension = Path.GetExtension(desktop_files).ToLower();
                                if (extension == ".jpg" || extension == ".png" || extension == ".webp" || extension == ".gif" || extension == ".jpeg")
                                {
                                    if (File.Exists(ImageDestination))
                                    {
                                        error();
                                    }
                                    else
                                    {
                                        File.Move(desktop_files, ImageDestination);
                                        Console.WriteLine(Path.GetFileName(desktop_files) + " has been moved to " + ImageDestinationFolder);
                                    }
                                }
                                else if (extension == ".docx" || extension == ".pdf" || extension == ".xlsx" || extension == ".pptx" || extension == ".txt" || extension == ".html" || extension == ".md" || extension == ".csv" || extension == ".pages")
                                {
                                    if (File.Exists(DocumentDestination))
                                    {
                                        error();
                                    }
                                    else
                                    {
                                        File.Move(desktop_files, DocumentDestination);
                                        Console.WriteLine(Path.GetFileName(desktop_files) + " has been moved to " + DocumentDestinationFolder);
                                    }
                                }
                                else if (extension == ".mp4" || extension == ".mov" || extension == ".avi" || extension == ".mkv")
                                {
                                    if (File.Exists(VideoDestination))
                                    {
                                        error();
                                    }
                                    else
                                    {
                                        File.Move(desktop_files, VideoDestination);
                                        Console.WriteLine(Path.GetFileName(desktop_files) + " has been moved to " + VideosDestinationFolder);
                                    }
                                }
                                else if (extension == ".mp3" || extension == ".wav" || extension == ".aiff" || extension == ".aac")
                                {
                                    if (File.Exists(AudioDestination))
                                    {
                                        error();
                                    }
                                    else
                                    {
                                        File.Move(desktop_files, AudioDestination);
                                        Console.WriteLine(Path.GetFileName(desktop_files) + " has been moved to " + AudioDestinationFolder);
                                    }
                                }
                            }
                        }
                    }
                    else if(Folder.ToUpper() == "ALL")
                    {
                        foreach (string desktop_files in Desktop)
                        {
                            string DocumentDestination = Path.Combine(DocumentDestinationFolder, Path.GetFileName(desktop_files));
                            string VideoDestination = Path.Combine(VideosDestinationFolder, Path.GetFileName(desktop_files));
                            string AudioDestination = Path.Combine(AudioDestinationFolder, Path.GetFileName(desktop_files));
                            string ImageDestination = Path.Combine(ImageDestinationFolder, Path.GetFileName(desktop_files));
                            string extension = Path.GetExtension(desktop_files).ToLower();
                            if (extension == ".jpg" || extension == ".png" || extension == ".webp" || extension == ".gif" || extension == ".jpeg")
                            {
                                if (File.Exists(ImageDestination))
                                {
                                    error();
                                }
                                else
                                {
                                    File.Move(desktop_files, ImageDestination);
                                    Console.WriteLine(Path.GetFileName(desktop_files) + " has been moved to " + ImageDestinationFolder);
                                }
                            }
                            else if (extension == ".docx" || extension == ".pdf" || extension == ".xlsx" || extension == ".pptx" || extension == ".txt" || extension == ".html" || extension == ".md" || extension == ".csv" || extension == ".pages")
                            {
                                if (File.Exists(DocumentDestination))
                                {
                                    error();
                                }
                                else
                                {
                                    File.Move(desktop_files, DocumentDestination);
                                    Console.WriteLine(Path.GetFileName(desktop_files) + " has been moved to " + DocumentDestinationFolder);
                                }
                            }
                            else if (extension == ".mp4" || extension == ".mov" || extension == ".avi" || extension == ".mkv")
                            {
                                if (File.Exists(VideoDestination))
                                {
                                    error();
                                }
                                else
                                {
                                    File.Move(desktop_files, VideoDestination);
                                    Console.WriteLine(Path.GetFileName(desktop_files) + " has been moved to " + VideosDestinationFolder);
                                }
                            }
                            else if (extension == ".mp3" || extension == ".wav" || extension == ".aiff" || extension == ".aac")
                            {
                                if (File.Exists(AudioDestination))
                                {
                                    error();
                                }
                                else
                                {
                                    File.Move(desktop_files, AudioDestination);
                                    Console.WriteLine(Path.GetFileName(desktop_files) + " has been moved to " + AudioDestinationFolder);
                                }
                            }
                        }
                        foreach (string download_files in Downloads)
                        {
                            string DocumentDestination = Path.Combine(DocumentDestinationFolder, Path.GetFileName(download_files));
                            string VideoDestination = Path.Combine(VideosDestinationFolder, Path.GetFileName(download_files));
                            string AudioDestination = Path.Combine(AudioDestinationFolder, Path.GetFileName(download_files));
                            string ImageDestination = Path.Combine(ImageDestinationFolder, Path.GetFileName(download_files));
                            string extension = Path.GetExtension(download_files).ToLower();
                            if (extension == ".jpg" || extension == ".png" || extension == ".webp" || extension == ".gif" || extension == ".jpeg")
                            {
                                if (File.Exists(ImageDestination))
                                {
                                    error();
                                }
                                else
                                {
                                    File.Move(download_files, ImageDestination);
                                    Console.WriteLine(Path.GetFileName(download_files) + " has been moved to " + ImageDestinationFolder);
                                }
                            }
                            else if (extension == ".docx" || extension == ".pdf" || extension == ".xlsx" || extension == ".pptx" || extension == ".txt" || extension == ".html" || extension == ".md" || extension == ".csv" || extension == ".pages")
                            {
                                if (File.Exists(DocumentDestination))
                                {
                                    error();
                                }
                                else
                                {
                                    File.Move(download_files, DocumentDestination);
                                    Console.WriteLine(Path.GetFileName(download_files) + " has been moved to " + DocumentDestinationFolder);
                                }
                            }
                            else if (extension == ".mp4" || extension == ".mov" || extension == ".avi" || extension == ".mkv")
                            {
                                if (File.Exists(VideoDestination))
                                {
                                    error();
                                }
                                else
                                {
                                    File.Move(download_files, VideoDestination);
                                    Console.WriteLine(Path.GetFileName(download_files) + " has been moved to " + VideosDestinationFolder);
                                }
                            }
                            else if (extension == ".mp3" || extension == ".wav" || extension == ".aiff" || extension == ".aac")
                            {
                                if (File.Exists(AudioDestination))
                                {
                                    error();
                                }
                                else
                                {
                                    File.Move(download_files, AudioDestination);
                                    Console.WriteLine(Path.GetFileName(download_files) + " has been moved to " + AudioDestinationFolder);
                                }
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine(" Invalid selection");
                    }
                }
                else
                {
                    Console.WriteLine(" Exiting program...");
                    Selection = false;
                }
            }
        }
        static void error()
        {
            Console.WriteLine("File already exists please rename it manuanlly if its a mistake");
        }
    }
}
