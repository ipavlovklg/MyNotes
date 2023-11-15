using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Shell;

namespace Ivi.UI {
    public partial class StickyWindow : Window {
        static StickyWindow() {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(StickyWindow),
                         new FrameworkPropertyMetadata(typeof(StickyWindow)));
        }
        public StickyWindow() {
            WindowStyle = WindowStyle.ToolWindow;
            SetCustomWindowStyle();
        }
        protected override void OnInitialized(EventArgs e) {
            base.OnInitialized(e);
        }
        public bool AllowMove {
            get { return (bool)GetValue(AllowMoveProperty); }
            set { SetValue(AllowMoveProperty, value); }
        }
        public static readonly DependencyProperty AllowMoveProperty =
            DependencyProperty.Register("AllowMove", typeof(bool), typeof(StickyWindow), new PropertyMetadata(true));
        public bool AllowResize {
            get { return (bool)GetValue(AllowResizeProperty); }
            set { SetValue(AllowResizeProperty, value); }
        }
        public static readonly DependencyProperty AllowResizeProperty =
            DependencyProperty.Register("AllowResize", typeof(bool), typeof(StickyWindow), new PropertyMetadata(true));

        void SetCustomWindowStyle() {
            var chrome = new WindowChrome() {
                UseAeroCaptionButtons = false,
                NonClientFrameEdges = NonClientFrameEdges.None,
                CornerRadius = new CornerRadius(0),
                GlassFrameThickness = WindowChrome.GlassFrameCompleteThickness,
                ResizeBorderThickness = new Thickness(4),
                CaptionHeight = 0
            };
            WindowChrome.SetWindowChrome(this, chrome);
            // remove artefacts that occur on resising.
            var hWndHelper = new WindowInteropHelper(this);
            hWndHelper.EnsureHandle();
            var prevLong = SysUtils.GetWindowLong(hWndHelper.Handle, (int)WS2.GWL_STYLE);
            var newLong = (WS)prevLong.ToInt32();
            newLong = newLong ^ WS.WS_SYSMENU ^ WS.WS_MAXIMIZEBOX ^ WS.WS_MINIMIZEBOX ^ WS.WS_SIZEFRAME;
            SysUtils.SetWindowLong(hWndHelper.Handle, (int)WS2.GWL_STYLE, (int)newLong);
        }
    }
    [Flags]
    enum WS : uint {
        WS_BORDER = 0x800000,
        WS_CAPTION = 0xc00000,
        WS_CHILD = 0x40000000,
        WS_CLIPCHILDREN = 0x2000000,
        WS_CLIPSIBLINGS = 0x4000000,
        WS_DISABLED = 0x8000000,
        WS_DLGFRAME = 0x400000,
        WS_GROUP = 0x20000,
        WS_HSCROLL = 0x100000,
        WS_MAXIMIZE = 0x1000000,
        WS_MAXIMIZEBOX = 0x10000,
        WS_MINIMIZE = 0x20000000,
        WS_MINIMIZEBOX = 0x20000,
        WS_OVERLAPPED = 0x0,
        WS_OVERLAPPEDWINDOW = WS_OVERLAPPED | WS_CAPTION | WS_SYSMENU | WS_SIZEFRAME | WS_MINIMIZEBOX | WS_MAXIMIZEBOX,
        WS_POPUP = 0x80000000,
        WS_POPUPWINDOW = WS_POPUP | WS_BORDER | WS_SYSMENU,
        WS_SIZEFRAME = 0x40000,
        WS_SYSMENU = 0x80000,
        WS_TABSTOP = 0x10000,
        WS_VISIBLE = 0x10000000,
        WS_VSCROLL = 0x200000
    }
    enum WS2 : int {
        GWL_EXSTYLE = -20,
        GWLP_HINSTANCE = -6,
        GWLP_HWNDPARENT = -8,
        GWL_ID = -12,
        GWL_STYLE = -16,
        GWL_USERDATA = -21,
        GWL_WNDPROC = -4,
        DWLP_USER = 0x8,
        DWLP_MSGRESULT = 0x0,
        DWLP_DLGPROC = 0x4
    }
    public static class SysUtils {
        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr GetWindowLong(IntPtr window, int index);
        [DllImport("user32.dll")]
        public static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);
    }
}
