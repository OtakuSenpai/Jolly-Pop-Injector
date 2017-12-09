using System.Windows.Forms;

namespace Jolly_Pop_Injector
{
    public static class FormHandler
    {
        public static bool formopen(Form frm)
        { //General formopen func, return true if the form is found, false otherwise.
            foreach (Form form in Application.OpenForms)
            {
                if (form == frm)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
