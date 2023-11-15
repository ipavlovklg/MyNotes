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
