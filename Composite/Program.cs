using System;
using System.Collections.Generic;

namespace Composite
{

    // Component
    interface SystemItem
    {
        string Name { get; set; }
        string Path { get; set; }
        float Size { get; }
    }



    // Leaf
    class File : SystemItem
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public float Size { get; }

        public File(string name, string path, float size)
        {
            Name = name;
            Path = path;
            Size = size;
        }
    }



    // Composite
    class Folder : SystemItem 
    {
        public List<SystemItem> Children { get; set; } = new List<SystemItem>();
        public string Name { get; set; }
        public string Path { get; set; }
        
        public float Size
        {
            get
            {
                float size = 0;
                Children.ForEach(s => size += s.Size);
                return size;
            }
        }

        public void Add(SystemItem si)
        {
            Children.Add(si);
        }

        public void Remove(SystemItem si)
        {
            Children.Remove(si);
        }
    }



    // Client
    class Program
    {
        static void Main(string[] args)
        {
            Folder folderC = new Folder { Name = "C", Path = @"C:\" };
            Folder folderUsers = new Folder { Name = "Users", Path = @"C:\Users" };
            Folder folderProgramFiles = new Folder { Name = "Program Files", Path = @"C:\Program Files" };



            folderUsers.Children.Add(new File("file1", "path1", 1.5f));

            folderProgramFiles.Children.Add(new File("file2", "path2", 3.5f));
            folderProgramFiles.Children.Add(new File("file3", "path3", 1.2f));

            folderC.Add(folderUsers);
            folderC.Add(folderProgramFiles);

            Console.WriteLine(folderC.Size);

        }
    }
}
