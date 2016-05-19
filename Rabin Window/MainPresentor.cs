using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using Rabin_Window.BL;
using StartMenu;
using OpenkeyWindow;
using GenerateKeyWindow;
using System.Windows.Forms;

namespace Rabin_Window
{
    class MainPresentor
    {
        private readonly IGenerateKeyWindow _iGenerate;
        private readonly IMainForm _imainForm;
        private readonly IFileManager _manager;
        private readonly IMessageService _messageService;
        private readonly IMenuForm _imenuForm;
        private readonly IOpenKeyForm _iopenkeyForm;

        private string _currentFilePath;

        public MainPresentor(IMainForm imainForm, IFileManager _manager, IMessageService _messageService, IMenuForm imenuForm, IOpenKeyForm iopenkey, IGenerateKeyWindow igkWondow)
        {
            _iGenerate = igkWondow;
            this._imainForm = imainForm;
            this._manager = _manager;
            this._messageService = _messageService;
            this._imenuForm = imenuForm;
            this._iopenkeyForm = iopenkey;

            _imainForm.SetSymbolCount(0);
            _imainForm.SetByteCount(0);

              _imainForm.FileSaveClick += ImainForm_FileSaveClick;
             _imainForm.FileOpenClick += ImainForm_FileOpenClick;
            _imainForm.GoToMenuClick += ImainForm_GoToMenuClick;
            _imainForm.ContentChanged += ImainForm_ContentChanged;
            _imainForm.FileSaveAsClick += _imainForm_FileSaveAsClick;
            _imainForm.SecretKeyClick += _imainForm_SecretKeyClick;
            _imainForm.CloseForm += CloseProg;

            _imenuForm.GoToMainForm += _imenuForm_GoToMainForm;
            _imenuForm.GoToOpenKeyForm += _imenuForm_GoToOpenKeyForm;
            _imenuForm.GoToGenerateKeysWindow += _imenuForm_GoToGenerateKeysWindow;


            _iopenkeyForm.GoToMenuClick += _iopenkeyForm_GoToMenuClick;
            _iopenkeyForm.FileСheckSignature += _iopenkeyForm_FileSaveAsClick;
            _iopenkeyForm.LoadOpneKeyFormFile += _iopenkeyForm_LoadOpneKeyFormFile;
            _iopenkeyForm.Close += CloseProg;

            _iGenerate.PressOk += _iGenerate_PressOk;
            _iGenerate.GoHome += _iGenerate_GoHome;
            _iGenerate.CloseForm += CloseProg;
        }
        private void CloseProg(object sender, EventArgs e)
        {
            _imenuForm.CloseFrom();
        }

        private void _iGenerate_GoHome(object sender, EventArgs e)
        {
            _iGenerate.SkipFrom();
            _imenuForm.ShowForm();
        }

        private void _iopenkeyForm_LoadOpneKeyFormFile(object sender, EventArgs e)
        {
            try
            {
                string readkeys = _manager.GetContent(_iopenkeyForm.pathToOpenKey);
                _iopenkeyForm.OpenKey = BigInteger.Parse(readkeys);
                _messageService.ShowMessage("Ключ успешно загружен");
            }
            catch
            {
                _messageService.ShowError("Неверный формат ключа");
            }

        }

        private void _imainForm_SecretKeyClick(object sender, EventArgs e)
        {
            try
            {
                string readSecKey = _manager.GetContent(_imainForm.SecretkeyPath);
                string readopKey = _manager.GetContent(_imainForm.OpenKeyPath);

                _imainForm.SecretKey = BigInteger.Parse(readSecKey);
                _imainForm.OpenKey = BigInteger.Parse(readopKey);
                _messageService.ShowMessage("Ключ успешно загружен");
            }
            catch
            {
                _messageService.ShowError("Неверный формат ключей");
            }

        }

