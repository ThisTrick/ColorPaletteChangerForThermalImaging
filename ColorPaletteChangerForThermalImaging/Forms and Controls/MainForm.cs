using ColorPaletteChangerForThermalImaging.Logic;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ColorPaletteChangerForThermalImaging
{
    public partial class MainForm : Form
    {
        #region Премещение формы
        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        extern static void ReleaseCapture();
        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        #endregion

        Bitmap LoadedImg;
        public MainForm()
        {
            InitializeComponent();
        }

        private void TestColorPaletteCreator()
        {
            ColorPaletteCreator creator = new ColorPaletteCreator();
            var colorPalette = creator.CreateAndSave("TestImage\\test.png", Color.White, Color.Black);
            pbColorPalette.Image = colorPalette;
            ColorPaletteEditor editor = new ColorPaletteEditor();
            var img = new Bitmap("testImage\\testImg1.png");
            pbImage.Image = editor.Edit(img, colorPalette);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadedImg = ImageLoad(pbImage);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ImageSave(pbImage);
        }

        private void pbColorPalette_Click(object sender, EventArgs e)
        {
            using (SelectingColorPalette selectingColor = new SelectingColorPalette())
            {
                var dialogResult = selectingColor.ShowDialog();
                if (dialogResult == DialogResult.OK)
                {
                    var bitmapColorPalette = selectingColor.Tag as Bitmap;
                    pbColorPalette.Image = bitmapColorPalette ?? pbColorPalette.Image;
                }

            }
        }


        Bitmap ImageLoad(PictureBox pictureBox)
        {
            //создание диалогового окна "Открыть изображение", для сохранения изображения
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Title = "Открыть изображение";
            //отображать ли предупреждение, если пользователь указывает несуществующее название файла
            openDialog.CheckFileExists = true;
            //отображать ли предупреждение, если пользователь указывает несуществующий путь
            openDialog.CheckPathExists = true;
            //отображается ли кнопка "Справка" в диалоговом окне
            openDialog.ShowHelp = true;
            //список форматов файла, отображаемый в поле "Тип файла"
            openDialog.Filter = "Image Files(*.JPG)|*.JPG|Image Files(*.PNG)|*.PNG|Image Files(*.BMP)|*.BMP|Image Files(*.GIF)|*.GIF|All files (*.*)|*.*";
            if (openDialog.ShowDialog() == DialogResult.OK) //если в диалоговом окне нажата кнопка "ОК"
            {
                try
                {
                    //Получаем путь к файлу
                    var path = openDialog.FileName;
                    //Получаем изображение 
                    var image = new Bitmap(path);
                    //Загружаем изображение в PictureBox
                    pictureBox.Image = image;
                    return image;
                }
                catch
                {
                    MessageBox.Show("Невозможно открыть изображение", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return null;
        }
        void ImageSave(PictureBox pictureBox)
        {
            if (pictureBox.Image != null) //если в pictureBox есть изображение
            {
                //создание диалогового окна "Сохранить как..", для сохранения изображения
                SaveFileDialog savedialog = new SaveFileDialog();
                savedialog.Title = "Сохранить картинку как...";
                //отображать ли предупреждение, если пользователь указывает имя уже существующего файла
                savedialog.OverwritePrompt = true;
                //отображать ли предупреждение, если пользователь указывает несуществующий путь
                savedialog.CheckPathExists = true;
                //список форматов файла, отображаемый в поле "Тип файла"
                savedialog.Filter = "Image Files(*.JPG)|*.JPG|Image Files(*.PNG)|*.PNG|Image Files(*.BMP)|*.BMP|Image Files(*.GIF)|*.GIF|All files (*.*)|*.*";
                //отображается ли кнопка "Справка" в диалоговом окне
                savedialog.ShowHelp = false;
                if (savedialog.ShowDialog() == DialogResult.OK) //если в диалоговом окне нажата кнопка "ОК"
                {
                    try
                    {
                        pictureBox.Image.Save(savedialog.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
                    catch
                    {
                        MessageBox.Show("Невозможно сохранить изображение", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
