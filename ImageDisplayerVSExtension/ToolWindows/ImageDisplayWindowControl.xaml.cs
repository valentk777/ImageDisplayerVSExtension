using System;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using WpfAnimatedGif;

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
            OpenFileDialog fileDialog = new OpenFileDialog
            {
                DefaultExt = ".png",
                Filter = "All supported graphics|*.jpg;*.jpeg;*.png;*.gif|Animations (*.gif)|*.gif"
            };

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                SetImage(fileDialog);
                // TODO: store somewhere elso to keep image for later.
            }
        }

        private void SetImage(OpenFileDialog fileDialog)
        {
            fullPath = fileDialog.FileName;
            var image = new BitmapImage(new Uri(fileDialog.FileName));

            if (fileDialog.FileName.EndsWith(".gif"))
            {
                imageToDisplay.Source = null;
                ImageBehavior.SetAnimatedSource(imageToDisplay, image);
            }
            else
            {
                imageToDisplay.Source = image;
            }
        }
    }
}