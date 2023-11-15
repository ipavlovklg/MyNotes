using System.Windows;
using System.Windows.Controls;

namespace Ivi.UI {
    public class ControlBoxButton : Button {
        static ControlBoxButton() {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ControlBoxButton), new FrameworkPropertyMetadata(typeof(ControlBoxButton)));
        }
    }
}
