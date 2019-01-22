using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HJ.Common.Log
{
    class ExceptionMessage
    {
        private string _SD_CODE;
        private string _SD_ITEM_CODE;
        private string _SD_EKPI_CODE;
        private string _FuncName;
        private string _SD_CPAT_NO;
        private Exception _Exception;
        private StackFrame _StackFrame;
        public string SD_CODE
        {
            get
            {
                if (_SD_CODE == null)
                    return "";
                else
                    return _SD_CODE;
            }
            set
            {
                _SD_CODE = value;
            }
        }
        public string SD_ITEM_CODE
        {
            get
            {
                if (_SD_ITEM_CODE == null)
                    return "";
                else
                    return _SD_ITEM_CODE;
            }
            set
            {
                _SD_ITEM_CODE = value;
            }
        }
        public string SD_EKPI_CODE
        {
            get
            {
                if (_SD_EKPI_CODE == null)
                    return "";
                else
                    return _SD_EKPI_CODE;
            }
            set
            {
                _SD_EKPI_CODE = value;
            }
        }
        public string FuncName
        {
            get
            {
                if (_FuncName == null)
                    return "";
                else
                    return _FuncName;
            }
            set
            {
                _FuncName = value;
            }
        }
        public string SD_CPAT_NO
        {
            get
            {
                if (_SD_CPAT_NO == null)
                    return "";
                else
                    return _SD_CPAT_NO;
            }
            set
            {
                _SD_CPAT_NO = value;
            }
        }
        public Exception Exception
        {
            get
            {
                if (_Exception == null)
                    return new Exception();
                else
                    return _Exception;
            }
            set
            {
                _Exception = value;
            }
        }
        public StackFrame StackFrame
        {
            get
            {
                if (_StackFrame == null)
                    return new StackFrame();
                else
                    return _StackFrame;
            }
            set
            {
                _StackFrame = value;
            }
        }
    }
}