        private void _iGenerate_PressOk(object sender, EventArgs e)
        {
            string OpKey;

            string keys2 = RabinLib.Rabin.gen2Keys3and7mod8(int.Parse(_iGenerate.Key1), int.Parse(_iGenerate.Key2),out OpKey);

            _manager.SaveContent(keys2, _iGenerate.pathSecretkey);
         
            _manager.SaveContent(OpKey, _iGenerate.pathOpenKey);
            _iGenerate.SkipFrom();
            _imenuForm.ShowForm();
        }

        private void _imenuForm_GoToGenerateKeysWindow(object sender, EventArgs e)
        {
            _iGenerate.ShowForm();
            _imenuForm.SkipForm();
        }

        private void _iopenkeyForm_FileSaveAsClick(object sender, EventArgs e)
        {


            _currentFilePath = _iopenkeyForm.path;

            bool[] outputSign;


            string res = _manager.GetContent(_currentFilePath, _iopenkeyForm.OpenKey, out outputSign);

            _iopenkeyForm.Content = res;

            _messageService.ShowMessage(String.Format("В открытом файле приняты {0}/{1} подписей", outputSign.Where(p => p == true).ToArray().Length, outputSign.Length));
        }

        private void _iopenkeyForm_GoToMenuClick(object sender, EventArgs e)
        {
            _imenuForm.ShowForm();
            _iopenkeyForm.SkipForm();
        }

        private void _imenuForm_GoToOpenKeyForm(object sender, EventArgs e)
        {
            _imenuForm.SkipForm();
            _iopenkeyForm.ShowForm();
        }

        private void _imenuForm_GoToMainForm(object sender, EventArgs e)
        {
            _imenuForm.SkipForm();
            _imainForm.ShowForm();
        }

        private void _imainForm_FileSaveAsClick(object sender, EventArgs e)
        {
            string content = _imainForm.Content;

            _currentFilePath = _imainForm.FilePath;

            _manager.SaveContent(content, _currentFilePath, _imainForm.OpenKey, _imainForm.SecretKey);

            _messageService.ShowMessage("Файл успешно сохранён");
        }

        private void ImainForm_ContentChanged(object sender, EventArgs e)
        {
            _imainForm.SetSymbolCount(_imainForm.Content.Length);
            _imainForm.SetByteCount(Encoding.UTF8.GetBytes(_imainForm.Content).Length);
        }

        private void ImainForm_GoToMenuClick(object sender, EventArgs e)
        {

            _imenuForm.ShowForm();
            _imainForm.SkipForm();

        }

        private void ImainForm_FileOpenClick(object sender, EventArgs e)
        {
            try
            {


                _imainForm.FormGoToWorkMode();
                string filepath = _imainForm.FilePath;
                bool isExist = _manager.isExist(filepath);

                if (!isExist)
                {
                    _messageService.ShowExclamation("Такого файлай не сушествует");
                    return;
                }

                _currentFilePath = filepath;


                bool[] Signs;
                string Content = _manager.GetContent(_currentFilePath, _imainForm.OpenKey, out Signs);

                int count = _manager.GetSymbloCount(Content);

                _imainForm.Content = Content;
                _imainForm.SetSymbolCount(count);
                _messageService.ShowMessage(String.Format("В открытом файле приняты {0}/{1} подписей", Signs.Where(p => p == true).ToArray().Length, Signs.Length));


            }
            catch (Exception ex)
            {

                _messageService.ShowError(ex.Message);
            }
            finally
            {
                _imainForm.FormGoToReadyMode();

            }
        }

        private void ImainForm_FileSaveClick(object sender, EventArgs e)
        {
            try
            {
                string content = _imainForm.Content;

                _manager.SaveContent(content, _currentFilePath, _imainForm.OpenKey, _imainForm.SecretKey);

                _messageService.ShowMessage("Файл успешно сохранён");
            }
            catch (Exception ex)
            {
                _messageService.ShowError("Не возможно сохранить файл по текущему пути");
            }
        }
    }
}
