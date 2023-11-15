using Ivi.UI;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows;

namespace MyNotesApp {
    public partial class MyNotesWindow : StickyWindow {

        const string notesFolder = "Notes";

        public MyNotesWindow() {
            InitializeComponent();

            Directory.CreateDirectory(notesFolder);

            File.CreateText(Path.Combine(notesFolder, "to do.txt")).Close();
            File.CreateText(Path.Combine(notesFolder, "to see.txt")).Close();
            File.CreateText(Path.Combine(notesFolder, "to buy.txt")).Close();
            File.CreateText(Path.Combine(notesFolder, "to learn.txt")).Close();
            File.CreateText(Path.Combine(notesFolder, "my paylog.txt")).Close();
            File.CreateText(Path.Combine(notesFolder, "personal.txt")).Close();

            DataContext = new { Notes = GetFiles() };
        }

        NoteFileInfo[] GetFiles()
        {
            var directoryFiles = Directory.GetFiles(notesFolder, "*.txt", SearchOption.TopDirectoryOnly);
            return directoryFiles
                .Where(file => !Path.GetFileName(file).StartsWith("_"))
                .Select(file => new NoteFileInfo()
                {
                    Title = Path.GetFileNameWithoutExtension(file),
                    Path = file
                })
                .ToArray();
        }

        private void OnNoteTileClick(object sender, RoutedEventArgs e) {
            NoteFileInfo note = (NoteFileInfo)((FrameworkElement)sender).DataContext;
            Process.Start(note.Path);
        }
    }

    internal class NoteFileInfo {
        public string Path { get; internal set; }
        public string Title { get; internal set; }
    }
}
