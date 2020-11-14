using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TestEreignisse
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    public MainWindow()
    {
      InitializeComponent();
    }

    private void StartDragDrop(object sender, MouseButtonEventArgs e)
    {
      e.Handled = true;
      Button button = (Button)sender;
      DataObject dto = new DataObject();
      dto.SetData(typeof(Button), button);

      DragDrop.DoDragDrop(button, dto, DragDropEffects.Move);
    }

    private void EndDragDrop(object sender, DragEventArgs e)
    {
      e.Handled = true;
      DockPanel dockPanel = (DockPanel)sender;
      Button button = (Button)e.Data.GetData(typeof(Button));
      button.Height = double.NaN;
      DockPanel oldPanel = (DockPanel)button.Parent;

      oldPanel.Children.Remove(button);
      dockPanel.Children.Add(button);
    }
  }
}
