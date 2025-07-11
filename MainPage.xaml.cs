using SharpGLTF.Schema2;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Foundation.Numerics;
using Windows.Graphics.Imaging;
using Windows.Perception.Spatial;
using Windows.Storage;
//using Windows.Perception.Spatial.Persistence;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Composition;
using Windows.UI.StartScreen;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace glTF_3DLoad_N
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        SpatialAnchorStore anchorStore;

        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void loadMyModelAsHolo(string pathFile)
        {

        }

        
        private void launchURI_Click(object sender, RoutedEventArgs e)
        {
            loadMyModelAsHolo("");
        }

    }
}
