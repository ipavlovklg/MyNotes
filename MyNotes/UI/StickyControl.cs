using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Ivi.UI
{
    public class StickyControl : ContentControl {
        static StickyControl() {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(StickyControl),
                         new FrameworkPropertyMetadata(typeof(StickyControl)));
        }
        protected override void OnPreviewMouseLeftButtonDown(MouseButtonEventArgs e) {
            var mousePos = Mouse.GetPosition(this);
            if (AllowMove && !HitTestHelper.IsMatch(this, mousePos, HitTestType.Ignore) && HitTestHelper.IsMatch(this, mousePos, HitTestType.Header)) {
                Window.GetWindow(this)?.DragMove();
            }
            base.OnPreviewMouseLeftButtonDown(e);
        }
        public override void OnApplyTemplate() {
            base.OnApplyTemplate();
            Button closeButton = (Button)GetTemplateChild("PART_Close");
            closeButton.Command = new DelegateCommand(() => Window.GetWindow(this)?.Close());
        }
        public string Title {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }
        public Style TitleStyle {
            get { return (Style)GetValue(TitleStyleProperty); }
            set { SetValue(TitleStyleProperty, value); }
        }
        public Brush HeaderBackground {
            get { return (Brush)GetValue(HeaderBackgroundProperty); }
            set { SetValue(HeaderBackgroundProperty, value); }
        }
        public GridLength HeaderHeight {
            get { return (GridLength)GetValue(HeaderHeightProperty); }
            set { SetValue(HeaderHeightProperty, value); }
        }
        public GridLength HeaderWidth {
            get { return (GridLength)GetValue(HeaderWidthProperty); }
            set { SetValue(HeaderWidthProperty, value); }
        }
        public GridLength ResizeFrameWidth {
            get { return (GridLength)GetValue(ResizeFrameWidthProperty); }
            set { SetValue(ResizeFrameWidthProperty, value); }
        }
        public bool AllowResize {
            get { return (bool)GetValue(AllowResizeProperty); }
            set { SetValue(AllowResizeProperty, value); }
        }
        public bool AllowMove {
            get { return (bool)GetValue(AllowMoveProperty); }
            set { SetValue(AllowMoveProperty, value); }
        }
        public static readonly DependencyProperty ResizeFrameWidthProperty =
            DependencyProperty.Register("ResizeFrameWidth", typeof(GridLength), typeof(StickyControl));
        public static readonly DependencyProperty HeaderBackgroundProperty =
            DependencyProperty.Register("HeaderBackground", typeof(Brush), typeof(StickyControl));
        public static readonly DependencyProperty HeaderWidthProperty =
            DependencyProperty.Register("HeaderWidth", typeof(GridLength), typeof(StickyControl));
        public static readonly DependencyProperty HeaderHeightProperty =
            DependencyProperty.Register("HeaderHeight", typeof(GridLength), typeof(StickyControl));
        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(string), typeof(StickyControl));
        public static readonly DependencyProperty TitleStyleProperty =
            DependencyProperty.Register("TitleStyle", typeof(Style), typeof(StickyControl));
        public static readonly DependencyProperty AllowResizeProperty =
            DependencyProperty.Register("AllowResize", typeof(bool), typeof(StickyControl));
        public static readonly DependencyProperty AllowMoveProperty =
            DependencyProperty.Register("AllowMove", typeof(bool), typeof(StickyControl));
    }
    public enum HitTestType {
        Content,
        Ignore,
        Header,
        ResizeFrame,
    }
    public class HitTestHelper {
        public static HitTestType GetType(DependencyObject obj) {
            return (HitTestType)obj.GetValue(TypeProperty);
        }
        public static void SetType(DependencyObject obj, HitTestType value) {
            obj.SetValue(TypeProperty, value);
        }
        public static readonly DependencyProperty TypeProperty =
            DependencyProperty.RegisterAttached("Type", typeof(HitTestType), typeof(HitTestHelper), new FrameworkPropertyMetadata(HitTestType.Content, FrameworkPropertyMetadataOptions.Inherits));
        public static bool IsMatch(Visual root, Point mousePos, HitTestType matchType) {
            bool isMatch = false;
            HitTestResultCallback callBack =
                (hitResult) => {
                    isMatch = GetType(hitResult.VisualHit) == matchType;
                    return isMatch ? HitTestResultBehavior.Stop : HitTestResultBehavior.Continue;
                };
            VisualTreeHelper.HitTest(root, null, callBack, new PointHitTestParameters(mousePos));
            return isMatch;
        }
    }
}
