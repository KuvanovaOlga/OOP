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
using Microsoft.Win32;
using System.IO;

namespace LabC_4_5
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //переменные
        private static int _counter = 1; // номер файла
        private int _lettersCount = 0; // количество букв
        private int _wordsCount = 0; // количество слов
        private static int _boldCounter = 1;
        private static int _italicCounter = 1;
        private static int _underLineCounter = 1;

        #region Обработчики событий главного меню
        private void ItmMenuNew_Click(object sender, RoutedEventArgs e)
        {
            rtbEditor.Document.Blocks.Clear();
            rtbEditor.TabIndex = 1;
            if (_counter == 0)
                Title = "New document";
            if (_counter >= 1)
                Title = "New document " + _counter.ToString();
            _counter++;
    }

        private void ItmMenuOpen_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Rich Text Format (*.rtf)|*.rtf|All files (*.*)|*.*";
            if (dlg.ShowDialog() == true)
            {
                FileStream fileStream = new FileStream(dlg.FileName, FileMode.Open);
                TextRange range = new TextRange(rtbEditor.Document.ContentStart, rtbEditor.Document.ContentEnd);
                range.Load(fileStream, DataFormats.Text);
            }
        }

        private void ItmMenuSaveAs_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Rich Text Format (*.rtf)|*.rtf|All files (*.*)|*.*";
            if (dlg.ShowDialog() == true)
            {
                FileStream fileStream = new FileStream(dlg.FileName, FileMode.Create);
                TextRange range = new TextRange(rtbEditor.Document.ContentStart, rtbEditor.Document.ContentEnd);
                range.Save(fileStream, DataFormats.Text);
            }
        }

        private void ItmMenuExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        #endregion

        #region FontSize
        private void ItmSizeFont_Selected8(object sender, RoutedEventArgs e)
        {
                rtbEditor.FontSize = 8;
        }
        private void ItmSizeFont_Selected10(object sender, RoutedEventArgs e)
        {
            rtbEditor.FontSize = 10;
        }
        private void ItmSizeFont_Selected12(object sender, RoutedEventArgs e)
        {
            rtbEditor.FontSize = 12;
        }
        private void ItmSizeFont_Selected14(object sender, RoutedEventArgs e)
        {
            rtbEditor.FontSize = 14;
        }
        private void ItmSizeFont_Selected16(object sender, RoutedEventArgs e)
        {
            rtbEditor.FontSize = 16;
        }
        private void ItmSizeFont_Selected18(object sender, RoutedEventArgs e)
        {
            rtbEditor.FontSize = 18;
        }
        private void ItmSizeFont_Selected36(object sender, RoutedEventArgs e)
        {
            rtbEditor.FontSize = 36;
        }
        #endregion

        #region FontColor
        private void ItmColorFontRed_Selected(object sender, RoutedEventArgs e)
        {
            if (rtbEditor.Selection.IsEmpty)
                rtbEditor.Document.Foreground = Brushes.Red;
            else
                rtbEditor.Selection.ApplyPropertyValue(ForegroundProperty, Brushes.Red);
        }
        private void ItmColorFontOrange_Selected(object sender, RoutedEventArgs e)
        {
            if (rtbEditor.Selection.IsEmpty)
                rtbEditor.Document.Foreground = Brushes.Orange;
            else
                rtbEditor.Selection.ApplyPropertyValue(ForegroundProperty, Brushes.Orange);
        }
        private void ItmColorFontYellow_Selected(object sender, RoutedEventArgs e)
        {
            if (rtbEditor.Selection.IsEmpty)
                rtbEditor.Document.Foreground = Brushes.Yellow;
            else
                rtbEditor.Selection.ApplyPropertyValue(ForegroundProperty, Brushes.Yellow);
        }
        private void ItmColorFontGreen_Selected(object sender, RoutedEventArgs e)
        {
            if (rtbEditor.Selection.IsEmpty)
                rtbEditor.Document.Foreground = Brushes.Green;
            else
                rtbEditor.Selection.ApplyPropertyValue(ForegroundProperty, Brushes.Green);
        }
        private void ItmColorFontBlue_Selected(object sender, RoutedEventArgs e)
        {
            if (rtbEditor.Selection.IsEmpty)
                rtbEditor.Document.Foreground = Brushes.Blue;
            else
                rtbEditor.Selection.ApplyPropertyValue(ForegroundProperty, Brushes.Blue);
        }
        private void ItmColorFontViolet_Selected(object sender, RoutedEventArgs e)
        {
            if (rtbEditor.Selection.IsEmpty)
                rtbEditor.Document.Foreground = Brushes.Violet;
            else
                rtbEditor.Selection.ApplyPropertyValue(ForegroundProperty, Brushes.Violet);
        }
        private void ItmColorFontBlack_Selected(object sender, RoutedEventArgs e)
        {
            if (rtbEditor.Selection.IsEmpty)
                rtbEditor.Document.Foreground = Brushes.Black;
            else
                rtbEditor.Selection.ApplyPropertyValue(ForegroundProperty, Brushes.Black);
        }
        private void ItmColorFontWhite_Selected(object sender, RoutedEventArgs e)
        {
            if (rtbEditor.Selection.IsEmpty)
                rtbEditor.Document.Foreground = Brushes.White;
            else
                rtbEditor.Selection.ApplyPropertyValue(ForegroundProperty, Brushes.White);
        }
        #endregion

        #region Обработчики B I U
        private void Bold_Click(object sender, RoutedEventArgs e)//обработчик жирный текст
        {
            _boldCounter++;
            if (_boldCounter % 2 == 0)
            {
                rtbEditor.Selection.ApplyPropertyValue(FontWeightProperty, FontWeights.Bold);
            }
            else
            {
                rtbEditor.Selection.ApplyPropertyValue(FontWeightProperty, FontWeights.Normal);
            }
        }
        private void Italic_Click(object sender, RoutedEventArgs e)//обработчик курсив
        {
            _italicCounter++;
            if (_italicCounter % 2 == 0)
            {
                rtbEditor.Selection.ApplyPropertyValue(FontStyleProperty, FontStyles.Italic);
            }
            else
            {
                rtbEditor.Selection.ApplyPropertyValue(FontStyleProperty, FontStyles.Normal);
            }
        }
        private void UnderLine_Click(object sender, RoutedEventArgs e)//обработчик подчеркивание текст
        {
            _underLineCounter++;
            if (_underLineCounter % 2 == 0)
            {
                rtbEditor.Selection.ApplyPropertyValue(Inline.TextDecorationsProperty, TextDecorations.Underline);
            }
            else
            {
                rtbEditor.Selection.ApplyPropertyValue(Inline.TextDecorationsProperty, null);
            }
        }
        #endregion

        #region Cut Copy Paste DelAll
        private void Cut_Click(object sender, RoutedEventArgs e)//вырезать
        {
            rtbEditor.Cut();
        }

        private void Copy_Click(object sender, RoutedEventArgs e)//скопировать
        {
            rtbEditor.Copy();
        }
        private void Paste_Click(object sender, RoutedEventArgs e)//вставить
        {
            rtbEditor.Paste();
        }
        private void DeleteAll_Click(object sender, RoutedEventArgs e)//очистить все
        {
            rtbEditor.Document.Blocks.Clear();
        }
        #endregion

        #region Словари RU & EN
        private void RU_Click(object sender, RoutedEventArgs e)//обработчик ru словаря
        {
            _FileMenu.Header = "Файл";
            _NewProjectMenu.Header = "Новый файл";
            _OpenProjectMenu.Header = "Открыть файл";
            _SaveAsMenu.Header = "Сохранить как";
            _ExitMenu.Header = "Выход";
            _EditMenu.Header = "Редактировать";
            _CopyMenu.Header = "Копировать";
            _CutMenu.Header = "Вырезать";
            _PasteMenu.Header = "Вставить";
            _DeleteAllMenu.Header = "Удалить все";
            _HelpMenu.Header = "Помощь";
            _AboutMenu.Header = "О чем";
            _FontsMenu.Content = "Шрифты";
            _SizeMenu.Content = "Размер";
            _ColorMenu.Content = "Цвет";
        }
        private void EN_Click(object sender, RoutedEventArgs e)//обработчик en словаря
        {
            _FileMenu.Header = "File";
            _NewProjectMenu.Header = "New project";
            _OpenProjectMenu.Header = "Open project";
            _SaveAsMenu.Header = "Save as";
            _ExitMenu.Header = "Exit";
            _EditMenu.Header = "Edit";
            _CopyMenu.Header = "Copy";
            _CutMenu.Header = "Cut";
            _PasteMenu.Header = "Paste";
            _DeleteAllMenu.Header = "Delete all";
            _HelpMenu.Header = "Help";
            _AboutMenu.Header = "About";
            _FontsMenu.Content = "Fonts";
            _SizeMenu.Content = "Size";
            _ColorMenu.Content = "Color";
        }
        #endregion

        private void Text_Checked(object sender, TextChangedEventArgs e)//обработчик подсчета символов в RichTextBox
        {
            var textRange = new TextRange(rtbEditor.Document.ContentStart, rtbEditor.Document.ContentEnd);
            _lettersCount = textRange.Text.Length - 2;
            char[] delimetr = { ' ', '.', ',', '!', '?', '-' };
            string[] substr = textRange.Text.Split(delimetr);
            _wordsCount = substr.Length;
            StatusBarTextBlock.Text = "Всего символов: " + _lettersCount;/* + " Всего слов: " + _wordsCount;*/
        }
        private void About_Click(object sender, RoutedEventArgs e)//обработчик about
        {
            MessageBox.Show("Простой текстовый редактор выполнен студентом 2 курса Вашковом Н.А.");
        }
    }
}