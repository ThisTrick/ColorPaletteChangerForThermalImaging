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

        private Bitmap _colorPalette;
        private Bitmap _loadedImg;
        private Bitmap LoadedImg 
        { 
            get => _loadedImg;
            set 
            {
                if (value == null && value == _loadedImg)
                {
                    return;
                }
                _loadedImg = value;
                pbImage.Image = _loadedImg;
            }
        }
        private Bitmap ColorPalette 
        {
            get => _colorPalette;
            set
            {
                if (value == null && value == _colorPalette)
                {
                    return;
                }
                _colorPalette = value;
                pbColorPalette.Image = _colorPalette;
            }
        }
        private ColorPaletteEditor Editor;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Editor = new ColorPaletteEditor();
            ColorPalette = Properties.Resources.White_Hot;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadedImg = ImageLoad(pbImage);
            if (LoadedImg != null && ColorPalette != null)
            {
                var img = Editor.Edit(LoadedImg, ColorPalette);
                pbImage.Image = img;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (pbImage.Image == null)
            {
                return;
            }
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
                    if (bitmapColorPalette == ColorPalette)
                    {
                        return;
                    }
                    if (bitmapColorPalette != null)
                    {
                        ColorPalette = bitmapColorPalette;
                        if (LoadedImg != null)
                        {
                            pbImage.Image = Editor.Edit(LoadedImg, ColorPalette);
                        }
                    }
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
