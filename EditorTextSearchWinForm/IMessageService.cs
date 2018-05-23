﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EditorTextSearchWinForm
{
    public interface IMessageService
    {
        void ShowMessage(string message);
        void ShowExclamation(string exclamation);
        void ShowError(string error);
    }
}