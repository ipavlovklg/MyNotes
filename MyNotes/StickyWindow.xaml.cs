using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;

namespace WpfApp1 {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    //public partial class StickyWindow : Window {
    //    public StickyWindow() {
    //        InitializeComponent();
    //        SetCustomWindowStyle();
    //    }
    //    public bool AllowMove {
    //        get { return (bool)GetValue(AllowMoveProperty); }
    //        set { SetValue(AllowMoveProperty, value); }
    //    }
    //    // Using a DependencyProperty as the backing store for AllowMove.  This enables animation, styling, binding, etc...
    //    public static readonly DependencyProperty AllowMoveProperty =
    //        DependencyProperty.Register("AllowMove", typeof(bool), typeof(StickyWindow));

    //    void SetCustomWindowStyle() {
    //        ShowInTaskbar = false;
    //        WindowStyle = WindowStyle.None;
    //        var chrome = new WindowChrome() {
    //            UseAeroCaptionButtons = false,
    //            NonClientFrameEdges = NonClientFrameEdges.None,
    //            CornerRadius = new CornerRadius(0),
    //            GlassFrameThickness = WindowChrome.GlassFrameCompleteThickness,
    //            ResizeBorderThickness = new Thickness(0, 0, 4, 4),
    //            CaptionHeight = 0
    //        };            
    //        WindowChrome.SetWindowChrome(this, chrome);
    //        // remove artefacts that occur on resising.
    //        var hWndHelper = new WindowInteropHelper(this);
    //        hWndHelper.EnsureHandle();
    //        var prevLong = SysUtils.GetWindowLong(hWndHelper.Handle, (int)WS2.GWL_STYLE);
    //        var newLong = (WS)prevLong.ToInt32();
    //        newLong = newLong ^ WS.WS_SYSMENU ^ WS.WS_MAXIMIZEBOX ^ WS.WS_MINIMIZEBOX ^ WS.WS_SIZEFRAME;
    //        SysUtils.SetWindowLong(hWndHelper.Handle, (int)WS2.GWL_STYLE, (int)newLong);
    //    }
    //    protected override void OnPreviewMouseLeftButtonDown(MouseButtonEventArgs e) {
    //        if(AllowMove) {
    //            DragMove();
    //        }
    //        base.OnPreviewMouseLeftButtonDown(e);
    //    }
    //}
    //[Flags]
    //enum WS : uint {
    //    WS_BORDER = 0x800000,
    //    WS_CAPTION = 0xc00000,
    //    WS_CHILD = 0x40000000,
    //    WS_CLIPCHILDREN = 0x2000000,
    //    WS_CLIPSIBLINGS = 0x4000000,
    //    WS_DISABLED = 0x8000000,
    //    WS_DLGFRAME = 0x400000,
    //    WS_GROUP = 0x20000,
    //    WS_HSCROLL = 0x100000,
    //    WS_MAXIMIZE = 0x1000000,
    //    WS_MAXIMIZEBOX = 0x10000,
    //    WS_MINIMIZE = 0x20000000,
    //    WS_MINIMIZEBOX = 0x20000,
    //    WS_OVERLAPPED = 0x0,
    //    WS_OVERLAPPEDWINDOW = WS_OVERLAPPED | WS_CAPTION | WS_SYSMENU | WS_SIZEFRAME | WS_MINIMIZEBOX | WS_MAXIMIZEBOX,
    //    WS_POPUP = 0x80000000,
    //    WS_POPUPWINDOW = WS_POPUP | WS_BORDER | WS_SYSMENU,
    //    WS_SIZEFRAME = 0x40000,
    //    WS_SYSMENU = 0x80000,
    //    WS_TABSTOP = 0x10000,
    //    WS_VISIBLE = 0x10000000,
    //    WS_VSCROLL = 0x200000
    //}
    //enum WS2 : int {
    //    GWL_EXSTYLE = -20,
    //    GWLP_HINSTANCE = -6,
    //    GWLP_HWNDPARENT = -8,
    //    GWL_ID = -12,
    //    GWL_STYLE = -16,
    //    GWL_USERDATA = -21,
    //    GWL_WNDPROC = -4,
    //    DWLP_USER = 0x8,
    //    DWLP_MSGRESULT = 0x0,
    //    DWLP_DLGPROC = 0x4
    //}
    //public static class SysUtils {
    //    [DllImport("user32.dll", SetLastError = true)]
    //    public static extern IntPtr GetWindowLong(IntPtr window, int index);
    //    [DllImport("user32.dll")]
    //    public static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);
        
    //}
}
