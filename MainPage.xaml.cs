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
            /* 
            REQUIRMENTS:
            Latest release for Desktop: Windows 10 April 2018 Update (10.0.17134.1)
            Latest release for HoloLens: Windows 10 April 2018 Update (10.0.17134.80)
            Usage: https://learn.microsoft.com/en-us/windows/mixed-reality/distribute/enable-placement-of-3d-models-in-the-home
            */
            // Define the add model URI (LOCAL WAY)
            var uriAddModel = new Uri(@"ms-mixedreality:addModel?uri="+pathFile);
            // WEB WAY
            //< a class="btn btn-default" href="ms-mixedreality:addModel?uri=sample.glb"> Place 3D Model</a>

            // Launch the URI to invoke the placement
            var success = await Windows.System.Launcher.LaunchUriAsync(uriAddModel);

            if (success)
            {
                FileName.Text += "<br> Succesfuly added your model to WMR Home";
            }
            else
            {
                // if get the error or empty holBox, check the requrments
                // https://learn.microsoft.com/en-us/windows/mixed-reality/distribute/creating-3d-models-for-use-in-the-windows-mixed-reality-home
                FileName.Text += "<br> Model load filed... Please check the requrments and opimize it via WMR_Converter";
            }
        }


        private async void launchURI_Click(object sender, RoutedEventArgs e)
        {
            // Normal file picker.
            // Will work in Windows Holographic, and normal WMR envoirments.
            // May carash the app in last version of Windows 11 23H2 with WMR Home
            // https://learn.microsoft.com/en-us/uwp/api/windows.storage.pickers.fileopenpicker?view=winrt-26100
            FileOpenPicker openPicker = new FileOpenPicker();
            openPicker.ViewMode = PickerViewMode.Thumbnail;
            openPicker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
            openPicker.FileTypeFilter.Add(".glb");
            //openPicker.FileTypeFilter.Add(".jpeg");
            //openPicker.FileTypeFilter.Add(".png");

            StorageFile file = await openPicker.PickSingleFileAsync();
            if (file != null)
            {
                // Application now has read/write access to the picked file
                FileName.Text = "Picked photo: " + file.Name;
                loadMyModelAsHolo(file.Path);
            }
            else
            {
                FileName.Text = "Operation cancelled.";
            }

            
        }

    }
}
