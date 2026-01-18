using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;

using Blitzkrieg.QuestV4.Lib.Models;

using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;

using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Blitzkrieg.QuestV4.Game.exe
{

    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public const int GRID_SIZE = 50;

        public MainWindow()
        {
            InitializeComponent();
            grdBoard.BorderThickness = new Thickness(1);
            grdBoard.ColumnSpacing = 0;
            grdBoard.RowSpacing = 0;
            grdBoard.HorizontalAlignment = HorizontalAlignment.Left;
            grdBoard.VerticalAlignment = VerticalAlignment.Top;
            grdBoard.Visibility = Visibility.Visible;
            grdBoard.Background = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 200, 200, 200));
            grdBoard.RowDefinitions.Clear();
            grdBoard.ColumnDefinitions.Clear();
            for (int row = 0; row < MapLevel.MapRowsDefault; row++)
            {
                var rd =  new RowDefinition();
                rd.Height = new GridLength(GRID_SIZE, GridUnitType.Pixel);
              
                grdBoard.RowDefinitions.Add(rd);
            }
            for (int col = 0; col < MapLevel.MapColsDefault; col++)
            {
                var cd = new ColumnDefinition();
                cd.Width  = new GridLength(GRID_SIZE, GridUnitType.Pixel);
                grdBoard.ColumnDefinitions.Add(cd);
            }
        }
    }
}
