using System;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ImageDisplayerVSExtension.ToolWindows
{
    /// <summary>
    /// Interaction logic for ImageDisplayWindowControl.
    /// </summary>
    public partial class ImageDisplayWindowControl : System.Windows.Controls.UserControl
    {
        private string fullPath;

        /// <summary>
        /// Initializes a new instance of the <see cref="ImageDisplayWindowControl"/> class.
        /// </summary>
        public ImageDisplayWindowControl()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Handles click on the image upload button to store uploaded image.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event args.</param>
        private void button1_UploadImage(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.DefaultExt = ".png";
            //fileDialog.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|Portable Network Graphic (*.png)|*.png";
            //fileDialog.Filter = "Images (.png)|*.png"; // Optional file extensions

            if (fileDialog.ShowDialog() != DialogResult.OK)
            {
                System.Windows.MessageBox.Show("Image is not uploaded. Try another one", "ImageDisplayWindow");
                return;
            }

            SetImage(fileDialog);
        }

        private void SetImage(OpenFileDialog fileDialog)
        {
            // TODO: store somewhere elso to keep image for later.

            imageToDisplay.Source = new BitmapImage(new Uri(fileDialog.FileName));
            fullPath = fileDialog.FileName;
        }
    }
}