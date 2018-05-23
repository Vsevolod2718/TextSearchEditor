using System.Windows.Forms;

namespace EditorTextSearchWinForm
{
    public class MessageService : IMessageService
    {
        public void ShowMessage(string message)
        {
            // message -- Текст, отбражаемый в окне сообщения.  
            // "Сообщение" -- Текст, отображаемый в строке заголовка окна сообщения.
            // MessageBoxButtons.OK -- В окне сообщения будет кнопка OK.  
            // MessageBoxIcon.Information --  Окно сообщения содержит символ, состоящий из буквы I в круге.               
            MessageBox.Show(message, "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void ShowExclamation(string exclamation)
        {
            // MessageBoxIcon.Exclamation -- Окно сообщения содержит символ, состоящий из восклицательного знака в треугольнике на желтом фоне.
            MessageBox.Show(exclamation, "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        public void ShowError(string error)
        {
            // MessageBoxIcon.Error -- Окно сообщения содержит символ, состоящий из белого X в окружности с красным фоном. 
            MessageBox.Show(error, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}