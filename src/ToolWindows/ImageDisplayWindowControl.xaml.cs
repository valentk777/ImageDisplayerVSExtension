using System;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Media.Imaging;
using WpfAnimatedGif;

namespace ImageDisplayer.ToolWindows
{
    public partial class ImageDisplayWindowControl : System.Windows.Controls.UserControl
    {
        private string fullPath = "press-here.jpg";

        public ImageDisplayWindowControl()
        {
            InitializeComponent();
        }

        private void button1_UploadImage(object sender, RoutedEventArgs e)
        {
            SetFilePathOnUploadImage();
            UpdateUIImage();
            SaveProvidedImage();
        }

        private void SetFilePathOnUploadImage()
        {
            var fileDialog = new OpenFileDialog
            {
                DefaultExt = ".jpg",
                Filter = "All supported graphics|*.jpg;*.jpeg;*.png;*.gif|Animations (*.gif)|*.gif"
            };

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                fullPath = fileDialog.FileName;
            }
        }

        private void UpdateUIImage()
        {
            var image = new BitmapImage(new Uri(fullPath));

            if (fullPath.EndsWith(".gif"))
            {
                imageToDisplay.Source = null;
                ImageBehavior.SetAnimatedSource(imageToDisplay, image);
            }
            else
            {
                imageToDisplay.Source = image;
            }
        }

        private void SaveProvidedImage()
        {

        }
    }
}